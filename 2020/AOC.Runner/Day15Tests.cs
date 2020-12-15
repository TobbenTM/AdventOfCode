using AOC.Solver;
using Xunit;

namespace AOC.Runner
{
    public class Day15Tests
    {
        [Fact]
        public void Part1()
        {
            var result = Day15.Solve(_input, 2020);
            Assert.Equal(1325, result);
        }

        [Fact(Skip = "Still a bit slow (~5s)")]
        public void Part2()
        {
            var result = Day15.Solve(_input, 30_000_000);
            Assert.Equal(59006, result);
        }

        [Theory]
        [InlineData("0,3,6", 436)]
        [InlineData("1,3,2", 1)]
        [InlineData("2,1,3", 10)]
        [InlineData("1,2,3", 27)]
        [InlineData("2,3,1", 78)]
        [InlineData("3,2,1", 438)]
        [InlineData("3,1,2", 1836)]
        public void Part1_WithExampleData_ReturnsExpectedAnswers(string input, int expectedAnswer)
        {
            var result = Day15.Solve(input, 2020);
            Assert.Equal(expectedAnswer, result);
        }

        private readonly string _input = "19,20,14,0,9,1";
    }
}
