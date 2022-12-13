using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace AOC.Solver;

public static class Day13
{
    public static int SolvePart1(string input)
    {
        var pairs = input.Split("\n\n").Select(pair => new Pair(pair));
        var correctPairs = pairs.Select((pair, index) => (pair, index)).Where(x => x.pair.IsCorrectOrder);
        return correctPairs.Sum(x => x.index + 1);
    }

    public static int SolvePart2(string input)
    {
        var packets = input
            .Split('\n', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries)
            .Select(p => new ListPart(JsonSerializer.Deserialize<JsonArray>(p)!))
            .ToList();
        var dividers = new[]
        {
            new ListPart(new ListPart(new IntegerPart{ Value = 2})),
            new ListPart(new ListPart(new IntegerPart{ Value = 6})),
        };
        packets.AddRange(dividers);
        packets.Sort(new ListPartComparer());
        return dividers.Select(d => packets.IndexOf(d)).Select(i => i + 1).Aggregate(1, (a, b) => a * b);
    }

    private class Pair
    {
        private ListPart Left { get; init; }

        private ListPart Right { get; init; }

        public Pair(string input)
        {
            var parts = input.Split('\n');
            Left = new ListPart(JsonSerializer.Deserialize<JsonArray>(parts[0])!);
            Right = new ListPart(JsonSerializer.Deserialize<JsonArray>(parts[1])!);
        }

        public bool IsCorrectOrder => ListPart.IsCorrectOrder(Left, Right) ?? true;
    }

    private abstract class Part { }

    private class IntegerPart : Part
    {
        public int Value { get; init; }

        public override string ToString() => Value.ToString();
    }

    private class ListPart : Part
    {
        public List<Part> Parts { get; }

        public ListPart(Part value)
        {
            Parts = new List<Part> { value };
        }

        public ListPart(JsonArray input)
        {
            Part ResolveNode(JsonNode? node)
            {
                if (node == null) throw new ArgumentNullException(nameof(node));
                if (node is JsonArray jsonArray)
                {
                    return new ListPart(jsonArray);
                }
                return new IntegerPart { Value = node.GetValue<int>() };
            }
            Parts = input.Select(ResolveNode).ToList();
        }

        public override string ToString() =>$"[{string.Join(',', Parts.Select(p => p.ToString()))}]";

        public static bool? IsCorrectOrder(ListPart left, ListPart right)
        {
            var leftItems = new List<Part>(left.Parts);
            var rightItems = new List<Part>(right.Parts);
            for (var i = 0; i < leftItems.Count; i++)
            {
                if (rightItems.Count <= i)
                {
                    return false;
                }

                if (leftItems[i] is IntegerPart lint && rightItems[i] is IntegerPart rint)
                {
                    if (lint.Value > rint.Value)
                    {
                        return false;
                    }
                    else if (lint.Value < rint.Value)
                    {
                        return true;
                    }
                }
                else if (leftItems[i] is ListPart llist && rightItems[i] is ListPart rlist)
                {
                    var comparisonResult = IsCorrectOrder(llist, rlist);
                    if (llist.Parts.Count != rlist.Parts.Count)
                    {
                        if (!comparisonResult.HasValue || comparisonResult.Value)
                        {
                            return true;
                        }
                        else if (comparisonResult.HasValue && !comparisonResult.Value)
                        {
                            return false;
                        }
                    }
                    if (comparisonResult.HasValue)
                    {
                        return comparisonResult.Value;
                    }
                }
                else if (leftItems[i] is IntegerPart lsint)
                {
                    leftItems.RemoveAt(i);
                    leftItems.Insert(i, new ListPart(lsint));
                    i--;
                }
                else if (rightItems[i] is IntegerPart rsint)
                {
                    rightItems.RemoveAt(i);
                    rightItems.Insert(i, new ListPart(rsint));
                    i--;
                }
            }
            return null;
        }
    }

    private class ListPartComparer : IComparer<ListPart>
    {
        public int Compare(ListPart? x, ListPart? y)
        {
            if (x == null || y == null) return 0;
            var result = ListPart.IsCorrectOrder(x, y);
            if (result == null) return -1;
            return result.Value ? -1 : 1;
        }
    }
}
