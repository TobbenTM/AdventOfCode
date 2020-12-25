using System.Collections.Generic;
using System.Linq;

namespace AOC.Solver
{
    public static class Day24
    {
        public static int SolvePart1(string[] input)
        {
            var tiles = input.Select(ParseDirections);
            var blackedTiles = ApplyDirections(tiles);
            return blackedTiles.Count;
        }

        public static int SolvePart2(string[] input)
        {
            var neighborsDirections = new[]
            {
                (x: +1, y: -1, z: 0),
                (x: +1, y: 0, z: -1),
                (x: 0, y: +1, z: -1),
                (x: -1, y: +1, z: 0),
                (x: -1, y: 0, z: +1),
                (x: 0, y: -1, z: +1),
            };
            var tiles = input.Select(ParseDirections);
            var blackedTiles = ApplyDirections(tiles);
            for (var i = 0; i < 100; i++)
            {
                var interestingTiles = new HashSet<(int x, int y, int z)>();
                foreach (var tile in blackedTiles
                    .SelectMany(t => neighborsDirections.Select(dir => (x: t.x + dir.x, y: t.y + dir.y, z: t.z + dir.z)))
                    .Concat(blackedTiles))
                {
                    interestingTiles.Add(tile);
                }
                var newMap = new HashSet<(int x, int y, int z)>();
                foreach (var (x, y, z) in interestingTiles)
                {
                    var neighbors = neighborsDirections.Count(dir => blackedTiles.Contains((x + dir.x, y + dir.y, z + dir.z)));
                    if (blackedTiles.Contains((x, y, z)))
                    {
                        if (neighbors > 0 && neighbors <= 2)
                        {
                            newMap.Add((x, y, z));
                        }
                    }
                    else
                    {
                        if (neighbors == 2)
                        {
                            newMap.Add((x, y, z));
                        }
                    }
                }
                blackedTiles = newMap;
            }
            return blackedTiles.Count;
        }

        private static IEnumerable<string> ParseDirections(string input)
        {
            for (var i = 0; i < input.Length; i++)
            {
                if (input[i] == 's' || input[i] == 'n')
                {
                    yield return new string(new[] { input[i], input[i + 1] });
                    i += 1;
                }
                else
                {
                    yield return new string(new[] { input[i] });
                }
            }
        }

        private static HashSet<(int x, int y, int z)> ApplyDirections(IEnumerable<IEnumerable<string>> tiles)
        {
            var blackedTiles = new HashSet<(int x, int y, int z)>();
            foreach (var directions in tiles)
            {
                var pos = (x: 0, y: 0, z: 0);
                foreach (var direction in directions)
                {
                    switch (direction)
                    {
                        case "e":
                            pos.x += 1;
                            pos.y -= 1;
                            break;
                        case "se":
                            pos.y -= 1;
                            pos.z += 1;
                            break;
                        case "sw":
                            pos.x -= 1;
                            pos.z += 1;
                            break;
                        case "w":
                            pos.x -= 1;
                            pos.y += 1;
                            break;
                        case "ne":
                            pos.x += 1;
                            pos.z -= 1;
                            break;
                        case "nw":
                            pos.z -= 1;
                            pos.y += 1;
                            break;
                    }
                }
                if (blackedTiles.Contains(pos))
                {
                    blackedTiles.Remove(pos);
                }
                else
                {
                    blackedTiles.Add(pos);
                }
            }
            return blackedTiles;
        }
    }
}
