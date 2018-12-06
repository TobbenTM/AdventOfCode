using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace AOC.Solver
{
    public static class Day5
    {
        public static int SolvePart1(string input)
        {
            var polymer = input
                .ToCharArray()
                .ToList()
                .React();

            return polymer.Count;
        }

        public static int SolvePart2(string input)
        {
            var sw = Stopwatch.StartNew();
            var polymer = input
                .ToCharArray()
                .ToList();
            var t1 = sw.ElapsedMilliseconds;
            var unitTypes = polymer.Select(char.ToLower).Distinct();
            var t2 = sw.ElapsedMilliseconds;
            var mutations = unitTypes.Select(t => polymer.Where(c => c != t && c != char.ToUpper(t)));
            var t3 = sw.ElapsedMilliseconds;
            var results = mutations.Select(p => p.ToList().React());
            var t4 = sw.ElapsedMilliseconds;
            var best = results.AsParallel().Min(p => p.Count);
            var t5 = sw.ElapsedMilliseconds;

            return best;
        }

        private static List<char> React(this List<char> polymer)
        {
            while (true)
            {
                var hadReactions = false;

                for (var i = 0; i < polymer.Count - 1; i++)
                {
                    var current = polymer[i];
                    var next = polymer[i + 1];
                    if (char.ToLower(current) == char.ToLower(next) &&
                        (char.IsLower(current) && char.IsUpper(next) ||
                         char.IsUpper(current) && char.IsLower(next)))
                    {
                        polymer.RemoveRange(i, 2);
                        i -= 1;
                        hadReactions = true;
                    }
                }

                if (!hadReactions)
                {
                    return polymer;
                }
            }
        }
    }
}
