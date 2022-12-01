using System;
using System.Linq;

namespace AOC.Solver;

public static class Day01
{
    public static long SolvePart1(string input)
    {
        return input.Split("\n\n").Select(e => e.Split("\n", StringSplitOptions.RemoveEmptyEntries).Select(long.Parse).Sum()).Max();
    }

    public static long SolvePart2(string input)
    {
        return input.Split("\n\n").Select(e => e.Split("\n", StringSplitOptions.RemoveEmptyEntries).Select(long.Parse).Sum()).OrderByDescending(n => n).Take(3).Sum();
    }
}
