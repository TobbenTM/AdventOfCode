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
        _input = File.ReadAllLines("./Day13.input");
    }

    [Fact]
    public void Part1()
    {
        var result = Day13.SolvePart1(_input);
        Assert.Equal(32026, result);
    }

    [Fact]
    public void Part1_Example()
    {
        var result = Day13.SolvePart1([
            "Button A: X+94, Y+34",
            "Button B: X+22, Y+67",
            "Prize: X=8400, Y=5400",
            "",
            "Button A: X+26, Y+66",
            "Button B: X+67, Y+21",
            "Prize: X=12748, Y=12176",
            "",
            "Button A: X+17, Y+86",
            "Button B: X+84, Y+37",
            "Prize: X=7870, Y=6450",
            "",
            "Button A: X+69, Y+23",
            "Button B: X+27, Y+71",
            "Prize: X=18641, Y=10279",
        ]);
        Assert.Equal(480, result);
    }

    [Fact]
    public void Part2()
    {
        var result = Day13.SolvePart2(_input);
        Assert.Equal(89013607072065L, result);
    }
}
