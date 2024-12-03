using System;
using System.Linq;

namespace AOC.Solver;

public static class Day02
{
    public static int SolvePart1(string[] input)
    {
        var reports = input.Select(l => l.Split(" ").Select(int.Parse).ToArray()).ToArray();
        return reports.Count(IsSafe);
    }

    private static bool IsSafe(int[] report)
    {
        for (var i = 0; i < report.Length - 1; i++)
        {
            var diff = Math.Abs(report[i] - report[i + 1]);
            if (diff is < 1 or > 3) return false;
        }
        return report.SequenceEqual(report.OrderBy(n => n)) || report.SequenceEqual(report.OrderByDescending(n => n));
    }

    public static int SolvePart2(string[] input)
    {
        var reports = input.Select(l => l.Split(" ").Select(int.Parse).ToArray()).ToArray();
        return reports.Count(r =>
        {
            if (IsSafe(r)) return true;
            for (var i = 0; i < r.Length; i++)
            {
                if (IsSafe(r.Where((_, n) => n != i).ToArray())) return true;
            }

            return false;
        });
    }
}
