using System;
using System.Linq;

namespace AOC.Solver;

public static class Day05
{
    public static int SolvePart1(string[] input)
    {
        var fresh = input.Where(str => str.Contains('-'))
            .Select(str => (long.Parse(str.Split('-')[0]), long.Parse(str.Split('-')[1]))).ToArray();
        var ingredients = input.Where(str => !str.Contains('-')).Select(long.Parse).ToArray();

        return ingredients.Count(id => fresh.Any(r => id >= r.Item1 && id <= r.Item2));
    }

    public static long SolvePart2(string[] input)
    {
        var fresh = input
            .Where(str => str.Contains('-'))
            .Select(str => (Min: long.Parse(str.Split('-')[0]), Max: long.Parse(str.Split('-')[1])))
            .ToHashSet();

        while (true)
        {
            var merged = false;
            foreach (var range in fresh)
            {
                var overlappingRange = fresh.FirstOrDefault(other =>
                    other != range &&
                    (other.Min <= range.Min && other.Max >= range.Min ||
                     other.Min <= range.Max && other.Max >= range.Max));
                if (overlappingRange != default)
                {
                    fresh.Remove(overlappingRange);
                    fresh.Remove(range);
                    fresh.Add((Math.Min(overlappingRange.Min, range.Min), Math.Max(overlappingRange.Max, range.Max)));
                    merged = true;
                    break;
                }
            }

            if (!merged)
                return fresh.Sum(range => range.Max - range.Min + 1);
        }
    }
}
