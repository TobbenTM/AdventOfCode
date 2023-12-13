using System;
using System.Collections.Generic;
using System.Linq;

namespace AOC.Solver;

public static class Day13
{
    public static int SolvePart1(string[] input)
    {
        var result = 0;

        for (var i = 0; i < input.Length; i++)
        {
            var map = new List<char[]>();
            while (!string.IsNullOrWhiteSpace(input[i]) && i < input.Length - 1)
            {
                map.Add(input[i++].ToCharArray());
            }

            var horizontal = FindHorizontalMirror(map.ToArray());
            var vertical = FindVerticalMirror(map.ToArray());

            if (horizontal == null && vertical == null) throw new InvalidOperationException("Yo, there's no mirrors");

            result += vertical ?? 0;
            result += (horizontal ?? 0) * 100;
        }

        return result;
    }

    public static int SolvePart2(string[] input)
    {
        var result = 0;

        for (var i = 0; i < input.Length; i++)
        {
            var map = new List<char[]>();
            while (!string.IsNullOrWhiteSpace(input[i]) && i < input.Length - 1)
            {
                map.Add(input[i++].ToCharArray());
            }

            var horizontal = FindHorizontalMirror(map.ToArray());
            var vertical = FindVerticalMirror(map.ToArray());

            result += FindAlternateMirrorValue(map.ToArray(), horizontal, vertical);
        }

        return result;
    }

    private static int? FindVerticalMirror(char[][] map, params int[] except)
    {
        var candidates = Enumerable.Range(1, map[0].Length - 1).Except(except).ToArray();
        for (var y = 0; y < map.Length && candidates.Any(); y++)
        {
            candidates = candidates.Where(x =>
            {
                var length = Math.Min(x, map[y].Length - x);
                var left = map[y]
                    .Skip(x - length)
                    .Take(length)
                    .Reverse();
                var right = map[y]
                    .Skip(x)
                    .Take(length);
                return left.SequenceEqual(right);
            }).ToArray();
        }

        if (candidates.Length != 1) return null;
        return candidates.Single();
    }

    private static int? FindHorizontalMirror(char[][] map, params int[] except)
    {
        var candidates = Enumerable.Range(1, map.Length - 1).Except(except).ToArray();
        for (var x = 0; x < map[0].Length && candidates.Any(); x++)
        {
            candidates = candidates.Where(y =>
            {
                var length = Math.Min(y, map.Length - y);
                var left = map
                    .Select(m => m[x])
                    .ToArray()
                    .Skip(y - length)
                    .Take(length)
                    .Reverse();
                var right = map
                    .Select(m => m[x])
                    .ToArray()
                    .Skip(y)
                    .Take(length);
                return left.SequenceEqual(right);
            }).ToArray();
        }

        if (candidates.Length != 1) return null;
        return candidates.Single();
    }

    private static int FindAlternateMirrorValue(char[][] map, int? horizontal, int? vertical)
    {
        for (var y = 0; y < map.Length; y++)
        {
            for (var x = 0; x < map[y].Length; x++)
            {
                var alternateMap = map.Select(line => line.ToArray()).ToArray();
                alternateMap[y][x] = alternateMap[y][x] == '.' ? '#' : '.';

                var alternateHorizontal = FindHorizontalMirror(alternateMap, horizontal ?? 0);
                var alternateVertical = FindVerticalMirror(alternateMap, vertical ?? 0);

                if (alternateHorizontal.HasValue || alternateVertical.HasValue)
                {
                    return (alternateHorizontal ?? 0) * 100 + (alternateVertical ?? 0);
                }
            }
        }

        throw new InvalidOperationException("No alternate mirror found");
    }
}
