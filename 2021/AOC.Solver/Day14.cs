using System.Linq;

namespace AOC.Solver
{
    public static class Day14
    {
        public static long SolvePart1(string[] input)
        {
            return EvaluateIterations(input, 10);
        }

        public static long SolvePart2(string[] input)
        {
            return EvaluateIterations(input, 40);
        }

        private static long EvaluateIterations(string[] input, int iterations)
        {
            var polymer = input.First();
            var polymerPairs = polymer.Zip(polymer.Skip(1)).ToArray();

            var rules = input.Skip(1).ToDictionary(
                rule => (rule.Split(" -> ")[0][0], rule.Split(" -> ")[0][1]),
                rule => rule.Split(" -> ")[1].Single());

            var counter = rules.Keys.ToDictionary(pair => pair, _ => 0L);
            foreach (var pair in polymerPairs)
            {
                counter[pair]++;
            }

            for (var i = 0; i < iterations; i++)
            {
                var state = counter.Select(kv => new { kv.Key, kv.Value }).ToArray();
                foreach (var count in state)
                {
                    var el = rules[count.Key];
                    counter[count.Key] -= count.Value;
                    counter[(count.Key.Item1, el)] += count.Value;
                    counter[(el, count.Key.Item2)] += count.Value;
                }
            }

            var elements = rules
                .Select(rule => rule.Value)
                .Distinct()
                .ToDictionary(element => element, _ => 0L);
            foreach (var count in counter)
            {
                elements[count.Key.Item1] += count.Value;
            }

            elements[polymerPairs.Last().Second]++;

            return elements.Values.Max() - elements.Values.Min();
        }
    }
}
