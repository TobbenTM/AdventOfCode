using System.Collections.Generic;
using System.Linq;

namespace AOC.Solver
{
    public static class Day10
    {
        public static int SolvePart1(int[] input)
        {
            var ordered = input.OrderBy(n => n).ToArray();
            return ordered
                .Skip(1)
                .Select((n, i) => n - ordered[i])
                .Concat(new[] { ordered[0], 3 })
                .GroupBy(n => n)
                .Aggregate(1, (a, g) => a * g.Count());
        }

        public static long SolvePart2(int[] input)
        {
            var ordered = input.Concat(new[] { 0 }).OrderBy(n => n).ToArray();
            var permutations = 1L;
            var cur = 0;
            while (cur < ordered.Length)
            {
                var group = new List<int> { ordered[cur] };
                while (cur < ordered.Length - 1 && ordered[cur] == ordered[cur + 1] - 1)
                {
                    group.Add(ordered[cur + 1]);
                    cur += 1;
                }
                switch (group.Count)
                {
                    case 3:
                        permutations *= 2;
                        break;
                    case 4:
                        permutations *= 4;
                        break;
                    case 5:
                        permutations *= 7;
                        break;
                    default:
                        break;
                }
                cur += 1;
            }
            return permutations;
        }
    }
}
