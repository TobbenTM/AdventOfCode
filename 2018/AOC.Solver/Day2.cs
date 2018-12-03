using System;
using System.Collections.Generic;
using System.Linq;

namespace AOC.Solver
{
    public static class Day2
    {
        public static int SolvePart1(string[] input)
        {
            var aggregatedIds = input.Select(EvaluateId).ToArray();
            var doubles = aggregatedIds.Count(d => d.Values.Contains(2));
            var triples = aggregatedIds.Count(d => d.Values.Contains(3));
            return doubles * triples;
        }

        public static string SolvePart2(string[] input)
        {
            for (var i = 0; i < input.Length; i++)
            {
                var candidate = input[i];
                for (var j = i + 1; j < input.Length; j++)
                {
                    var match = input[j];
                    if (HasOneDifference(candidate, match, out var index))
                    {
                        return match.Remove(index, 1);
                    }
                }
            }
            throw new Exception("No matches found!");
        }

        private static Dictionary<char, int> EvaluateId(string id)
        {
            return id.ToCharArray().Aggregate(new Dictionary<char, int>(), (acc, ch) =>
            {
                if (acc.ContainsKey(ch))
                {
                    acc[ch] += 1;
                }
                else
                {
                    acc.Add(ch, 1);
                }

                return acc;
            });
        }

        private static bool HasOneDifference(string a, string b, out int index)
        {
            if (a.Length != b.Length) throw new ArgumentException("Unexpectedly unequal lengths to compare!");
            var foundOne = false;
            index = 0;
            for (var i = 0; i < a.Length; i++)
            {
                if (a[i] != b[i])
                {
                    if (foundOne) return false;
                    foundOne = true;
                    index = i;
                }
            }

            return foundOne;
        }
    }
}
