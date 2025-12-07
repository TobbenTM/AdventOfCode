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
        Assert.Equal(4387670995909L, result);
    }

    [Fact]
    public void Part1_Example()
    {
        var result = Day06.SolvePart1([
            "123 328  51 64 ",
            " 45 64  387 23 ",
            "  6 98  215 314",
            "*   +   *   +  ",
        ]);
        Assert.Equal(4277556L, result);
    }

    [Fact]
    public void Part2()
    {
        var result = Day06.SolvePart2(_input);
        Assert.Equal(9625320374409L, result);
    }

    [Fact]
    public void Part2_Example()
    {
        var result = Day06.SolvePart2([
            "123 328  51 64 ",
            " 45 64  387 23 ",
            "  6 98  215 314",
            "*   +   *   +  ",
        ]);
        Assert.Equal(3263827L, result);
    }
}
