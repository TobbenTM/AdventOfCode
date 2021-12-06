using AOC.Solver;
using System.IO;
using System.Linq;
using Xunit;

namespace AOC.Runner
{
    public class Day06Tests
    {
        private readonly int[] _input;

        public Day06Tests()
        {
            var lines = File.ReadAllLines("./Day06.input");
            _input = lines
                .Single(line => line.Length > 0)
                .Split(",")
                .Select(int.Parse)
                .ToArray();
        }

        [Fact]
        public void Part1()
        {
            var result = Day06.SolvePart1(_input);
            Assert.Equal(360610, result);
        }

        [Fact]
        public void Part2()
        {
            var result = Day06.SolvePart2(_input);
            Assert.Equal(1631629590423, result);
        }

        [Fact]
        public void Part1_WithExampleInput_ReturnsExpectedAnswer()
        {
            var input = new[] {3, 4, 3, 1, 2};
            var result = Day06.SolvePart1(input);
            Assert.Equal(5934, result);
        }
    }
}
