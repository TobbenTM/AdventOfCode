using System;
using System.Collections.Generic;
using System.Linq;

namespace AOC.Solver;

public static class Day08
{
    private static bool IsVisible(int x, int y, int[][] trees)
    {
        var left = trees[y][..x];
        var right = trees[y][(x + 1)..];
        var top = trees[..y].Select(l => l[x]);
        var bottom = trees[(y + 1)..].Select(l => l[x]);
        return new[]
        {
            left,
            right,
            top,
            bottom,
        }.Any(d => d.Max() < trees[y][x]);
    }

    public static int SolvePart1(int[][] input)
    {
        var totalVisible = input.Length * 2 + input[0].Length * 2 - 4;
        for (var y = 1; y < input.Length - 1; y++)
        {
            for (var x = 1; x < input[y].Length - 1; x++)
            {
                if (IsVisible(x, y, input)) totalVisible++;
            }
        }
        return totalVisible;
    }

    private static long Score(int x, int y, int[][] trees)
    {
        var left = trees[y][..x].Reverse();
        var right = trees[y][(x + 1)..];
        var top = trees[..y].Select(l => l[x]).Reverse();
        var bottom = trees[(y + 1)..].Select(l => l[x]);
        var horizon = new[]
        {
            top,
            left,
            right,
            bottom,
        }.Select(r => r.TakeWhile((t, i) => i == 0 || r.ElementAt(i - 1) < trees[y][x]).ToArray()).ToArray();
        return horizon.Select(t => t.Count()).Aggregate(1L, (a, b) => a * b);
    }

    public static long SolvePart2(int[][] input)
    {
        var highScores = new List<long>();
        for (var y = 0; y < input.Length; y++)
        {
            for (var x = 0; x < input[y].Length; x++)
            {
                highScores.Add(Score(x, y, input));
            }
        }
        return highScores.Max();
    }
}
