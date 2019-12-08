using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AOC.Solver
{
    public class IntcodeComputer
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

            public int Get(int address)
            {
                return _stack[address];
            }
        }

        private readonly Context _ctx;

        public Task Computation { get; private set; }

        public BlockingCollection<int> Input { get; private set; } = new BlockingCollection<int>();

        public BlockingCollection<int> Output { get; } = new BlockingCollection<int>();

        public IntcodeComputer(int[] program)
        {
            var localStack = program.ToArray();
            _ctx = new Context(localStack);
        }

        public int GetValue(int address) => _ctx.Get(address);

        /// <summary>
        /// TODO: Refactor this
        /// </summary>
        public IEnumerable<int> Compute(params int[] inputs)
        {
            foreach (var input in inputs)
            {
                Input.Add(input);
            }
            Computation = Task.Factory.StartNew(Compute);
            Computation.GetAwaiter().GetResult();
            return Output;
        }

        public void StartCompute(BlockingCollection<int> input)
        {
            Input = input;
            Computation = Task.Factory.StartNew(Compute);
        }

        private void Compute()
        {
            while (true)
            {
                _ctx.Clear();
                switch (_ctx.OpCode)
                {
                    case OpCode.Add:
                        var sum = _ctx.GetNextParameter() + _ctx.GetNextParameter();
                        _ctx.Assign(_ctx.GetNextParameter(ParameterMode.Immediate), sum);
                        break;

                    case OpCode.Multiply:
                        var product = _ctx.GetNextParameter() * _ctx.GetNextParameter();
                        _ctx.Assign(_ctx.GetNextParameter(ParameterMode.Immediate), product);
                        break;

                    case OpCode.Assign:
                        _ctx.Assign(_ctx.GetNextParameter(ParameterMode.Immediate), Input.Take());
                        break;

                    case OpCode.Output:
                        Output.Add(_ctx.GetNextParameter());
                        break;

                    case OpCode.JumpIfPositive:
                        if (_ctx.GetNextParameter() != 0)
                        {
                            var address = _ctx.GetNextParameter();
                            _ctx.Jump(address);
                            break;
                        }
                        _ctx.Skip();
                        break;

                    case OpCode.JumpIfZero:
                        if (_ctx.GetNextParameter() == 0)
                        {
                            var address = _ctx.GetNextParameter();
                            _ctx.Jump(address);
                            break;
                        }
                        _ctx.Skip();
                        break;

                    case OpCode.CompareLessThan:
                        var lesser = _ctx.GetNextParameter();
                        var greater = _ctx.GetNextParameter();
                        var lessThan = lesser < greater ? 1 : 0;
                        _ctx.Assign(_ctx.GetNextParameter(ParameterMode.Immediate), lessThan);
                        break;

                    case OpCode.CompareEquals:
                        var a = _ctx.GetNextParameter();
                        var b = _ctx.GetNextParameter();
                        var equal = a == b ? 1 : 0;
                        _ctx.Assign(_ctx.GetNextParameter(ParameterMode.Immediate), equal);
                        break;

                    case OpCode.Halt:
                        Output.CompleteAdding();
                        return;

                    case OpCode.Unknown:
                    default:
                        throw new NotImplementedException($"OpCode {(int)_ctx.OpCode} is not yet implemented!");
                }
            }
        }
    }
}
