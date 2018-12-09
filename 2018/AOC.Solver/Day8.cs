using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;

namespace AOC.Solver
{
    public static class Day8
    {
        public static int SolvePart1(int[] input)
        {
            var result = TreeNode.Create(input);

            return result.node.DeepSum;
        }

        public static int SolvePart2(int[] input)
        {
            var result = TreeNode.Create(input);

            return result.node.CalculateValue();
        }

        private class TreeNode
        {
            public int[] Metadata { get; set; }
            public List<TreeNode> Children { get; set; }
            public int DeepCount => Metadata.Length + Children.Sum(n => n.DeepCount);
            public int DeepSum => Metadata.Sum() + Children.Sum(n => n.DeepSum);

            public int CalculateValue() {
                if (Children.Count == 0) {
                    return Metadata.Sum();
                }
                return Metadata
                    .Select(m => m == 0 || m > Children.Count ? null : Children[m - 1])
                    .Where(n => n != null)
                    .Sum(n => n.CalculateValue());
            }

            public static (int skip, TreeNode node) Create(int[] input)
            {
                var childrenCount = input[0];
                var metadataCount = input[1];
                var offset = 2;
                var children = new List<TreeNode>();
                for (var i = 0; i < childrenCount; i++)
                {
                    var result = Create(input.Skip(offset).ToArray());
                    offset += result.skip;
                    children.Add(result.node);
                }
                var node = new TreeNode
                {
                    Metadata = input.Skip(offset).Take(metadataCount).ToArray(),
                    Children = children,
                };
                return (offset + metadataCount, node);
            }
        }
    }
}
