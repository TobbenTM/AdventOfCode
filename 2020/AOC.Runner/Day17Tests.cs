using AOC.Solver;
using Xunit;

namespace AOC.Runner
{
    public class Day17Tests
    {
        [Fact]
        public void Part1()
        {
            var result = Day17.SolvePart1(_input);
            Assert.True(result > 332 && result < 340, $"{result} is out of bounds");
            Assert.Equal(336, result);
        }

        [Fact]
        public void Part1_WithExampleInput_RunsSimulation()
        {
            var input = new[]
            {
                ".#.",
                "..#",
                "###",
            };
            var result = Day17.SolvePart1(input);
            Assert.Equal(112, result);
        }

        [Fact(Skip = "Kinda slow (~3s)")]
        public void Part2()
        {
            var result = Day17.SolvePart2(_input);
            Assert.Equal(2620, result);
        }

        [Fact(Skip = "Kinda slow (~1s)")]
        public void Part2_WithExampleInput_RunsSimulation()
        {
            var input = new[]
            {
                ".#.",
                "..#",
                "###",
            };
            var result = Day17.SolvePart2(input);
            Assert.Equal(848, result);
        }

        private readonly string[] _input =
        {
            "#####..#",
            "#..###.#",
            "###.....",
            ".#.#.#..",
            "##.#..#.",
            "######..",
            ".##..###",
            "###.####",
        };
    }
}
