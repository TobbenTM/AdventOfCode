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
        Assert.Equal(674, result);
    }

    [Fact]
    public void Part1_ExampleData()
    {
        var result = Day14.SolvePart1(new[] { "498,4 -> 498,6 -> 496,6", "503,4 -> 502,4 -> 502,9 -> 494,9" });
        Assert.Equal(24, result);
    }

    [Fact]
    public void Part2()
    {
        var result = Day14.SolvePart2(_input);
        Assert.Equal(24958, result);
    }

    [Fact]
    public void Part2_ExampleData()
    {
        var result = Day14.SolvePart2(new[] { "498,4 -> 498,6 -> 496,6", "503,4 -> 502,4 -> 502,9 -> 494,9" });
        Assert.Equal(93, result);
    }
}
