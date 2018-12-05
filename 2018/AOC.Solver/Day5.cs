using System;
using System.Collections.Generic;
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
            var polymer = input
                .ToCharArray()
                .ToList();
            var unitTypes = polymer.Select(char.ToLower).Distinct();
            var mutations = unitTypes.Select(t => polymer.Where(c => c != t && c != char.ToUpper(t)));
            var results = mutations.Select(p => p.ToList().React());

            return results.Min(p => p.Count);
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
