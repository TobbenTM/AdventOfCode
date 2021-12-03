using System;
using System.Linq;

namespace AOC.Solver
{
    public static class Day03
    {
        public static int SolvePart1(string[] input)
        {
            var mostCommonBits = FindMostCommonBits(input);

            var (gamma, epsilon) = (0, 0);

            for (var i = 0; i < mostCommonBits.Length; i++)
            {
                if (mostCommonBits[mostCommonBits.Length-i-1] > input.Length / 2)
                {
                    gamma += 1 << i;
                }
                else
                {
                    epsilon += 1 << i;
                }
            }

            return gamma * epsilon;
        }

        public static int SolvePart2(string[] input)
        {
            return FindCo2Rating(input) * FindOxygenRating(input);
        }

        private static int[] FindMostCommonBits(string[] input)
        {
            var mostCommonBits = new int[input[0].Length];
            Array.Fill(mostCommonBits, 0);

            foreach (var num in input)
            {
                for (var i = 0; i < mostCommonBits.Length; i++)
                {
                    if (num[i] == '1')
                    {
                        mostCommonBits[i] += 1;
                    }
                }
            }

            return mostCommonBits;
        }

        public static int FindOxygenRating(string[] input)
        {
            var oxygenCandidates = input.ToArray();

            for (var i = 0; oxygenCandidates.Length > 1; i++)
            {
                var mostCommonBits = FindMostCommonBits(oxygenCandidates);
                if (mostCommonBits[i] >= oxygenCandidates.Length / 2f)
                {
                    oxygenCandidates = oxygenCandidates
                        .Where(candidate => candidate[i] == '1')
                        .ToArray();
                }
                else
                {
                    oxygenCandidates = oxygenCandidates
                        .Where(candidate => candidate[i] == '0')
                        .ToArray();
                }
            }

            return Convert.ToInt32(oxygenCandidates.Single(), 2);
        }

        public static int FindCo2Rating(string[] input)
        {
            var co2Candidates = input.ToArray();

            for (var i = 0; co2Candidates.Length > 1; i++)
            {
                var mostCommonBits = FindMostCommonBits(co2Candidates);
                if (mostCommonBits[i] < co2Candidates.Length / 2f)
                {
                    co2Candidates = co2Candidates
                        .Where(candidate => candidate[i] == '1')
                        .ToArray();
                }
                else
                {
                    co2Candidates = co2Candidates
                        .Where(candidate => candidate[i] == '0')
                        .ToArray();
                }
            }

            return Convert.ToInt32(co2Candidates.Single(), 2);
        }
    }
}
