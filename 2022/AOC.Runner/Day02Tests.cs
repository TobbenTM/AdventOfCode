using AOC.Solver;
using System.IO;
using System.Linq;
using Xunit;

namespace AOC.Runner;

public class Day02Tests
{
    private readonly string[] _input;

    public Day02Tests()
    {
        var lines = File.ReadAllLines("./Day02.input");
        _input = lines
            .Where(line => line.Length > 0)
            .ToArray();
    }

    [Fact]
    public void Part1()
    {
        var result = Day02.SolvePart1(_input);
        Assert.Equal(13484, result);
    }

    [Fact]
    public void Part1_Example()
    {
        var result = Day02.SolvePart1(new[]
        {
            "A Y", "B X", "C Z"
        });
        Assert.Equal(15, result);
    }

    [Fact]
    public void Part2()
    {
        var result = Day02.SolvePart2(_input);
        Assert.Equal(13433, result);
    }

    [Fact]
    public void Part2_Example()
    {
        var result = Day02.SolvePart2(new[]
        {
            "A Y", "B X", "C Z"
        });
        Assert.Equal(12, result);
    }
}
