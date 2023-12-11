using AOC.Solver;
using System.IO;
using System.Linq;
using Xunit;

namespace AOC.Runner;

public class Day11Tests
{
    private readonly string[] _input;

    public Day11Tests()
    {
        var lines = File.ReadAllLines("./Day11.input");
        _input = lines
            .Where(line => line.Length > 0)
            .ToArray();
    }

    [Fact]
    public void Part1()
    {
        var result = Day11.SolvePart1(_input);
        Assert.Equal(9403026, result);
    }

    [Fact]
    public void Part2()
    {
        var result = Day11.SolvePart2(_input);
        Assert.Equal(543018317006, result);
    }
}
