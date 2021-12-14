using AOC.Solver;
using System.IO;
using System.Linq;
using Xunit;

namespace AOC.Runner
{
    public class Day14Tests
    {
        private readonly string[] _input;

        public Day14Tests()
        {
            var lines = File.ReadAllLines("./Day14.input");
            _input = lines
                .Where(line => line.Length > 0)
                .ToArray();
        }

        [Fact]
        public void Part1()
        {
            var result = Day14.SolvePart1(_input);
            Assert.Equal(3284, result);
        }

        [Fact]
        public void Part1_WithExampleInput_ReturnsExpectedAnswer()
        {
            var input = new[]
            {
                "NNCB",
                "CH -> B",
                "HH -> N",
                "CB -> H",
                "NH -> C",
                "HB -> C",
                "HC -> B",
                "HN -> C",
                "NN -> C",
                "BH -> H",
                "NC -> B",
                "NB -> B",
                "BN -> B",
                "BB -> N",
                "BC -> B",
                "CC -> N",
                "CN -> C",
            };
            var result = Day14.SolvePart1(input);
            Assert.Equal(1588, result);
        }

        [Fact]
        public void Part2()
        {
            var result = Day14.SolvePart2(_input);
            Assert.Equal(4302675529689, result);
        }
    }
}
