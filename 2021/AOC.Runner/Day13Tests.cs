using AOC.Solver;
using System.IO;
using System.Linq;
using Xunit;

namespace AOC.Runner
{
    public class Day13Tests
    {
        private readonly string[] _input;

        public Day13Tests()
        {
            var lines = File.ReadAllLines("./Day13.input");
            _input = lines
                .Where(line => line.Length > 0)
                .ToArray();
        }

        [Fact]
        public void Part1()
        {
            var result = Day13.SolvePart1(_input);
            Assert.Equal(751, result);
        }

        [Fact]
        public void Part2()
        {
            var result = Day13.SolvePart2(_input);
            Assert.NotEmpty(result);
        }

        [Fact]
        public void Part2_WithExampleInput_ReturnsExpectedOutput()
        {
            var input = new[]
            {
                "6,10",
                "0,14",
                "9,10",
                "0,3",
                "10,4",
                "4,11",
                "6,0",
                "6,12",
                "4,1",
                "0,13",
                "10,12",
                "3,4",
                "3,0",
                "8,4",
                "1,10",
                "2,14",
                "8,10",
                "9,0",
                "fold along y=7",
                "fold along x=5"
            };
            var result = Day13.SolvePart2(input);
            Assert.Equal("#####\n#...#\n#...#\n#...#\n#####\n", result);
        }
    }
}
