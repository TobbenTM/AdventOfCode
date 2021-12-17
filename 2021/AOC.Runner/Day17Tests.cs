using AOC.Solver;
using System.IO;
using System.Linq;
using Xunit;

namespace AOC.Runner
{
    public class Day17Tests
    {
        private readonly string _input;

        public Day17Tests()
        {
            var lines = File.ReadAllLines("./Day17.input");
            _input = lines.Single(line => line.Length > 0);
        }

        [Fact]
        public void Part1()
        {
            var result = Day17.SolvePart1(_input);
            Assert.Equal(4656, result);
        }

        [Fact]
        public void Part1_WithExampleInput_ReturnsCorrectAnswer()
        {
            var input = "target area: x=20..30, y=-10..-5";
            var result = Day17.SolvePart1(input);
            Assert.Equal(45, result);
        }

        [Fact]
        public void Part2()
        {
            var result = Day17.SolvePart2(_input);
            Assert.Equal(1908, result);
        }
    }
}
