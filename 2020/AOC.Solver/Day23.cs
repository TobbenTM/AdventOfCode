using System.Collections.Generic;
using System.Linq;

namespace AOC.Solver
{
    public static class Day23
    {
        public static int SolvePart1(string input)
        {
            var cups = input.Select(c => int.Parse(c.ToString())).ToList();
            PlayCrabCups(cups, 100);
            var finalCups = cups.Skip(cups.IndexOf(1) + 1).Concat(cups.Take(cups.IndexOf(1)));
            return int.Parse(string.Join("", finalCups));
        }

        public static long SolvePart2(string input)
        {
            var cups = input.Select(c => int.Parse(c.ToString()))
                .Concat(Enumerable.Range(input.Length + 1, 1_000_000 - input.Length))
                .ToList();
            //PlayCrabCups(cups, 10_000);
            var start = cups.IndexOf(1);
            return (long)cups[(start + 1) % cups.Count] * cups[(start + 2) % cups.Count];
        }

        private static void PlayCrabCups(List<int> cups, int iterations)
        {
            var currentCup = cups.First();
            for (var i = 0; i < iterations; i++)
            {
                var start = (cups.IndexOf(currentCup) + 1) % cups.Count;
                var pickedCups = cups.Skip(start).Take(3).ToList();
                cups.RemoveRange(start, pickedCups.Count);
                var missing = 3 - pickedCups.Count;
                pickedCups.AddRange(cups.Take(missing));
                cups.RemoveRange(0, missing);

                var destinationCup = currentCup - 1;
                while (!cups.Contains(destinationCup))
                {
                    destinationCup -= 1;
                    if (destinationCup < 0) destinationCup += 10;
                }
                cups.InsertRange(cups.IndexOf(destinationCup) + 1, pickedCups);

                currentCup = cups[(cups.IndexOf(currentCup) + 1) % cups.Count];
            }
        }
    }
}
