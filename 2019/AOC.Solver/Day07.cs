using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
            return results.Max();
        }

        public static Task<int> ComputeOnce(int[] program, params int[] phases)
        {
            var a = new IntcodeComputer(program).Compute(phases[0], 0);
            var b = new IntcodeComputer(program).Compute(phases[1], a.Last());
            var c = new IntcodeComputer(program).Compute(phases[2], b.Last());
            var d = new IntcodeComputer(program).Compute(phases[3], c.Last());
            var e = new IntcodeComputer(program).Compute(phases[4], d.Last());
            return Task.FromResult(e.Last());
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
            var amplifierA = new IntcodeComputer(program);
            var amplifierB = new IntcodeComputer(program);
            var amplifierC = new IntcodeComputer(program);
            var amplifierD = new IntcodeComputer(program);
            var amplifierE = new IntcodeComputer(program);

            var outputA = amplifierA.Compute(phases[0], 0);
            var outputB = amplifierA.Compute(phases[1], 0);
            var outputC = amplifierA.Compute(phases[2], 0);
            var outputD = amplifierA.Compute(phases[3], 0);
            var outputE = amplifierA.Compute(phases[4], 0);

            // TODO

            return outputE.Last();
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
