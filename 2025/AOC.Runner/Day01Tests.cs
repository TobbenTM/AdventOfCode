using AOC.Solver;
using System.IO;
using System.Linq;
using Xunit;

namespace AOC.Runner;

public class Day01Tests
{
    private readonly string[] _input;

    public Day01Tests()
    {
        var lines = File.ReadAllLines("./Day01.input");
        _input = lines
            .Where(line => line.Length > 0)
            .ToArray();
    }

    [Fact]
    public void Part1()
    {
        var result = Day01.SolvePart1(_input);
        Assert.Equal(1168, result);
    }

    [Fact]
    public void Part2()
    {
        var result = Day01.SolvePart2(_input);
        Assert.Equal(7199, result);
    }

    [Fact]
    public void Part2_Example()
    {
        var result = Day01.SolvePart2([
            "L68",
            "L30",
            "R48",
            "L5",
            "R60",
            "L55",
            "L1",
            "L99",
            "R14",
            "L82",
        ]);
        Assert.Equal(6, result);
    }

    [Theory]
    [InlineData(50, "L68", 82, 1)]
    [InlineData(50, "R1000", 50, 10)]
    public void Turns(int currentDial, string input, int expectedDial, int expectedRotations)
    {
        var (dial, rotations) = Day01.TurnDial(currentDial, int.Parse(input[1..]), input[0]);

        Assert.Equal(expectedDial, dial);
        Assert.Equal(expectedRotations, rotations);
    }
}
