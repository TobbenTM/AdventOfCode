using System;
using System.Collections.Generic;
using System.Linq;

namespace AOC.Solver
{
    public static class Day05
    {
        public static int SolvePart1(int[] program, int input)
        {
            var result = Compute(ref program, input);

            return result.Last();
        }

        public static int SolvePart2(int[] program, int input)
        {
            var result = Compute(ref program, input);

            return result.Last();
        }

        public enum ParameterMode
        {
            Position = 0,
            Immediate = 1,
        }

        public static List<int> Compute(ref int[] stack, int input)
        {
            var output = new List<int>();
            for (var i = 0; i < stack.Length;)
            {
                var op = stack[i];

                var mode1 = (ParameterMode)(Math.Floor(op / 100m) % 10);
                var mode2 = (ParameterMode)Math.Floor(op / 1000m);
                var mode3 = (ParameterMode)Math.Floor(op / 10000m);

                if (op >= 100)
                {
                    op = op % 100;
                }

                switch (op)
                {
                    case 1:
                        var a1 = mode1 == ParameterMode.Immediate ? stack[i + 1] : stack[stack[i + 1]];
                        var b1 = mode2 == ParameterMode.Immediate ? stack[i + 2] : stack[stack[i + 2]];
                        stack[stack[i + 3]] = a1 + b1;
                        i += 4;
                        break;

                    case 2:
                        var a2 = mode1 == ParameterMode.Immediate ? stack[i + 1] : stack[stack[i + 1]];
                        var b2 = mode2 == ParameterMode.Immediate ? stack[i + 2] : stack[stack[i + 2]];
                        stack[stack[i + 3]] = a2 * b2;
                        i += 4;
                        break;

                    case 3:
                        stack[stack[i + 1]] = input;
                        i += 2;
                        break;

                    case 4:
                        var a4 = mode1 == ParameterMode.Immediate ? stack[i + 1] : stack[stack[i + 1]];
                        output.Add(a4);
                        if (a4 > 0)
                        {
                            Console.WriteLine($"Warning executing op #{i}!");
                        }
                        i += 2;
                        break;

                    case 5:
                        var a5 = mode1 == ParameterMode.Immediate ? stack[i + 1] : stack[stack[i + 1]];
                        var b5 = mode2 == ParameterMode.Immediate ? stack[i + 2] : stack[stack[i + 2]];
                        if (a5 != 0)
                        {
                            i = b5;
                        }
                        else
                        {
                            i += 3;
                        }
                        break;

                    case 6:
                        var a6 = mode1 == ParameterMode.Immediate ? stack[i + 1] : stack[stack[i + 1]];
                        var b6 = mode2 == ParameterMode.Immediate ? stack[i + 2] : stack[stack[i + 2]];
                        if (a6 == 0)
                        {
                            i = b6;
                        }
                        else
                        {
                            i += 3;
                        }
                        break;

                    case 7:
                        var a7 = mode1 == ParameterMode.Immediate ? stack[i + 1] : stack[stack[i + 1]];
                        var b7 = mode2 == ParameterMode.Immediate ? stack[i + 2] : stack[stack[i + 2]];
                        stack[stack[i + 3]] = a7 < b7 ? 1 : 0;
                        i += 4;
                        break;

                    case 8:
                        var a8 = mode1 == ParameterMode.Immediate ? stack[i + 1] : stack[stack[i + 1]];
                        var b8 = mode2 == ParameterMode.Immediate ? stack[i + 2] : stack[stack[i + 2]];
                        stack[stack[i + 3]] = a8 == b8 ? 1 : 0;
                        i += 4;
                        break;

                    case 99:
                        return output;
                }
            }
            return output;
        }
    }
}
