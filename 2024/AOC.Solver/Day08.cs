using System;
using System.Collections.Generic;
using System.Linq;
using AOC.Solver.Tools;

namespace AOC.Solver;

public static class Day08
{
    public static int SolvePart1(string[] input)
    {
        var map = new MapV2(input);

        var antinodes = new HashSet<(int row, int col)>();
        foreach (var kv in map.Entities)
        {
            if (kv.Key == '.') continue;
            for (var i = 0; i < kv.Value.Length - 1; i++)
            {
                for (var j = i + 1; j < kv.Value.Length; j++)
                {
                    var a = kv.Value[i];
                    var b = kv.Value[j];
                    var distance = a.Distance(b);
                    antinodes.Add(a.Position.Add(distance));
                    antinodes.Add(b.Position.Subtract(distance));
                }
            }
        }

        return antinodes.Count(pos => pos.col >= 0 && pos.col < map.Width && pos.row >= 0 && pos.row < map.Height);
    }

    public static int SolvePart2(string[] input)
    {
        var map = new MapV2(input);

        var antinodes = new HashSet<(int row, int col)>();
        foreach (var kv in map.Entities)
        {
            if (kv.Key == '.') continue;
            for (var i = 0; i < kv.Value.Length - 1; i++)
            {
                for (var j = i + 1; j < kv.Value.Length; j++)
                {
                    var a = kv.Value[i];
                    var b = kv.Value[j];
                    var distance = a.Distance(b);
                    var gcd = GreatestCommonDivisor((uint)Math.Abs(distance.colDiff), (uint)Math.Abs(distance.rowDiff));
                    var vector = (distance.rowDiff / (int)gcd, distance.colDiff / (int)gcd);

                    var pos = a.Position;
                    antinodes.Add(pos);
                    while (pos.col >= 0 && pos.col < map.Width && pos.row >= 0 && pos.row < map.Height)
                    {
                        pos = pos.Add(vector);
                        antinodes.Add(pos);
                    }
                    pos = a.Position;
                    while (pos.col >= 0 && pos.col < map.Width && pos.row >= 0 && pos.row < map.Height)
                    {
                        pos = pos.Subtract(vector);
                        antinodes.Add(pos);
                    }
                }
            }
        }

        return antinodes.Count(pos => pos.col >= 0 && pos.col < map.Width && pos.row >= 0 && pos.row < map.Height);
    }

    private static uint GreatestCommonDivisor(uint a, uint b)
    {
        while (a != 0 && b != 0)
        {
            if (a > b)
                a %= b;
            else
                b %= a;
        }

        return a | b;
    }
}
