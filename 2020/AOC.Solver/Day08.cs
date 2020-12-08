using System;
using System.Collections.Generic;

namespace AOC.Solver
{
    public static class Day08
    {
        public static int SolvePart1(string[] input)
        {
            return Run(input).acc;
        }

        public static int SolvePart2(string[] input)
        {
            for (var i = 0; i < input.Length; i++)
            {
                var cmd = input[i].Substring(0, 3);
                if (cmd == "acc") continue;

                var copy = new string[input.Length];
                Array.Copy(input, copy, input.Length);
                if (cmd == "jmp") copy[i] = "nop " + input[i].Substring(3);
                else copy[i] = "jmp " + input[i].Substring(3);

                var result = Run(copy);
                if (!result.terminatedEarly) return result.acc;
            }
            throw new InvalidOperationException("Could not find a finite permutation");
        }

        private static (int acc, bool terminatedEarly) Run(string[] input)
        {
            var acc = 0;
            var pointer = 0;
            var visitedPointers = new HashSet<int>();
            while (pointer < input.Length)
            {
                if (visitedPointers.Contains(pointer)) return (acc, true);
                visitedPointers.Add(pointer);

                var cmd = input[pointer].Substring(0, 3);
                var arg = int.Parse(input[pointer].Substring(3));
                switch (cmd)
                {
                    case "nop":
                        pointer += 1;
                        break;
                    case "acc":
                        acc += arg;
                        pointer += 1;
                        break;
                    case "jmp":
                        pointer += arg;
                        break;
                }
            }
            return (acc, false);
        }
    }
}
