using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace AOC.Solver
{
    public static class Day3
    {
        public static int SolvePart1(string[] input)
        {
            var map = new int[1000, 1000];
            foreach (var claim in input.Select(EvaluateClaim))
            {
                for (var x = claim.X; x < claim.Right; x++)
                {
                    for (var y = claim.Y; y < claim.Bottom; y++)
                    {
                        map[x, y] += 1;
                    }
                }
            }

            var overlaps = 0;
            foreach (var n in map)
            {
                if (n > 1)
                {
                    overlaps += 1;
                }
            }
            return overlaps;
        }

        public static int SolvePart2(string[] input)
        {
            var claims = input.Select(EvaluateClaim).ToArray();
            foreach (var candidate in claims)
            {
                var hasOverlap = false;

                foreach (var match in claims)
                {
                    if (candidate.ID == match.ID) continue;
                    if (candidate.Intersects(match))
                    {
                        hasOverlap = true;
                        break;
                    };
                }

                if (!hasOverlap)
                {
                    return candidate.ID;
                }
            }
            throw new Exception("Could not find any claims that did not overlap!");
        }

        private static Claim EvaluateClaim(string claim)
        {
            var rx = new Regex("#(\\d+) @ (\\d+),(\\d+): (\\d+)x(\\d+)");
            var match = rx.Match(claim);
            if (!match.Success) throw new ArgumentException($"Could not parse claim '{claim}'!");
            if (match.Groups.Count != 6) throw new ArgumentException($"Could not parse claim '{claim}'!");
            return new Claim {
                ID = int.Parse(match.Groups[1].Value),
                X = int.Parse(match.Groups[2].Value),
                Y = int.Parse(match.Groups[3].Value),
                W = int.Parse(match.Groups[4].Value),
                H = int.Parse(match.Groups[5].Value)
            };
        }

        public struct Claim
        {
            public int ID { get; set; }
            public int X { get; set; }
            public int Y { get; set; }
            public int W { private get; set; }
            public int H { private get; set; }

            public int Right => X + W;
            public int Bottom => Y + H;

            public bool Intersects(Claim other)
            {
                return X < other.Right &&
                       Right > other.X &&
                       Y < other.Bottom &&
                       Bottom > other.Y;
            }
        }
    }
}
