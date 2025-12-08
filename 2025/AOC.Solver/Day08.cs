using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Runtime.InteropServices;

namespace AOC.Solver;

public static class Day08
{
    public static long SolvePart1(string[] input, int iterations)
    {
        var junctionBoxes = input
            .Select(line => new Vector3(CollectionsMarshal.AsSpan(line.Split(",").Select(float.Parse).ToList())))
            .ToArray();
        var distances = junctionBoxes.ToDictionary(j => j, j => junctionBoxes
            .Where(other => other != j)
            .Select(other => (Other: other, Distance: Vector3.Distance(j, other)))
            .OrderBy(kv => kv.Distance)
            .ToArray());
        var circuits = junctionBoxes.ToDictionary((_) => Guid.NewGuid(), j => new HashSet<Vector3>([j]));

        for (var i = 0; i < iterations; i++)
        {
            var shortestDistance = distances
                .OrderBy(kv => kv.Value[0].Distance)
                .Select(kv => (
                    From: kv.Key,
                    To: kv.Value[0])
                )
                .First();
            distances[shortestDistance.From] = distances[shortestDistance.From][1..];
            distances[shortestDistance.To.Other] =  distances[shortestDistance.To.Other][1..];

            var fromCircuit = circuits.First(c => c.Value.Contains(shortestDistance.From)).Key;
            var toCircuit = circuits.First(c => c.Value.Contains(shortestDistance.To.Other)).Key;
            if (fromCircuit == toCircuit) continue;

            foreach (var junction in circuits[fromCircuit])
            {
                circuits[toCircuit].Add(junction);
            }

            circuits.Remove(fromCircuit);
        }

        return circuits.Values
            .Select(grid => grid.Count)
            .OrderDescending()
            .Take(3)
            .Aggregate(1L, (a, b) => a * b);
    }

    public static long SolvePart2(string[] input)
    {
        var junctionBoxes = input
            .Select(line => new Vector3(CollectionsMarshal.AsSpan(line.Split(",").Select(float.Parse).ToList())))
            .ToArray();
        var distances = junctionBoxes.ToDictionary(j => j, j => junctionBoxes
            .Where(other => other != j)
            .Select(other => (Other: other, Distance: Vector3.Distance(j, other)))
            .OrderBy(kv => kv.Distance)
            .ToArray());
        var circuits = junctionBoxes.ToDictionary((_) => Guid.NewGuid(), j => new HashSet<Vector3>([j]));

        while (true)
        {
            var shortestDistance = distances
                .OrderBy(kv => kv.Value[0].Distance)
                .Select(kv => (
                    From: kv.Key,
                    To: kv.Value[0])
                )
                .First();
            distances[shortestDistance.From] = distances[shortestDistance.From][1..];
            distances[shortestDistance.To.Other] =  distances[shortestDistance.To.Other][1..];

            var fromCircuit = circuits.First(c => c.Value.Contains(shortestDistance.From)).Key;
            var toCircuit = circuits.First(c => c.Value.Contains(shortestDistance.To.Other)).Key;
            if (fromCircuit == toCircuit) continue;

            foreach (var junction in circuits[fromCircuit])
            {
                circuits[toCircuit].Add(junction);
            }

            circuits.Remove(fromCircuit);

            if (circuits.Count == 1)
            {
                return (long) shortestDistance.From.X * (long) shortestDistance.To.Other.X;
            }
        }
    }
}
