using System;
using System.Linq;

namespace AOC.Solver;

public static class Day07
{
    public static long SolvePart1(string[] input)
    {
        var results = input.Select(l => (Target: long.Parse(l.Split(':')[0]),
            Values: l.Split(':')[1].Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray())).ToArray();
        return results.Where(t => TestPart1(t.Target, t.Values)).Aggregate(0L, (a, b) => a + b.Target);
    }

    private static bool TestPart1(long target, int[] values, long current = 0L)
    {
        if (values.Length == 0) return current == target;
        return TestPart1(target, values.Skip(1).ToArray(), current + values[0]) || TestPart1(target, values.Skip(1).ToArray(), current * values[0]);
    }

    public static long SolvePart2(string[] input)
    {
        var results = input.Select(l => (Target: long.Parse(l.Split(':')[0]),
            Values: l.Split(':')[1].Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray())).ToArray();
        return results.Where(t => TestPart2(t.Target, t.Values)).Aggregate(0L, (a, b) => a + b.Target);
    }

    private static bool TestPart2(long target, int[] values, long current = 0L)
    {
        if (values.Length == 0) return current == target;
        return TestPart2(target, values.Skip(1).ToArray(), current + values[0])
               || TestPart2(target, values.Skip(1).ToArray(), current * values[0])
               || TestPart2(target, values.Skip(1).ToArray(), long.Parse(current.ToString() + values[0]));
    }
}
