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
        Assert.Equal(107142, result);
    }

    [Fact]
    public void Part2()
    {
        var result = Day14.SolvePart2(_input);
        Assert.True(result > 104715, "Too low");
        Assert.True(result < 104913, "Too high");
        Assert.True(result != 104842, "Wrong number");
        Assert.Equal(-1, result);
    }
}
