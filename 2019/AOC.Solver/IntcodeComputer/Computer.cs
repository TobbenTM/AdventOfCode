using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AOC.Solver.IntcodeComputer
{
    public class Computer
    {
        private readonly Context _ctx;
        private readonly Queue<int> _inputSeed;

        public Task Computation { get; private set; }

        public BlockingCollection<int> Input { get; private set; } = new BlockingCollection<int>();

        public BlockingCollection<int> Output { get; } = new BlockingCollection<int>();

        public Computer(int[] program, params int[] inputSeed)
        {
            var localStack = program.ToArray();
            _ctx = new Context(localStack);
            _inputSeed = new Queue<int>(inputSeed);
        }

        public int GetValue(int address) => _ctx.Get(address);

        /// <summary>
        /// Obsolete - legacy synchronous computation
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
                        int input;
                        if (_inputSeed.Count > 0)
                        {
                            input = _inputSeed.Dequeue();
                        }
                        else
                        {
                            input = Input.Take();
                        }
                        _ctx.Assign(_ctx.GetNextParameter(ParameterMode.Immediate), input);
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
