using System;

namespace AOC.Solver
{
    public static class Day01
    {
        public static int SolvePart1(int[] input)
        {
            var total = 0;
            for (var i = 1; i < input.Length; i++)
            {
                if (input[i-1] < input[i]) total++;
            }
            return total;
        }

        public static int SolvePart2(int[] input)
        {
            var total = 0;
            for (var i = 3; i < input.Length; i++)
            {
                if (input[i - 3] + input[i - 2] + input[i - 1] < input[i - 2] + input[i - 1] + input[i]) total++;
            }
            return total;
        }
    }
}
