using System;
using System.Linq;
using AOC.Solver.IntcodeComputer;

namespace AOC.Solver
{
    public static class Day09
    {
        public static long SolvePart1(long[] program, long input)
        {
            var computer = new Computer(program, input);
            var result = computer.Compute();
            var errors = result.Where((output, index) => output > 0 && index != result.Count() - 1);
            if (errors.Any())
            {
                throw new InvalidOperationException($"Got errors: {string.Join(", ", errors)}!");
            }
            return result.Last();
        }

        public static int SolvePart2()
        {
            throw new NotImplementedException("Part 2 not implemented yet!");
        }
    }
}
