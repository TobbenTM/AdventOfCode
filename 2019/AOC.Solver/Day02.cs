using System.Linq;

namespace AOC.Solver
{
    public static class Day02
    {
        public static int SolvePart1(int[] input)
        {
            input[1] = 12;
            input[2] = 2;

            Compute(ref input);

            return input[0];
        }

        public static int SolvePart2(int[] input, int target)
        {
            for (var noun = 0; noun <= 99; noun++)
            {
                for (var verb = 0; verb <= 99; verb++)
                {
                    var stack = input.ToArray();
                    stack[1] = noun;
                    stack[2] = verb;
                    Compute(ref stack);
                    if (stack[0] == target)
                    {
                        return 100 * noun + verb;
                    }
                }
            }
            return 0;
        }

        public static void Compute(ref int[] stack)
        {
            for (var i = 0; i < stack.Length;)
            {
                var op = stack[i];
                switch (op)
                {
                    case 1:
                        var a1 = stack[stack[i + 1]];
                        var b1 = stack[stack[i + 2]];
                        stack[stack[i + 3]] = a1 + b1;
                        break;

                    case 2:
                        var a2 = stack[stack[i + 1]];
                        var b2 = stack[stack[i + 2]];
                        stack[stack[i + 3]] = a2 * b2;
                        break;

                    case 99:
                        return;
                }
                i += 4;
            }
        }
    }
}
