using System;
using System.Collections.Generic;
using System.Linq;

namespace AOC.Solver;

public static class Day14
{
    private static Dictionary<(int x, int y), char> ParseMap(string[] input)
    {
        var map = new Dictionary<(int x, int y), char>();
        foreach (var line in input)
        {
            var coordinates = line.Split(" -> ");
            for (var i = 1; i < coordinates.Length; i++)
            {
                var start = coordinates[i - 1].Split(',').Select(int.Parse).ToArray();
                var end = coordinates[i].Split(',').Select(int.Parse).ToArray();
                var direction = (x: Math.Sign(end[0] - start[0]), y: Math.Sign(end[1] - start[1]));
                var numberOfSteps = Math.Max(Math.Abs(start[0] - end[0]), Math.Abs(start[1] - end[1]));
                for (var j = 0; j <= numberOfSteps; j++)
                {
                    map.TryAdd((start[0] + direction.x * j, start[1] + direction.y * j), '#');
                }
            }
        }
        return map;
    }

    public static int SolvePart1(string[] input)
    {
        var map = ParseMap(input);
        var lowerBound = map.Keys.Max(k => k.y);
        for (var grains = 0; true; grains++)
        {
            var currentPos = (x: 500, y: 0);
            var settled = false;
            do
            {
                if (currentPos.y >= lowerBound)
                {
                    return grains;
                }
                if (map.ContainsKey((currentPos.x, currentPos.y + 1)))
                {
                    if (!map.ContainsKey((currentPos.x - 1, currentPos.y + 1)))
                    {
                        currentPos = (currentPos.x - 1, currentPos.y + 1);
                    }
                    else if (!map.ContainsKey((currentPos.x + 1, currentPos.y + 1)))
                    {
                        currentPos = (currentPos.x + 1, currentPos.y + 1);
                    }
                    else
                    {
                        map.Add(currentPos, 'o');
                        settled = true;
                    }
                }
                else
                {
                    currentPos = (currentPos.x, currentPos.y + 1);
                }
            } while (!settled);
        }
    }

    public static int SolvePart2(string[] input)
    {
        var map = ParseMap(input);
        var floor = map.Keys.Max(k => k.y) + 2;
        for (var grains = 0; true; grains++)
        {
            var currentPos = (x: 500, y: 0);
            do
            {
                if (currentPos.y == floor - 1)
                {
                    map.Add(currentPos, 'o');
                    break;
                }
                else if (map.ContainsKey((currentPos.x, currentPos.y + 1)))
                {
                    if (!map.ContainsKey((currentPos.x - 1, currentPos.y + 1)))
                    {
                        currentPos = (currentPos.x - 1, currentPos.y + 1);
                    }
                    else if (!map.ContainsKey((currentPos.x + 1, currentPos.y + 1)))
                    {
                        currentPos = (currentPos.x + 1, currentPos.y + 1);
                    }
                    else
                    {
                        map.Add(currentPos, 'o');
                        if (currentPos == (500, 0))
                        {
                            return grains + 1;
                        }
                        break;
                    }
                }
                else
                {
                    currentPos = (currentPos.x, currentPos.y + 1);
                }
            } while (true);
        }
    }
}
