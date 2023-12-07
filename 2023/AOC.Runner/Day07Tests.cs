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
        Assert.Equal(248396258, result);
    }

    [Fact]
    public void Part2()
    {
        var result = Day07.SolvePart2(_input);
        Assert.True(result < 246513035, "Too low");
        Assert.True(result > 246346661, "Too high");
        Assert.Equal(246436046, result);
    }
}
