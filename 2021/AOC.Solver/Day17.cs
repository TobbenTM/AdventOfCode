using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace AOC.Solver
{
    public static class Day17
    {
        public static int SolvePart1(string input)
        {
            var target = Parse(input);

            var highest = 0;
            for (var xv = TriangularNumber(target.x1); xv < target.x2 / 2; xv++)
            {
                for (var yv = target.y1 / 2; yv < 100; yv++)
                {
                    var trajectory = CalculateTrajectory(xv, yv, target).ToArray();
                    var (x, y) = trajectory.Last();
                    if (x < target.x1 || x > target.x2 || y < target.y1 || y > target.y2) continue;
                    var peak = trajectory.Max(xy => xy.y);
                    if (peak > highest)
                    {
                        highest = peak;
                    }
                }
            }

            return highest;
        }

        public static int SolvePart2(string input)
        {
            var target = Parse(input);

            var numberOfHits = 0;
            for (var xv = TriangularNumber(target.x1); xv <= target.x2; xv++)
            {
                for (var yv = target.y1; yv < 100; yv++)
                {
                    var trajectory = CalculateTrajectory(xv, yv, target).ToArray();
                    var (x, y) = trajectory.Last();
                    if (x < target.x1 || x > target.x2 || y < target.y1 || y > target.y2) continue;
                    numberOfHits++;
                }
            }

            return numberOfHits;
        }

        private static int TriangularNumber(int target)
        {
            var (current, total) = (0, 0);
            while (total < target)
            {
                total += ++current;
            }

            return current - 1;
        }

        private static (int x1, int x2, int y1, int y2) Parse(string input)
        {
            var match = new Regex("target area: x=(-?\\d+)..(-?\\d+), y=(-?\\d+)..(-?\\d+)").Match(input);
            var numbers = match.Groups.Values.Skip(1).Select(g => int.Parse(g.Value)).ToArray();
            return (numbers[0], numbers[1], numbers[2], numbers[3]);
        }

        private static IEnumerable<(int x, int y)> CalculateTrajectory(
            int xv,
            int yv,
            (int x1, int x2, int y1, int y2) target)
        {
            (int x, int y) current = (0, 0);
            yield return current;

            while (true)
            {
                current.x += xv;
                current.y += yv;

                if (xv > 0) xv--;
                yv--;

                if (current.x > target.x2
                    || yv < 0 && current.y < target.y1
                    || xv == 0 && current.x < target.x1)
                {
                    yield break;
                }

                yield return current;
            }
        }
    }
}
