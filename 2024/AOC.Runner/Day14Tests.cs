using AOC.Solver;
using System.IO;
using System.Linq;
using Xunit;

namespace AOC.Runner;

public class Day14Tests
{
    private readonly string[] _input;

    public Day14Tests()
    {
        var lines = File.ReadAllLines("./Day14.input");
        _input = lines
            .Where(line => line.Length > 0)
            .ToArray();
    }

    [Fact]
    public void Part1()
    {
        var result = Day14.SolvePart1(_input, 103, 101);
        Assert.Equal(230461440, result);
    }

    [Fact]
    public void Part1_Example()
    {
        var result = Day14.SolvePart1([
            "p=0,4 v=3,-3",
            "p=6,3 v=-1,-3",
            "p=10,3 v=-1,2",
            "p=2,0 v=2,-1",
            "p=0,0 v=1,3",
            "p=3,0 v=-2,-2",
            "p=7,6 v=-1,-3",
            "p=3,0 v=-1,-2",
            "p=9,3 v=2,3",
            "p=7,3 v=-1,2",
            "p=2,4 v=2,-3",
            "p=9,5 v=-3,-3",
        ], 7, 11);
        Assert.Equal(12, result);
    }

    [Fact(Skip = "Whatever")]
    public void Part2()
    {
        var result = Day14.SolvePart2(_input, 103, 101);
        Assert.Equal(6668, result);
    }
}
