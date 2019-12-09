using System;
using System.Linq;
using AOC.Solver.IntcodeComputer;
using Xunit;

namespace AOC.Runner
{
    public class IntcodeComputerTests
    {
        [Theory]
        [InlineData(3500, 1, 9, 10, 3, 2, 3, 11, 0, 99, 30, 40, 50)]
        [InlineData(2, 1, 0, 0, 0, 99)]
        [InlineData(30, 1, 1, 1, 4, 99, 5, 6, 0, 99)]
        public void ShouldAlterFirstSlot(int expected, params int[] program)
        {
            var computer = new Computer(program);
            computer.Compute();
            Assert.Equal(expected, computer.GetValue(0));
        }

        [Theory]
        [InlineData("Using position mode, consider whether the input is equal to 8; output 1 (if it is) or 0 (if it is not).", 0, 0, 3, 9, 8, 9, 10, 9, 4, 9, 99, -1, 8)]
        [InlineData("Using position mode, consider whether the input is equal to 8; output 1 (if it is) or 0 (if it is not).", 1, 8, 3, 9, 8, 9, 10, 9, 4, 9, 99, -1, 8)]
        [InlineData("Using position mode, consider whether the input is equal to 8; output 1 (if it is) or 0 (if it is not).", 0, 10, 3, 9, 8, 9, 10, 9, 4, 9, 99, -1, 8)]
        [InlineData("Using position mode, consider whether the input is less than 8; output 1 (if it is) or 0 (if it is not).", 1, 6, 3, 9, 7, 9, 10, 9, 4, 9, 99, -1, 8)]
        [InlineData("Using position mode, consider whether the input is less than 8; output 1 (if it is) or 0 (if it is not).", 0, 8, 3, 9, 7, 9, 10, 9, 4, 9, 99, -1, 8)]
        [InlineData("Using immediate mode, consider whether the input is equal to 8; output 1 (if it is) or 0 (if it is not).", 1, 8, 3, 3, 1108, -1, 8, 3, 4, 3, 99)]
        [InlineData("Using immediate mode, consider whether the input is equal to 8; output 1 (if it is) or 0 (if it is not).", 0, 6, 3, 3, 1108, -1, 8, 3, 4, 3, 99)]
        [InlineData("Using immediate mode, consider whether the input is less than 8; output 1 (if it is) or 0 (if it is not).", 0, 10, 3, 3, 1107, -1, 8, 3, 4, 3, 99)]
        [InlineData("Using immediate mode, consider whether the input is less than 8; output 1 (if it is) or 0 (if it is not).", 0, 8, 3, 3, 1107, -1, 8, 3, 4, 3, 99)]
        [InlineData("Using immediate mode, consider whether the input is less than 8; output 1 (if it is) or 0 (if it is not).", 1, 6, 3, 3, 1107, -1, 8, 3, 4, 3, 99)]
        [InlineData("Outputs whatever it gets as input, then halts", 0, 0, 3, 0, 4, 0, 99)]
        [InlineData("Outputs whatever it gets as input, then halts", 123, 123, 3, 0, 4, 0, 99)]
        [InlineData("Take an input, then output 0 if the input was zero or 1 if the input was non-zero. (using position mode)", 0, 0, 3, 12, 6, 12, 15, 1, 13, 14, 13, 4, 13, 99, -1, 0, 1, 9)]
        [InlineData("Take an input, then output 0 if the input was zero or 1 if the input was non-zero. (using position mode)", 1, 1, 3, 12, 6, 12, 15, 1, 13, 14, 13, 4, 13, 99, -1, 0, 1, 9)]
        [InlineData("Take an input, then output 0 if the input was zero or 1 if the input was non-zero. (using immediate mode)", 0, 0, 3, 3, 1105, -1, 9, 1101, 0, 0, 12, 4, 12, 99, 1)]
        [InlineData("Take an input, then output 0 if the input was zero or 1 if the input was non-zero. (using immediate mode)", 1, 1, 3, 3, 1105, -1, 9, 1101, 0, 0, 12, 4, 12, 99, 1)]
        [InlineData("The program will output 999 if the input value is below 8", 999, 6, 3, 21, 1008, 21, 8, 20, 1005, 20, 22, 107, 8, 21, 20, 1006, 20, 31, 1106, 0, 36, 98, 0, 0, 1002, 21, 125, 20, 4, 20, 1105, 1, 46, 104, 999, 1105, 1, 46, 1101, 1000, 1, 20, 4, 20, 1105, 1, 46, 98, 99)]
        [InlineData("The program will output 1000 if the input value is equal to 8", 1000, 8, 3, 21, 1008, 21, 8, 20, 1005, 20, 22, 107, 8, 21, 20, 1006, 20, 31, 1106, 0, 36, 98, 0, 0, 1002, 21, 125, 20, 4, 20, 1105, 1, 46, 104, 999, 1105, 1, 46, 1101, 1000, 1, 20, 4, 20, 1105, 1, 46, 98, 99)]
        [InlineData("The program will output 1001 if the input value is greater than 8", 1001, 10, 3, 21, 1008, 21, 8, 20, 1005, 20, 22, 107, 8, 21, 20, 1006, 20, 31, 1106, 0, 36, 98, 0, 0, 1002, 21, 125, 20, 4, 20, 1105, 1, 46, 104, 999, 1105, 1, 46, 1101, 1000, 1, 20, 4, 20, 1105, 1, 46, 98, 99)]
        public void ShouldRunSmallerPrograms(string description, int expected, int input, params int[] program)
        {
            Console.WriteLine(description);
            var computer = new Computer(program);
            var output = computer.Compute(input);
            Console.WriteLine($"Got result: {output.Last()}, {output.Count(i => i == 0)} checks passed");
            Assert.Equal(expected, output.Last());
        }

        [Fact]
        public void ShouldThrowExceptionOnUnknownOpCode()
        {
            var program = new[] { 123 };
            var computer = new Computer(program);
            Assert.Throws<NotImplementedException>(() => computer.Compute());
        }

        [Fact]
        public void ShouldSupportOutputtingLargeNumbers1()
        {
            var program = new long[] { 109, 1, 204, -1, 1001, 100, 1, 100, 1008, 100, 16, 101, 1006, 101, 0, 99 };
            var computer = new Computer(program);
            var output = computer.Compute();
            Assert.Equal(program, output);
        }

        [Fact]
        public void ShouldSupportOutputtingLargeNumbers2()
        {
            var program = new long[] { 1102, 34915192, 34915192, 7, 4, 7, 99, 0 };
            var computer = new Computer(program);
            var output = computer.Compute();
            Assert.Equal(16, output.Last().ToString().Length);
        }

        [Fact]
        public void ShouldSupportOutputtingLargeNumbers3()
        {
            var program = new long[] { 104, 1125899906842624, 99 };
            var computer = new Computer(program);
            var output = computer.Compute();
            Assert.Equal(program[1], output.Last());
        }
    }
}
