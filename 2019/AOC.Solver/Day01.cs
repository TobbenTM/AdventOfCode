using System;
using System.Linq;

namespace AOC.Solver
{
    public static class Day01
    {
        public static int SolvePart1(int[] input) {
            return input.Aggregate(0, (acc, cur) => acc + CalculateFuel(cur));
        }

        public static int SolvePart2(int[] input) {
            return input.Aggregate(0, (acc, cur) => acc + CalculateFuelReccurring(cur));
        }

        public static int CalculateFuel(int mass) => (int)Math.Floor((decimal)mass/3m) - 2;
        public static int CalculateFuelReccurring(int mass) {
            var result = CalculateFuel(mass);
            var currentFuel = CalculateFuel(result);
            if (currentFuel > 0) {
                result += currentFuel;
            }
            while (currentFuel > 0) {
                currentFuel = CalculateFuel(currentFuel);
                if (currentFuel > 0) {
                    result += currentFuel;
                }
            }
            return result;
        }
    }
}
