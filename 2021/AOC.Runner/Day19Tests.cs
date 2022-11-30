using AOC.Solver;
using System.IO;
using System.Linq;
using Xunit;

namespace AOC.Runner
{
    public class Day19Tests
    {
        private readonly string[] _input;

        public Day19Tests()
        {
            _input = File.ReadAllLines("./Day19.input");
        }

        [Fact]
        public void Part1()
        {
            var result = Day19.SolvePart1(_input);
            Assert.Equal(-1, result);
        }

        [Fact]
        public void Part2()
        {
            var result = Day19.SolvePart2(_input);
            Assert.Equal(-1, result);
        }
    }
}
