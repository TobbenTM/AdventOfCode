using AOC.Solver;
using System;
using System.IO;
using System.Linq;
using Xunit;

namespace AOC.Runner
{
    public class Day03Tests
    {
        private readonly string[] _input;

        public Day03Tests()
        {
            var lines = File.ReadAllLines("./Day03.input");
            _input = lines
                .Where(line => line.Length > 0)
                .ToArray();
        }

        [Fact]
        public void Part1()
        {
            var result = Day03.SolvePart1(_input);
            Assert.Equal(4160394, result);
        }

        [Fact]
        public void Part2()
        {
            var result = Day03.SolvePart2(_input);
            Assert.Equal(4125600, result);
        }

        [Fact]
        public void FindOxygenRating_WithExampleInput_ReturnsRating ()
        {
            var input = new[]
            {
                "00100",
                "11110",
                "10110",
                "10111",
                "10101",
                "01111",
                "00111",
                "11100",
                "10000",
                "11001",
                "00010",
                "01010"
            };
            var result = Day03.FindOxygenRating(input);
            Assert.Equal(23, result);
        }

        [Fact]
        public void FindCo2Rating_WithExampleInput_ReturnsRating()
        {
            var input = new[]
            {
                "00100",
                "11110",
                "10110",
                "10111",
                "10101",
                "01111",
                "00111",
                "11100",
                "10000",
                "11001",
                "00010",
                "01010"
            };
            var result = Day03.FindCo2Rating(input);
            Assert.Equal(10, result);
        }
    }
}
