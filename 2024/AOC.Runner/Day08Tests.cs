using AOC.Solver;
using System.IO;
using System.Linq;
using Xunit;

namespace AOC.Runner;

public class Day08Tests
{
    private readonly string[] _input;

    public Day08Tests()
    {
        var lines = File.ReadAllLines("./Day08.input");
        _input = lines
            .Where(line => line.Length > 0)
            .ToArray();
    }

    [Fact]
    public void Part1()
    {
        var result = Day08.SolvePart1(_input);
        Assert.Equal(305, result);
    }

    [Fact]
    public void Part2()
    {
        var result = Day08.SolvePart2(_input);
        Assert.Equal(1150, result);
    }
}
