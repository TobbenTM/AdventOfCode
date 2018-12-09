using System;
using AOC.Solver;
using Xunit;
using static AOC.Solver.Day9;

namespace AOC.Runner
{
    public class Day9Tests
    {
        private const int _players = 431;
        private const int _lastMarble = 70950;

        [Fact]
        public void Part1()
        {
            var game = new MarbleGame(_players, _lastMarble);
            game.Play();
            Assert.Equal((ulong)404611, game.LeadingPlayer.score);
        }

        [Fact]
        public void Part2()
        {
            var game = new MarbleGame(_players, _lastMarble * 100);
            game.Play();
            Assert.Equal((ulong)3350093681, game.LeadingPlayer.score);
        }

        [Theory]
        [InlineData(10, 1618, 8317)]
        [InlineData(13, 7999, 146373)]
        [InlineData(17, 1104, 2764)]
        [InlineData(21, 6111, 54718)]
        [InlineData(30, 5807, 37305)]
        public void GameShouldPlay(int players, int lastMarble, ulong expectedScore)
        {
            var game = new MarbleGame(players, lastMarble);
            game.Play();
            Assert.Equal(expectedScore, game.LeadingPlayer.score);
        }
    }
}
