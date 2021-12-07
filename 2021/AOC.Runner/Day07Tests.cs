using AOC.Solver;
using System.IO;
using System.Linq;
using Xunit;

namespace AOC.Runner
{
    public class Day07Tests
    {
        private readonly int[] _input;

        public Day07Tests()
        {
            var lines = File.ReadAllLines("./Day07.input");
            _input = lines
                .Single(line => line.Length > 0)
                .Split(",")
                .Select(int.Parse)
                .ToArray();
        }

        [Fact]
        public void Part1()
        {
            var result = Day07.SolvePart1(_input);
            Assert.Equal(344535, result);
        }

        [Fact]
        public void Part2()
        {
            var result = Day07.SolvePart2(_input);
            Assert.Equal(95581659, result);
        }

        [Fact]
        public void Part1_WithExampleInput_ReturnsExpectedAnswer()
        {
            var input = new[] {16, 1, 2, 0, 4, 2, 7, 1, 2, 14};
            var result = Day07.SolvePart1(input);
            Assert.Equal(37, result);
        }
    }
}
