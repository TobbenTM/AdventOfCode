using System;

namespace AOC.Solver
{
    public static class Day12
    {
        public static int SolvePart1(string[] input)
        {
            var directions = new[] { "N", "E", "S", "W" };
            var dir = "E";
            var x = 0;
            var y = 0;

            foreach (var line in input)
            {
                var cmd = line.Substring(0, 1);
                var arg = int.Parse(line.Substring(1));

                switch (cmd)
                {
                    case "N":
                    case "E":
                    case "S":
                    case "W":
                        Move(cmd, arg, ref x, ref y);
                        break;
                    case "F":
                        Move(dir, arg, ref x, ref y);
                        break;
                    case "R":
                        dir = directions[(Array.IndexOf(directions, dir) + arg / 90) % directions.Length];
                        break;
                    case "L":
                        dir = directions[(Array.IndexOf(directions, dir) + directions.Length - arg / 90) % directions.Length];
                        break;
                }
            }

            return Math.Abs(x) + Math.Abs(y);
        }

        public static int SolvePart2(string[] input)
        {
            var shipX = 0;
            var shipY = 0;
            var waypointX = 10;
            var waypointY = 1;

            foreach (var line in input)
            {
                var cmd = line.Substring(0, 1);
                var arg = int.Parse(line.Substring(1));

                switch (cmd)
                {
                    case "N":
                    case "E":
                    case "S":
                    case "W":
                        Move(cmd, arg, ref waypointX, ref waypointY);
                        break;
                    case "F":
                        shipX += arg * waypointX;
                        shipY += arg * waypointY;
                        break;
                    case "R":
                        Pivot(arg/90, ref waypointX, ref waypointY);
                        break;
                    case "L":
                        Pivot((360-arg)/90, ref waypointX, ref waypointY);
                        break;
                }
            }

            return Math.Abs(shipX) + Math.Abs(shipY);
        }

        private static void Move(string dir, int steps, ref int x, ref int y)
        {
            switch (dir)
            {
                case "N":
                    y += steps;
                    break;
                case "E":
                    x += steps;
                    break;
                case "S":
                    y -= steps;
                    break;
                case "W":
                    x -= steps;
                    break;
            }
        }

        private static void Pivot(int times, ref int x, ref int y)
        {
            for (var i = 0; i < times; i++)
            {
                var tempX = x;
                x = y;
                y = -tempX;
            }
        }
    }
}
