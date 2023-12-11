using System;
using System.Collections.Generic;
using System.Linq;

namespace AOC.Solver;

public static class Day11
{
    public static int SolvePart1(string[] input)
    {
        var map = input.Select(line => line.ToCharArray().ToList()).ToList();

        for (var x = 0; x < map[1].Count; x++)
        {
            if (map.All(line => line[x] == '.'))
            {
                foreach (var row in map)
                    row.Insert(x, '.');
                x++;
            }
        }

        for (var y = 0; y < input.Length; y++)
        {
            if (map[y].All(spot => spot == '.'))
            {
                map.Insert(y, map[y].ToList());
                y++;
            }
        }

        var galaxies = new List<(int y, int x)>();
        for (var y = 0; y < map.Count; y++)
        {
            for (var x = 0; x < map[y].Count; x++)
            {
                if (map[y][x] == '#')
                    galaxies.Add((y, x));
            }
        }

        var result = 0;
        for (var i = 0; i < galaxies.Count - 1; i++)
        {
            for (var j = i + 1; j < galaxies.Count; j++)
            {
                result += Math.Abs(galaxies[i].y - galaxies[j].y) + Math.Abs(galaxies[i].x - galaxies[j].x);
            }
        }

        return result;
    }

    public static long SolvePart2(string[] input)
    {
        var map = input.Select(line => line.ToCharArray().ToList()).ToList();
        var expandedRows = new List<int>();
        var expandedColumns = new List<int>();

        for (var x = 0; x < map[1].Count; x++)
        {
            if (map.All(line => line[x] == '.'))
                expandedColumns.Add(x);
        }

        for (var y = 0; y < input.Length; y++)
        {
            if (map[y].All(spot => spot == '.'))
                expandedRows.Add(y);
        }

        var galaxies = new List<(int y, int x)>();
        for (var y = 0; y < map.Count; y++)
        {
            for (var x = 0; x < map[y].Count; x++)
            {
                if (map[y][x] == '#')
                    galaxies.Add((y, x));
            }
        }

        var result = 0L;
        for (var i = 0; i < galaxies.Count - 1; i++)
        {
            for (var j = i + 1; j < galaxies.Count; j++)
            {
                var minY = Math.Min(galaxies[i].y, galaxies[j].y);
                var maxY = Math.Max(galaxies[i].y, galaxies[j].y);
                var minX = Math.Min(galaxies[i].x, galaxies[j].x);
                var maxX = Math.Max(galaxies[i].x, galaxies[j].x);
                result += maxY - minY + maxX - minX;
                result += expandedRows.Count(r => r > minY && r < maxY) * (1_000_000 - 1);
                result += expandedColumns.Count(c => c > minX && c < maxX) * (1_000_000 - 1);
            }
        }

        return result;
    }
}
