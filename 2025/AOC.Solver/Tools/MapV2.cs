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

    public static (int row, int col) Multiply(this (int row, int col) position, int times) =>
        (position.row * times, position.col * times);

    public static (long row, long col) Multiply(this (int row, int col) position, long times) =>
        (position.row * times, position.col * times);

    public static (long row, long col) Subtract(this (long row, long col) position, (long rowDiff, long colDiff) diff) =>
        (position.row - diff.rowDiff, position.col - diff.colDiff);

    public static (long row, long col) Add(this (long row, long col) position, (long rowDiff, long colDiff) diff) =>
        (position.row + diff.rowDiff, position.col + diff.colDiff);

    public static (long row, long col) Multiply(this (long row, long col) position, long times) =>
        (position.row * times, position.col * times);
}

public class MapV2
{
    public class Entity(char value, int row, int col)
    {
        public char Value { get; set; } = value;
        public int Row { get; set; } = row;
        public int Col { get; set; } = col;

        public Direction? Direction { get; set; }

        public long Score { get; set; }

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

    public Dictionary<char, Entity[]> Entities =>
        _map.SelectMany(r => r).GroupBy(e => e.Value).ToDictionary(g => g.Key, g => g.ToArray());

    public MapV2(IEnumerable<string> input)
    {
        _map = input.Select((line, row) => line.ToCharArray().Select((c, col) => new Entity(c, row, col)).ToArray()).ToArray();
    }

    public int Height => _map.Length;

    public int Width => _map[0].Length;

    public Entity this[(int row, int col) position]
    {
        get
        {
            if (position.row < 0 || position.row > Height - 1 || position.col < 0 || position.col > Width - 1) throw new OutOfBoundsException();
            return _map[position.row][position.col];
        }
        set => _map[position.row][position.col] = value;
    }

    public Entity this[int row, int column]
    {
        get => _map[row][column];
        set => _map[row][column] = value;
    }

    public Entity? TryGet((int row, int col) position)
    {
        if (position.row < 0 || position.row > Height - 1 || position.col < 0 || position.col > Width - 1) return null;
        return _map[position.row][position.col];
    }


    public IEnumerable<Entity[]> Rows => _map.Select(row => row);

    public IEnumerable<Entity[]> Columns => Enumerable.Range(0, Width)
        .Select(col => _map.Select(row => row[col]).ToArray());

    public IEnumerable<Entity> Neighbours((int row, int col) position, Direction[] directions) =>
        directions.Select(d => TryGet(d.Apply(position))).OfType<Entity>();

    public void Swap(Entity entity, Direction direction) =>
        Swap(entity.Row, entity.Col, direction);

    public void Swap(int rowIndex, int colIndex, Direction direction)
    {
        var (row, col) = direction.Apply(rowIndex, colIndex);
        if (row < 0 || row > Height - 1 || col < 0 || col > Width - 1) throw new OutOfBoundsException();

        (_map[rowIndex][colIndex], _map[row][col]) = (_map[row][col], _map[rowIndex][colIndex]);
        _map[rowIndex][colIndex].Swapped(_map[row][col]);
    }

    public int SwapNeighbourWhile(Entity entity, Direction direction, Func<Entity, bool> predicate) =>
        SwapNeighbourWhile(entity.Row, entity.Col, direction, predicate);

    public int SwapNeighbourWhile(int rowIndex, int colIndex, Direction direction, Func<Entity, bool> predicate)
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
            result = row.Aggregate(result, (current, entity) => current + entity.Value);
            result += "\n";
        }

        return result;
    }
}
