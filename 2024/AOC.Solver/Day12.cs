using System.Collections.Generic;
using System.Linq;
using AOC.Solver.Tools;

namespace AOC.Solver;

public static class Day12
{
    public static int SolvePart1(string[] input)
    {
        var map = new MapV2(input);
        var entities = map.Entities.Values.SelectMany(e => e).ToHashSet();
        var result = 0;
        while (entities.Any())
        {
            var entity = entities.First();
            entities.Remove(entity);
            var region = new HashSet<MapV2.Entity>{entity};
            var toDiscover = new Queue<MapV2.Entity>(region);
            var perimeter = 0;
            while (toDiscover.TryDequeue(out var regionEntity))
            {
                foreach (var dir in Direction.Orthogonal)
                {
                    try
                    {
                        var neighbour = map[dir.Apply(regionEntity.Position)];
                        if (region.Contains(neighbour)) continue;
                        if (neighbour.Value != regionEntity.Value)
                        {
                            perimeter++;
                            continue;
                        }
                        entities.Remove(neighbour);
                        region.Add(neighbour);
                        toDiscover.Enqueue(neighbour);
                    }
                    catch (OutOfBoundsException)
                    {
                        perimeter++;
                    }
                }
            }
            result += perimeter * region.Count;
        }
        return result;
    }

    public static int SolvePart2(string[] input)
    {
        var map = new MapV2(input);
        var entities = map.Entities.Values.SelectMany(e => e).ToHashSet();
        var result = 0;
        while (entities.Any())
        {
            var entity = entities.First();
            entities.Remove(entity);
            var region = new HashSet<MapV2.Entity>{entity};
            var toDiscover = new Queue<MapV2.Entity>(region);
            var sides = new HashSet<(float x, float y, bool vertical)>();
            while (toDiscover.TryDequeue(out var regionEntity))
            {
                foreach (var dir in Direction.Orthogonal)
                {
                    var pos = dir.Apply(regionEntity.Position);
                    var fencePos = dir.Apply(regionEntity.Position, 0.1f);
                    var vertical = dir.DeltaY == 0;
                    try
                    {
                        var neighbour = map[pos];
                        if (region.Contains(neighbour)) continue;
                        if (neighbour.Value != regionEntity.Value)
                        {
                            sides.Add((fencePos.x, fencePos.y, vertical));
                            continue;
                        }
                        entities.Remove(neighbour);
                        region.Add(neighbour);
                        toDiscover.Enqueue(neighbour);
                    }
                    catch (OutOfBoundsException)
                    {
                        sides.Add((fencePos.x, fencePos.y, vertical));
                    }
                }
            }

            var uniqueSides = 0;
            while (sides.Any())
            {
                var side = sides.First();
                sides.Remove(side);
                uniqueSides++;
                var delta = 1;
                while (sides.Remove((side.x + (side.vertical ? 0 : delta), side.y + (side.vertical ? delta : 0), side.vertical)))
                {
                    delta++;
                }
                delta = -1;
                while (sides.Remove((side.x + (side.vertical ? 0 : delta), side.y + (side.vertical ? delta : 0), side.vertical)))
                {
                    delta--;
                }
            }
            result += uniqueSides * region.Count;
        }
        return result;
    }
}
