using AOC.Solver;
using System.IO;
using System.Linq;
using Xunit;

namespace AOC.Runner;

public class Day05Tests
{
    private readonly string[] _input;

    public Day05Tests()
    {
        var lines = File.ReadAllLines("./Day05.input");
        _input = lines
            .Where(line => line.Length > 0)
            .ToArray();
    }

    [Fact]
    public void Part1()
    {
        var result = Day05.SolvePart1(_input);
        Assert.Equal(674, result);
    }

    [Fact]
    public void Part2()
    {
        var result = Day05.SolvePart2(_input);
        Assert.Equal(352509891817881L, result);
    }

    [Fact]
    public void Part2_Example()
    {
        var result = Day05.SolvePart2([
            "3-5",
            "10-14",
            "16-20",
            "12-18",
        ]);
        Assert.Equal(14, result);
    }
}
