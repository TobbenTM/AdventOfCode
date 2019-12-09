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
        private readonly Queue<long> _inputSeed;

        public Task Computation { get; private set; }

        public BlockingCollection<long> Input { get; private set; } = new BlockingCollection<long>();

        public BlockingCollection<long> Output { get; } = new BlockingCollection<long>();

        public Computer(int[] program, params int[] inputSeed)
            : this(program.Select(i => (long)i).ToArray(), inputSeed.Select(i => (long)i).ToArray())
        {
        }

        public Computer(long[] program, params long[] inputSeed)
        {
            _ctx = new Context(program);
            _inputSeed = new Queue<long>(inputSeed);
        }

        public long GetValue(int address) => _ctx.Get(address);

        public async Task<IEnumerable<long>> ComputeAsync(params long[] inputs)
        {
            foreach (var input in inputs)
            {
                Input.Add(input);
            }
            StartCompute();
            await Computation;
            return Output;
        }

        public void StartCompute(BlockingCollection<long> input = null)
        {
            if (input != null)
            {
                Input = input;
            }
            Computation = Task.Factory.StartNew(Compute);
        }

        private void Compute()
        {
            while (true)
            {
                _ctx.Reset();
                switch (_ctx.OpCode)
                {
                    case OpCode.Add:
                        var sum = _ctx.GetNextParameter() + _ctx.GetNextParameter();
                        _ctx.Assign(_ctx.GetNextParameterAddress(), sum);
                        break;

                    case OpCode.Multiply:
                        var product = _ctx.GetNextParameter() * _ctx.GetNextParameter();
                        _ctx.Assign(_ctx.GetNextParameterAddress(), product);
                        break;

                    case OpCode.Assign:
                        long input;
                        if (_inputSeed.Count > 0)
                        {
                            input = _inputSeed.Dequeue();
                        }
                        else
                        {
                            input = Input.Take();
                        }
                        _ctx.Assign(_ctx.GetNextParameterAddress(), input);
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
                        _ctx.Assign(_ctx.GetNextParameterAddress(), lessThan);
                        break;

                    case OpCode.CompareEquals:
                        var a = _ctx.GetNextParameter();
                        var b = _ctx.GetNextParameter();
                        var equal = a == b ? 1 : 0;
                        _ctx.Assign(_ctx.GetNextParameterAddress(), equal);
                        break;

                    case OpCode.SetRelativeBase:
                        var baseAdjustment = _ctx.GetNextParameter();
                        _ctx.AdjustRelativeBase(baseAdjustment);
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
