using System.Linq;
using System.Threading.Tasks;
using AOC.Solver.IntcodeComputer;

namespace AOC.Solver
{
    public static class Day02
    {
        public static async Task<int> SolvePart1(int[] input)
        {
            input[1] = 12;
            input[2] = 2;

            var computer = new Computer(input);
            await computer.ComputeAsync();

            return (int)computer.GetValue(0);
        }

        public static async Task<int> SolvePart2(int[] input, int target)
        {
            for (var noun = 0; noun <= 99; noun++)
            {
                for (var verb = 0; verb <= 99; verb++)
                {
                    var stack = input.ToArray();
                    stack[1] = noun;
                    stack[2] = verb;

                    var computer = new Computer(stack);
                    await computer.ComputeAsync();

                    var result = computer.GetValue(0);
                    if (result == target)
                    {
                        return 100 * noun + verb;
                    }
                }
            }
            return 0;
        }
    }
}
