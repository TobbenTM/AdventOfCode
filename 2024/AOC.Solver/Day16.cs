using System;
using System.Collections.Generic;
using System.Linq;
using AOC.Solver.Tools;

namespace AOC.Solver;

public static class Day16
{
    public static int SolvePart1(string[] input)
    {
        var map = new MapV2(input);
        var current = map.Entities['S'].Single();
        current.Direction = Direction.East;
        var end = map.Entities['E'].Single();

        var toCheck = new Queue<MapV2.Entity>(map.Entities.Where(kv => kv.Key is '.' or 'E').SelectMany(kv => kv.Value));

        while (current != end)
        {
            visited.Add(current);

            foreach (var dir in Direction.Orthogonal)
            {
                var neighbour = map[dir.Apply(current.Position)];
                if (neighbour.Value == '#') continue;
                if (neighbour.Value == 'S') continue;
            }
        }

        return visited[map.Entities['E'].Single()];
    }

    public static int SolvePart2(string[] input)
    {
        throw new NotImplementedException("Part 2 not implemented yet!");
    }
}
