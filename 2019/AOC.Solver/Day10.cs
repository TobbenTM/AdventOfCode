using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AOC.Solver
{
    public static class Day10
    {
        public static async Task<int> SolvePart1(string input)
        {
            var map = ReadMap(input);
            var tasks = new List<Task<(int numberOfAsteroids, int x, int y)>>();

            for (var y = 0; y < map.Length; y++)
            {
                for (var x = 0; x < map[0].Length; x++)
                {
                    if (map[y][x] == '.') continue;

                    var xt = x;
                    var yt = y;

                    tasks.Add(Task.Factory.StartNew(() => FindNumberOfAsteroidsInView(map, xt, yt)));
                }
            }

            var results = await Task.WhenAll(tasks.ToArray());

            return results.Select(x => x.numberOfAsteroids).Max();
        }

        private static (int numberOfAsteroids, int x, int y) FindNumberOfAsteroidsInView(char[][] map, int x, int y)
        {
            var result = 0;

            for (var yi = 0; yi < map.Length; yi++)
            {
                for (var xi = 0; xi < map[0].Length; xi++)
                {
                    if (xi == x && yi == y || map[yi][xi] == '.') continue;

                    if (HasLineOfSight(map, x, y, xi, yi))
                    {
                        result += 1;
                    }
                }
            }

            return (result, x, y);
        }

        public static int SolvePart2(string input)
        {
            var map = ReadMap(input);
            throw new NotImplementedException("Part 2 not implemented yet!");
        }

        private static bool HasLineOfSight(char[][] map, int x1, int y1, int x2, int y2)
        {
            var diffX = x2 - x1;
            var diffY = y2 - y1;
            var steps = Math.Max(Math.Abs(diffX), 1) * Math.Max(Math.Abs(diffY), 1);

            for (var step = 1; step < steps; step++)
            {
                var currentX = x1 + (diffX * step / (decimal)steps);
                var currentY = y1 + (diffY * step / (decimal)steps);
                if (currentX % 1 == 0 && currentY % 1 == 0 && map[(int)currentY][(int)currentX] == '#')
                {
                    return false;
                }
            }

            return true;
        }

        private static char[][] ReadMap(string input)
        {
            return input.Split('\n').Where(line => line.Length > 0).Select(line => line.Trim().ToCharArray()).ToArray();
        }
    }
}
