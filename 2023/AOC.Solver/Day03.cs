using System;
using System.Collections.Generic;
using System.Linq;

namespace AOC.Solver;

public static class Day03
{
    public static int SolvePart1(string[] input)
    {
        var map = input.Select(line => line.ToCharArray()).ToArray();
        var result = 0;

        for (var line = 0; line < map.Length; line++)
        {
            for (var offset = 0; offset < map[line].Length; offset++)
            {
                var ch = map[line][offset];
                var isNumber = ch is >= '0' and <= '9';
                if (!isNumber) continue;

                var numberString = ch.ToString();
                var positions = new List<(int line, int offset)>
                {
                    (line, offset),
                };
                while (offset < map[line].Length - 1 && map[line][offset+1] is >= '0' and <= '9')
                {
                    offset++;
                    numberString += map[line][offset];
                    positions.Add((line, offset));
                }

                if (positions.Any(p => HasSymbolNeighbour(map, p.line, p.offset))) result += int.Parse(numberString);
            }
        }

        return result;
    }

    public static int SolvePart2(string[] input)
    {
        var map = input.Select(line => line.ToCharArray()).ToArray();
        var result = 0;

        for (var line = 0; line < map.Length; line++)
        {
            for (var offset = 0; offset < map[line].Length; offset++)
            {
                var ch = map[line][offset];
                if (ch != '*') continue;

                (int line, int offset)[] neighbouringNumberPositions = Neighbours
                    .Where(pos =>
                        line + pos.x >= 0
                        && line + pos.x < map.Length
                        && offset + pos.y >= 0
                        && offset + pos.y < map[line].Length
                        && map[line + pos.x][offset + pos.y] is >= '0' and <= '9')
                    .Select(pos => (line + pos.x, offset + pos.y))
                    .ToArray();
                var neighbouringNumbers = neighbouringNumberPositions
                    .Select(pos => ParseNumberFromPosition(map, pos.line, pos.offset))
                    .Distinct() // risky
                    .ToArray();

                if (neighbouringNumbers.Length == 2)
                {
                    result += neighbouringNumbers[0] * neighbouringNumbers[1];
                }
            }
        }

        return result;
    }

    private static readonly (int x, int y)[] Neighbours = new[]
    {
        (-1, -1),
        (-1, 0),
        (-1, 1),
        (0, 1),
        (0, -1),
        (1, -1),
        (1, 0),
        (1, 1),
    };

    private static bool HasSymbolNeighbour(char[][] map, int line, int offset)
    {
        return Neighbours.Any(pos =>
            line + pos.x >= 0
            && line + pos.x < map.Length
            && offset + pos.y >= 0
            && offset + pos.y < map[line].Length
            && map[line + pos.x][offset + pos.y] is (< '0' or > '9') and not '.');
    }

    private static int ParseNumberFromPosition(char[][] map, int line, int offset)
    {
        while (offset > 0 && map[line][offset - 1] is >= '0' and <= '9') offset--;
        var numberString = map[line][offset].ToString();
        while (offset < map[line].Length - 1 && map[line][offset+1] is >= '0' and <= '9')
        {
            offset++;
            numberString += map[line][offset];
        }

        return int.Parse(numberString);
    }
}
