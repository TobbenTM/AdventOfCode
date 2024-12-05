using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace AOC.Solver;

public static class Day05
{
    public static int SolvePart1(string[] input)
    {
        var rules = input.TakeWhile(i => i.Length > 0).Select(i => i.Split("|").Select(int.Parse).ToArray()).GroupBy(a => a[0]).ToDictionary(g => g.Key, g => g.Select(a => a[1]).ToArray());
        var updates = input.SkipWhile(i => i.Length > 0).Skip(1).Select(i => i.Split(",").Select(int.Parse).ToArray()).ToArray();

        return updates.Where(u => u.SequenceEqual(Order(u, rules))).Sum(u => u[u.Length / 2]);
    }

    public static int SolvePart2(string[] input)
    {
        var rules = input.TakeWhile(i => i.Length > 0).Select(i => i.Split("|").Select(int.Parse).ToArray()).GroupBy(a => a[0]).ToDictionary(g => g.Key, g => g.Select(a => a[1]).ToArray());
        var updates = input.SkipWhile(i => i.Length > 0).Skip(1).Select(i => i.Split(",").Select(int.Parse).ToArray()).ToArray();

        return updates.Where(u => !u.SequenceEqual(Order(u, rules))).Select(u => Order(u, rules)).Sum(u => u[u.Length / 2]);
    }

    private static int[] Order(int[] pages, Dictionary<int, int[]> rules)
    {
        var result = new List<int>();

        foreach (var page in pages)
        {
            if (rules.TryGetValue(page, out var laterPages) && result.Intersect(laterPages).Any())
            {
                var first = result.Any() ? result.FindIndex(i => laterPages.Contains(i)) : 0;
                result.Insert(first, page);
            }
            else
            {
                result.Add(page);
            }
        }

        return result.ToArray();
    }
}
