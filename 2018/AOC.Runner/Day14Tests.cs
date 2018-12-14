using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AOC.Solver;
using Xunit;
using Xunit.Abstractions;
using static AOC.Solver.Day14;

namespace AOC.Runner
{
    public class Day14Tests
    {
        private const int Input = 147061;

        [Fact]
        public void Part1()
        {
            var brewery = new KakaoBrewery(Input);
            var next10 = brewery.EvaluateNextTen();
            Assert.Equal("2145581131", string.Join("", next10));
        }

        [Fact]
        public void Part2()
        {
            var brewery = new KakaoBrewery();
            var firstOccurence = brewery.EvaluateUntilMatch(Input.ToString());
            Assert.True(firstOccurence < 26402229, ">= 26402229 is too high");
            Assert.Equal(20283721, firstOccurence);
        }

        [Theory]
        [InlineData(9, "5158916779")]
        [InlineData(5, "0124515891")]
        [InlineData(18, "9251071085")]
        [InlineData(2018, "5941429882")]
        public void BreweryShouldEvaluateNextTen(int targetIterations, string expectedAnswer)
        {
            var brewery = new KakaoBrewery(targetIterations);
            var next10 = brewery.EvaluateNextTen();
            Assert.Equal(expectedAnswer, string.Join("", next10));
        }

        [Theory]
        [InlineData("51589", 9)]
        [InlineData("01245", 5)]
        [InlineData("92510", 18)]
        [InlineData("59414", 2018)]
        public void BreweryShouldEvaluateUntilMatch(string target, int expectedFirstOccurence)
        {
            var brewery = new KakaoBrewery();
            var firstOccurence = brewery.EvaluateUntilMatch(target);
            Assert.Equal(expectedFirstOccurence, firstOccurence);
        }
    }
}
