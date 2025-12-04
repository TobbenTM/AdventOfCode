using AOC.Solver;
using System.IO;
using System.Linq;
using Xunit;

namespace AOC.Runner;

public class Day04Tests
{
    private readonly string[] _input;

    public Day04Tests()
    {
        var lines = File.ReadAllLines("./Day04.input");
        _input = lines
            .Where(line => line.Length > 0)
            .ToArray();
    }

    [Fact]
    public void Part1()
    {
        var result = Day04.SolvePart1(_input);
        Assert.Equal(1457, result);
    }

    [Fact]
    public void Part2()
    {
        var result = Day04.SolvePart2(_input);
        Assert.Equal(8310, result);
    }
}
