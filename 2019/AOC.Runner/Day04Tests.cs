using AOC.Solver;
using Xunit;

namespace AOC.Runner
{
    public class Day04Tests
    {
        [Theory]
        [InlineData(111111, true)]
        [InlineData(223450, false)]
        [InlineData(123789, false)]
        public void ShouldVerify1(int password, bool result)
        {
            Assert.Equal(result, Day04.SatisfiesCriteria1(password));
        }

        [Fact]
        public void Part1()
        {
            var result = Day04.SolvePart1(_input.from, _input.to);
            Assert.Equal(1855, result);
        }

        [Theory]
        [InlineData(112233, true)]
        [InlineData(123444, false)]
        [InlineData(111122, true)]
        public void ShouldVerify2(int password, bool result)
        {
            Assert.Equal(result, Day04.SatisfiesCriteria2(password));
        }

        [Fact]
        public void Part2()
        {
            var result = Day04.SolvePart2(_input.from, _input.to);
            Assert.Equal(1253, result);
        }

        private readonly (int from, int to) _input = (138307, 654504);
    }
}
