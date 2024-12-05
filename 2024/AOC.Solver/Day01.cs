using System;
using System.Collections.Generic;
using System.Linq;

namespace AOC.Solver;

public static class Day01
{
    public static int SolvePart1(string[] input)
    {
        var left = input.Select(l => int.Parse(l.Split("   ")[0])).OrderBy(n => n).ToArray();
        var right = input.Select(l => int.Parse(l.Split("   ")[1])).OrderBy(n => n).ToArray();
        return left.Zip(right).Aggregate(0, (a, b) => a + Math.Abs(b.First - b.Second));
    }

    public static int SolvePart2(string[] input)
    {
        var left = input.Select(l => int.Parse(l.Split("   ")[0])).ToArray();
        var right = input.Select(l => int.Parse(l.Split("   ")[1])).GroupBy(n => n).ToDictionary(n => n.Key, n => n.Count());
        return left.Aggregate(0, (a, b) => a + b * right.GetValueOrDefault(b));
    }
}
