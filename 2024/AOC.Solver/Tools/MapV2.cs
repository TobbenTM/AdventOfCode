using System;
using System.Collections.Generic;
using System.Linq;

namespace AOC.Solver.Tools;

public static class PositionExtensions
{
    public static (int row, int col) Subtract(this (int row, int col) position, (int rowDiff, int colDiff) diff) =>
        (position.row - diff.rowDiff, position.col - diff.colDiff);
    public static (int row, int col) Add(this (int row, int col) position, (int rowDiff, int colDiff) diff) =>
        (position.row + diff.rowDiff, position.col + diff.colDiff);
}

public class MapV2
{
    public class Entity(char value, int row, int col)
    {
        public char Value { get; set; } = value;
        public int Row { get; set; } = row;
        public int Col { get; set; } = col;

        public (int row, int col) Position => (Row, Col);

        public List<(int, int)> History { get; init; } = [(row, col)];

        public void Swapped(Entity entity)
        {
            (Row, entity.Row) = (entity.Row, Row);
            (Col, entity.Col) = (entity.Col, Col);
            History.Add((Row, Col));
            entity.History.Add((entity.Row, entity.Col));
        }

        public Entity Clone() => new(Value, Row, Col) {History = History.ToList()};

        public string FormatHistory(MapV2 map)
        {
            var result = "";
            for (var row = 0; row < map.Height; row++)
            {
                for (var col = 0; col < map.Width; col++)
                {
                    result += History.Contains((row, col)) ? "X" : map[row, col].Value;
                }
                result += "\n";
            }

            return result;
        }

        public (int rowDiff, int colDiff) Distance(Entity other)
        {
            var rowDiff = Row - other.Row;
            var colDiff = Col - other.Col;
            return (rowDiff, colDiff);
        }
    }

    private readonly Entity[][] _map;
    public Dictionary<char, Entity[]> Entities { get; init; }

    public MapV2(string[] input)
    {
        _map = input.Select((line, row) => line.ToCharArray().Select((c, col) => new Entity(c, row, col)).ToArray()).ToArray();
        Entities = _map.SelectMany(r => r).GroupBy(e => e.Value).ToDictionary(g => g.Key, g => g.ToArray());
    }

    public int Height => _map.Length;

    public int Width => _map[0].Length;

    public Entity this[int row, int column]
    {
        get => _map[row][column];
        set => _map[row][column] = value;
    }

    public IEnumerable<Entity[]> Rows => _map.Select(row => row);

    public IEnumerable<Entity[]> Columns => Enumerable.Range(0, Width)
        .Select(col => _map.Select(row => row[col]).ToArray());

    public int SwapNeighbourWhile(Entity entity, Neighbour direction, Func<Entity, bool> predicate) =>
        SwapNeighbourWhile(entity.Row, entity.Col, direction, predicate);

    public int SwapNeighbourWhile(int rowIndex, int colIndex, Neighbour direction, Func<Entity, bool> predicate)
    {
        var swaps = 0;
        while (true)
        {
            var (row, col) = direction.Apply(rowIndex, colIndex);
            if (row < 0 || row > Height - 1 || col < 0 || col > Width - 1) throw new OutOfBoundsException();
            if (!predicate(_map[row][col])) return swaps;

            (_map[rowIndex][colIndex], _map[row][col]) = (_map[row][col], _map[rowIndex][colIndex]);
            _map[rowIndex][colIndex].Swapped(_map[row][col]);
            (rowIndex, colIndex) = (row, col);
            swaps++;
        }
    }

    public override string ToString()
    {
        var result = "";
        foreach (var row in Rows)
        {
            result += row.Aggregate(result, (current, entity) => current + entity.Value);
            result += "\n";
        }

        return result;
    }

    public class OutOfBoundsException : Exception;
}
