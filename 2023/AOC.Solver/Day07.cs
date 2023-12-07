using System;
using System.Collections.Generic;
using System.Linq;

namespace AOC.Solver;

public static class Day07
{
    public static long SolvePart1(string[] input)
    {
        var hands = input.Select(line => line.Split(' ')[0]).Select(n => ParseHand(n, false)).ToArray();
        var bids = input.Select(line => line.Split(' ')[1]).Select(int.Parse).ToArray();
        var zip = hands.Zip(bids);
        var ranked = zip.OrderBy(x => x.First.strength).ThenBy(x => x.First.cards).Select((x, i) => (bid: x.Second, rank: i + 1));

        var result = 0L;

        foreach (var hand in ranked)
        {
            result += hand.bid * hand.rank;
        }

        return result;
    }

    public static long SolvePart2(string[] input)
    {
        var hands = input.Select(line => line.Split(' ')[0]).Select(n => ParseHand(n, true)).ToArray();
        var bids = input.Select(line => line.Split(' ')[1]).Select(int.Parse).ToArray();
        var zip = hands.Zip(bids);
        var ranked = zip.OrderBy(x => x.First.strength).ThenBy(x => x.First.cards).Select((x, i) => (bid: x.Second, rank: i + 1));

        var result = 0L;

        foreach (var hand in ranked)
        {
            result += hand.bid * hand.rank;
        }

        return result;
    }

    private static (string cards, int strength) ParseHand(string hand, bool withJoker)
    {
        var map = new Dictionary<char, int>
        {
            { 'T', 10 },
            { 'J', withJoker ? 0 : 11 },
            { 'Q', 12 },
            { 'K', 13 },
            { 'A', 14 },
        };
        var cards = hand.Select(card => map.TryGetValue(card, out var value) ? value : int.Parse(card.ToString())).ToArray();
        var numJokers = cards.Count(n => n == 0);
        var groups = cards.Where(n => n != 0).GroupBy(n => n).ToDictionary(n => n.Key, n => n.Count());
        // if (withJoker)
        // {
        //     foreach (var group in groups.Where(g => g.Key != 0))
        //     {
        //         groups[group.Key] += numJokers;
        //     }
        // }
        // var pairs = groups.Values.Count(c => c >= 2);
        var values = groups.Values.OrderByDescending(n => n).ToArray();
        if (!values.Any()) values = new[] { 0 };

        var pairs = 0;
        var pairedJokers = numJokers;
        foreach (var v in values)
        {
            if (v >= 2) pairs++;
            if (v == 1 && pairedJokers > 0)
            {
                pairedJokers--;
                pairs++;
            }
        }

        var strength = 0;
        if (values[0] + numJokers >= 5)
        {
            strength = 7; // Five of a kind
        }
        else if (values[0] + numJokers == 4)
        {
            strength = 6; // Four of a kind
        }
        else if (values[0] + values[1] + numJokers == 5)
        {
            strength = 5; // Full house
        }
        else if (values[0] + numJokers == 3)
        {
            strength = 4; // Three of a kind
        }
        else if (pairs == 2)
        {
            strength = 3; // Two pairs
        }
        else if (pairs == 1)
        {
            strength = 2; // One pair
        }
        else if (groups.Count == 5)
        {
            strength = 1; // High card
        }

        return (string.Join(null, cards.Select(n => n.ToString().PadLeft(2, '0'))), strength);
    }
}
