using System;
using System.Collections.Generic;
using System.Linq;

namespace AOC.Solver.IntcodeComputer
{
    public class Context
    {
        private Queue<ParameterMode> _parameterModes;
        private long[] _stack;
        private int _relativeBase = 0;
        private int _pointer;

        public OpCode OpCode { get; private set; }

        public Context(long[] program)
        {
            _pointer = 0;
            _stack = program.ToArray();
        }

        public void Reset()
        {
            var opCode = _stack[_pointer++];
            OpCode = (OpCode)(opCode % 100);

            _parameterModes = new Queue<ParameterMode>(new []
            {
                (ParameterMode)(Math.Floor(opCode / 100m) % 10),
                (ParameterMode)(Math.Floor(opCode / 1000m) % 10),
                (ParameterMode)Math.Floor(opCode / 10000m),
            });
        }

        public long GetNextParameter()
        {
            CheckArraySize();
            return _stack[GetNextParameterAddress()];
        }

        public long GetNextParameterAddress()
        {
            var parameterMode = _parameterModes.Dequeue();
            CheckArraySize();
            switch (parameterMode)
            {
                case ParameterMode.Immediate:
                    return _pointer++;
                case ParameterMode.Position:
                    return _stack[_pointer++];
                case ParameterMode.Relative:
                    return _relativeBase + _stack[_pointer++];
                default:
                    throw new InvalidOperationException($"Could not recognize parameter mode {(int)parameterMode}!");
            }
        }

        public void Jump(long address)
        {
            _pointer = (int)address;
            CheckArraySize();
        }

        public void Skip()
        {
            _pointer += 1;
            CheckArraySize();
        }

        public void Assign(long address, long value)
        {
            CheckArraySize((int)address);
            _stack[address] = value;
        }

        public long Get(int address)
        {
            CheckArraySize(address);
            return _stack[address];
        }

        public void AdjustRelativeBase(long baseAdjustment)
        {
            _relativeBase += (int)baseAdjustment;
        }

        private void CheckArraySize(int? expectedSize = null)
        {
            if (expectedSize == null)
            {
                expectedSize = _relativeBase + (int)_stack[_pointer];
            }
            if (expectedSize > _stack.Length - 1)
            {
                Array.Resize(ref _stack, expectedSize.Value);
            }
        }
    }
}
