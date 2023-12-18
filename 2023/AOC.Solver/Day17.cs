using System;
using System.Collections.Generic;
using System.Linq;
using AOC.Solver.Tools;

namespace AOC.Solver;

public static class Day17
{
    public static int SolvePart1(int[][] input)
    {
        var nodes = input.SelectMany((row, rowIndex) => row.Select((val, colIndex) => new Node
        {
            HeatLoss = val,
            Position = (rowIndex, colIndex),
        })).ToDictionary(n => n.Position);

        foreach (var node in nodes.Values)
        {
            node.Neighbours = Neighbour.Orthogonal
                .Select(dir => dir.Apply(node.Position))
                .Select(pos => nodes.GetValueOrDefault(pos))
                .OfType<Node>()
                .ToList();
        }

        return AStar(nodes);
    }

    public static int SolvePart2(int[][] input)
    {
        throw new NotImplementedException("Part 2 not implemented yet!");
    }

    private static int AStar(Dictionary<(int row, int col), Node> nodes)
    {
        var start = nodes.Values.First();
        var end = nodes.Values.Last();

        start.Distance = 0;

        var cameFrom = new Dictionary<Node, Node>();

        var open = new HashSet<Node>(new[] { start });

        while (open.Any())
        {
            var current = open.OrderBy(node => node.EstimatedDistance).First();
            if (current == end)
            {
                var total = current.HeatLoss;
                current.Visited = true;
                while (cameFrom.TryGetValue(current, out current))
                {
                    total += current.HeatLoss;
                    current.Visited = true;
                }

                var map = "";
                for (var y = 0; y <= end.Position.row; y++)
                {
                    for (var x = 0; x <= end.Position.col; x++)
                    {
                        var node = nodes[(y, x)];
                        map += node.Visited ? node.HeatLoss : " ";
                    }

                    map += "\n";
                }
                Console.Write(map);

                return total - start.HeatLoss;
            }

            open.Remove(current);

            var last4 = new List<Node> {current};
            for (var i = 0; i < 3; i++)
            {
                var previous = cameFrom.GetValueOrDefault(last4.Last());
                if (previous == null) break;
                last4.Add(previous);
            }

            var columnRestriction = last4.Count == 4 && last4.Select(n => n.Position.col).Distinct().Count() == 1;
            var rowRestriction = last4.Count == 4 && last4.Select(n => n.Position.row).Distinct().Count() == 1;

            foreach (var neighbour in current.Neighbours.Where(n => (!columnRestriction || n.Position.col != current.Position.col) && (!rowRestriction || n.Position.row != current.Position.row)))
            {
                var tentativeScore = current.Distance + neighbour.HeatLoss;
                if (tentativeScore < neighbour.Distance)
                {
                    cameFrom[neighbour] = current;
                    neighbour.Distance = tentativeScore;
                    neighbour.EstimatedDistance = tentativeScore + H(neighbour);
                    open.Add(neighbour);
                }
            }
        }

        return 0;

        int H(Node node) => Math.Abs(node.Position.col - end.Position.col) + Math.Abs(node.Position.row - end.Position.row);
    }

    private class Node
    {
        public List<Node> Neighbours { get; set; } = new();

        public int HeatLoss { get; init; }

        public bool Visited { get; set; }

        public (int row, int col) Position { get; init; }

        public int Distance { get; set; } = int.MaxValue;

        public int EstimatedDistance { get; set; } = int.MaxValue;
    }
}
