using AOC.Solver;
using System.IO;
using System.Linq;
using Xunit;

namespace AOC.Runner;

public class Day17Tests
{
    private readonly int[][] _input;

    public Day17Tests()
    {
        var lines = File.ReadAllLines("./Day17.input");
        _input = lines
            .Where(line => line.Length > 0)
            .Select(line => line.ToCharArray().Select(ch => int.Parse(ch.ToString())).ToArray())
            .ToArray();
    }

    [Fact]
    public void Part1_Example()
    {
        var result = Day17.SolvePart1(new[]
            {
                "2413432311323",
                "3215453535623",
                "3255245654254",
                "3446585845452",
                "4546657867536",
                "1438598798454",
                "4457876987766",
                "3637877979653",
                "4654967986887",
                "4564679986453",
                "1224686865563",
                "2546548887735",
                "4322674655533",
            }
            .Select(line => line.ToCharArray().Select(ch => int.Parse(ch.ToString())).ToArray())
            .ToArray());
        Assert.Equal(102, result);
    }

    [Fact]
    public void Part1()
    {
        var result = Day17.SolvePart1(_input);
        Assert.Equal(-1, result);
    }

    [Fact]
    public void Part2()
    {
        var result = Day17.SolvePart2(_input);
        Assert.Equal(-1, result);
    }
}
