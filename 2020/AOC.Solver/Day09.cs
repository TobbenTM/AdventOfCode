using System;
using System.Collections.Generic;
using System.Linq;

namespace AOC.Solver
{
    public static class Day09
    {
        public static long SolvePart1(long[] input)
        {
            for (var i = 25; i < input.Length; i++)
            {
                if (!HasCombination(input, i)) return input[i];
            }
            throw new InvalidOperationException("Found no invalid number!");
        }

        private static bool HasCombination(long[] input, int index)
        {
            var target = input[index];
            for (var j = index - 25; j < index - 1; j++)
            {
                if (input[j] >= target) continue;
                for (var k = j + 1; k < index; k++)
                {
                    if (input[j] + input[k] == target) return true;
                }
            }
            return false;
        }

        public static long SolvePart2(long[] input, long target)
        {
            for (var i = 0; i < input.Length; i++)
            {
                var j = i + 1;
                var set = new List<long>();
                var acc = input[i];
                while (acc < target)
                {
                    acc += input[j];
                    set.Add(input[j]);
                    j += 1;
                }
                if (acc == target) return set.Min() + set.Max();
            }
            throw new InvalidOperationException("Could not find a contiguous range!");
        }
    }
}
