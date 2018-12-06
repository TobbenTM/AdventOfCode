using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using AOC.Solver.Utils;

namespace AOC.Solver
{
    public static class Day6
    {
        public static int SolvePart1(int[,] input)
        {
            var vektors = Vektor.Transform(input).ToList();
            var map = new int[vektors.Max(v => v.X)+1, vektors.Max(v => v.Y)+1];

            for (var x = 0; x < map.GetLength(0); x++)
            {
                for (var y = 0; y < map.GetLength(1); y++)
                {
                    // If any vektor occupies this space; skip
                    if (vektors.Any(v => v.X == x && v.Y == y))
                    {
                        map[x, y] = -2;
                        continue;
                    }
                    // Find closest vektor(s)
                    var minDistance = vektors.Min(v => v.Distance(x, y));
                    var closestVektors = vektors.Where(v => v.Distance(x, y) == minDistance).ToList();
                    if (closestVektors.Count == 1)
                    {
                        map[x, y] = closestVektors.First().Index;
                    }
                    else
                    {
                        map[x, y] = -1;
                    }
                }
            }

            // We need to find which vektors are invalid; take all that touches the edges
            var invalidVektorIds = new List<int>();
            for (var x = 0; x < map.GetLength(0); x++)
            {
                var width = map.GetLength(1)-1;
                invalidVektorIds.Add(map[x,0]);
                invalidVektorIds.Add(map[x,width]);
            }
            for (var y = 0; y < map.GetLength(1); y++)
            {
                var height = map.GetLength(0)-1;
                invalidVektorIds.Add(map[0,y]);
                invalidVektorIds.Add(map[height,y]);
            }
            invalidVektorIds = invalidVektorIds.Where(n => n >= 0).Distinct().ToList();

            var sumArea = new Dictionary<int, int>();
            foreach (var point in map)
            {
                if (point >= 0)
                {
                    if (invalidVektorIds.Contains(point)) continue;
                    if (!sumArea.ContainsKey(point))
                    {
                        sumArea.Add(point, 1);
                    }
                    else
                    {
                        sumArea[point] += 1;
                    }
                }
            }

            var biggestArea = sumArea.First(kv => kv.Value == sumArea.Max(v => v.Value));
            var biggestVektor = vektors.First(v => v.Index == biggestArea.Key);

            // Debug printing to image
            CreateVektorImage(map, biggestVektor);

            // (area plus itself)
            return biggestArea.Value + 1;
        }

        public static int SolvePart2(int[,] input)
        {
            var vektors = Vektor.Transform(input).ToList();
            var map = new int[vektors.Max(v => v.X)+1, vektors.Max(v => v.Y)+1];

            for (var x = 0; x < map.GetLength(0); x++)
            {
                for (var y = 0; y < map.GetLength(1); y++)
                {
                    // Find closest vektor(s)
                    var distanceToAll = vektors.Sum(v => v.Distance(x, y));
                    map[x, y] = distanceToAll;
                }
            }

            // Debug printing to image
            CreateDistanceImage(map);
            
            var sumArea = 0;
            foreach (var point in map)
            {
                if (point > 0 && point < 10000)
                {
                    sumArea += 1;
                }
            }

            return sumArea;
        }

        private static void CreateVektorImage(int[,] map, Vektor biggestVektor)
        {
            var image = new Bitmap(map.GetLength(0), map.GetLength(1));
            for (var x = 0; x < map.GetLength(0); x++)
            {
                for (var y = 0; y < map.GetLength(1); y++)
                {
                    var val = map[x, y];
                    Color color;
                    if (val == -2)
                    {
                        color = Color.Black;
                    } 
                    else if (val == -1)
                    {
                        color = Color.White;
                    }
                    else if (val == biggestVektor.Index)
                    {
                        color = Color.Red;
                    }
                    else
                    {
                        color = ColorRGB.FromHSL(val/60d, 1.0, .5);
                    }
                    image.SetPixel(x, y, color);
                }
            }
            image.Save("vektor_map.bmp");
        }

        private static void CreateDistanceImage(int[,] map)
        {
            var image = new Bitmap(map.GetLength(0), map.GetLength(1));
            for (var x = 0; x < map.GetLength(0); x++)
            {
                for (var y = 0; y < map.GetLength(1); y++)
                {
                    var val = map[x, y];
                    Color color;
                    if (val == -2)
                    {
                        color = Color.Black;
                    } 
                    else if (val <= 10000)
                    {
                        color = Color.Green;
                    }
                    else
                    {
                        color = ColorRGB.FromHSL(1.0, 1.0, Math.Clamp(map[x,y]/20000d, 0.0, 1.0));
                    }

                    image.SetPixel(x, y, color);
                }
            }
            image.Save("distance_map.bmp");
        }

        private class Vektor
        {
            public int Index { get; }
            public int X { get; }
            public int Y { get; }

            private Vektor(int index, int x, int y)
            {
                Index = index;
                X = x;
                Y = y;
            }

            public int Distance(Vektor other)
            {
                return Math.Abs(X - other.X) + Math.Abs(Y - other.Y);
            }

            public int Distance(int x, int y)
            {
                return Math.Abs(X - x) + Math.Abs(Y - y);
            }

            public static IEnumerable<Vektor> Transform(int[,] points)
            {
                for (var i = 0; i < points.GetLength(0); i++)
                {
                    yield return new Vektor(i, points[i,0], points[i,1]);
                }
            }
        }
    }
}
