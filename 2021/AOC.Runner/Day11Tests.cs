using AOC.Solver;
using System.IO;
using System.Linq;
using Xunit;

namespace AOC.Runner
{
    public class Day11Tests
    {
        private readonly int[][] _input;

        public Day11Tests()
        {
            var lines = File.ReadAllLines("./Day11.input");
            _input = lines
                .Where(line => line.Length > 0)
                .Select(line => line.Select(ch => int.Parse(ch.ToString())).ToArray())
                .ToArray();
        }

        [Fact]
        public void Part1()
        {
            var result = Day11.SolvePart1(_input);
            Assert.Equal(1721, result);
        }

        [Fact]
        public void Part2()
        {
            var result = Day11.SolvePart2(_input);
            Assert.Equal(298, result);
        }
    }
}
