using System;
using System.Collections.Generic;
using System.Linq;

namespace AOC.Solver
{
    public static class Day17
    {
        public static int SolvePart1(string[] input)
        {
            int ymin = 0,
                ymax = input.Length - 1,
                xmin = 0,
                xmax = input[0].Length - 1,
                zmin = 0,
                zmax = 0;
            var map = new HashSet<(int y, int x, int z)>(input
                .SelectMany((line, y) => line
                    .ToCharArray()
                    .Select((c, i) => (c, i))
                    .Where(x => x.c == '#')
                    .Select(x => (y, x.i, 0))));

            for (var i = 0; i < 6; i++)
            {
                var copy = new HashSet<(int y, int x, int z)>(map);
                for (var y = ymin - 1; y <= ymax + 1; y++)
                {
                    for (var x = xmin - 1; x <= xmax + 1; x++)
                    {
                        for (var z = zmin - 1; z <= zmax + 1; z++)
                        {
                            var neighbours = NumberOfNeighbors3D(map, y, x, z);
                            var isActive = map.Contains((y, x, z));
                            if (isActive && (neighbours < 2 || neighbours > 3))
                            {
                                copy.Remove((y, x, z));
                            }
                            else if (!isActive && neighbours == 3)
                            {
                                ymin = Math.Min(ymin, y);
                                xmin = Math.Min(xmin, x);
                                zmin = Math.Min(zmin, z);
                                ymax = Math.Max(ymax, y);
                                xmax = Math.Max(xmax, x);
                                zmax = Math.Max(zmax, z);
                                copy.Add((y, x, z));
                            }
                        }
                    }
                }
                map = copy;
            }

            return map.Count;
        }

        private static int NumberOfNeighbors3D(HashSet<(int y, int x, int z)> map, int y, int x, int z)
        {
            var count = 0;
            for (var i = 0; i < Math.Pow(3, 3); i++)
            {
                var ty = y + i % 3 - 1;
                var tx = x + (i / 3) % 3 - 1;
                var tz = z + (i / 9) % 3 - 1;
                if (ty == y && tx == x && tz == z) continue;
                if (map.Contains((ty, tx, tz))) count += 1;
                if (count > 3) return count;
            }
            return count;
        }

        public static int SolvePart2(string[] input)
        {
            int ymin = 0,
                ymax = input.Length - 1,
                xmin = 0,
                xmax = input[0].Length - 1,
                zmin = 0,
                zmax = 0,
                wmin = 0,
                wmax = 0;
            var map = new HashSet<(int y, int x, int z, int w)>(input
                .SelectMany((line, y) => line
                    .ToCharArray()
                    .Select((c, i) => (c, i))
                    .Where(x => x.c == '#')
                    .Select(x => (y, x.i, 0, 0))));

            for (var i = 0; i < 6; i++)
            {
                var copy = new HashSet<(int y, int x, int z, int w)>(map);
                for (var y = ymin - 1; y <= ymax + 1; y++)
                {
                    for (var x = xmin - 1; x <= xmax + 1; x++)
                    {
                        for (var z = zmin - 1; z <= zmax + 1; z++)
                        {
                            for (var w = wmin - 1; w <= wmax + 1; w++)
                            {
                                var neighbours = NumberOfNeighbors4D(map, y, x, z, w);
                                var isActive = map.Contains((y, x, z, w));
                                if (isActive && (neighbours < 2 || neighbours > 3))
                                {
                                    copy.Remove((y, x, z, w));
                                }
                                else if (!isActive && neighbours == 3)
                                {
                                    ymin = Math.Min(ymin, y);
                                    xmin = Math.Min(xmin, x);
                                    zmin = Math.Min(zmin, z);
                                    wmin = Math.Min(wmin, w);
                                    ymax = Math.Max(ymax, y);
                                    xmax = Math.Max(xmax, x);
                                    zmax = Math.Max(zmax, z);
                                    wmax = Math.Max(wmax, w);
                                    copy.Add((y, x, z, w));
                                }
                            }
                        }
                    }
                }
                map = copy;
            }

            return map.Count;
        }

        private static int NumberOfNeighbors4D(HashSet<(int y, int x, int z, int w)> map, int y, int x, int z, int w)
        {
            var count = 0;
            for (var i = 0; i < Math.Pow(3, 4); i++)
            {
                var ty = y + i % 3 - 1;
                var tx = x + (i / 3) % 3 - 1;
                var tz = z + (i / 9) % 3 - 1;
                var tw = w + (i / 27) % 3 - 1;
                if (ty == y && tx == x && tz == z && tw == w) continue;
                if (map.Contains((ty, tx, tz, tw))) count += 1;
                if (count > 3) return count;
            }
            return count;
        }
    }
}
