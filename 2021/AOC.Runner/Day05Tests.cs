using AOC.Solver;
using System.IO;
using System.Linq;
using Xunit;

namespace AOC.Runner
{
    public class Day05Tests
    {
        private readonly string[] _input;

        public Day05Tests()
        {
            var lines = File.ReadAllLines("./Day05.input");
            _input = lines
                .Where(line => line.Length > 0)
                .ToArray();
        }

        [Fact]
        public void Part1()
        {
            var result = Day05.SolvePart1(_input);
            Assert.Equal(6572, result);
        }

        [Fact]
        public void Part2()
        {
            var result = Day05.SolvePart2(_input);
            Assert.Equal(21466, result);
        }
    }
}
