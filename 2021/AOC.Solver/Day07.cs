using System;
using System.Linq;

namespace AOC.Solver
{
    public static class Day07
    {
        public static int SolvePart1(int[] input)
        {
            var calculateFuelUsage = (int[] positions, int targetPosition) =>
                positions.Sum(pos => Math.Abs(targetPosition - pos));
            return FindMinimum(input, calculateFuelUsage);
        }

        public static int SolvePart2(int[] input)
        {
            var calculateFuelUsage = (int[] positions, int targetPosition) =>
                positions.Sum(pos => Math.Abs(targetPosition - pos)*(Math.Abs(targetPosition - pos)+1)/2);
            return FindMinimum(input, calculateFuelUsage);
        }

        private static int FindMinimum(int[] input, Func<int[], int, int> fuelUsageCalculation)
        {
            var minimum = int.MaxValue;
            for (var i = input.Max(); i > input.Min(); i--)
            {
                var cost = fuelUsageCalculation(input, i);
                if (cost < minimum)
                {
                    minimum = cost;
                }
            }

            return minimum;
        }
    }
}
