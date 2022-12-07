using AOC.Solver;
using System.IO;
using System.Linq;
using Xunit;

namespace AOC.Runner;

public class Day07Tests
{
    private readonly string[] _input;

    public Day07Tests()
    {
        var lines = File.ReadAllLines("./Day07.input");
        _input = lines
            .Where(line => line.Length > 0)
            .ToArray();
    }

    [Fact]
    public void Part1()
    {
        var result = Day07.SolvePart1(_input);
        Assert.Equal(1232307, result);
    }

    [Fact]
    public void Part2()
    {
        var result = Day07.SolvePart2(_input);
        Assert.Equal(7268994, result);
    }
}
