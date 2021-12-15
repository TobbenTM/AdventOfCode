using System;
using System.Collections.Generic;
using System.Linq;

namespace AOC.Solver
{
    public static class Day15
    {
        private static readonly (int deltaRow, int deltaCol)[] Neighbours =
        {
            (-1, 0),
            (0, -1),
            (0, 1),
            (1, 0),
        };

        public static int SolvePart1(int[][] input)
        {
            var nodes = new Dictionary<(int row, int col), Node>();
            for (var row = 0; row < input.Length; row++)
            {
                for (var col = 0; col < input[row].Length; col++)
                {
                    nodes.Add((row, col), new Node { Risk = input[row][col], Position = (row, col) });
                }
            }
            foreach (var kv in nodes)
            {
                foreach (var neighbourDiff in Neighbours)
                {
                    if (nodes.TryGetValue((kv.Key.row + neighbourDiff.deltaRow, kv.Key.col + neighbourDiff.deltaCol), out var neighbour))
                    {
                        kv.Value.Neighbours.Add(neighbour);
                    }
                }
            }

            return AStar(nodes);
        }

        public static int SolvePart2(int[][] input)
        {
            var nodes = new Dictionary<(int row, int col), Node>();
            var height = input.Length;
            var width = input[0].Length;

            for (var row = 0; row < height * 5; row++)
            {
                for (var col = 0; col < width * 5; col++)
                {
                    var addition = (int)(Math.Floor((decimal)row / height) + Math.Floor((decimal)col / width));
                    var risk = (input[row % height][col % width] + addition);
                    nodes.Add((row, col), new Node
                    {
                        Risk = risk % 10 + (risk > 9 ? 1 : 0),
                        Position = (row, col)
                    });
                }
            }
            foreach (var kv in nodes)
            {
                foreach (var neighbourDiff in Neighbours)
                {
                    if (nodes.TryGetValue((kv.Key.row + neighbourDiff.deltaRow, kv.Key.col + neighbourDiff.deltaCol), out var neighbour))
                    {
                        kv.Value.Neighbours.Add(neighbour);
                    }
                }
            }

            return AStar(nodes);
        }

        private static int Dijkstra(Dictionary<(int row, int col), Node> nodes)
        {
            var end = nodes.Values.Last();

            var current = nodes.Values.First();
            current.Distance = 0;

            var unvisitedNodes = nodes.Values.ToHashSet();

            while (current != end)
            {
                current.Visited = true;
                unvisitedNodes.Remove(current);

                foreach (var neighbour in current.Neighbours)
                {
                    if (neighbour.Visited) continue;
                    if (neighbour.Distance > current.Distance + neighbour.Risk)
                    {
                        neighbour.Distance = current.Distance + neighbour.Risk;
                    }
                }

                current = unvisitedNodes.OrderBy(node => node.Distance).First(node => !node.Visited);
            }

            return current.Distance;
        }

        private static int AStar(Dictionary<(int row, int col), Node> nodes)
        {
            var start = nodes.Values.First();
            var end = nodes.Values.Last();

            start.Distance = 0;

            var h = (Node node) => Math.Abs(node.Position.col - end.Position.col) + Math.Abs(node.Position.row - end.Position.row);
            var cameFrom = new Dictionary<Node, Node>();

            var open = new HashSet<Node>(new[] { start });

            while (open.Any())
            {
                var current = open.OrderBy(node => node.EstimatedDistance).First();
                if (current == end)
                {
                    var total = current.Risk;
                    while (cameFrom.TryGetValue(current, out current))
                    {
                        total += current.Risk;
                    }
                    return total - start.Risk;
                }

                open.Remove(current);

                foreach (var neighbour in current.Neighbours)
                {
                    var tentativeScore = current.Distance + neighbour.Risk;
                    if (tentativeScore < neighbour.Distance)
                    {
                        cameFrom[neighbour] = current;
                        neighbour.Distance = tentativeScore;
                        neighbour.EstimatedDistance = tentativeScore + h(neighbour);
                        open.Add(neighbour);
                    }
                }
            }

            return 0;
        }

        private class Node
        {
            public List<Node> Neighbours { get; } = new List<Node>();

            public bool Visited { get; set; }

            public int Risk { get; init; }

            public (int row, int col) Position { get; init; }

            public int Distance { get; set; } = int.MaxValue;

            public int EstimatedDistance { get; set; } = int.MaxValue;
        }
    }
}
