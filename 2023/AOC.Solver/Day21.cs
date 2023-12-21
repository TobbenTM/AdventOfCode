using System;
using System.Collections.Generic;
using System.Linq;
using AOC.Solver.Tools;

namespace AOC.Solver;

public static class Day21
{
    public static int SolvePart1(string[] input)
    {
        var map = new Map(input);
        var (_, startingRow, startingCol) = map.First('S');

        var visited = new HashSet<(int row, int col)> { (startingRow, startingCol) };

        var next = visited.ToList();

        for (var i = 0; i < 64; i++)
        {
            var newPositions = new List<(int row, int col)>();

            foreach (var pos in next)
            {
                foreach (var dir in Neighbour.Orthogonal)
                {
                    var neighbour = dir.Apply(pos);
                    if (map[neighbour] == '.' && !visited.Contains(neighbour))
                        newPositions.Add(neighbour);
                }
            }
        
            next = newPositions;
            foreach (var pos in newPositions)
            {
                visited.Add(pos);
            }
        }

        return visited.Count - 1;
    }

    public static int SolvePart2(string[] input)
    {
        throw new NotImplementedException("Part 2 not implemented yet!");
    }
}
