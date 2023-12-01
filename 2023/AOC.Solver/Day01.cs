using System;
using System.Collections.Generic;
using System.Linq;

namespace AOC.Solver;

public static class Day01
{
    public static int SolvePart1(string[] input)
    {
        return input
            .Select(l => l.ToCharArray()
                .Where(c => c is >= '0' and <= '9')
                .Select(c => int.Parse(c.ToString()))
                .ToArray())
            .Select(n => n.First() * 10 + n.Last())
            .Sum();
    }

    public static int SolvePart2(string[] input)
    {
        var parsed = input.Select(l => ParseNumbers(l).ToArray());
        var calculated = parsed.Select(n => n.First() * 10 + n.Last());
        return calculated.Sum();
    }

    private static IEnumerable<int> ParseNumbers(string line)
    {
        var map = new[]
        {
            ("zero", 0),
            ("one", 1),
            ("two", 2),
            ("three", 3),
            ("four", 4),
            ("five", 5),
            ("six", 6),
            ("seven", 7),
            ("eight", 8),
            ("nine", 9),
        };
        for (var i = 0; i < line.Length; i++)
        {
            if (line[i] >= '0' && line[i] <= '9') yield return int.Parse(line[i].ToString());
            else
            {
                foreach (var pair in map)
                {
                    if (line[i..].StartsWith(pair.Item1)) yield return pair.Item2;
                }
            }
        }
    }
}
