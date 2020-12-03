using System;
using System.Linq;

namespace AOC.Solver
{
    public static class Day03
    {
        public static int SolvePart1(string[] input)
        {
            var map = input.Select(line => line.ToCharArray().Select(ch => ch == '#').ToArray()).ToArray();
            return EvaluateSlope(3, 1, map);
        }

        public static int SolvePart2(string[] input)
        {
            var map = input.Select(line => line.ToCharArray().Select(ch => ch == '#').ToArray()).ToArray();
            (int right, int down)[] slopes = new[]
            {
                (1, 1),
                (3, 1),
                (5, 1),
                (7, 1),
                (1, 2),
            };

            return slopes.Select(slope => EvaluateSlope(slope.right, slope.down, map)).Aggregate(1, (a, b) => a * b);
        }

        private static int EvaluateSlope(int right, int down, bool[][] map)
        {
            var trees = 0;
            for (int y = 0, x = 0; y < map.Length; y += down, x = (x + right) % map[0].Length)
                if (map[y][x]) trees++;

            return trees;
        }
    }
}
