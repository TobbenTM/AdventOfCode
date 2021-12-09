using System.Collections.Generic;
using System.Linq;

namespace AOC.Solver
{
    public static class Day09
    {
        public static int SolvePart1(int[][] input)
        {
            var lowSpots = new List<int>();
            for (int row = 0; row < input.Length; row++)
            {
                for (int col = 0; col < input[row].Length; col++)
                {
                    var cur = input[row][col];
                    if ((row == 0 || input[row - 1][col] > cur)
                        && (col == input[row].Length - 1 || input[row][col + 1] > cur)
                        && (row == input.Length - 1 || input[row + 1][col] > cur)
                        && (col == 0 || input[row][col - 1] > cur))
                    {
                        lowSpots.Add(cur);
                    }
                }
            }

            return lowSpots.Select(n => n + 1).Sum();
        }

        public static int SolvePart2(int[][] input)
        {
            var basins = new List<int>();
            for (int row = 0; row < input.Length; row++)
            {
                for (int col = 0; col < input[row].Length; col++)
                {
                    var cur = input[row][col];
                    if ((row == 0 || input[row - 1][col] > cur)
                        && (col == input[row].Length - 1 || input[row][col + 1] > cur)
                        && (row == input.Length - 1 || input[row + 1][col] > cur)
                        && (col == 0 || input[row][col - 1] > cur))
                    {
                        // Low spot found
                        basins.Add(ExploreBasin(input, row, col));
                    }
                }
            }

            return basins.OrderByDescending(size => size).Take(3).Aggregate((a, b) => a * b);
        }

        private static int ExploreBasin(int[][] map, int row, int col)
        {
            if (row < 0 || row == map.Length) return 0;
            if (col < 0 || col == map[row].Length) return 0;
            if (map[row][col] == 9) return 0;
            map[row][col] = 9;
            return 1
                   + ExploreBasin(map, row - 1, col)
                   + ExploreBasin(map, row + 1, col)
                   + ExploreBasin(map, row, col - 1)
                   + ExploreBasin(map, row, col + 1);
        }
    }
}
