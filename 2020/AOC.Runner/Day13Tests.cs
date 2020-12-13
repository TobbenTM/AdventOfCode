using AOC.Solver;
using Xunit;

namespace AOC.Runner
{
    public class Day13Tests
    {
        [Fact]
        public void Part1()
        {
            var result = Day13.SolvePart1(_input);
            Assert.Equal(2382, result);
        }

        [Fact]
        public void Part2()
        {
            var result = Day13.SolvePart2(_input);
            Assert.Equal(906332393333683, result);
        }

        [Theory]
        [InlineData("17,x,13,19", 3417)]
        [InlineData("67,7,59,61", 754018)]
        [InlineData("67,x,7,59,61", 779210)]
        [InlineData("67,7,x,59,61", 1261476)]
        [InlineData("1789,37,47,1889", 1202161486)]
        public void Part2_WithExampleData_ShouldCalculate(string busIds, long expectedAnswer)
        {
            var result = Day13.SolvePart2(new[] { null, busIds });
            Assert.Equal(expectedAnswer, result);
        }

        private readonly string[] _input =
        {
            "1000434",
            "17,x,x,x,x,x,x,41,x,x,x,x,x,x,x,x,x,983,x,29,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,19,x,x,x,23,x,x,x,x,x,x,x,397,x,x,x,x,x,37,x,x,x,x,x,x,13",
        };
    }
}
