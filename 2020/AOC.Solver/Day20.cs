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
            foreach (var image in unMatchedImages)
            {
                image.FindAdjacentImages(unMatchedImages);
            }
            var map = new Dictionary<(int x, int y), Image>();
            var initialCorner = unMatchedImages.First(image => image.AdjacentImages.Count(i => i != null) == 2);
            map.Add((0, 0), initialCorner);
            unMatchedImages.Remove(initialCorner);

            throw new NotImplementedException("Part 2 not implemented yet!");
        }

        private class Image
        {
            public int Id { get; }
            public ImageOrientation Orientation { get; set; } = ImageOrientation.None;
            public Image[]? AdjacentImages => Transform(_adjacentImages, Orientation); 

            private readonly string[] _edges;
            private readonly string[] _data;
            private Image[]? _adjacentImages;

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

            public void FindAdjacentImages(List<Image> images)
            {
                _adjacentImages = _edges
                    .Select(edge => images.FirstOrDefault(i => i.Id != Id && i._edges.Any(e => e == edge || e == new string(edge.Reverse().ToArray()))))
                    .ToArray();
            }

            private static Image[] Transform(Image[]? adjacentImages, ImageOrientation orientation)
            {
                if (adjacentImages == null) return new Image[0];
                var copy = adjacentImages.ToArray();
                if (orientation.HasFlag(ImageOrientation.HFlipped))
                {
                    var tmp = copy[1];
                    copy[1] = copy[3];
                    copy[3] = tmp;
                }
                if (orientation.HasFlag(ImageOrientation.VFlipped))
                {
                    var tmp = copy[0];
                    copy[0] = copy[2];
                    copy[2] = tmp;
                }
                if (orientation.HasFlag(ImageOrientation.Rotated))
                {
                    var tmp = copy[0];
                    copy[0] = copy[1];
                    copy[1] = copy[2];
                    copy[2] = copy[3];
                    copy[3] = tmp;
                }
                return copy;
            }
        }

        [Flags]
        private enum ImageOrientation
        {
            None = 0,
            HFlipped = 1,
            VFlipped = 2,
            Rotated = 4,
        }
    }
}
