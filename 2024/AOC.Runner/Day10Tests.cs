using AOC.Solver;
using System.IO;
using System.Linq;
using Xunit;

namespace AOC.Runner;

public class Day10Tests
{
    private readonly string[] _input;

    public Day10Tests()
    {
        var lines = File.ReadAllLines("./Day10.input");
        _input = lines
            .Where(line => line.Length > 0)
            .ToArray();
    }

    [Fact]
    public void Part1()
    {
        var result = Day10.SolvePart1(_input);
        Assert.Equal(682, result);
    }

    [Fact]
    public void Part1_Example()
    {
        var result = Day10.SolvePart1([
            "0123",
            "1234",
            "8765",
            "9876",
        ]);
        Assert.Equal(1, result);
    }

    [Fact]
    public void Part2()
    {
        var result = Day10.SolvePart2(_input);
        Assert.Equal(1511, result);
    }
}
