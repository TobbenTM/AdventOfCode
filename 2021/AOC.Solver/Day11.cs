using System.Collections.Generic;
using System.Linq;

namespace AOC.Solver
{
    public static class Day11
    {
        private static readonly (int deltaRow, int deltaCol)[] Neighbours =
        {
            (-1, -1),
            (-1, 0),
            (-1, 1),
            (0, -1),
            (0, 1),
            (1, -1),
            (1, 0),
            (1, 1),
        };

        public static int SolvePart1(int[][] input)
        {
            var octopuses = ToMap(input);
            var flashes = 0;
            for (var step = 0; step < 100; step++)
            {
                flashes += RunStep(octopuses);
            }
            return flashes;
        }

        public static int SolvePart2(int[][] input)
        {
            var octopuses = ToMap(input);
            var steps = 0;
            while (true)
            {
                if (octopuses.Values.All(energy => energy == 0))
                {
                    return steps;
                }

                RunStep(octopuses);

                steps += 1;
            }
        }

        private static Dictionary<(int row, int col), int> ToMap(int[][] input)
        {
            var octopuses = new Dictionary<(int row, int col), int>();

            for (var row = 0; row < input.Length; row++)
            {
                for (var col = 0; col < input[row].Length; col++)
                {
                    octopuses.Add((row, col), input[row][col]);
                }
            }

            return octopuses;
        }

        private static int RunStep(Dictionary<(int row, int col), int> octopuses)
        {
            var flashes = 0;

            foreach (var octopus in octopuses)
            {
                octopuses[octopus.Key] = octopus.Value + 1;
            }

            while (octopuses.Values.Any(energy => energy > 9))
            {
                var flashingOctopus = octopuses.First(kv => kv.Value > 9);
                octopuses[flashingOctopus.Key] = -1;
                flashes += 1;

                foreach (var neighbour in Neighbours)
                {
                    var pos = (neighbour.deltaRow + flashingOctopus.Key.row,
                        neighbour.deltaCol + flashingOctopus.Key.col);
                    if (octopuses.TryGetValue(pos, out var value) && value != -1)
                    {
                        octopuses[pos] += 1;
                    }
                }
            }

            foreach (var octopus in octopuses.Where(kv => kv.Value == -1))
            {
                octopuses[octopus.Key] = 0;
            }

            return flashes;
        }
    }
}
