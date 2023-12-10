using System;
using System.Collections.Generic;
using System.Linq;
using AOC.Solver.Tools;

namespace AOC.Solver;

public static class Day10
{
    private static readonly Dictionary<char, Neighbour[]> Pipes = new()
    {
        { '|', new []{ Neighbour.North, Neighbour.South } },
        { '-', new []{ Neighbour.West, Neighbour.East } },
        { 'L', new []{ Neighbour.North, Neighbour.East } },
        { 'J', new []{ Neighbour.North, Neighbour.West } },
        { '7', new []{ Neighbour.West, Neighbour.South } },
        { 'F', new []{ Neighbour.South, Neighbour.East } },
        { '.', Array.Empty<Neighbour>() },
    };

    public static int SolvePart1(string[] input)
    {
        var map = input.Select(line => line.ToCharArray()).ToArray();
        (int y, int x) current = FindStart(map);

        var steps = 1;
        var previous = current;

        current = Neighbour.Orthogonal
            .Select(d => (Pipe: d.Apply(map, current), Position: d.Apply(current)))
            .Where(c => c.Pipe != null)
            .First(c => Pipes[c.Pipe!.Value].Any(d => d.Apply(c.Position) == current))
            .Position;

        var currentPipe = map[current.y][current.x];
        do
        {
            steps++;
            var possibleNextSteps = Pipes[currentPipe]
                .Select(d => d.Apply(current))
                .Where(pos => pos != previous)
                .ToArray();
            previous = current;
            current = possibleNextSteps.Single();
            currentPipe = map[current.y][current.x];
        } while (currentPipe != 'S');

        return steps / 2;
    }

    public static int SolvePart2(string[] input)
    {
        var map = input.Select(line => line.ToCharArray()).ToArray();
        var current = FindStart(map);
        var start = current;
        var previous = current;

        var startNeighbours = Neighbour.Orthogonal
            .Select(d => (Direction: d, Pipe: d.Apply(map, current), Position: d.Apply(current)))
            .Where(c => c.Pipe != null)
            .Where(c => Pipes[c.Pipe!.Value].Any(d => d.Apply(c.Position) == current))
            .ToArray();

        current = startNeighbours.First().Position;
        var startingPipe = Pipes
            .Single(kv => kv.Value.Intersect(startNeighbours.Select(x => x.Direction)).Count() == 2)
            .Key;
        map[start.y][start.x] = startingPipe;

        var currentPipe = map[current.y][current.x];
        var pipes = new Dictionary<(int y, int x), char>
        {
            {
                previous, startingPipe
            },
            {
                current, currentPipe
            },
        };
        do
        {
            var possibleNextSteps = Pipes[currentPipe]
                .Select(d => d.Apply(current))
                .Where(pos => pos != previous)
                .ToArray();
            previous = current;
            current = possibleNextSteps.Single();
            currentPipe = map[current.y][current.x];
            pipes.TryAdd(current, currentPipe);
        } while (current != start);

        for (var y = 0; y < map.Length; y++)
        {
            var pipesToOutside = 0;
            for (var x = 0; x < map[y].Length; x++)
            {
                if (pipes.ContainsKey((y, x)))
                {
                    var first = (y, x);
                    while (Pipes[map[y][x]].Any(n => n.DeltaX == 1))
                    {
                        ++x;
                    }

                    var last = (y, x);
                    if (first != last
                        && Pipes[map[first.y][first.x]].Single(n => n != Neighbour.West && n != Neighbour.East)
                        == Pipes[map[last.y][last.x]].Single(n => n != Neighbour.West && n != Neighbour.East))
                    {
                        continue;
                    }

                    pipesToOutside++;
                    continue;
                }

                map[y][x] = pipesToOutside % 2 == 1 ? 'I' : 'O';
            }
        }

        return map.SelectMany(r => r).Count(c => c == 'I');
    }

    private static (int y, int x) FindStart(char[][] map)
    {
        for (var y = 0; y < map.Length; y++)
        {
            for (var x = 0; x < map[y].Length; x++)
            {
                if (map[y][x] == 'S')
                    return (y, x);
            }
        }

        throw new InvalidOperationException("Could not find starting position");
    }
}
