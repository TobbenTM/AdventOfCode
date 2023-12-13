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
        Assert.Equal(7541, result);
    }

    [Fact]
    public void Part2()
    {
        var result = Day12.SolvePart2(_input);
        Assert.Equal(-1, result);
    }
}
