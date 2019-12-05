using System;
using System.Collections.Generic;
using System.Linq;

namespace AOC.Solver
{
    public static class IntcodeComputer
    {
        public enum ParameterMode
        {
            Position = 0,
            Immediate = 1,
            Auto = 999,
        }

        public enum OpCode
        {
            Unknown = 0,
            Add = 1,
            Multiply = 2,
            Assign = 3,
            Output = 4,
            JumpIfPositive = 5,
            JumpIfZero = 6,
            CompareLessThan = 7,
            CompareEquals = 8,
            Halt = 99,
        }

        public class Context
        {
            private readonly int[] _stack;
            private List<ParameterMode> _parameterModes;
            private int _pointer;

            public OpCode OpCode { get; private set; }


            public Context(int[] stack)
            {
                _pointer = 0;
                _stack = stack;
            }

            public void Clear()
            {
                var opCode = _stack[_pointer++];
                OpCode = (OpCode)(opCode % 100);

                _parameterModes = new List<ParameterMode>
                {
                    (ParameterMode)(Math.Floor(opCode / 100m) % 10),
                    (ParameterMode)Math.Floor(opCode / 1000m),
                    (ParameterMode)Math.Floor(opCode / 10000m),
                };
            }

            public int GetNextParameter(ParameterMode parameterMode = ParameterMode.Auto)
            {
                parameterMode = parameterMode == ParameterMode.Auto ? _parameterModes.First() : parameterMode;
                _parameterModes.RemoveAt(0);
                return parameterMode == ParameterMode.Immediate ? _stack[_pointer++] : _stack[_stack[_pointer++]];
            }

            public void Jump(int address)
            {
                _pointer = address;
            }

            public void Skip()
            {
                _pointer += 1;
            }

            public int[] Assign(int address, int value)
            {
                _stack[address] = value;
                return _stack;
            }
        }

        public static List<int> Compute(ref int[] stack, int input = 0)
        {
            var output = new List<int>();
            var ctx = new Context(stack);

            while (true)
            {
                ctx.Clear();
                switch (ctx.OpCode)
                {
                    case OpCode.Add:
                        var sum = ctx.GetNextParameter() + ctx.GetNextParameter();
                        stack = ctx.Assign(ctx.GetNextParameter(ParameterMode.Immediate), sum);
                        break;

                    case OpCode.Multiply:
                        var product = ctx.GetNextParameter() * ctx.GetNextParameter();
                        stack = ctx.Assign(ctx.GetNextParameter(ParameterMode.Immediate), product);
                        break;

                    case OpCode.Assign:
                        stack = ctx.Assign(ctx.GetNextParameter(ParameterMode.Immediate), input);
                        break;

                    case OpCode.Output:
                        output.Add(ctx.GetNextParameter());
                        break;

                    case OpCode.JumpIfPositive:
                        if (ctx.GetNextParameter() != 0)
                        {
                            var address = ctx.GetNextParameter();
                            ctx.Jump(address);
                            break;
                        }
                        ctx.Skip();
                        break;

                    case OpCode.JumpIfZero:
                        if (ctx.GetNextParameter() == 0)
                        {
                            var address = ctx.GetNextParameter();
                            ctx.Jump(address);
                            break;
                        }
                        ctx.Skip();
                        break;

                    case OpCode.CompareLessThan:
                        var lesser = ctx.GetNextParameter();
                        var greater = ctx.GetNextParameter();
                        var lessThan = lesser < greater ? 1 : 0;
                        stack = ctx.Assign(ctx.GetNextParameter(ParameterMode.Immediate), lessThan);
                        break;

                    case OpCode.CompareEquals:
                        var a = ctx.GetNextParameter();
                        var b = ctx.GetNextParameter();
                        var equal = a == b ? 1 : 0;
                        stack = ctx.Assign(ctx.GetNextParameter(ParameterMode.Immediate), equal);
                        break;

                    case OpCode.Halt:
                        return output;

                    case OpCode.Unknown:
                    default:
                        throw new NotImplementedException($"OpCode {(int)ctx.OpCode} is not yet implemented!");
                }
            }
        }
    }
}
