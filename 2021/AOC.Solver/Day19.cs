using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace AOC.Solver
{
    public static class Day19
    {
        private static Func<Vector3, Vector3[]>[] Orientations = new Func<Vector3, Vector3>[]
        {
            // All possible directions
            v => new Vector3(1, 1, 1),
            v => new Vector3(-1, 1, 1),
            v => new Vector3(1, 1, 1),
            v => new Vector3(1, 1, 1),
            v => new Vector3(1, 1, 1),
            v => new Vector3(1, 1, 1),
        }.SelectMany(f => (Vector3 v) => new[]
        {

        });

        public static int SolvePart1(string[] input)
        {
            var scanners = new List<Scanner>();
            for (var i = 0; i < input.Length; i++)
            {
                var beacons = new List<Vector3>();
                while (++i < input.Length && input[i].Length > 0)
                {
                    var coords = input[i].Split(',').Select(int.Parse).ToArray();
                    beacons.Add(new Vector3(coords[0], coords[1], coords[2]));
                }

                scanners.Add(new Scanner(beacons));
            }

            return scanners.Count;
        }

        public static int SolvePart2(string[] input)
        {
            throw new NotImplementedException("Part 2 not implemented yet!");
        }

        private class Scanner
        {
            private IEnumerable<Vector3> _normalizedOrderedBeacons;

            public Scanner(IEnumerable<Vector3> beacons)
            {
            }
        }
    }
}
