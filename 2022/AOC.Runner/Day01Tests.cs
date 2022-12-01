using System.IO;
using AOC.Solver;
using Xunit;

namespace AOC.Runner
{
    public class Day01Tests
    {
        private readonly string _input;

        public Day01Tests()
        {
            _input = File.ReadAllText("./Day01.input");
        }

        [Fact]
        public void Part1()
        {
            var result = Day01.SolvePart1(_input);
            Assert.Equal(67658, result);
        }

        [Fact]
        public void Part2()
        {
            var result = Day01.SolvePart2(_input);
            Assert.Equal(200158, result);
        }
    }
}
