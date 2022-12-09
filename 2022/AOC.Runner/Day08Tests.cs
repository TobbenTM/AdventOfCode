using AOC.Solver;
using System.IO;
using System.Linq;
using Xunit;

namespace AOC.Runner;

public class Day08Tests
{
    private readonly int[][] _input;

    public Day08Tests()
    {
        var lines = File.ReadAllLines("./Day08.input");
        _input = lines
            .Where(line => line.Length > 0)
            .Select(line => line.ToCharArray().Select(c => int.Parse(c.ToString())).ToArray())
            .ToArray();
    }

    [Fact]
    public void Part1()
    {
        var result = Day08.SolvePart1(_input);
        Assert.Equal(1798, result);
    }

    [Fact]
    public void Part1_ExampleData()
    {
        var example = @"30373
25512
65332
33549
35390";
        var input = example
            .Split("\n")
            .Select(line => line.ToCharArray().Select(c => int.Parse(c.ToString())).ToArray())
            .ToArray();
        var result = Day08.SolvePart1(input);
        Assert.Equal(21, result);
    }

    [Fact]
    public void Part2()
    {
        var result = Day08.SolvePart2(_input);
        Assert.Equal(259308, result);
    }

    [Fact]
    public void Part2_ExampleData()
    {
        var example = @"30373
25512
65332
33549
35390";
        var input = example
            .Split("\n")
            .Select(line => line.ToCharArray().Select(c => int.Parse(c.ToString())).ToArray())
            .ToArray();
        var result = Day08.SolvePart2(input);
        Assert.Equal(8, result);
    }
}
