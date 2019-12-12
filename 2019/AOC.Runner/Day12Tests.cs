using AOC.Solver;
using Xunit;

namespace AOC.Runner
{
    public class Day12Tests
    {
        [Fact]
        public void Part1()
        {
            var result = Day12.SolvePart1(_input, 1000);
            Assert.Equal(6423, result);
        }

        [Fact]
        public void ShouldCalculateExample1ForPart1()
        {
            var input = new[]
            {
                "<x=-1, y=0, z=2>",
                "<x=2, y=-10, z=-7>",
                "<x=4, y=-8, z=8>",
                "<x=3, y=5, z=-1>",
            };
            var result = Day12.SolvePart1(input, 10);
            Assert.Equal(179, result);
        }

        [Fact]
        public void ShouldCalculateExample2()
        {
            var input = new[]
            {
                "<x=-8, y=-10, z=0>",
                "<x=5, y=5, z=10>",
                "<x=2, y=-7, z=3>",
                "<x=9, y=-8, z=-3>",
            };
            var result = Day12.SolvePart1(input, 100);
            Assert.Equal(1940, result);
        }

        [Fact]
        public void Part2()
        {
            var result = Day12.SolvePart2(_input);
            Assert.Equal(-1, result);
        }

        [Fact]
        public void ShouldCalculateExample1ForPart2()
        {
            var input = new[]
            {
                "<x=-1, y=0, z=2>",
                "<x=2, y=-10, z=-7>",
                "<x=4, y=-8, z=8>",
                "<x=3, y=5, z=-1>",
            };
            var result = Day12.SolvePart2(input);
            Assert.Equal(2772, result);
        }

        private readonly string[] _input =
        {
            "<x=14, y=4, z=5>",
            "<x=12, y=10, z=8>",
            "<x=1, y=7, z=-10>",
            "<x=16, y=-5, z=3>",
        };
    }
}
