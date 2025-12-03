using AOC.Solver;
using System.IO;
using System.Linq;
using Xunit;

namespace AOC.Runner;

public class Day03Tests
{
    private readonly int[][] _input;

    public Day03Tests()
    {
        var lines = File.ReadAllLines("./Day03.input");
        _input = lines
            .Where(line => line.Length > 0)
            .Select(line => line.ToArray().Select(c => int.Parse(c.ToString())).ToArray())
            .ToArray();
    }

    [Fact]
    public void Part1()
    {
        var result = Day03.SolvePart1(_input);
        Assert.Equal(17113, result);
    }

    [Fact]
    public void Part2()
    {
        var result = Day03.SolvePart2(_input);
        Assert.Equal(169709990062889L, result);
    }

    [Fact]
    public void Part2_Example()
    {
        var result = Day03.SolvePart2([
            [9,8,7,6,5,4,3,2,1,1,1,1,1,1,1],
            [8,1,1,1,1,1,1,1,1,1,1,1,1,1,9],
            [2,3,4,2,3,4,2,3,4,2,3,4,2,7,8],
            [8,1,8,1,8,1,9,1,1,1,1,2,1,1,1],
        ]);
        Assert.Equal(3121910778619L, result);
    }
}
