using AOC.Solver;
using System.IO;
using System.Linq;
using Xunit;

namespace AOC.Runner
{
    public class Day04Tests
    {
        private readonly string[] _input;

        public Day04Tests()
        {
            var lines = File.ReadAllLines("./Day04.input");
            _input = lines
                .ToArray();
        }

        [Fact]
        public void Part1()
        {
            var result = Day04.SolvePart1(_input);
            Assert.Equal(89001, result);
        }

        [Fact]
        public void Part2()
        {
            var result = Day04.SolvePart2(_input);
            Assert.Equal(7296, result);
        }

        [Fact]
        public void Part1_WithExampleInput_ReturnsCorrectAnswer()
        {
            var input = new[]
            {
                "7,4,9,5,11,17,23,2,0,14,21,24,10,16,13,6,15,25,12,22,18,20,8,19,3,26,1",
                "",
                "22 13 17 11  0",
                " 8  2 23  4 24",
                "21  9 14 16  7",
                " 6 10  3 18  5",
                " 1 12 20 15 19",
                "",
                " 3 15  0  2 22",
                " 9 18 13 17  5",
                "19  8  7 25 23",
                "20 11 10 24  4",
                "14 21 16 12  6",
                "",
                "14 21 17 24  4",
                "10 16 15  9 19",
                "18  8 23 26 20",
                "22 11 13  6  5",
                " 2  0 12  3  7",
                ""
            };
            var result = Day04.SolvePart1(input);
            Assert.Equal(4512, result);
        }
    }
}
