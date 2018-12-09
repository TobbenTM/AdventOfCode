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
        public class MarbleGame
        {
            private readonly int _lastMarbleScore;
            private readonly LinkedList<int> _marbles;
            private readonly ulong[] _players;
            private int _currentMarbleScore = 0;
            private int _currentPlayer = 0;
            private LinkedListNode<int> _currentMarble;

            public MarbleGame(int numberOfPlayers, int lastMarbleScore)
            {
                _lastMarbleScore = lastMarbleScore;
                _marbles = new LinkedList<int>(new []{ 0 });
                _currentMarble = _marbles.First;
                _players = new ulong[numberOfPlayers];
            }

            public (int player, ulong score) LeadingPlayer => (Array.IndexOf(_players, _players.Max()), _players.Max());

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
                    _players[_currentPlayer] += (ulong)_currentMarbleScore;
                    for (var i = 0; i < 7; i++)
                    {
                        if (_currentMarble.Previous == null)
                        {
                            _currentMarble = _marbles.Last;
                        }
                        else
                        {
                            _currentMarble = _currentMarble.Previous;
                        }
                    }
                    var deletedMarble = _currentMarble;
                    _currentMarble = deletedMarble.Next;
                    _players[_currentPlayer] += (ulong)deletedMarble.Value;
                    _marbles.Remove(deletedMarble);
                }
                else
                {
                    if (_currentMarble.Next == null)
                    {
                        _currentMarble = _marbles.First;
                    }
                    else
                    {
                        _currentMarble = _currentMarble.Next;
                    }

                    _currentMarble = _marbles.AddAfter(_currentMarble, _currentMarbleScore);
                }
                
                _currentPlayer = (_currentPlayer + 1) % _players.Length;

                if (_currentMarbleScore == _lastMarbleScore) return false;
                return true;
            }
        }
    }
}
