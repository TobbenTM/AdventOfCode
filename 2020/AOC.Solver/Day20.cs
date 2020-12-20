using System;
using System.Collections.Generic;
using System.Linq;

namespace AOC.Solver
{
    public static class Day20
    {
        public static long SolvePart1(string input)
        {
            var images = input.Split(new[] { "\n\n" }, StringSplitOptions.RemoveEmptyEntries)
                .Select(image => new Image(image))
                .ToArray();
            var corners = images.Select(image => (image, edges: images.Count(i => image.MatchingEdge(i))))
                .Where(x => x.edges == 2)
                .Select(x => (long)x.image.Id);
            return corners.Aggregate((a, b) => a * b);
        }

        public static int SolvePart2(string input)
        {
            var unMatchedImages = input.Split(new[] { "\n\n" }, StringSplitOptions.RemoveEmptyEntries)
                .Select(image => new Image(image))
                .ToList();
            var map = new Dictionary<(int x, int y), Image>();
            var initialCorner = unMatchedImages.First(i => 2 == unMatchedImages.Count(j => i.MatchingEdge(j)));
            map.Add((0, 0), initialCorner);
            unMatchedImages.Remove(initialCorner);
            throw new NotImplementedException("Part 2 not implemented yet!");
        }

        private class Image
        {
            public int Id { get; }

            private readonly string[] _edges;
            private readonly string[] _data;

            public Image(string input)
            {
                var lines = input.Split('\n').ToList();
                Id = int.Parse(lines.First().Split(' ').Last().Trim(':'));
                lines.RemoveAt(0);
                _edges = new[]
                {
                    lines.First(),
                    lines.Select(line => line.Last()).Aggregate("", (a, b) => a + b),
                    lines.Last(),
                    lines.Select(line => line.First()).Aggregate("", (a, b) => a + b),
                };
                _data = lines.Skip(1).Take(lines.Count - 2)
                    .Select(line => new string(line.Skip(1).Take(line.Length - 2).ToArray()))
                    .ToArray();
            }

            public bool MatchingEdge(Image other)
            {
                return Id != other.Id && _edges.Any(edge => other._edges.Any(otherEdge => edge == otherEdge || edge == new string(otherEdge.Reverse().ToArray())));
            }
        }
    }
}
