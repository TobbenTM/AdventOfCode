using System;
using System.Collections.Generic;
using System.Linq;

namespace AOC.Solver;

public static class Day05
{
    public static long SolvePart1(string[] input)
    {
        var current = input[0]
            .Split(':')[1]
            .Split(' ', StringSplitOptions.RemoveEmptyEntries)
            .Select(long.Parse)
            .ToList();

        for (var i = 3; i < input.Length; i++)
        {
            var next = new List<long>();
            var maps = new List<(long dest, long source, long range)>();

            for (; i < input.Length; i++)
            {
                if (input[i].Contains(':')) break;
                var numbers = input[i].Split(' ').Select(long.Parse).ToArray();
                maps.Add((numbers[0], numbers[1], numbers[2]));
            }

            foreach (var map in maps.OrderBy(m => m.source))
            {
                var applicable = current.Where(n => n >= map.source && n < map.source + map.range).ToArray();
                foreach (var n in applicable)
                {
                    current.RemoveAll(x => x == n);
                    next.Add(map.dest + (n - map.source));
                }
            }

            next.AddRange(current);
            current = next;
        }

        return current.Min();
    }

    public static long SolvePart2(string[] input)
    {
        var seeds = input[0]
            .Split(':')[1]
            .Split(' ', StringSplitOptions.RemoveEmptyEntries)
            .Select(long.Parse)
            .ToArray();

        var current = new List<(long start, long end)>();
        for (var i = 0; i < seeds.Length - 1; i += 2)
        {
            current.Add((seeds[i], seeds[i] + seeds[i+1]));
        }

        for (var i = 3; i < input.Length; i++)
        {
            var next = new List<(long start, long end)>();
            var maps = new List<(long dest, long source, long range)>();

            for (; i < input.Length; i++)
            {
                if (input[i].Contains(':')) break;
                var numbers = input[i].Split(' ').Select(long.Parse).ToArray();
                maps.Add((numbers[0], numbers[1], numbers[2]));
            }

            foreach (var map in maps.OrderBy(m => m.source))
            {
                var mapEnd = map.source + map.range - 1;
                var applicable = current.Where(n => Overlaps(n.start, n.end, map.source, mapEnd)).ToArray();
                foreach (var n in applicable)
                {
                    var diff = map.dest - map.source;
                    current.Remove(n);

                    if (n.end > mapEnd)
                    {
                        current.Add((mapEnd + 1, n.end));
                        next.Add((n.start + diff, mapEnd + diff));
                    }
                    else
                    {
                        next.Add((n.start + diff, n.end + diff));
                    }
                }
            }

            next.AddRange(current);
            current = next.OrderBy(n => n.start).ToList();
        }

        return current.Min(s => s.start);
    }

    private static bool Overlaps(long aStart, long aEnd, long bStart, long bEnd) => aStart <= bEnd && aEnd >= bStart;
}
