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
            var size = Math.Sqrt(unMatchedImages.Count);
            var dataSize = (int)size * unMatchedImages[0].DataWidth;
            foreach (var image in unMatchedImages)
            {
                image.FindAdjacentImages(unMatchedImages);
            }
            var map = new Dictionary<(int x, int y), Image>();
            var initialCorner = unMatchedImages.First(image => image.AdjacentImages.Count(i => i != null) == 2);
            while (initialCorner.AdjacentImages[1] == null || initialCorner.AdjacentImages[2] == null) initialCorner.Rotate();
            map.Add((0, 0), initialCorner);
            unMatchedImages.Remove(initialCorner);

            for (var y = 0; y < size; y++)
            {
                for (var x = 0; x < size; x++)
                {
                    if (map.ContainsKey((x, y))) continue;
                    if (y == 0)
                    {
                        var left = map[(x - 1, 0)];
                        var next = left.AdjacentImages[1];
                        while (left != next.AdjacentImages[3]) next.Rotate();
                        if (next.AdjacentImages[0] != null) next.VFlip();
                        unMatchedImages.Remove(next);
                        map.Add((x, y), next);
                    }
                    else
                    {
                        var top = map[(x, y - 1)];
                        var next = top.AdjacentImages[2];
                        while (top != next.AdjacentImages[0]) next.Rotate();
                        if (x == 1 && map[(0, y)].AdjacentImages[1] != next) map[(0, y)].HFlip();
                        if (x >= 1 && next.AdjacentImages[3] != map[(x - 1, y)]) next.HFlip();
                        unMatchedImages.Remove(next);
                        map.Add((x, y), next);
                    }
                }
            }

            var roughSeaMap = new HashSet<(int x, int y)>();
            foreach (var kv in map)
            {
                var roughSea = kv.Value.CalculateRoughSea(kv.Key.x, kv.Key.y);
                foreach (var point in roughSea)
                {
                    roughSeaMap.Add(point);
                }
            }

            var seaMonsterPattern = new[]
            {
                "                  # ",
                "#    ##    ##    ###",
                " #  #  #  #  #  #   ",
            };
            var seaMonster = seaMonsterPattern.SelectMany((line, y) => line.Select((c, x) => c == ' ' ? (x: -1, y: -1) : (x, y)))
                    .Where(x => x.x >= 0)
                    .ToArray();

            for (var flip = 0; flip < 3; flip++)
            {
                if (flip == 1)
                {
                    roughSeaMap = FlipHorisontally(roughSeaMap, dataSize);
                }
                else if (flip == 2)
                {
                    roughSeaMap = FlipVertically(FlipHorisontally(roughSeaMap, dataSize), dataSize);
                }
                for (var rotate = 0; rotate < 4; rotate++)
                {
                    var monstersFound = FindPatterns(roughSeaMap, seaMonster, dataSize);
                    if (monstersFound > 0) return roughSeaMap.Count - monstersFound * seaMonster.Count();
                    roughSeaMap = Rotate(roughSeaMap, dataSize);
                }
            }

            throw new InvalidOperationException("No suitable orientations found!");
        }

        private static HashSet<(int x, int y)> Rotate(HashSet<(int x, int y)> set, int size)
        {
            return new HashSet<(int x, int y)>(set.Select(point => (-point.y + size, point.x)));
        }

        private static HashSet<(int x, int y)> FlipHorisontally(HashSet<(int x, int y)> set, int size)
        {
            return new HashSet<(int x, int y)>(set.Select(point => (size - point.x, point.y)));
        }

        private static HashSet<(int x, int y)> FlipVertically(HashSet<(int x, int y)> set, int size)
        {
            return new HashSet<(int x, int y)>(set.Select(point => (point.x, size - point.y)));
        }

        private static int FindPatterns(HashSet<(int x, int y)> map, (int x, int y)[] pattern, int size)
        {
            var numberFound = 0;
            for (var y = 0; y < size - pattern.Select(p => p.y).Max(); y++)
            {
                for (var x = 0; x < size - pattern.Select(p => p.x).Max(); x++)
                {
                    if (pattern.All(point => map.Contains((point.x + x, point.y + y))))
                    {
                        numberFound += 1;
                    }
                }
            }
            return numberFound;
        }

        private class Image
        {
            public int Id { get; }
            public int DataWidth => _data.Length;
            public Image[] AdjacentImages => _adjacentImages;

            private readonly string[] _edges;
            private readonly string[] _data;
            private Image[] _adjacentImages = default!;

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

            public void Rotate()
            {
                ShiftArray(_edges);
                ShiftArray(_adjacentImages);
                var rotatedData = Enumerable.Range(0, _data.Length)
                    .Select(i => new string(_data.Select(line => line[_data.Length - i - 1]).ToArray()))
                    .ToArray();
                Array.Copy(rotatedData, _data, _data.Length);
            }

            public void HFlip()
            {
                var tempEdge = _edges[1];
                _edges[1] = _edges[3];
                _edges[3] = tempEdge;
                _edges[0] = new string(_edges[0].Reverse().ToArray());
                _edges[2] = new string(_edges[2].Reverse().ToArray());
                var tempImage = _adjacentImages[1];
                _adjacentImages[1] = _adjacentImages[3];
                _adjacentImages[3] = tempImage;
                var flippedData = _data.Select(line => new string(line.Reverse().ToArray())).ToArray();
                Array.Copy(flippedData, _data, _data.Length);
            }

            public void VFlip()
            {
                var tempEdge = _edges[0];
                _edges[0] = _edges[2];
                _edges[2] = tempEdge;
                _edges[1] = new string(_edges[1].Reverse().ToArray());
                _edges[3] = new string(_edges[3].Reverse().ToArray());
                var tempImage = _adjacentImages[0];
                _adjacentImages[0] = _adjacentImages[2];
                _adjacentImages[2] = tempImage;
                var flippedData = _data.Reverse().ToArray();
                Array.Copy(flippedData, _data, _data.Length);
            }

            public (int x, int y)[] CalculateRoughSea(int xOffset, int yOffset)
            {
                return _data.SelectMany((line, y) => line.Select((c, x) => c == '.' ? (x: -1, y: -1) : (x: xOffset * _data.Length + x, y: yOffset * _data.Length + y)))
                    .Where(x => x.x >= 0)
                    .ToArray();
            }

            private void ShiftArray<T>(T[] arr)
            {
                var temp = arr[0];
                Array.Copy(arr, 1, arr, 0, arr.Length - 1);
                arr[arr.Length - 1] = temp;
            }
        }
    }
}
