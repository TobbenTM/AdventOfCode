using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;

namespace AOC.Solver
{
    public static class Day9
    {
        public static int SolvePart1(int players, int lastMarble)
        {
            var game = new MarbleGame(players, lastMarble);
            game.Play();
            var winner = game.LeadingPlayer;
            return winner.score;
        }

        public static int SolvePart2(int players, int lastMarble)
        {
            throw new NotImplementedException();
        }

        public class MarbleGame
        {
            private readonly int _lastMarbleScore;
            private readonly List<int> _marbles;
            private readonly int[] _players;
            private int _currentMarbleScore = 0;
            private int _currentMarblePosition = 0;
            private int _currentPlayer = 0;

            public MarbleGame(int numberOfPlayers, int lastMarbleScore)
            {
                _lastMarbleScore = lastMarbleScore;
                _marbles = new List<int>(lastMarbleScore + 1){ 0 };
                _players = new int[numberOfPlayers];
            }

            public (int player, int score) LeadingPlayer => (Array.IndexOf(_players, _players.Max()), _players.Max());

            public void Play()
            {
                while (PlayOne()) {}
            }

            private bool PlayOne()
            {
                _currentMarbleScore += 1;
                if (_currentMarbleScore % 1000 == 0)
                {
                    Debug.WriteLine($"Reached marble score {_currentMarbleScore}!");
                }

                if (_currentMarbleScore % 23 == 0)
                {
                    _players[_currentPlayer] += _currentMarbleScore;
                    _currentMarblePosition -= 7;
                    if (_currentMarblePosition < 0)
                    {
                        _currentMarblePosition += _marbles.Count;
                    }
                    _players[_currentPlayer] += _marbles[_currentMarblePosition];
                    _marbles.RemoveAt(_currentMarblePosition);
                }
                else
                {
                    int nextPosition;
                    if (_marbles.Count == 1)
                    {
                        nextPosition = 1;
                    }
                    else
                    {
                        nextPosition = (_currentMarblePosition + 2) % _marbles.Count;
                    }

                    if (nextPosition == 0)
                    {
                        _marbles.Add(_currentMarbleScore);
                        _currentMarblePosition = _marbles.Count - 1;
                    }
                    else
                    {
                        _marbles.Insert(nextPosition, _currentMarbleScore);
                        _currentMarblePosition = nextPosition;
                    }
                }
                
                _currentPlayer = (_currentPlayer + 1) % _players.Length;

                if (_currentMarbleScore == _lastMarbleScore) return false;
                return true;
            }
        }
    }
}
