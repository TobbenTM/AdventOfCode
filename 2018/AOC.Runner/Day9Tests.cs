using System;
using AOC.Solver;
using Xunit;
using static AOC.Solver.Day9;

namespace AOC.Runner
{
    public class Day9Tests
    {
        [Fact]
        public void Part1()
        {
            var result = Day9.SolvePart1(_players, _lastMarble);
            Assert.Equal(404611, result);
        }

        [Fact]
        public void Part2()
        {
            var result = Day9.SolvePart1(_players, _lastMarble * 100);
            Assert.Equal(0, result);
        }

        [Theory]
        [InlineData(10, 1618, 8317)]
        [InlineData(13, 7999, 146373)]
        [InlineData(17, 1104, 2764)]
        [InlineData(21, 6111, 54718)]
        [InlineData(30, 5807, 37305)]
        public void GameShouldPlay(int players, int lastMarble, int expectedScore)
        {
            var game = new MarbleGame(players, lastMarble);
            game.Play();
            Assert.Equal(expectedScore, game.LeadingPlayer.score);
        }
        
        private const int _players = 431;
        private const int _lastMarble = 70950;
    }
}
