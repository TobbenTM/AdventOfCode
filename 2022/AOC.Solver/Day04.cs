using System;
using System.Linq;

namespace AOC.Solver;

public static class Day04
{
    public static int SolvePart1(string[] input)
    {
        return input
            .Select(p => p.Split(',').Select(r => r.Split('-').Select(int.Parse).ToArray()).ToArray())
            .Count(a => a[0][0] <= a[1][0] && a[0][1] >= a[1][1] || a[0][0] >= a[1][0] && a[0][1] <= a[1][1]);
    }

    public static int SolvePart2(string[] input)
    {
        return input
            .Select(p => p.Split(',').Select(r => r.Split('-').Select(int.Parse).ToArray()).ToArray())
            .Select(a => (Enumerable.Range(a[0][0], a[0][1] - a[0][0] + 1), Enumerable.Range(a[1][0], a[1][1] - a[1][0] + 1)))
            .Count(a => a.Item1.Intersect(a.Item2).Any());
    }
}
