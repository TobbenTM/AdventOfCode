using System;
using System.Linq;
using System.Text.RegularExpressions;
using AOC.Solver.Tools;

namespace AOC.Solver;

public static class Day14
{
    public static long SolvePart1(string[] input, int height, int width)
    {
        var re = new Regex(@"p=(-?\d+),(-?\d+) v=(-?\d+),(-?\d+)");
        var bots = input.Select(s => s.Match<int, int, int, int>(re))
            .Where(t => t.HasValue)
            .Select(t => (pos: (t!.Value.Item2, t.Value.Item1), vel: (t.Value.Item4, t.Value.Item3)))
            .ToArray();
        var finalPositions = bots
            .Select(b => b.pos.Add(b.vel.Multiply(100)))
            .Select(p => (row: p.row % height, col: p.col % width))
            .Select(p => (row: p.row < 0 ? p.row + height : p.row, col: p.col < 0 ? p.col + width : p.col))
            .ToArray();
        var quadrants = finalPositions
            .Where(p => p.row != height / 2 && p.col != width / 2)
            .GroupBy(p => (p.row / ((height + 1) / 2), p.col / ((width + 1) / 2)));
        return quadrants.Aggregate(1L, (a, g) => a * g.Count());
    }

    public static int SolvePart2(string[] input, int height, int width)
    {
        var re = new Regex(@"p=(-?\d+),(-?\d+) v=(-?\d+),(-?\d+)");
        var bots = input.Select(s => s.Match<int, int, int, int>(re))
            .Where(t => t.HasValue)
            .Select(t => (pos: (t!.Value.Item2, t.Value.Item1), vel: (t.Value.Item4, t.Value.Item3)))
            .ToArray();

        for (var i = 1; i < 100_000; i++)
        {
            var positions = bots
                .Select(b => b.pos.Add(b.vel.Multiply(i)))
                .Select(p => (row: p.row % height, col: p.col % width))
                .Select(p => (row: p.row < 0 ? p.row + height : p.row, col: p.col < 0 ? p.col + width : p.col))
                .ToArray();

            var cols = positions
                .GroupBy(p => p.col)
                .OrderBy(g => g.Key)
                .Select(g => g.Select(p => p.row).Distinct());

            if (cols.Count(r => r.Count() > height / 5) < 6)
            {
                continue;
            }

            // var map = "";
            // for (var row = 0; row < height; row++)
            // {
            //     for (var col = 0; col < width; col++)
            //     {
            //         map += positions.Any(b => b == (row, col)) ? '#' : '.';
            //     }
            //
            //     map += '\n';
            // }
            //
            // Console.WriteLine($"After {i} seconds:");
            // Console.WriteLine(map);

            return i;
        }

        return 0;
    }
}
