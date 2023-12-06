using AOC.Solver;
using System.IO;
using System.Linq;
using Xunit;

namespace AOC.Runner;

public class Day06Tests
{
    private readonly string[] _input;

    public Day06Tests()
    {
        var lines = File.ReadAllLines("./Day06.input");
        _input = lines
            .Where(line => line.Length > 0)
            .ToArray();
    }

    [Fact]
    public void Part1()
    {
        var result = Day06.SolvePart1(_input);
        Assert.Equal(393120, result);
    }

    [Fact]
    public void Part2()
    {
        var result = Day06.SolvePart2(_input);
        Assert.Equal(36872656, result);
    }
}
