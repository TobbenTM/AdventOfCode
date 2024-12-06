using AOC.Solver;
using System.IO;
using System.Linq;
using Xunit;

namespace AOC.Runner;

public class Day06Tests
{
    private readonly string[] _input;

    public Day06Tests()
    {
        var lines = File.ReadAllLines("./Day06.input");
        _input = lines
            .Where(line => line.Length > 0)
            .ToArray();
    }

    [Fact]
    public void Part1()
    {
        var result = Day06.SolvePart1(_input);
        Assert.Equal(4665, result);
    }

    [Fact]
    public void Part1_Example()
    {
        var result = Day06.SolvePart1([
        "....#.....",
        ".........#",
        "..........",
        "..#.......",
        ".......#..",
        "..........",
        ".#..^.....",
        "........#.",
        "#.........",
        "......#..."]);
        Assert.Equal(41, result);
    }

    [Fact]
    public void Part2()
    {
        var result = Day06.SolvePart2(_input);
        Assert.Equal(1688, result);
    }
}
