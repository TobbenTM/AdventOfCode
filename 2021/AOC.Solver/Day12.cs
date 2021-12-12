using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace AOC.Solver
{
    public static class Day12
    {
        public static int SolvePart1(string[] input)
        {
            var map = CreateMap(input);

            return map["start"]
                .Select(neighbour => ExploreCavesV1(
                    map: map,
                    entry: neighbour,
                    path: new[] {"start"}.ToImmutableArray()))
                .Sum();
        }

        public static int SolvePart2(string[] input)
        {
            var map = CreateMap(input);

            return map["start"]
                .Select(neighbour => ExploreCavesV2(
                    map: map,
                    entry: neighbour,
                    path: new[] {"start"}.ToImmutableArray(),
                    hasVisitedSmallCaveTwice: false))
                .Sum();
        }

        private static ImmutableDictionary<string, HashSet<string>> CreateMap(string[] input)
        {
            var map = new Dictionary<string, HashSet<string>>();

            var connections = input.Select(line => line.Split("-")).ToList();
            foreach (var cave in connections.SelectMany(c => c).Distinct())
            {
                map[cave] = new HashSet<string>();
            }
            foreach (var connection in connections)
            {
                map[connection[0]].Add(connection[1]);
                map[connection[1]].Add(connection[0]);
            }

            return map.ToImmutableDictionary();
        }

        private static int ExploreCavesV1(
            ImmutableDictionary<string, HashSet<string>> map,
            string entry,
            ImmutableArray<string> path)
        {
            if (entry == "end") return 1;
            return map[entry]
                .Where(neighbour => Char.IsUpper(neighbour[0]) || !path.Contains(neighbour))
                .Select(validNeighbour => ExploreCavesV1(map, validNeighbour, path.Add(entry)))
                .Sum();
        }

        private static int ExploreCavesV2(
            ImmutableDictionary<string, HashSet<string>> map,
            string entry,
            ImmutableArray<string> path,
            bool hasVisitedSmallCaveTwice)
        {
            if (entry == "end") return 1;
            if (!hasVisitedSmallCaveTwice && path
                    .Add(entry)
                    .Where(node => Char.IsLower(node[0]))
                    .GroupBy(node => node)
                    .Any(g => g.Count() == 2))
            {
                hasVisitedSmallCaveTwice = true;
            }
            return map[entry]
                .Where(neighbour => neighbour != "start" &&
                    (Char.IsUpper(neighbour[0]) || !hasVisitedSmallCaveTwice || !path.Contains(neighbour)))
                .Select(validNeighbour => ExploreCavesV2(map, validNeighbour, path.Add(entry), hasVisitedSmallCaveTwice))
                .Sum();
        }
    }
}
