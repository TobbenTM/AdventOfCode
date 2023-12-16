using AOC.Solver;
using System.IO;
using System.Linq;
using Xunit;

namespace AOC.Runner;

public class Day14Tests
{
    private readonly string[] _input;

    public Day14Tests()
    {
        var lines = File.ReadAllLines("./Day14.input");
        _input = lines
            .Where(line => line.Length > 0)
            .ToArray();
    }

    [Fact]
    public void Part1()
    {
        var result = Day14.SolvePart1(_input);
        Assert.Equal(107142, result);
    }

    [Fact]
    public void Part1_Example()
    {
        var result = Day14.SolvePart1(new[]
        {
            "O....#....",
            "O.OO#....#",
            ".....##...",
            "OO.#O....O",
            ".O.....O#.",
            "O.#..O.#.#",
            "..O..#O..O",
            ".......O..",
            "#....###..",
            "#OO..#....",
        });
        Assert.Equal(136, result);
    }

    [Fact(Skip = "Slow")]
    public void Part2()
    {
        var result = Day14.SolvePart2(_input);
        Assert.Equal(104815, result);
    }

    [Fact]
    public void Part2_Example()
    {
        var result = Day14.SolvePart2(new[]
        {
            "O....#....",
            "O.OO#....#",
            ".....##...",
            "OO.#O....O",
            ".O.....O#.",
            "O.#..O.#.#",
            "..O..#O..O",
            ".......O..",
            "#....###..",
            "#OO..#....",
        });
        Assert.Equal(64, result);
    }
}
