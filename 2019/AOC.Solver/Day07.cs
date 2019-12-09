using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AOC.Solver.IntcodeComputer;

namespace AOC.Solver
{
    public static class Day07
    {
        public static async Task<int> SolvePart1(int[] program)
        {
            var phases = new[] { 0, 1, 2, 3, 4 };
            var phaseCombinations = GetPermutations(phases, 5);

            var computeTasks = phaseCombinations.Select(c => ComputeOnce(program, c.ToArray())).ToArray();
            var results = await Task.WhenAll(computeTasks);
            return (int)results.Max();
        }

        public static async Task<long> ComputeOnce(int[] program, params int[] phases)
        {
            var a = await new Computer(program).ComputeAsync(phases[0], 0);
            var b = await new Computer(program).ComputeAsync(phases[1], a.Last());
            var c = await new Computer(program).ComputeAsync(phases[2], b.Last());
            var d = await new Computer(program).ComputeAsync(phases[3], c.Last());
            var e = await new Computer(program).ComputeAsync(phases[4], d.Last());
            return e.Last();
        }

        public static async Task<int> SolvePart2(int[] program)
        {
            var phases = new[] { 5, 6, 7, 8, 9 };
            var phaseCombinations = GetPermutations(phases, 5);

            var computeTasks = phaseCombinations.Select(c => ComputeWithFeedbackLoop(program, c.ToArray())).ToArray();
            var results = await Task.WhenAll(computeTasks);
            return results.Max();
        }

        public static async Task<int> ComputeWithFeedbackLoop(int[] program, params int[] phases)
        {
            var amplifierA = new Computer(program, phases[0], 0);
            var amplifierB = new Computer(program, phases[1]);
            var amplifierC = new Computer(program, phases[2]);
            var amplifierD = new Computer(program, phases[3]);
            var amplifierE = new Computer(program, phases[4]);

            amplifierA.StartCompute(amplifierE.Output);
            amplifierB.StartCompute(amplifierA.Output);
            amplifierC.StartCompute(amplifierB.Output);
            amplifierD.StartCompute(amplifierC.Output);
            amplifierE.StartCompute(amplifierD.Output);

            await Task.WhenAll(amplifierA.Computation, amplifierB.Computation, amplifierC.Computation, amplifierD.Computation, amplifierE.Computation);

            return (int)amplifierE.Output.Last();
        }

        // Source: https://stackoverflow.com/questions/1952153/what-is-the-best-way-to-find-all-combinations-of-items-in-an-array/10629938#10629938
        public static IEnumerable<IEnumerable<T>> GetPermutations<T>(IEnumerable<T> list, int length)
        {
            if (length == 1) return list.Select(t => new T[] { t });
            return GetPermutations(list, length - 1)
                .SelectMany(t => list.Where(o => !t.Contains(o)),
                    (t1, t2) => t1.Concat(new T[] { t2 }));
        }
    }
}
