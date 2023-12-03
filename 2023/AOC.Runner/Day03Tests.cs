using AOC.Solver;
using System.IO;
using System.Linq;
using Xunit;

namespace AOC.Runner;

public class Day03Tests
{
    private readonly string[] _input;

    public Day03Tests()
    {
        var lines = File.ReadAllLines("./Day03.input");
        _input = lines
            .Where(line => line.Length > 0)
            .ToArray();
    }

    [Fact]
    public void Part1()
    {
        var result = Day03.SolvePart1(_input);
        Assert.Equal(529618, result);
    }

    [Fact]
    public void Part2()
    {
        var result = Day03.SolvePart2(_input);
        Assert.Equal(77509019, result);
    }
}
