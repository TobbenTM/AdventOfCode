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
            tail.x + (Math.Abs(dx) <= 1 ? dx : dx < 0 ? dx + 1 : dx - 1),
            tail.y + (Math.Abs(dy) <= 1 ? dy : dy < 0 ? dy + 1 : dy - 1)
        );
    }

    public static int SolvePart1(string[] input)
    {
        (int x, int y) head = (0, 0);
        (int x, int y) tail = (0, 0);
        var visited = new HashSet<(int, int)>{ tail };

        foreach (var line in input)
        {
            var direction = line[0];
            var count = int.Parse(line[2..]);

            for (var i = 0; i < count; i++)
            {
                head = direction switch
                {
                    'U' => (head.x, head.y + 1),
                    'L' => (head.x - 1, head.y),
                    'R' => (head.x + 1, head.y),
                    'D' => (head.x, head.y - 1),
                    _ => head,
                };

                tail = GetNewTailPos(head, tail);
                visited.Add(tail);
            }
        }

        return visited.Count;
    }

    public static int SolvePart2(string[] input)
    {
        (int x, int y) head = (0, 0);
        (int x, int y)[] knots = Enumerable.Range(0, 10).Select(_ => (0, 0)).ToArray();
        var visited = new HashSet<(int, int)>{ head };

        foreach (var line in input)
        {
            var direction = line[0];
            var count = int.Parse(line[2..]);

            for (var i = 0; i < count; i++)
            {
                head = direction switch
                {
                    'U' => (head.x, head.y + 1),
                    'L' => (head.x - 1, head.y),
                    'R' => (head.x + 1, head.y),
                    'D' => (head.x, head.y - 1),
                    _ => head,
                };

                knots[0] = GetNewTailPos(head, knots[0]);
                for (var j = 1; j < knots.Length; j++)
                {
                    knots[j] = GetNewTailPos(knots[j - 1], knots[j]);
                }
                visited.Add(knots.Last());
            }
        }

        return visited.Count;
    }
}
