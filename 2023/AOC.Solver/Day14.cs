using System.Collections.Generic;
using System.Linq;
using AOC.Solver.Tools;

namespace AOC.Solver;

public static class Day14
{
    public static int SolvePart1(string[] input)
    {
        var map = new Map(input);

        foreach (var column in map.Columns)
        {
            foreach (var (value, rowIndex, colIndex) in column.Skip(1))
            {
                if (value is '.' or '#') continue;
                map.SwapNeighbourWhile(rowIndex, colIndex, Neighbour.North, ch => ch == '.');
            }
        }

        return FindLoad(map);
    }

    public static int SolvePart2(string[] input)
    {
        var map = new Map(input);
        var history = new List<int>();
        var seeded = false;
        var seedSize = 1000;

        while (true)
        {
            // North
            foreach (var column in map.Columns)
            {
                foreach (var (value, rowIndex, colIndex) in column.Skip(1))
                {
                    if (value is '.' or '#') continue;
                    map.SwapNeighbourWhile(rowIndex, colIndex, Neighbour.North, ch => ch == '.');
                }
            }

            // West
            foreach (var row in map.Rows)
            {
                foreach (var (value, rowIndex, colIndex) in row.Skip(1))
                {
                    if (value is '.' or '#') continue;
                    map.SwapNeighbourWhile(rowIndex, colIndex, Neighbour.West, ch => ch == '.');
                }
            }

            // South
            foreach (var column in map.Columns)
            {
                foreach (var (value, rowIndex, colIndex) in column.Reverse().Skip(1))
                {
                    if (value is '.' or '#') continue;
                    map.SwapNeighbourWhile(rowIndex, colIndex, Neighbour.South, ch => ch == '.');
                }
            }

            // East
            foreach (var row in map.Rows)
            {
                foreach (var (value, rowIndex, colIndex) in row.Reverse().Skip(1))
                {
                    if (value is '.' or '#') continue;
                    map.SwapNeighbourWhile(rowIndex, colIndex, Neighbour.East, ch => ch == '.');
                }
            }

            history.Add(FindLoad(map));
            if (!seeded && history.Count == seedSize)
            {
                seeded = true;
                history.Clear();
            }

            var cycleSize = history.Count / 2;
            if (seeded
                && history.Count > 10
                && history.Count % 2 == 0
                && history
                    .Take(cycleSize)
                    .SequenceEqual(history
                        .Skip(cycleSize)))
            {
                var offset = (1_000_000_000 - seedSize) % cycleSize;
                return history[cycleSize - offset - 1];
            }
        }
    }

    private static int FindLoad(Map map)
    {
        var result = 0;

        for (var y = 0; y < map.Height; y++)
        {
            for (var x = 0; x < map.Width; x++)
            {
                if (map[y, x] != 'O') continue;
                result += map.Height - y;
            }
        }

        return result;
    }
}
