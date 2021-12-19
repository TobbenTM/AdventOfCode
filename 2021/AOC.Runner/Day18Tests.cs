using AOC.Solver;
using System.IO;
using System.Linq;
using Xunit;

namespace AOC.Runner
{
    public class Day18Tests
    {
        private readonly string[] _input;

        public Day18Tests()
        {
            var lines = File.ReadAllLines("./Day18.input");
            _input = lines
                .Where(line => line.Length > 0)
                .ToArray();
        }

        [Fact]
        public void Part1()
        {
            var result = Day18.SolvePart1(_input);
            Assert.Equal(4111, result);
        }

        [Fact]
        public void Part2()
        {
            var result = Day18.SolvePart2(_input);
            Assert.Equal(4917, result);
        }
    }
}
