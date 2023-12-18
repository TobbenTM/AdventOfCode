using System;
using System.Linq;
using AOC.Solver.Tools;

namespace AOC.Solver;

public static class Day18
{
    public static int SolvePart1(string[] input)
    {
        var digs = input.Select(line => line.Split(" "))
            .Select(parts => (Direction: ToNeighbour(parts[0]), Length: int.Parse(parts[1])))
            .ToArray();

        var result = 0f;
        (int y, int x) current = (0, 0);

        foreach (var dig in digs)
        {
            var next = dig.Direction.Apply(current, dig.Length);
            result += (current.x * next.y - current.y * next.x + dig.Length) / 2f;
            current = next;
        }

        return Math.Abs((int)result) + 1;
    }

    public static long SolvePart2(string[] input)
    {
        var digs = input.Select(line => line.Split(" ")[2])
            .Select(hex => (Length: hex[2..7], Direction: hex[7]))
            .Select(parts => (
                Direction: ToNeighbour(int.Parse(parts.Direction.ToString())),
                Length: Convert.ToInt32(parts.Length, 16)))
            .ToArray();

        var area = 0d;
        (long y, long x) current = (0, 0);

        foreach (var dig in digs)
        {
            var next = dig.Direction.Apply(current, dig.Length);
            area += current.x * next.y - current.y * next.x;
            current = next;
        }

        area = Math.Abs(area) / 2d;
        var edge = digs.Select(d => d.Length).Sum();
        var inside = area - edge / 2d + 1;

        return (long) (edge + inside);
    }

    private static Neighbour ToNeighbour(string direction) => direction switch
    {
        "L" => Neighbour.West,
        "U" => Neighbour.North,
        "D" => Neighbour.South,
        "R" => Neighbour.East,
        _ => throw new ArgumentOutOfRangeException(nameof(direction)),
    };

    private static Neighbour ToNeighbour(int direction) => direction switch
    {
        0 => Neighbour.East,
        1 => Neighbour.South,
        2 => Neighbour.West,
        3 => Neighbour.North,
        _ => throw new ArgumentOutOfRangeException(nameof(direction)),
    };
}
