using System.Collections.Generic;
using System.Linq;

namespace AOC.Solver
{
    public static class Day1
    {
        public static int SolvePart1(string[] input)
        {
            return input
                .Select(int.Parse)
                .Aggregate((acc, cur) => acc + cur);
        }

        public static int SolvePart2(string[] input)
        {
            int current = 0, index = 0;
            var history = new List<int> { 0 };
            var sequence = input.Select(int.Parse).ToArray();
            while (true)
            {
                var n = sequence[index % sequence.Length];
                current += n;
                if (history.Contains(current))
                {
                    return current;
                }
                history.Add(current);
                index++;
            }
        }
    }
}
