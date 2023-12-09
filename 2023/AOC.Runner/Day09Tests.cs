using AOC.Solver;
using System.IO;
using System.Linq;
using Xunit;

namespace AOC.Runner;

public class Day09Tests
{
    private readonly string[] _input;

    public Day09Tests()
    {
        var lines = File.ReadAllLines("./Day09.input");
        _input = lines
            .Where(line => line.Length > 0)
            .ToArray();
    }

    [Fact]
    public void Part1()
    {
        var result = Day09.SolvePart1(_input);
        Assert.Equal(2075724761, result);
    }

    [Fact]
    public void Part2()
    {
        var result = Day09.SolvePart2(_input);
        Assert.Equal(1072, result);
    }
}
