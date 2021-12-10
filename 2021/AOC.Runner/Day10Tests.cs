using AOC.Solver;
using System.IO;
using System.Linq;
using Xunit;

namespace AOC.Runner
{
    public class Day10Tests
    {
        private readonly string[] _input;

        public Day10Tests()
        {
            var lines = File.ReadAllLines("./Day10.input");
            _input = lines
                .Where(line => line.Length > 0)
                .ToArray();
        }

        [Fact]
        public void Part1()
        {
            var result = Day10.SolvePart1(_input);
            Assert.Equal(243939, result);
        }

        [Fact]
        public void Part2()
        {
            var result = Day10.SolvePart2(_input);
            Assert.Equal(2421222841, result);
        }

        [Fact]
        public void Part2_WithExampleInput_ReturnsExpectedAnswer()
        {
            var input = new []
            {
                "[({(<(())[]>[[{[]{<()<>>",
                "[(()[<>])]({[<{<<[]>>(",
                "{([(<{}[<>[]}>{[]{[(<()>",
                "(((({<>}<{<{<>}{[]{[]{}",
                "[[<[([]))<([[{}[[()]]]",
                "[{[{({}]{}}([{[{{{}}([]",
                "{<[[]]>}<{[{[{[]{()[[[]",
                "[<(<(<(<{}))><([]([]()",
                "<{([([[(<>()){}]>(<<{{",
                "<{([{{}}[<[[[<>{}]]]>[]]"
            };
            var result = Day10.SolvePart2(input);
            Assert.Equal(288957, result);
        }
    }
}
