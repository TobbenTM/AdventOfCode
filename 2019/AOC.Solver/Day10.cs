using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AOC.Solver
{
    public static class Day10
    {
        public class RemoteAsteroid
        {
            public int X { get; set; }

            public int Y { get; set; }

            public int Distance { get; set; }

            public double Angle { get; set; }

            public int OtherAsteroidsInView { get; set; }

            public void CalculateAngleAndDistance(RemoteAsteroid other)
            {
                var diffX = other.X - X;
                var diffY = other.Y - Y;
                Distance = Math.Abs(diffX) + Math.Abs(diffY);
                Angle = ((Math.Atan2(diffY, -diffX) * (180d / Math.PI)) + 360) % 360;
            }
        }

        public static async Task<int> SolvePart1(string input)
        {
            var map = ReadMap(input);
            var asteroids = await EvaluateMap(map);

            return asteroids.Select(a => a.OtherAsteroidsInView).Max();
        }

        public static async Task<int> SolvePart2(string input)
        {
            var map = ReadMap(input);
            var asteroids = await EvaluateMap(map);
            var station = asteroids.OrderByDescending(a => a.OtherAsteroidsInView).First();
            asteroids.Remove(station);

            foreach (var asteroid in asteroids)
            {
                asteroid.CalculateAngleAndDistance(station);
            }

            asteroids = asteroids.OrderByDescending(a => a.Angle).ThenBy(a => a.Distance).ToList();

            var currentAngle = 91d;
            for (var i = 0; i < 200 - 1; i++)
            {
                var next = asteroids.FirstOrDefault(a => a.Angle < currentAngle);
                if (next == null)
                {
                    i -= 1;
                    currentAngle = 361;
                    continue;
                }
                asteroids.Remove(next);
                currentAngle = next.Angle;
            }

            var finalAsteroid = asteroids.First(a => a.Angle < currentAngle);
            return finalAsteroid.X * 100 + finalAsteroid.Y;
        }

        private static async Task<List<RemoteAsteroid>> EvaluateMap(char[][] map)
        {
            var tasks = new List<Task<RemoteAsteroid>>();

            for (var y = 0; y < map.Length; y++)
            {
                for (var x = 0; x < map[0].Length; x++)
                {
                    if (map[y][x] == '.') continue;

                    var xt = x;
                    var yt = y;

                    tasks.Add(Task.Factory.StartNew(() => EvaluateAsteroid(map, xt, yt)));
                }
            }

            var result = await Task.WhenAll(tasks.ToArray());
            return result.ToList();
        }

        private static RemoteAsteroid EvaluateAsteroid(char[][] map, int x, int y)
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

            return new RemoteAsteroid
            {
                X = x,
                Y = y,
                OtherAsteroidsInView = result,
            };
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
