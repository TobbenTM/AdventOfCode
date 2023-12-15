using AOC.Solver;
using System.IO;
using System.Linq;
using Xunit;

namespace AOC.Runner;

public class Day15Tests
{
    private readonly string _input;

    public Day15Tests()
    {
        var lines = File.ReadAllLines("./Day15.input");
        _input = lines
            .Where(line => line.Length > 0)
            .Single();
    }

    [Fact]
    public void Part1()
    {
        var result = Day15.SolvePart1(_input);
        Assert.Equal(519603, result);
    }

    [Fact]
    public void Part2()
    {
        var result = Day15.SolvePart2(_input);
        Assert.Equal(244342, result);
    }
}
