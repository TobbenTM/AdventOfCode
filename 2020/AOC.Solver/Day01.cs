using System;

namespace AOC.Solver
{
    public static class Day01
    {
        public static int SolvePart1(int[] input)
        {
            for (var i = 0; i < input.Length; i++)
            {
                if (input[i] > 2020) continue;
                for (var j = i + 1; j < input.Length; j++)
                {
                    if (input[i] + input[j] == 2020)
                    {
                        return input[i] * input[j];
                    }
                }
            }

            throw new InvalidOperationException("Could not find the number");
        }

        public static int SolvePart2(int[] input)
        {
            for (var i = 0; i < input.Length; i++)
            {
                if (input[i] > 2020) continue;
                for (var j = i + 1; j < input.Length; j++)
                {
                    if (input[i] + input[j] > 2020) continue;
                    for (var k = j + 1; k < input.Length; k++)
                    {
                        if (input[i] + input[j] + input[k] == 2020)
                        {
                            return input[i] * input[j] * input[k];
                        }
                    }
                }
            }

            throw new InvalidOperationException("Could not find the number");
        }
    }
}
