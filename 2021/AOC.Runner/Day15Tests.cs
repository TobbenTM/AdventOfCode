using AOC.Solver;
using System.IO;
using System.Linq;
using Xunit;

namespace AOC.Runner
{
    public class Day15Tests
    {
        private readonly int[][] _input;

        public Day15Tests()
        {
            var lines = File.ReadAllLines("./Day15.input");
            _input = lines
                .Where(line => line.Length > 0)
                .Select(line => line.Select(ch => int.Parse(ch.ToString())).ToArray())
                .ToArray();
        }

        [Fact]
        public void Part1()
        {
            var result = Day15.SolvePart1(_input);
            Assert.Equal(386, result);
        }

        [Fact(Skip = "Still slooooow")]
        public void Part2()
        {
            var result = Day15.SolvePart2(_input);
            Assert.Equal(2806, result);
        }

        [Fact]
        public void Part2_WithExampleInput_ReturnsExpectedAnswer()
        {
            var input = new[]
            {
                new []{ 1, 1, 6, 3, 7, 5, 1, 7, 4, 2 },
                new []{ 1, 3, 8, 1, 3, 7, 3, 6, 7, 2 },
                new []{ 2, 1, 3, 6, 5, 1, 1, 3, 2, 8 },
                new []{ 3, 6, 9, 4, 9, 3, 1, 5, 6, 9 },
                new []{ 7, 4, 6, 3, 4, 1, 7, 1, 1, 1 },
                new []{ 1, 3, 1, 9, 1, 2, 8, 1, 3, 7 },
                new []{ 1, 3, 5, 9, 9, 1, 2, 4, 2, 1 },
                new []{ 3, 1, 2, 5, 4, 2, 1, 6, 3, 9 },
                new []{ 1, 2, 9, 3, 1, 3, 8, 5, 2, 1 },
                new []{ 2, 3, 1, 1, 9, 4, 4, 5, 8, 1 },
            };
            var result = Day15.SolvePart2(input);
            Assert.Equal(315, result);
        }
    }
}
