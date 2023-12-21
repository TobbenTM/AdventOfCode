using AOC.Solver;
using System.IO;
using System.Linq;
using Xunit;

namespace AOC.Runner;

public class Day21Tests
{
    private readonly string[] _input;

    public Day21Tests()
    {
        var lines = File.ReadAllLines("./Day21.input");
        _input = lines
            .Where(line => line.Length > 0)
            .ToArray();
    }

    [Fact]
    public void Part1()
    {
        var result = Day21.SolvePart1(_input);
        Assert.Equal(-1, result);
    }

    [Fact]
    public void Part2()
    {
        var result = Day21.SolvePart2(_input);
        Assert.Equal(-1, result);
    }
}
