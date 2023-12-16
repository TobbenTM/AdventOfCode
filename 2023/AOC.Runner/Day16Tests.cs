using AOC.Solver;
using System.IO;
using System.Linq;
using Xunit;

namespace AOC.Runner;

public class Day16Tests
{
    private readonly string[] _input;

    public Day16Tests()
    {
        var lines = File.ReadAllLines("./Day16.input");
        _input = lines
            .Where(line => line.Length > 0)
            .ToArray();
    }

    [Fact]
    public void Part1()
    {
        var result = Day16.SolvePart1(_input);
        Assert.Equal(7979, result);
    }

    [Fact]
    public void Part2()
    {
        var result = Day16.SolvePart2(_input);
        Assert.Equal(8437, result);
    }
}
