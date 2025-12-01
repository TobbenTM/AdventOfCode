using System;
using System.Collections.Generic;
using System.Linq;

namespace AOC.Solver.Tools;

public class Map
{
    private readonly char[][] _map;

    public Map(string[] input)
    {
        _map = input.Select(line => line.ToCharArray()).ToArray();
    }

    public Map(char[][] input)
    {
        _map = input;
    }

    public int Height => _map.Length;

    public int Width => _map[0].Length;

    public char this[int row, int column]
    {
        get => _map[row][column];
        set => _map[row][column] = value;
    }

    public IEnumerable<(char Value, int Row, int Column)[]> Rows => _map
        .Select((row, ri) => row.Select((val, vi) => (val, ri, vi)).ToArray());

    public IEnumerable<(char Value, int Row, int Column)[]> Columns => Enumerable.Range(0, Width)
        .Select(col => _map.Select((row, ri) => (row[col], ri, col)).ToArray());

    public int SwapNeighbourWhile(int rowIndex, int colIndex, Direction direction, Func<char, bool> predicate)
    {
        var swaps = 0;
        while (true)
        {
            var (row, col) = direction.Apply(rowIndex, colIndex);
            if (row < 0 || row > Height - 1 || col < 0 || col > Width - 1) return swaps;
            if (!predicate(_map[row][col])) return swaps;

            (_map[rowIndex][colIndex], _map[row][col]) = (_map[row][col], _map[rowIndex][colIndex]);
            (rowIndex, colIndex) = (row, col);
            swaps++;
        }
    }

    public override string ToString()
    {
        var result = "";
        foreach (var row in Rows)
        {
            foreach (var (ch, _, _) in row)
            {
                result += ch;
            }

            result += "\n";
        }

        return result;
    }
}
