using System;
using System.Collections.Generic;
using System.Linq;
using AOC.Solver.Tools;

namespace AOC.Solver;

public static class Day15
{
    public static int SolvePart1(string[] input)
    {
        var map = new MapV2(input.TakeWhile(l => l.Length > 0));
        var directions = input.SkipWhile(l => l.Length > 0).Skip(1).SelectMany(l => l.Select(Direction.Parse)).ToArray();

        var robot = map.Entities['@'].Single();
        foreach (var direction in directions)
        {
            var position = direction.Apply(robot.Position);
            if (map[position].Value == '#') continue;
            if (map[position].Value == '.')
            {
                map.Swap(robot, direction);
                continue;
            }

            var neighboursToShift = new Stack<MapV2.Entity>();
            while (map[position].Value == 'O')
            {
                neighboursToShift.Push(map[position]);
                position = direction.Apply(position);
            }
            if (map[position].Value == '#') continue;
            while (neighboursToShift.Any())
            {
                map.Swap(neighboursToShift.Pop(), direction);
            }
            map.Swap(robot, direction);
        }

        var boxes = map.Entities['O'];
        return boxes.Sum(b => b.Col + b.Row * 100);
    }

    public static int SolvePart2(string[] input)
    {
        var map = new MapV2(input.TakeWhile(l => l.Length > 0).Select(l => string.Join("", l.Select(ch => ch switch
        {
            '#' => "##",
            'O' => "[]",
            '.' => "..",
            '@' => "@.",
            _ => throw new ArgumentOutOfRangeException(nameof(ch), ch, null)
        }))));
        var directions = input.SkipWhile(l => l.Length > 0).Skip(1).SelectMany(l => l.Select(Direction.Parse)).ToArray();

        var robot = map.Entities['@'].Single();
        foreach (var direction in directions)
        {
            var position = direction.Apply(robot.Position);
            if (map[position].Value == '#') continue;
            if (map[position].Value == '.')
            {
                map.Swap(robot, direction);
                continue;
            }

            var neighboursToShift = new Stack<MapV2.Entity>();
            MapV2.Entity[] lastBatch = [robot];
            while (lastBatch.Any())
            {
                var nextPositions = lastBatch.Select(b => direction.Apply(b.Position)).ToArray();
                if (nextPositions.Any(b => map[b].Value == '#')) break;
                var batch = new List<MapV2.Entity>();
                foreach (var neighbourPosition in nextPositions)
                {
                    if (batch.Any(b => b.Position == neighbourPosition)) continue;
                    if (map[neighbourPosition].Value == '[')
                    {
                        if (direction == Direction.East)
                        {
                            // We need to push the western one first
                            neighboursToShift.Push(map[neighbourPosition]);
                            neighboursToShift.Push(map[Direction.East.Apply(neighbourPosition)]);
                        }
                        else
                        {
                            neighboursToShift.Push(map[Direction.East.Apply(neighbourPosition)]);
                            neighboursToShift.Push(map[neighbourPosition]);
                        }
                        if (direction == Direction.West || direction == Direction.East)
                            batch.AddRange(neighboursToShift.Take(1));
                        else
                            batch.AddRange(neighboursToShift.Take(2));
                    }
                    else if (map[neighbourPosition].Value == ']')
                    {
                        if (direction == Direction.West)
                        {
                            // We need to push the eastern one first
                            neighboursToShift.Push(map[neighbourPosition]);
                            neighboursToShift.Push(map[Direction.West.Apply(neighbourPosition)]);
                        }
                        else
                        {
                            neighboursToShift.Push(map[Direction.West.Apply(neighbourPosition)]);
                            neighboursToShift.Push(map[neighbourPosition]);
                        }
                        if (direction == Direction.West || direction == Direction.East)
                            batch.AddRange(neighboursToShift.Take(1));
                        else
                            batch.AddRange(neighboursToShift.Take(2));
                    }
                }
                lastBatch = batch.ToArray();
            }

            if (neighboursToShift.Select(b => direction.Apply(b.Position)).Any(b => map[b].Value == '#')) continue;

            // Console.WriteLine($"Before moving {direction}:");
            // Console.WriteLine(map.ToString());

            while (neighboursToShift.Any())
            {
                map.Swap(neighboursToShift.Pop(), direction);
            }
            map.Swap(robot, direction);

            // Console.WriteLine($"After moving {direction}:");
            // Console.WriteLine(map.ToString());
        }

        var boxes = map.Entities['['];
        return boxes.Sum(b => b.Col + b.Row * 100);
    }
}
