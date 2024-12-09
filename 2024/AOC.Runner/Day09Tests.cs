using AOC.Solver;
using System.IO;
using System.Linq;
using Xunit;

namespace AOC.Runner;

public class Day09Tests
{
    private readonly string _input;

    public Day09Tests()
    {
        var lines = File.ReadAllLines("./Day09.input");
        _input = lines.Single(line => line.Length > 0);
    }

    [Fact]
    public void Part1()
    {
        var result = Day09.SolvePart1(_input);
        Assert.Equal(6332189866718L, result);
    }

    [Fact]
    public void Part2()
    {
        var result = Day09.SolvePart2(_input);
        Assert.Equal(6353648390778L, result);
    }

    [Fact]
    public void Part2_Example()
    {
        var result = Day09.SolvePart2("2333133121414131402");
        Assert.Equal(2858, result);
    }
}
