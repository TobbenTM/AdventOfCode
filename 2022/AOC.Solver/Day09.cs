using System;
using System.Collections.Generic;
using System.Linq;

namespace AOC.Solver;

public static class Day09
{
    private static (int x, int y) GetNewTailPos((int x, int y) head, (int x, int y) tail)
    {
        var dx = head.x - tail.x;
        var dy = head.y - tail.y;

        if (Math.Abs(dx) <= 1 && Math.Abs(dy) <= 1) return tail;
        return (
            tail.x + Math.Sign(dx),
            tail.y + Math.Sign(dy)
        );
    }

    private static int GetUniqueTailVisits(string[] headMoves, int numberOfKnots)
    {
        (int x, int y)[] knots = Enumerable.Range(0, numberOfKnots).Select(_ => (0, 0)).ToArray();
        var visited = new HashSet<(int, int)> { (0, 0) };

        foreach (var line in headMoves)
        {
            var direction = line[0];
            var count = int.Parse(line[2..]);

            for (var i = 0; i < count; i++)
            {
                knots[0] = direction switch
                {
                    'U' => (knots[0].x, knots[0].y + 1),
                    'L' => (knots[0].x - 1, knots[0].y),
                    'R' => (knots[0].x + 1, knots[0].y),
                    'D' => (knots[0].x, knots[0].y - 1),
                    _ => knots[0],
                };

                for (var j = 1; j < knots.Length; j++)
                {
                    knots[j] = GetNewTailPos(knots[j - 1], knots[j]);
                }
                visited.Add(knots.Last());
            }
        }

        return visited.Count;
    }

    public static int SolvePart1(string[] input) => GetUniqueTailVisits(input, 2);

    public static int SolvePart2(string[] input) => GetUniqueTailVisits(input, 10);
}
