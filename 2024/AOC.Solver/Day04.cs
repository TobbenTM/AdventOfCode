using System.Linq;
using AOC.Solver.Tools;

namespace AOC.Solver;

public static class Day04
{
    public static int SolvePart1(string[] input)
    {
        var result = 0;
        var map = input.Select(l => l.ToArray()).ToArray();
        for (var row = 0; row < map.Length; row++)
        {
            for (var col = 0; col < map[row].Length; col++)
            {
                if (map[row][col] is not 'X') continue;
                result += Direction.All
                    .Select(dir => dir.Apply(map, row, col, 3))
                    .Count(word => word.SequenceEqual(['M', 'A', 'S']));
            }
        }

        return result;
    }

    public static int SolvePart2(string[] input)
    {
        var result = 0;
        var map = input.Select(l => l.ToArray()).ToArray();
        for (var row = 0; row < map.Length; row++)
        {
            for (var col = 0; col < map[row].Length; col++)
            {
                if (map[row][col] is not 'A') continue;
                var a = Direction.NorthEast.Apply(map, row + 2, col - 2, 3);
                var b = Direction.NorthWest.Apply(map, row + 2, col + 2, 3);
                if ((a.SequenceEqual(['M', 'A', 'S']) || a.Reverse().SequenceEqual(['M', 'A', 'S'])) &&
                    (b.SequenceEqual(['M', 'A', 'S']) || b.Reverse().SequenceEqual(['M', 'A', 'S'])))
                    result++;
            }
        }

        return result;
    }
}
