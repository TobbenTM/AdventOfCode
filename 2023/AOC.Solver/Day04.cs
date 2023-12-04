using System;
using System.Collections.Generic;
using System.Linq;

namespace AOC.Solver;

public static class Day04
{
    public static int SolvePart1(string[] input)
    {
        return input
            .Select(l => l.Split(':')[1]
                .Split('|')
                .Select(n => n
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray())
                .ToArray())
            .Select(a => a[0].Intersect(a[1]).Count())
            .Select(n => n == 0 ? 0 : (int)Math.Pow(2, n - 1))
            .Sum();
    }

    public static int SolvePart2(string[] input)
    {
        var cards = input
            .Select(l => l.Split(':')[1]
                .Split('|')
                .Select(n => n
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray())
                .ToArray())
            .Select((c, i) => (i, c[0], c[1]))
            .ToDictionary(x => x.i);

        var count = 0;
        var queue = new Queue<(int id, int[] winners, int[] owned)>(cards.Values);

        while (queue.TryDequeue(out var card))
        {
            count++;
            var copies = card.winners.Intersect(card.owned).Count();
            for (var i = 1; i <= copies; i++)
            {
                queue.Enqueue(cards[card.id + i]);
            }
        }

        return count;
    }
}
