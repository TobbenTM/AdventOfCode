using System;
using System.Collections.Generic;
using System.Linq;

namespace AOC.Solver;

public static class Day14
{
    public static int SolvePart1(string[] input)
    {
        var map = input.Select(line => line.ToCharArray()).ToArray();

        for (var x = 0; x < map[0].Length; x++)
        {
            for (var y = 1; y < map.Length; y++)
            {
                if (map[y][x] is '.' or '#') continue;

                var maxY = y;
                for (var dy = y - 1; dy >= 0; dy--)
                    if (map[dy][x] == '.')
                        maxY = dy;
                    else
                        break;

                map[y][x] = '.';
                map[maxY][x] = 'O';
            }
        }

        return FindLoad(map);
    }

    public static int SolvePart2(string[] input)
    {
        var map = input.Select(line => line.ToCharArray()).ToArray();
        var history = new List<int>();
        var seeded = false;
        var seedSize = 150;

        while (true)
        {
            // North
            for (var x = 0; x < map[0].Length; x++)
            {
                for (var y = 1; y < map.Length; y++)
                {
                    if (map[y][x] is '.' or '#') continue;

                    var maxY = y;
                    for (var dy = y - 1; dy >= 0; dy--)
                        if (map[dy][x] == '.')
                            maxY = dy;
                        else
                            break;

                    map[y][x] = '.';
                    map[maxY][x] = 'O';
                }
            }

            // West
            for (var y = 0; y < map.Length; y++)
            {
                for (var x = 1; x < map[0].Length; x++)
                {
                    if (map[y][x] is '.' or '#') continue;

                    var maxX = x;
                    for (var dx = x - 1; dx >= 0; dx--)
                        if (map[y][dx] == '.')
                            maxX = dx;
                        else
                            break;

                    map[y][x] = '.';
                    map[y][maxX] = 'O';
                }
            }

            // South
            for (var x = 0; x < map[0].Length; x++)
            {
                for (var y = map.Length - 2; y >= 0; y--)
                {
                    if (map[y][x] is '.' or '#') continue;

                    var minY = y;
                    for (var dy = y + 1; dy < map.Length; dy++)
                        if (map[dy][x] == '.')
                            minY = dy;
                        else
                            break;

                    map[y][x] = '.';
                    map[minY][x] = 'O';
                }
            }

            // East
            for (var y = 0; y < map.Length; y++)
            {
                for (var x = map[0].Length - 2; x >= 0; x--)
                {
                    if (map[y][x] is '.' or '#') continue;

                    var minX = x;
                    for (var dx = x + 1; dx < map[0].Length; dx++)
                        if (map[y][dx] == '.')
                            minX = dx;
                        else
                            break;

                    map[y][x] = '.';
                    map[y][minX] = 'O';
                }
            }

            history.Add(FindLoad(map));
            if (!seeded && history.Count == seedSize)
            {
                seeded = true;
                history.Clear();
            }

            var cycleSize = history.Count / 2;
            if (seeded
                && history.Count > 10
                && history.Count % 2 == 0
                && history
                    .Take(cycleSize)
                    .SequenceEqual(history
                        .Skip(cycleSize)))
            {
                var offset = (1_000_000_000 - seedSize) % cycleSize;
                return history[cycleSize - offset];
            }
        }
    }

    private static int FindLoad(char[][] map)
    {
        var result = 0;

        for (var y = 0; y < map.Length; y++)
        {
            for (var x = 0; x < map[y].Length; x++)
            {
                if (map[y][x] != 'O') continue;
                result += map.Length - y;
            }
        }

        return result;
    }
}
