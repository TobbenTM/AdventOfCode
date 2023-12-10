using AOC.Solver;
using System.IO;
using System.Linq;
using Xunit;

namespace AOC.Runner;

public class Day10Tests
{
    private readonly string[] _input;

    public Day10Tests()
    {
        var lines = File.ReadAllLines("./Day10.input");
        _input = lines
            .Where(line => line.Length > 0)
            .ToArray();
    }

    [Fact]
    public void Part1_Example1()
    {
        var result = Day10.SolvePart1(new []
        {
            ".....",
            ".S-7.",
            ".|.|.",
            ".L-J.",
            ".....",
        });
        Assert.Equal(4, result);
    }

    [Fact]
    public void Part1_Example2()
    {
        var result = Day10.SolvePart1(new []
        {
            "..F7.",
            ".FJ|.",
            "SJ.L7",
            "|F--J",
            "LJ...",
        });
        Assert.Equal(8, result);
    }

    [Fact]
    public void Part1()
    {
        var result = Day10.SolvePart1(_input);
        Assert.Equal(6697, result);
    }

    [Fact]
    public void Part2_Example1()
    {
        var result = Day10.SolvePart2(new []
        {
            "...........",
            ".S-------7.",
            ".|F-----7|.",
            ".||.....||.",
            ".||.....||.",
            ".|L-7.F-J|.",
            ".|..|.|..|.",
            ".L--J.L--J.",
            "...........",
        });
        Assert.Equal(4, result);
    }

    [Fact]
    public void Part2()
    {
        var result = Day10.SolvePart2(_input);
        Assert.Equal(423, result);
    }
}
