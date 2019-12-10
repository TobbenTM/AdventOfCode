using System.IO;
using System.Threading.Tasks;
using AOC.Solver;
using Xunit;

namespace AOC.Runner
{
    public class Day10Tests
    {
        [Fact]
        public async Task Part1()
        {
            var result = await Day10.SolvePart1(await ReadInput());
            Assert.Equal(260, result);
        }

        [Theory]
        [InlineData("Day10.Test.Small.Input", 8)]
        [InlineData("Day10.Test.Large1.Input", 33)]
        [InlineData("Day10.Test.Large2.Input", 35)]
        [InlineData("Day10.Test.Large3.Input", 41)]
        [InlineData("Day10.Test.Large4.Input", 210)]
        public async Task ShouldHandleExamplesForPart1(string scenario, int expectedResult)
        {
            var result = await Day10.SolvePart1(await ReadInput(scenario));
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task Part2()
        {
            var result = await Day10.SolvePart2(await ReadInput());
            Assert.Equal(-1, result);
        }

        [Theory]
        [InlineData("Day10.Test.Large4.Input", 802)]
        public async Task ShouldHandleExamplesForPart2(string scenario, int expectedResult)
        {
            var result = await Day10.SolvePart2(await ReadInput(scenario));
            Assert.Equal(expectedResult, result);
        }

        private Task<string> ReadInput(string scenario = "Day10.Input") => File.ReadAllTextAsync(scenario);
    }
}
