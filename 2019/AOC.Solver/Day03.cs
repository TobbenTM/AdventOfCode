using System;
using System.Collections.Generic;
using System.Linq;

namespace AOC.Solver
{
    public static class Day03
    {
        public class Point
        {
            public int X { get; set; }

            public int Y { get; set; }

            public int Distance { get; set; }

            public int Taxi => Math.Abs(X) + Math.Abs(Y);

            override public bool Equals(object obj) {
                return X == ((Point)obj).X && Y == ((Point)obj).Y;
            }

            override public int GetHashCode() {
                return X * 100000 + Y;
            }
        }

        public static int SolvePart1(string[] input1, string[] input2) {
            var c1 = Eval(input1);
            var c2 = Eval(input2);
            var collisions = c1.Intersect(c2);
            return collisions.OrderBy(p => p.Taxi).First().Taxi;
        }

        public static HashSet<Point> Eval(string[] input) {
            var coords = new HashSet<Point>();
            int currentX = 0, currentY = 0, currentDist = 0;
            foreach (var coord in input)
            {
                var direction = coord[0];
                var length = int.Parse(coord.Substring(1));
                for (var i = 0; i < length; i++) {
                    switch (direction)
                    {
                        case 'D':
                            currentY -= 1;
                            break;
                        case 'U':
                            currentY += 1;
                            break;
                        case 'L':
                            currentX -= 1;
                            break;
                        case 'R':
                            currentX += 1;
                            break;
                    }
                    coords.Add(new Point { X = currentX, Y = currentY, Distance = ++currentDist });
                }
            }
            return coords;
        }

        public static int SolvePart2(string[] input1, string[] input2) {
            var c1 = Eval(input1);
            var c2 = Eval(input2);
            var collisions1 = c1.Intersect(c2);
            var collisions2 = c2.Intersect(c1);
            var collisions = collisions1.Join(
                collisions2,
                p => p.GetHashCode(),
                p => p.GetHashCode(),
                (a, b) => a.Distance + b.Distance);
            return collisions.Min();
        }
    }
}
