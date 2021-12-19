using System;
using System.Collections.Generic;
using System.Linq;

namespace AOC.Solver
{
    public static class Day18
    {
        public static long SolvePart1(string[] input)
        {
            var roots = new Queue<Pair>(input.Select(ParseInput));
            var newRoot = roots.Dequeue();
            while (roots.Any())
            {
                newRoot = Reduce(new Pair(newRoot, roots.Dequeue()));
            }

            return newRoot.Magnitude;
        }

        public static long SolvePart2(string[] input)
        {
            var magnitudes = new List<long>();
            for (var a = 0; a < input.Length - 1; a++)
            {
                for (var b = a + 1; b < input.Length; b++)
                {
                    magnitudes.Add(Reduce(new Pair(ParseInput(input[a]), ParseInput(input[b]))).Magnitude);
                    magnitudes.Add(Reduce(new Pair(ParseInput(input[b]), ParseInput(input[a]))).Magnitude);
                }
            }

            return magnitudes.Max();
        }

        private static Pair ParseInput(string line)
        {
            Pair? current = null;
            var pairs = new List<Pair>();

            foreach (var ch in line)
            {
                switch (ch)
                {
                    case '[':
                        current = new Pair
                        {
                            Parent = current
                        };
                        pairs.Add(current);
                        break;
                    case ']':
                        if (current?.Parent == null) break;
                        if (current.Parent.Left == null)
                        {
                            current.Parent.Left = current;
                        } else
                        {
                            current.Parent.Right = current;
                        }
                        current = current?.Parent ?? null;
                        break;
                    case ',':
                        break;
                    default:
                        var child = new Pair(int.Parse(ch.ToString()), current!);
                        if (current!.Left == null)
                        {
                            current!.Left = child;
                        }
                        else
                        {
                            current!.Right = child;
                        }
                        break;
                }
            }

            return pairs.First();
        }

        private static Pair Reduce(Pair root)
        {
            while (true)
            {
                var explodes = root.GetSubtree()
                    .Where(pair => !pair.Value.HasValue)
                    .FirstOrDefault(pair => pair.Depth >= 4);
                if (explodes != null)
                {
                    var left = explodes.LeftNeighbour;
                    if (left != null) left.Value += explodes.Left!.Value;
                    var right = explodes.RightNeighbour;
                    if (right != null) right.Value += explodes.Right!.Value;
                    explodes.Value = 0;
                    explodes.Left = null;
                    explodes.Right = null;
                    continue;
                }

                var splits = root
                    .GetSubtree()
                    .Where(pair => pair.Value.HasValue)
                    .FirstOrDefault(pair => pair.Value!.Value > 9);
                if (splits?.Value != null)
                {
                    var left = (int)Math.Floor(splits.Value.Value / 2d);
                    var right = (int) Math.Ceiling(splits.Value.Value / 2d);
                    splits.Value = null;
                    splits.Left = new Pair(left, splits);
                    splits.Right = new Pair(right, splits);
                    continue;
                }

                return root;
            }
        }

        private class Pair
        {
            public Pair()
            {
            }

            public Pair(Pair left, Pair right)
            {
                Left = left;
                Right = right;
                Left.Parent = Right.Parent = this;
            }

            public Pair(int value, Pair parent)
            {
                Value = value;
                Parent = parent;
            }

            public Pair? Parent { get; set; }

            public Pair? Left { get; set; }

            public Pair? Right { get; set; }

            public int? Value { get; set; }

            public int Depth
            {
                get
                {
                    var depth = 0;
                    var current = this;
                    while (current.Parent != null)
                    {
                        current = current.Parent;
                        depth++;
                    }

                    return depth;
                }
            }

            public long Magnitude
            {
                get
                {
                    if (Value.HasValue) return Value.Value;
                    return Left!.Magnitude * 3 + Right!.Magnitude * 2;
                }
            }

            public Pair? LeftNeighbour
            {
                get
                {
                    var current = this;
                    while (current?.Parent?.Left == current)
                    {
                        current = current!.Parent;
                    }

                    current = current?.Parent?.Left;

                    while (current?.Right != null)
                    {
                        current = current.Right;
                    }

                    return current;
                }
            }

            public Pair? RightNeighbour
            {
                get
                {
                    var current = this;
                    while (current?.Parent?.Right == current)
                    {
                        current = current!.Parent;
                    }

                    current = current?.Parent?.Right;

                    while (current?.Left != null)
                    {
                        current = current.Left;
                    }

                    return current;
                }
            }

            public IEnumerable<Pair> GetSubtree()
            {
                yield return this;
                if (Left != null)
                {
                    foreach (var pair in Left.GetSubtree())
                    {
                        yield return pair;
                    }
                }
                if (Right != null)
                {
                    foreach (var pair in Right.GetSubtree())
                    {
                        yield return pair;
                    }
                }
            }

            public override string ToString()
            {
                return Value.HasValue ? Value.Value.ToString() : $"[{Left!},{Right!}]";
            }
        }
    }
}
