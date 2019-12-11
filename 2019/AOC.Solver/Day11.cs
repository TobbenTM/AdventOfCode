using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using AOC.Solver.IntcodeComputer;

namespace AOC.Solver
{
    public static class Day11
    {
        public static async Task<Dictionary<(int x, int y), long>> Solve(long[] input, int startTileColor)
        {
            var computer = new Computer(input);

            var camera = new BlockingCollection<long>();

            computer.StartCompute(camera);

            var map = new Dictionary<(int x, int y), long>();
            (int x, int y, int direction) robot = (0, 0, 0);

            while (true)
            {
                try
                {
                    // Input camera output
                    if (map.ContainsKey((robot.x, robot.y)))
                    {
                        camera.Add(map[(robot.x, robot.y)]);
                    }
                    else
                    {
                        camera.Add(robot.x == 0 && robot.y == 0 ? startTileColor : 0);
                    }

                    // Get output
                    var color = await computer.GetOutputAsync();
                    var turn = await computer.GetOutputAsync();

                    // Paint
                    map[(robot.x, robot.y)] = color;

                    Trace.WriteLine($"Robot painted {color} at ({robot.x},{robot.y})");

                    // Turn
                    if (turn == 1) robot.direction = robot.direction == 0 ? 3 : robot.direction - 1;
                    else robot.direction = robot.direction == 3 ? 0 : robot.direction + 1;

                    // Move
                    switch (robot.direction)
                    {
                        case 0: // Up
                            robot.y -= 1;
                            break;
                        case 1: // Right
                            robot.x += 1;
                            break;
                        case 2: // Down
                            robot.y += 1;
                            break;
                        case 3: // Left
                            robot.x -= 1;
                            break;
                    }

                    Trace.WriteLine($"Robot moved to ({robot.x},{robot.y})");
                }
                catch (InvalidOperationException)
                {
                    if (computer.Output.IsCompleted)
                    {
                        return map;
                    }
                    throw;
                }
            }
        }
    }
}
