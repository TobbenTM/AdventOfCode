using System;
using System.Collections.Generic;
using System.Linq;
using AOC.Solver.Tools;

namespace AOC.Solver;

public static class Day16
{
    public static int SolvePart1(string[] input)
    {
        var map = input.Select(line => line.ToCharArray()).ToArray();
        return Energize(map, 0, 0, Neighbour.East);
    }

    public static int SolvePart2(string[] input)
    {
        var map = input.Select(line => line.ToCharArray()).ToArray();
        var highestEnergy = 0;

        for (var y = 0; y < map.Length; y++)
        {
            highestEnergy = Math.Max(highestEnergy, Energize(map, y, 0, Neighbour.East));
            highestEnergy = Math.Max(highestEnergy, Energize(map, y, map[y].Length - 1, Neighbour.West));
        }
        for (var x = 0; x < map[0].Length; x++)
        {
            highestEnergy = Math.Max(highestEnergy, Energize(map, 0, x, Neighbour.South));
            highestEnergy = Math.Max(highestEnergy, Energize(map, map.Length - 1, x, Neighbour.North));
        }

        return highestEnergy;
    }

    private static int Energize(char[][] map, int startingY, int startingX, Neighbour startingDirection)
    {
        var visited = new Dictionary<(int y, int x), HashSet<Neighbour>>();
        var queue = new Queue<((int y, int x), Neighbour direction)>();
        queue.Enqueue(((startingY, startingX), startingDirection));

        while (queue.TryDequeue(out var light))
        {
            var ((y, x), direction) = light;
            if (y < 0 || y >= map.Length || x < 0 || x >= map[0].Length) continue;
            var spot = map[y][x];
            if (!visited.ContainsKey((y, x))) visited[(y, x)] = new HashSet<Neighbour>();
            if (visited[(y, x)].Contains(direction)) continue;
            visited[(y, x)].Add(direction);
            switch (spot)
            {
                case '.':
                    queue.Enqueue((direction.Apply(y, x), direction));
                    break;
                case '/':
                    var nextDirection1 = direction;
                    if (direction == Neighbour.North) nextDirection1 = Neighbour.East;
                    if (direction == Neighbour.South) nextDirection1 = Neighbour.West;
                    if (direction == Neighbour.East) nextDirection1 = Neighbour.North;
                    if (direction == Neighbour.West) nextDirection1 = Neighbour.South;
                    queue.Enqueue((nextDirection1.Apply(y, x), nextDirection1));
                    break;
                case '\\':
                    var nextDirection2 = direction;
                    if (direction == Neighbour.North) nextDirection2 = Neighbour.West;
                    if (direction == Neighbour.South) nextDirection2 = Neighbour.East;
                    if (direction == Neighbour.East) nextDirection2 = Neighbour.South;
                    if (direction == Neighbour.West) nextDirection2 = Neighbour.North;
                    queue.Enqueue((nextDirection2.Apply(y, x), nextDirection2));
                    break;
                case '-':
                    if (direction == Neighbour.East || direction == Neighbour.West)
                    {
                        queue.Enqueue((direction.Apply(y, x), direction));
                    }
                    else
                    {
                        queue.Enqueue((Neighbour.East.Apply(y, x), Neighbour.East));
                        queue.Enqueue((Neighbour.West.Apply(y, x), Neighbour.West));
                    }
                    break;
                case '|':
                    if (direction == Neighbour.North || direction == Neighbour.South)
                    {
                        queue.Enqueue((direction.Apply(y, x), direction));
                    }
                    else
                    {
                        queue.Enqueue((Neighbour.North.Apply(y, x), Neighbour.North));
                        queue.Enqueue((Neighbour.South.Apply(y, x), Neighbour.South));
                    }
                    break;

            }
        }

        return visited.Count;
    }
}
