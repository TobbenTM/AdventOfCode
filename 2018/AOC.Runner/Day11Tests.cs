using System;
using System.Threading.Tasks;
using AOC.Solver;
using Xunit;
using static AOC.Solver.Day11;
using static AOC.Solver.Day9;

namespace AOC.Runner
{
    public class Day11Tests
    {

        private const int Input = 4455;

        [Fact]
        public void Part1()
        {
            var grid = new PowerGrid(300, 300, Input);
            var best = grid.EvaluateBestLocation();
            Assert.Equal((21, 54), best);
        }

        [Fact]
        public async Task Part2()
        {
            var grid = new PowerGrid(300, 300, Input);
            var best = await grid.EvaluateBestDynamicLocation();
            Assert.Equal((0, 0, 0), best);
        }

        [Theory]
        [InlineData(300, 300, 18, 90, 269, 16)]
        [InlineData(300, 300, 42, 232, 251, 12)]
        public async Task PowerGridShouldEvaluateBestDynamicLocation(
            int width, int height, int serialNumber, int expectedX, int expectedY, int expectedDimension)
        {
            var grid = new PowerGrid(width, height, serialNumber);
            var best = await grid.EvaluateBestDynamicLocation();
            Assert.Equal((expectedX, expectedY, expectedDimension), best);
        }

        [Theory]
        [InlineData(3, 5, 8, 4)]
        [InlineData(122, 79, 57, -5)]
        [InlineData(217, 196, 39, 0)]
        [InlineData(101, 153, 71, 4)]
        public void PowerCellShouldCalculateLevel(int x, int y, int serialNumber, int expectedResult)
        {
            var cell = new PowerCell(x, y, serialNumber);
            Assert.Equal(expectedResult, cell.PowerLevel);
        }
    }
}
