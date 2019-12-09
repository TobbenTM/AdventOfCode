using System;
using System.Linq;
using System.Threading.Tasks;
using AOC.Solver.IntcodeComputer;

namespace AOC.Solver
{
    public static class Day09
    {
        public static async Task<long> Solve(long[] program, long input)
        {
            var computer = new Computer(program, input);
            var result = await computer.ComputeAsync();
            var errors = result.Where((output, index) => output > 0 && index != result.Count() - 1);
            if (errors.Any())
            {
                throw new InvalidOperationException($"Got errors: {string.Join(", ", errors)}!");
            }
            return result.Last();
        }
    }
}
