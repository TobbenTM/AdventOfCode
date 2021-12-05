using System;
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
                .Aggregate(new Dictionary<(int x, int y), int>(), (agg, cur) =>
                {
                    if (agg.ContainsKey(cur))
                    {
                        agg[cur]++;
                    }
                    else
                    {
                        agg.Add(cur, 1);
                    }

                    return agg;
                })
                .Count(kv => kv.Value > 1);
        }

        public static int SolvePart2(string[] input)
        {
            return input
                .Select(line => new Line(line))
                .SelectMany(line => line.TouchesCells)
                .Aggregate(new Dictionary<(int x, int y), int>(), (agg, cur) =>
                {
                    if (agg.ContainsKey(cur))
                    {
                        agg[cur]++;
                    }
                    else
                    {
                        agg.Add(cur, 1);
                    }

                    return agg;
                })
                .Count(kv => kv.Value > 1);
        }

        private class Line
        {
            public (int x, int y) From { get; }
            public (int x, int y) To { get; }

            public bool IsStraightLine => From.x == To.x || From.y == To.y;

            public IEnumerable<(int x, int y)> TouchesCells
            {
                get
                {
                    var current = (x: From.x, y: From.y);
                    yield return current;

                    while (current != To)
                    {
                        if (current.x != To.x)
                        {
                            current.x += current.x < To.x ? 1 : -1;
                        }

                        if (current.y != To.y)
                        {
                            current.y += current.y < To.y ? 1 : -1;
                        }

                        yield return current;
                    }
                }
            }

            public Line(string input)
            {
                var match = new Regex("(\\d+),(\\d+) -> (\\d+),(\\d+)").Match(input);
                From = (x: int.Parse(match.Groups[1].Value), y: int.Parse(match.Groups[2].Value));
                To = (x: int.Parse(match.Groups[3].Value), y: int.Parse(match.Groups[4].Value));
            }
        }
    }
}
