using AOC.Solver;
using Xunit;

namespace AOC.Runner
{
    public class Day25Tests
    {
        [Fact]
        public void Part1()
        {
            var result = Day25.SolvePart1(_input);
            Assert.Equal(1478097, result);
        }

        private readonly int[] _input =
        {
            9232416,
            14144084,
        };
    }
}
