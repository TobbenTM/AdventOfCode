using AOC.Solver;
using System.IO;
using System.Linq;
using Xunit;

namespace AOC.Runner;

public class Day04Tests
{
    private readonly string[] _input;

    public Day04Tests()
    {
        var lines = File.ReadAllLines("./Day04.input");
        _input = lines
            .Where(line => line.Length > 0)
            .ToArray();
    }

    [Fact]
    public void Part1_Example()
    {
        var result = Day04.SolvePart1(new []
        {
            "Card 1: 41 48 83 86 17 | 83 86  6 31 17  9 48 53",
            "Card 2: 13 32 20 16 61 | 61 30 68 82 17 32 24 19",
            "Card 3:  1 21 53 59 44 | 69 82 63 72 16 21 14  1",
            "Card 4: 41 92 73 84 69 | 59 84 76 51 58  5 54 83",
            "Card 5: 87 83 26 28 32 | 88 30 70 12 93 22 82 36",
            "Card 6: 31 18 13 56 72 | 74 77 10 23 35 67 36 11",
        });
        Assert.Equal(13, result);
    }

    [Fact]
    public void Part1()
    {
        var result = Day04.SolvePart1(_input);
        Assert.Equal(25183, result);
    }

    [Fact]
    public void Part2_Example()
    {
        var result = Day04.SolvePart2(new []
        {
            "Card 1: 41 48 83 86 17 | 83 86  6 31 17  9 48 53",
            "Card 2: 13 32 20 16 61 | 61 30 68 82 17 32 24 19",
            "Card 3:  1 21 53 59 44 | 69 82 63 72 16 21 14  1",
            "Card 4: 41 92 73 84 69 | 59 84 76 51 58  5 54 83",
            "Card 5: 87 83 26 28 32 | 88 30 70 12 93 22 82 36",
            "Card 6: 31 18 13 56 72 | 74 77 10 23 35 67 36 11",
        });
        Assert.Equal(30, result);
    }

    [Fact]
    public void Part2()
    {
        var result = Day04.SolvePart2(_input);
        Assert.Equal(5667240, result);
    }
}
