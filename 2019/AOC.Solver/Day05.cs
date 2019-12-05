using System.Linq;

namespace AOC.Solver
{
    public static class Day05
    {
        public static int SolvePart1(int[] program, int input)
        {
            var result = IntcodeComputer.Compute(ref program, input);

            return result.Last();
        }

        public static int SolvePart2(int[] program, int input)
        {
            var result = IntcodeComputer.Compute(ref program, input);

            return result.Last();
        }
    }
}
