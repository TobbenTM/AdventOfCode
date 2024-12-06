using System;
using System.Linq;
using AOC.Solver.Tools;

namespace AOC.Solver;

public static class Day06
{
    public static int SolvePart1(string[] input)
    {
        return RunToEnd(new MapV2(input)).History.Distinct().Count();
    }

    private static MapV2.Entity RunToEnd(MapV2 map)
    {
        var guard = map.Entities['^'].Single();
        try
        {
            while (true)
            {
                map.SwapNeighbourWhile(guard, Neighbour.North, e => e.Value == '.');
                map.SwapNeighbourWhile(guard, Neighbour.East, e => e.Value == '.');
                map.SwapNeighbourWhile(guard, Neighbour.South, e => e.Value == '.');
                map.SwapNeighbourWhile(guard, Neighbour.West, e => e.Value == '.');
                var tail = guard.History.TakeLast(2).ToArray();
                if (guard.History.Select((pos, i) => (pos, i)).SkipLast(2).Any(t => t.i > 0 && t.pos == tail.Last() && guard.History[t.i-1] == tail.First()))
                {
                    throw new Exception("Looping");
                }
            }
        }
        catch (MapV2.OutOfBoundsException)
        {
            return guard;
        }
    }

    public static int SolvePart2(string[] input)
    {
        var original = RunToEnd(new MapV2(input));

        var result = 0;
        foreach (var (row, col) in original.History.Distinct())
        {
            try
            {
                var map = new MapV2(input);
                if (map[row, col].Value != '.') continue;
                map[row, col].Value = '#';
                RunToEnd(map);
            }
            catch (Exception)
            {
                result++;
            }
        }

        return result;
    }
}
