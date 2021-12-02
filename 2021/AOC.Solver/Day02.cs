using System;
using System.Linq;

namespace AOC.Solver
{
    public static class Day02
    {
        public static int SolvePart1(string[] input)
        {
            var movements = input
                .Select(movement => movement.Split(" "))
                .Select(tuple => new { direction = tuple[0], value = int.Parse(tuple[1]) });

            var (hpos, depth) = (0, 0);
            foreach (var movement in movements)
            {
                switch (movement.direction)
                {
                    case "down":
                        depth += movement.value;
                        break;
                    case "up":
                        depth -= movement.value;
                        break;
                    case "forward":
                        hpos += movement.value;
                        break;
                    default:
                        throw new NotImplementedException("Does not support movement type " + movement.direction);
                }
            }

            return hpos * depth;
        }

        public static int SolvePart2(string[] input)
        {
            var movements = input
                .Select(movement => movement.Split(" "))
                .Select(tuple => new { direction = tuple[0], value = int.Parse(tuple[1]) });

            var (hpos, depth, aim) = (0, 0, 0);
            foreach (var movement in movements)
            {
                switch (movement.direction)
                {
                    case "down":
                        aim += movement.value;
                        break;
                    case "up":
                        aim -= movement.value;
                        break;
                    case "forward":
                        hpos += movement.value;
                        depth += aim * movement.value;
                        break;
                    default:
                        throw new NotImplementedException("Does not support movement type " + movement.direction);
                }
            }

            return hpos * depth;
        }
    }
}
