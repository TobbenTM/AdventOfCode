using System.Collections.Generic;
using System.Linq;
using AOC.Solver.Tools;

namespace AOC.Solver;

public static class Day10
{
    public static int SolvePart1(string[] input)
    {
        var map = new MapV2(input);

        return map.Entities['0'].Sum(trailhead => WalkTrail(trailhead, map).Distinct().Count());
    }

    private static IEnumerable<MapV2.Entity> WalkTrail(MapV2.Entity current, MapV2 map)
    {
        if (current.Value == '9') yield return current;
        foreach (var direction in Neighbour.Orthogonal)
        {
            MapV2.Entity neighour;
            try
            {
                neighour = map[direction.Apply(current.Position)];
            }
            catch (MapV2.OutOfBoundsException)
            {
                continue;
            }

            if (neighour.Value != current.Value + 1) continue;

            foreach (var destination in WalkTrail(neighour, map))
            {
                yield return destination;
            }
        }
    }

    public static int SolvePart2(string[] input)
    {
        var map = new MapV2(input);

        return map.Entities['0'].Sum(trailhead => WalkTrail(trailhead, map).Count());
    }
}
