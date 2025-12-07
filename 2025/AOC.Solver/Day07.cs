using System;
using System.Collections.Generic;
using System.Linq;
using AOC.Solver.Tools;

namespace AOC.Solver;

public static class Day07
{
    public static int SolvePart1(string[] input)
    {
        var map = new MapV2(input);
        var start = map.Entities['S'].Single();
        var queue = new Queue<MapV2.Entity>([start]);
        var splits = 0;
        while (queue.TryDequeue(out var entity))
        {
            var below = map.Neighbour(entity.Position, Direction.South);
            switch (below?.Value)
            {
                case '.':
                    below.Value = '|';
                    queue.Enqueue(below);
                    break;
                case '^':
                    var sides = map.Neighbours(below.Position, [Direction.East, Direction.West]);
                    foreach (var side in sides.Where(s => s.Value == '.'))
                    {
                        side.Value = '|';
                        queue.Enqueue(side);
                    }

                    splits++;

                    break;
            }
        }

        // return map.Rows.Last().Count(e => e.Value == '|');
        return splits;
    }

    public static long SolvePart2(string[] input)
    {
        var map = new MapV2(input);
        var start = map.Entities['S'].Single();
        return ParticleTimelines(map, start);
    }

    private static long ParticleTimelines(MapV2 map, MapV2.Entity entity)
    {
        if (entity.Score > 0) return entity.Score;
            var below = map.Neighbour(entity.Position, Direction.South);
            switch (below?.Value)
            {
                case '.':
                    return ParticleTimelines(map, below);
                case '^':
                    var sides = map.Neighbours(below.Position, [Direction.East, Direction.West]).ToArray();
                    var left = ParticleTimelines(map, sides[0]);
                    var right = ParticleTimelines(map, sides[1]);
                    entity.Score = left + right;
                    return entity.Score;
                default:
                    return 1;
        }
    }
}
