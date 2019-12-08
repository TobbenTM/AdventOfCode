using System.Linq;
using AOC.Solver.IntcodeComputer;

namespace AOC.Solver
{
    public static class Day05
    {
        public static int SolvePart1(int[] program, int input)
        {
            var result = new Computer(program).Compute(input);

            return result.Last();
        }

        public static int SolvePart2(int[] program, int input)
        {
            return SolvePart1(program, input);
        }
    }
}
