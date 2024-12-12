using AOC.Solver;
using System.IO;
using System.Linq;
using Xunit;

namespace AOC.Runner;

public class Day12Tests
{
    private readonly string[] _input;

    public Day12Tests()
    {
        var lines = File.ReadAllLines("./Day12.input");
        _input = lines
            .Where(line => line.Length > 0)
            .ToArray();
    }

    [Fact]
    public void Part1()
    {
        var result = Day12.SolvePart1(_input);
        Assert.Equal(1437300, result);
    }

    [Fact]
    public void Part1_Example1()
    {
        var result = Day12.SolvePart1([
            "AAAA",
            "BBCD",
            "BBCC",
            "EEEC"
        ]);
        Assert.Equal(140, result);
    }

    [Fact]
    public void Part2()
    {
        var result = Day12.SolvePart2(_input);
        Assert.Equal(849332, result);
    }

    [Fact]
    public void Part2_Example1()
    {
        var result = Day12.SolvePart2([
            "AAAA",
            "BBCD",
            "BBCC",
            "EEEC"
        ]);
        Assert.Equal(80, result);
    }

    [Fact]
    public void Part2_Example2()
    {
        var result = Day12.SolvePart2([
            "EEEEE",
            "EXXXX",
            "EEEEE",
            "EXXXX",
            "EEEEE"
        ]);
        Assert.Equal(236, result);
    }

    [Fact]
    public void Part2_Example3()
    {
        var result = Day12.SolvePart2([
            "AAAAAA",
            "AAABBA",
            "AAABBA",
            "ABBAAA",
            "ABBAAA",
            "AAAAAA"
        ]);
        Assert.Equal(368, result);
    }
}
