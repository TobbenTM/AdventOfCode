using System.Linq;
using AOC.Solver.Tools;

namespace AOC.Solver;

public static class Day04
{
    public static int SolvePart1(string[] input)
    {
        var map = new MapV2(input);
        return map.Entities['@'].Count(e => map.Neighbours(e.Position, Direction.All).Count(n => n.Value == '@') < 4);
    }

    public static int SolvePart2(string[] input)
    {
        var map = new MapV2(input);
        var removed = 0;
        while (true)
        {
            var toRemove = map.Entities['@']
                .Where(e => map.Neighbours(e.Position, Direction.All).Count(n => n.Value == '@') < 4)
                .ToArray();

            if (toRemove.Any())
            {
                removed += toRemove.Length;
                foreach (var entity in toRemove)
                {
                    map[entity.Position] = new MapV2.Entity('.', entity.Row, entity.Col);
                }
            }
            else
            {
                break;
            }
        }
        return removed;
    }
}
