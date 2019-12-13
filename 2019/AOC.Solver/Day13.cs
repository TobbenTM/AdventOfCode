using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AOC.Solver.IntcodeComputer;

namespace AOC.Solver
{
    public static class Day13
    {
        public static async Task<int> SolvePart1(long[] input)
        {
            var computer = new Computer(input);
            var result = (await computer.ComputeAsync()).ToArray();
            var map = new Dictionary<(long x, long y), long>();

            for (var i = 0; i < result.Length; i += 3)
            {
                var x = result[i];
                var y = result[i+1];
                var tile = result[i+2];
                map[(x, y)] = tile;
            }

            return map.Values.Count(tile => tile == 2);
        }
    }
}
