using System.Linq;

namespace AOC.Solver.Tools;

public record Neighbour(int DeltaY, int DeltaX)
{
    public static Neighbour North = new(-1, 0);
    public static Neighbour South = new(1, 0);
    public static Neighbour West = new(0, -1);
    public static Neighbour East = new(0, 1);

    public static Neighbour[] Orthogonal = new[]
    {
        North,
        South,
        West,
        East,
    };

    public static Neighbour From((int y, int x) a, (int y, int x) b) => new(a.y - b.y, a.x - b.x);

    public static T[] FindOrthogonalValues<T>(T[][] map, int y, int x) where T : struct
        => Orthogonal.Select(n => n.Apply(map, y, x)).OfType<T>().ToArray();

    public T? Apply<T>(T[][] map, int y, int x) where T : struct
    {
        y += DeltaY;
        x += DeltaX;
        if (y < 0 || y >= map.Length || x < 0 || x >= map[y].Length) return null;
        return map[y][x];
    }

    public T? Apply<T>(T[][] map, (int y, int x) value) where T : struct
        => Apply(map, value.y, value.x);

    public (int y, int x) Apply(int y, int x) => (y + DeltaY, x + DeltaX);

    public (int y, int x) Apply((int y, int x) value) => Apply(value.y, value.x);
}
