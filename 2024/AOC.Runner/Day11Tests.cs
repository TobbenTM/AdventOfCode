using AOC.Solver;
using System.IO;
using System.Linq;
using Xunit;

namespace AOC.Runner;

public class Day11Tests
{
    private readonly string _input;

    public Day11Tests()
    {
        var lines = File.ReadAllLines("./Day11.input");
        _input = lines.Single();
    }

    [Fact]
    public void Part1()
    {
        var result = Day11.Solve(_input, 25);
        Assert.Equal(197357, result);
    }

    [Fact]
    public void Part1_Example1()
    {
        var result = Day11.Solve("125 17", 6);
        Assert.Equal(22, result);
    }

    [Fact]
    public void Part1_Example2()
    {
        var result = Day11.Solve("125 17", 25);
        Assert.Equal(55312, result);
    }

    [Fact]
    public void Part2()
    {
        var result = Day11.Solve(_input, 75);
        Assert.Equal(234568186890978L, result);
    }
}
