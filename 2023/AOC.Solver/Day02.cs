using System;
using System.Collections.Generic;
using System.Linq;

namespace AOC.Solver;

public static class Day02
{
    public static int SolvePart1(string[] input)
    {
        var result = 0;

        foreach (var line in input)
        {
            var sets = line
                .Split(":")[1]
                .Split(";")
                .Select(s =>
                    s.Split(",")
                        .Select(m => m.Split(" ", StringSplitOptions.RemoveEmptyEntries))
                        .ToDictionary(m => m[1], m => int.Parse(m[0])));
            if (sets.All(s =>
                    (!s.ContainsKey("red") || s["red"] <= 12)
                    && (!s.ContainsKey("green") || s["green"] <= 13)
                    && (!s.ContainsKey("blue") || s["blue"] <= 14)))
                result += int.Parse(line.Split(":")[0][5..]);
        }

        return result;
    }

    public static int SolvePart2(string[] input)
    {
        var result = 0;

        foreach (var line in input)
        {
            var min = new Dictionary<string, int>
            {
                { "green", 0 },
                { "blue", 0 },
                { "red", 0 },
            };
            var sets = line
                .Split(":")[1]
                .Split(";")
                .Select(s =>
                    s.Split(",")
                        .Select(m => m.Split(" ", StringSplitOptions.RemoveEmptyEntries))
                        .ToDictionary(m => m[1], m => int.Parse(m[0])))
                .ToArray();
            foreach (var set in sets)
            {
                foreach (var cubes in set)
                {
                    min[cubes.Key] = Math.Max(min[cubes.Key], cubes.Value);
                }
            }

            result += min["green"] * min["red"] * min["blue"];
        }

        return result;
    }
}
