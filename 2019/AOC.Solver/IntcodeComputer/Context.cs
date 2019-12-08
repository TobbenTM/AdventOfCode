using System;
using System.Collections.Generic;
using System.Linq;

namespace AOC.Solver.IntcodeComputer
{
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
}
