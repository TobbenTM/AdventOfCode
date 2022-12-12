using AOC.Solver;
using System.IO;
using System.Linq;
using Xunit;

namespace AOC.Runner;

public class Day12Tests
{
    private readonly string[] _input;

    public Day12Tests()
    {
        var lines = File.ReadAllLines("./Day12.input");
        _input = lines
            .Where(line => line.Length > 0)
            .ToArray();
    }

    [Fact]
    public void Part1()
    {
        var result = Day12.SolvePart1(_input);
        Assert.Equal(-1, result);
    }

    [Fact]
    public void Part1_ExampleData()
    {
        var input = @"Sabqponm
abcryxxl
accszExk
acctuvwj
abdefghi";
        var result = Day12.SolvePart1(input.Split('\n').ToArray());
        Assert.Equal(31, result);
    }

    [Fact]
    public void Part2()
    {
        var result = Day12.SolvePart2(_input);
        Assert.Equal(-1, result);
    }
}
