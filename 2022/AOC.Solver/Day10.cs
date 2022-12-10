using System;
using System.Linq;
using System.Text;

namespace AOC.Solver;

public static class Day10
{
    private class Operation
    {
        private int _ticksLeft;
        private readonly Func<int, int> _action;

        public Operation(string input)
        {
            var parts = input.Split(" ");
            switch (parts.First())
            {
                case "noop":
                    _ticksLeft = 1;
                    _action = r => r;
                    break;
                case "addx":
                    _ticksLeft = 2;
                    _action = r => r + int.Parse(parts.Last());
                    break;
                default:
                    throw new InvalidOperationException("Unknown operation");
            }
        }

        public bool Tick(ref int register)
        {
            _ticksLeft -= 1;
            if (_ticksLeft == 0)
            {
                register = _action(register);
                return true;
            }

            return false;
        }
    }

    private class Computer
    {
        private readonly Operation[] _operations;
        private int _stackPointer = 0;
        private int _tick = 1;
        private int _register = 1;

        public Computer(string[] input)
        {
            _operations = input.Select(op => new Operation(op)).ToArray();
        }

        public int CurrentRegisterValue => _register;

        public int ComputeSingle() => ComputeTo(_tick + 1);

        public int ComputeTo(int tick)
        {
            while (_tick < tick)
            {
                _tick += 1;
                if (_operations[_stackPointer].Tick(ref _register))
                {
                    _stackPointer += 1;
                }
            }

            return _register;
        }
    }

    public static int SolvePart1(string[] input)
    {
        var computer = new Computer(input);
        var results = new[]
        {
            computer.ComputeTo(20) * 20,
            computer.ComputeTo(60) * 60,
            computer.ComputeTo(100) * 100,
            computer.ComputeTo(140) * 140,
            computer.ComputeTo(180) * 180,
            computer.ComputeTo(220) * 220,
        };
        return results.Sum();
    }

    public static string SolvePart2(string[] input)
    {
        var computer = new Computer(input);
        var result = new StringBuilder();
        for (var row = 0; row < 6; row++)
        {
            for (var col = 0; col < 40; col++)
            {
                result.Append(Math.Abs(col - computer.CurrentRegisterValue) <= 1 ? '#' : '.');

                computer.ComputeSingle();
            }

            result.Append('\n');
        }

        return result.ToString();
    }
}
