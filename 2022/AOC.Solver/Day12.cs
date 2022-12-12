using System;
using System.Collections.Generic;
using System.Linq;

namespace AOC.Solver;

public static class Day12
{
    private static readonly (int deltaRow, int deltaCol)[] _neighbours =
    {
        (-1, 0),
        (0, -1),
        (0, 1),
        (1, 0),
    };

    public static int SolvePart1(string[] input)
    {
        var nodes = new Dictionary<(int row, int col), Node>();
        for (var row = 0; row < input.Length; row++)
        {
            for (var col = 0; col < input[row].Length; col++)
            {
                nodes.Add((row, col), new Node { Height = input[row][col], Position = (row, col) });
            }
        }
        foreach (var kv in nodes)
        {
            foreach (var neighbourDiff in _neighbours)
            {
                if (nodes.TryGetValue((kv.Key.row + neighbourDiff.deltaRow, kv.Key.col + neighbourDiff.deltaCol), out var neighbour))
                {
                    var heightDiff = neighbour.Height - kv.Value.Height;
                    if ((heightDiff is <= 1 && neighbour.Height != 'E')
                        || (neighbour.Height == 'E' && kv.Value.Height == 'z')
                        || (kv.Value.Height == 'S' && neighbour.Height == 'a'))
                    {
                        kv.Value.Neighbours.Add(neighbour);
                    }
                }
            }
        }

        var start = nodes.Values.Single(n => n.Height == 'S');

        return AStar(nodes.Values.ToArray(), start);
    }

    public static int SolvePart2(string[] input)
    {
        var nodes = new Dictionary<(int row, int col), Node>();
        for (var row = 0; row < input.Length; row++)
        {
            for (var col = 0; col < input[row].Length; col++)
            {
                nodes.Add((row, col), new Node { Height = input[row][col] == 'S' ? 'a' : input[row][col], Position = (row, col) });
            }
        }
        foreach (var kv in nodes)
        {
            foreach (var neighbourDiff in _neighbours)
            {
                if (nodes.TryGetValue((kv.Key.row + neighbourDiff.deltaRow, kv.Key.col + neighbourDiff.deltaCol), out var neighbour))
                {
                    var heightDiff = neighbour.Height - kv.Value.Height;
                    if ((heightDiff is <= 1 && neighbour.Height != 'E')
                        || (neighbour.Height == 'E' && kv.Value.Height == 'z')
                        || (kv.Value.Height == 'S' && neighbour.Height == 'a'))
                    {
                        kv.Value.Neighbours.Add(neighbour);
                    }
                }
            }
        }

        var nodeList = nodes.Values.ToArray();
        return nodeList.Where(n => n.Height == 'a').Select(n => AStar(nodeList, n)).Where(d => d > 0).Min();
    }

    private static int AStar(Node[] nodes, Node start)
    {
        var end = nodes.Single(n => n.Height == 'E');

        start.Distance = 0;

        int H(Node node) => Math.Abs(node.Position.col - end.Position.col) + Math.Abs(node.Position.row - end.Position.row);

        var open = new HashSet<Node>(new[] { start });

        while (open.Any())
        {
            var current = open.OrderBy(node => node.EstimatedDistance).First();
            if (current == end)
            {
                return current.Distance;
            }

            open.Remove(current);

            foreach (var neighbour in current.Neighbours)
            {
                var tentativeScore = current.Distance + 1;
                if (tentativeScore < neighbour.Distance)
                {
                    neighbour.Distance = tentativeScore;
                    neighbour.EstimatedDistance = tentativeScore + H(neighbour);
                    open.Add(neighbour);
                }
            }
        }

        return 0;
    }

    private class Node
    {
        public List<Node> Neighbours { get; } = new();

        public bool Visited { get; set; }

        public char Height { get; init; }

        public (int row, int col) Position { get; init; }

        public int Distance { get; set; } = int.MaxValue;

        public int EstimatedDistance { get; set; } = int.MaxValue;
    }
}
