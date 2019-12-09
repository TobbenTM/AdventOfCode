using System.Linq;
using System.Threading.Tasks;
using AOC.Solver.IntcodeComputer;

namespace AOC.Solver
{
    public static class Day05
    {
        public static async Task<int> SolvePart1(int[] program, int input)
        {
            var computer = new Computer(program);
            var result = await computer.ComputeAsync(input);

            return (int)result.Last();
        }

        public static Task<int> SolvePart2(int[] program, int input)
        {
            return SolvePart1(program, input);
        }
    }
}
