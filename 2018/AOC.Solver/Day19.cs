using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AOC.Solver
{
    public static class Day19
    {
        public class TimeTravellingDevice
        {
            public static string[] OpCodes => new string[]
            {
                "addr",
                "addi",
                "mulr",
                "muli",
                "banr",
                "bani",
                "borr",
                "bori",
                "setr",
                "seti",
                "gtir",
                "gtri",
                "gtrr",
                "eqir",
                "eqri",
                "eqrr",
            };

            private readonly Instruction[] _instructions;
            private readonly int _ipBinding;
            private long[] _currentState;

            public TimeTravellingDevice(string[] input, long[] initialState = null)
            {
                if (initialState == null)
                {
                    initialState = new []{0L, 0L, 0L, 0L, 0L, 0L};
                }
                _ipBinding = int.Parse(input[0].Split(" ").Last());
                _instructions = input.Skip(1).Select(i => new Instruction(i)).ToArray();
                _currentState = initialState;
            }

            public long[] DoWork()
            {
                while (_currentState[_ipBinding] < _instructions.Length && _currentState[_ipBinding] >= 0)
                {
                    _currentState = Execute(_currentState, _instructions[_currentState[_ipBinding]]);
                    _currentState[_ipBinding] += 1;
                    Debug.WriteLine($"IP: {_currentState[_ipBinding]}, state: {string.Join(", ", _currentState)}");
                }

                return _currentState;
            }

            public static long[] Execute(long[] input, Instruction instruction)
            {
                var registers = input.ToArray();
                switch (instruction.OpCode)
                {
                    case "addr":
                        registers[instruction.C] = registers[instruction.A] + registers[instruction.B];
                        break;
                    case "addi":
                        registers[instruction.C] = registers[instruction.A] + instruction.B;
                        break;
                    case "mulr":
                        registers[instruction.C] = registers[instruction.A] * registers[instruction.B];
                        break;
                    case "muli":
                        registers[instruction.C] = registers[instruction.A] * instruction.B;
                        break;
                    case "banr":
                        registers[instruction.C] = registers[instruction.A] & registers[instruction.B];
                        break;
                    case "bani":
                        registers[instruction.C] = registers[instruction.A] & instruction.B;
                        break;
                    case "borr":
                        registers[instruction.C] = registers[instruction.A] | registers[instruction.B];
                        break;
                    case "bori":
                        registers[instruction.C] = registers[instruction.A] | instruction.B;
                        break;
                    case "setr":
                        registers[instruction.C] = registers[instruction.A];
                        break;
                    case "seti":
                        registers[instruction.C] = instruction.A;
                        break;
                    case "gtir":
                        registers[instruction.C] = instruction.A > registers[instruction.B] ? 1 : 0;
                        break;
                    case "gtri":
                        registers[instruction.C] = registers[instruction.A] > instruction.B ? 1 : 0;
                        break;
                    case "gtrr":
                        registers[instruction.C] = registers[instruction.A] > registers[instruction.B] ? 1 : 0;
                        break;
                    case "eqir":
                        registers[instruction.C] = instruction.A == registers[instruction.B] ? 1 : 0;
                        break;
                    case "eqri":
                        registers[instruction.C] = registers[instruction.A] == instruction.B ? 1 : 0;
                        break;
                    case "eqrr":
                        registers[instruction.C] = registers[instruction.A] == registers[instruction.B] ? 1 : 0;
                        break;
                    default: throw new ArgumentOutOfRangeException($"Instruction with opcode {instruction.OpCode} not supported!");
                }
                return registers;
            }
        }

        public class Instruction
        {
            public string OpCode { get; set; }

            // Input 1
            public int A { get; set; }
            // Input 2
            public int B { get; set; }

            // Output 1
            public int C { get; set; }

            public Instruction(string input)
            {
                var parts = input.Split(" ");
                OpCode = parts[0];
                A = int.Parse(parts[1]);
                B = int.Parse(parts[2]);
                C = int.Parse(parts[3]);
            }
        }
    }
}
