using System.Linq;

namespace AOC.Solver
{
    public static class Day05
    {
        public static int SolvePart1(int[] program, int input)
        {
            var result = new IntcodeComputer(program).Compute(input);

            return result.Last();
        }

        public static int SolvePart2(int[] program, int input)
        {
            return SolvePart1(program, input);
        }
    }
}
