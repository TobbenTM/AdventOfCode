using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace AOC.Solver
{
    public static class Day05
    {
        public static int SolvePart1(string[] input)
        {
            return input
                .Select(line => new Line(line))
                .Where(line => line.IsStraightLine)
                .SelectMany(line => line.TouchesCells)
                .GroupBy(point => point)
                .Count(group => group.Count() > 1);
        }

        public static int SolvePart2(string[] input)
        {
            return input
                .Select(line => new Line(line))
                .SelectMany(line => line.TouchesCells)
                .GroupBy(point => point)
                .Count(group => group.Count() > 1);
        }

        private class Line
        {
            private readonly (int x, int y) _from;
            private readonly (int x, int y) _to;

            public bool IsStraightLine => _from.x == _to.x || _from.y == _to.y;

            public IEnumerable<(int x, int y)> TouchesCells
            {
                get
                {
                    var current = (x: _from.x, y: _from.y);
                    yield return current;

                    while (current != _to)
                    {
                        if (current.x != _to.x)
                        {
                            current.x += current.x < _to.x ? 1 : -1;
                        }

                        if (current.y != _to.y)
                        {
                            current.y += current.y < _to.y ? 1 : -1;
                        }

                        yield return current;
                    }
                }
            }

            public Line(string input)
            {
                var match = new Regex("(\\d+),(\\d+) -> (\\d+),(\\d+)").Match(input);
                _from = (x: int.Parse(match.Groups[1].Value), y: int.Parse(match.Groups[2].Value));
                _to = (x: int.Parse(match.Groups[3].Value), y: int.Parse(match.Groups[4].Value));
            }
        }
    }
}
