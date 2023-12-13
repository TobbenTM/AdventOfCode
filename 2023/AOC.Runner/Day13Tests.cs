using AOC.Solver;
using System.IO;
using System.Linq;
using Xunit;

namespace AOC.Runner;

public class Day13Tests
{
    private readonly string[] _input;

    public Day13Tests()
    {
        var lines = File.ReadAllLines("./Day13.input");
        _input = lines.ToArray();
    }

    [Fact]
    public void Part1_Example()
    {
        var result = Day13.SolvePart1(new[]
        {
            "#.##..##.",
            "..#.##.#.",
            "##......#",
            "##......#",
            "..#.##.#.",
            "..##..##.",
            "#.#.##.#.",
            "",
            "#...##..#",
            "#....#..#",
            "..##..###",
            "#####.##.",
            "#####.##.",
            "..##..###",
            "#....#..#",
        });
        Assert.Equal(405, result);
    }

    [Fact]
    public void Part1()
    {
        var result = Day13.SolvePart1(_input);
        Assert.Equal(37381, result);
    }

    [Fact]
    public void Part2_Example()
    {
        var result = Day13.SolvePart2(new[]
        {
            "#.##..##.",
            "..#.##.#.",
            "##......#",
            "##......#",
            "..#.##.#.",
            "..##..##.",
            "#.#.##.#.",
            "",
            "#...##..#",
            "#....#..#",
            "..##..###",
            "#####.##.",
            "#####.##.",
            "..##..###",
            "#....#..#",
        });
        Assert.Equal(400, result);
    }

    [Fact]
    public void Part2()
    {
        var result = Day13.SolvePart2(_input);
        Assert.Equal(28210, result);
    }
}
