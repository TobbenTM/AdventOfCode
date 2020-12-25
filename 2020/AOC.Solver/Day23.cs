using System.Collections.Generic;
using System.Linq;

namespace AOC.Solver
{
    public static class Day23
    {
        public static int SolvePart1(string input)
        {
            var cups = input.Select(c => int.Parse(c.ToString())).ToArray();
            var result = PlayCrabCups(cups, 100);
            var currentCup = result[1];
            return int.Parse(string.Join("", Enumerable.Range(0, cups.Length - 1).Select(_ => (currentCup = currentCup.Next).Value)));
        }

        public static long SolvePart2(string input)
        {
            var cups = input.Select(c => int.Parse(c.ToString()))
                .Concat(Enumerable.Range(input.Length + 1, 1_000_000 - input.Length))
                .ToArray();
            var result = PlayCrabCups(cups, 10_000_000);
            var start = result[1];
            return (long)start.Next.Value * start.Next.Next.Value;
        }

        private static IDictionary<int, Cup> PlayCrabCups(int[] cups, int iterations)
        {
            var map = cups.Select(i => new Cup(i)).ToDictionary(cup => cup.Value, cup => cup);
            for (var i = 0; i < map.Count; i++)
            {
                map[cups[i]].Next = map[cups[(i + 1) % cups.Length]];
            }
            var currentCup = map.Values.First();
            for (var i = 0; i < iterations; i++)
            {
                var picked = new[]
                {
                    currentCup.Next,
                    currentCup.Next.Next,
                    currentCup.Next.Next.Next,
                };

                var destinationValue = currentCup.Value - 1;
                if (destinationValue == 0) destinationValue = cups.Max();
                while (picked.Any(cup => cup.Value == destinationValue))
                {
                    destinationValue -= 1;
                    if (destinationValue == 0) destinationValue = cups.Max();
                }

                var destinationCup = map[destinationValue];
                currentCup.Next = picked.Last().Next;
                picked.Last().Next = destinationCup.Next;
                destinationCup.Next = picked.First();
                currentCup = currentCup.Next;
            }
            return map;
        }

        private class Cup
        {
            public int Value { get; set; }

            public Cup Next { get; set; } = default!;

            public Cup(int value)
            {
                Value = value;
            }
        }
    }
}
