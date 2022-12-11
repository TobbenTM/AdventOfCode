using AOC.Solver;
using System.IO;
using Xunit;

namespace AOC.Runner;

public class Day11Tests
{
    private readonly string _input;

    public Day11Tests()
    {
        _input = File.ReadAllText("./Day11.input");
    }

    [Fact]
    public void Part1()
    {
        var result = Day11.SolvePart1(_input);
        Assert.Equal(98280UL, result);
    }

    [Fact]
    public void Part2()
    {
        var result = Day11.SolvePart2(_input);
        Assert.Equal(17673687232UL, result);
    }
}
