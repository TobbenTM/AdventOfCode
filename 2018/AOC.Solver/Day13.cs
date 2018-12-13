using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AOC.Solver
{
    public static class Day13
    {
        private enum CartDirection
        {
            UP = '^',
            DOWN = 'v',
            LEFT = '<',
            RIGHT = '>',
        }

        public class MineCart
        {
            public int X { get; set; }
            public int Y { get; set; }

            private CartDirection _currentDirection;
            private int _intersections = 0;
            private int _moves = 0;

            public MineCart(char cart, int x, int y)
            {
                X = x;
                Y = y;
                _currentDirection = (CartDirection)cart;
            }

            public void Move(char[,] tracks)
            {
                var track = tracks[X, Y];
                if (track == '|')
                {
                    if (_currentDirection == CartDirection.UP)
                    {
                        Y -= 1;
                    }
                    else if (_currentDirection == CartDirection.DOWN)
                    {
                        Y += 1;
                    }
                    else
                    {
                        throw new ArgumentOutOfRangeException();
                    }
                }
                else if (track == '-')
                {
                    if (_currentDirection == CartDirection.LEFT)
                    {
                        X -= 1;
                    }
                    else if (_currentDirection == CartDirection.RIGHT)
                    {
                        X += 1;
                    }
                    else
                    {
                        throw new ArgumentOutOfRangeException();
                    }
                }
                else if (track == '\\')
                {
                    if (_currentDirection == CartDirection.UP)
                    {
                        X -= 1;
                        _currentDirection = CartDirection.LEFT;
                    }
                    else if (_currentDirection == CartDirection.RIGHT)
                    {
                        Y += 1;
                        _currentDirection = CartDirection.DOWN;
                    }
                    else if (_currentDirection == CartDirection.LEFT)
                    {
                        Y -= 1;
                        _currentDirection = CartDirection.UP;
                    }
                    else if (_currentDirection == CartDirection.DOWN)
                    {
                        X += 1;
                        _currentDirection = CartDirection.RIGHT;
                    }
                }
                else if (track == '/')
                {
                    if (_currentDirection == CartDirection.UP)
                    {
                        X += 1;
                        _currentDirection = CartDirection.RIGHT;
                    }
                    else if (_currentDirection == CartDirection.RIGHT)
                    {
                        Y -= 1;
                        _currentDirection = CartDirection.UP;
                    }
                    else if (_currentDirection == CartDirection.LEFT)
                    {
                        Y += 1;
                        _currentDirection = CartDirection.DOWN;
                    }
                    else if (_currentDirection == CartDirection.DOWN)
                    {
                        X -= 1;
                        _currentDirection = CartDirection.LEFT;
                    }
                }
                else if (track == '+')
                {
                    if (_intersections % 3 == 0)
                    {
                        // Left
                        if (_currentDirection == CartDirection.UP)
                        {
                            _currentDirection = CartDirection.LEFT;
                            X -= 1;
                        }
                        else if (_currentDirection == CartDirection.DOWN)
                        {
                            _currentDirection = CartDirection.RIGHT;
                            X += 1;
                        }
                        else if (_currentDirection == CartDirection.LEFT)
                        {
                            _currentDirection = CartDirection.DOWN;
                            Y += 1;
                        }
                        else if (_currentDirection == CartDirection.RIGHT)
                        {
                            _currentDirection = CartDirection.UP;
                            Y -= 1;
                        }
                    }
                    else if (_intersections % 3 == 1)
                    {
                        // Straight
                        if (_currentDirection == CartDirection.UP)
                        {
                            Y -= 1;
                        }
                        else if (_currentDirection == CartDirection.DOWN)
                        {
                            Y += 1;
                        }
                        else if (_currentDirection == CartDirection.LEFT)
                        {
                            X -= 1;
                        }
                        else if (_currentDirection == CartDirection.RIGHT)
                        {
                            X += 1;
                        }
                    }
                    else if (_intersections % 3 == 2)
                    {
                        // Right
                        if (_currentDirection == CartDirection.UP)
                        {
                            _currentDirection = CartDirection.RIGHT;
                            X += 1;
                        }
                        else if (_currentDirection == CartDirection.DOWN)
                        {
                            _currentDirection = CartDirection.LEFT;
                            X -= 1;
                        }
                        else if (_currentDirection == CartDirection.LEFT)
                        {
                            _currentDirection = CartDirection.UP;
                            Y -= 1;
                        }
                        else if (_currentDirection == CartDirection.RIGHT)
                        {
                            _currentDirection = CartDirection.DOWN;
                            Y += 1;
                        }
                    }
                    _intersections += 1;
                }
                else
                {
                    throw new ArgumentOutOfRangeException();
                }

                _moves += 1;
            }

            public char ToTrack()
            {
                switch (_currentDirection)
                {
                    case CartDirection.UP:
                    case CartDirection.DOWN:
                        return '|';
                    case CartDirection.LEFT:
                    case CartDirection.RIGHT:
                        return '-';
                    default: throw new ArgumentOutOfRangeException();
                }
            }
        }

        public class MineTracks
        {
            private readonly char[] _cartTypes = new []{ '^', '<', '>', 'v' };
            private readonly List<MineCart> _carts = new List<MineCart>();
            private readonly int _width;
            private readonly int _height;
            private char[,] _tracks;

            public MineTracks(string[] input)
            {
                var parsedInput = input.Select(l => l.ToCharArray()).ToArray();
                _width = parsedInput[0].Length;
                _height = parsedInput.Length;
                _tracks = new char[_width, _height];
                for (var y = 0; y < _height; y++)
                {
                    for (var x = 0; x < _width; x++)
                    {
                        var entity = parsedInput[y][x];
                        if (_cartTypes.Contains(entity))
                        {
                            var cart = new MineCart(entity, x, y);
                            entity = cart.ToTrack();
                            _carts.Add(cart);
                        }
                        _tracks[x, y] = entity;
                    }
                }
            }

            public (int x, int y) MoveAllCartsTillCollision()
            {
                while (true)
                {
                    var orderedCarts = _carts.OrderBy(c => c.Y).ThenBy(c => c.X).ToList();
                    foreach (var cart in orderedCarts)
                    {
                        cart.Move(_tracks);
                        if (_carts.Any(c => c != cart && c.X == cart.X && c.Y == cart.Y))
                        {
                            return (cart.X, cart.Y);
                        }
                    }
                }
            }

            public (int x, int y) MoveAllCartsTillOneLeft()
            {
                while (_carts.Count > 1)
                {
                    var orderedCarts = _carts.OrderBy(c => c.Y).ThenBy(c => c.X).ToList();
                    foreach (var cart in orderedCarts)
                    {
                        cart.Move(_tracks);
                        var collidingCart = _carts.FirstOrDefault(c => c != cart && c.X == cart.X && c.Y == cart.Y);
                        if (collidingCart != null)
                        {
                            _carts.Remove(cart);
                            _carts.Remove(collidingCart);
                        }
                    }
                }
                return (_carts[0].X, _carts[0].Y);
            }
        }
    }
}
