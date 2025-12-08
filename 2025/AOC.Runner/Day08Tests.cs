using AOC.Solver;
using System.IO;
using System.Linq;
using Xunit;

namespace AOC.Runner;

public class Day08Tests
{
    private readonly string[] _input;

    public Day08Tests()
    {
        var lines = File.ReadAllLines("./Day08.input");
        _input = lines
            .Where(line => line.Length > 0)
            .ToArray();
    }

    [Fact]
    public void Part1()
    {
        var result = Day08.SolvePart1(_input, 1000);
        Assert.Equal(26400, result);
    }

    [Fact]
    public void Part1_Example()
    {
        var result = Day08.SolvePart1([
            "162,817,812",
            "57,618,57",
            "906,360,560",
            "592,479,940",
            "352,342,300",
            "466,668,158",
            "542,29,236",
            "431,825,988",
            "739,650,466",
            "52,470,668",
            "216,146,977",
            "819,987,18",
            "117,168,530",
            "805,96,715",
            "346,949,466",
            "970,615,88",
            "941,993,340",
            "862,61,35",
            "984,92,344",
            "425,690,689",
        ], 10);
        Assert.Equal(40, result);
    }

    [Fact]
    public void Part2()
    {
        var result = Day08.SolvePart2(_input);
        Assert.Equal(8199963486L, result);
    }
}
