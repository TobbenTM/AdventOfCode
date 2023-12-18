using AOC.Solver;
using System.IO;
using System.Linq;
using Xunit;

namespace AOC.Runner;

public class Day18Tests
{
    private readonly string[] _input;

    public Day18Tests()
    {
        var lines = File.ReadAllLines("./Day18.input");
        _input = lines
            .Where(line => line.Length > 0)
            .ToArray();
    }

    [Fact]
    public void Part1_Example()
    {
        var result = Day18.SolvePart1(new []
        {
            "R 6 (#70c710)",
            "D 5 (#0dc571)",
            "L 2 (#5713f0)",
            "D 2 (#d2c081)",
            "R 2 (#59c680)",
            "D 2 (#411b91)",
            "L 5 (#8ceee2)",
            "U 2 (#caa173)",
            "L 1 (#1b58a2)",
            "U 2 (#caa171)",
            "R 2 (#7807d2)",
            "U 3 (#a77fa3)",
            "L 2 (#015232)",
            "U 2 (#7a21e3)",
        });
        Assert.Equal(62, result);
    }

    [Fact]
    public void Part1()
    {
        var result = Day18.SolvePart1(_input);
        Assert.Equal(52035, result);
    }

    [Fact]
    public void Part2_Example()
    {
        var result = Day18.SolvePart2(new []
        {
            "R 6 (#70c710)",
            "D 5 (#0dc571)",
            "L 2 (#5713f0)",
            "D 2 (#d2c081)",
            "R 2 (#59c680)",
            "D 2 (#411b91)",
            "L 5 (#8ceee2)",
            "U 2 (#caa173)",
            "L 1 (#1b58a2)",
            "U 2 (#caa171)",
            "R 2 (#7807d2)",
            "U 3 (#a77fa3)",
            "L 2 (#015232)",
            "U 2 (#7a21e3)",
        });
        Assert.Equal(952408144115, result);
    }

    [Fact]
    public void Part2()
    {
        var result = Day18.SolvePart2(_input);
        Assert.Equal(60612092439765L, result);
    }
}
