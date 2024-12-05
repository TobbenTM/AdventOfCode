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
        Assert.Equal(2057374, result);
    }

    [Fact]
    public void Part2()
    {
        var result = Day01.SolvePart2(_input);
        Assert.Equal(23177084, result);
    }
}
