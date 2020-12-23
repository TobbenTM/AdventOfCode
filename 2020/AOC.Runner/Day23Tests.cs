using AOC.Solver;
using Xunit;

namespace AOC.Runner
{
    public class Day23Tests
    {
        [Fact]
        public void Part1()
        {
            var result = Day23.SolvePart1(_input);
            Assert.Equal(89573246, result);
        }

        [Fact]
        public void Part2()
        {
            var result = Day23.SolvePart2(_input);
            Assert.Equal(-1, result);
        }

        [Fact]
        public void Part1_WithExampleData_PlaysGame()
        {
            var input = "389125467";
            var result = Day23.SolvePart1(input);
            Assert.Equal(67384529, result);
        }

        [Fact]
        public void Part2_WithExampleData_PlaysGame()
        {
            var input = "389125467";
            var result = Day23.SolvePart2(input);
            Assert.Equal(149245887792, result);
        }

        private readonly string _input = "487912365";
    }
}
