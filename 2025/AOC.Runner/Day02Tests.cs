using AOC.Solver;
using System.IO;
using System.Linq;
using Xunit;

namespace AOC.Runner;

public class Day02Tests
{
    private readonly string _input;

    public Day02Tests()
    {
        var lines = File.ReadAllLines("./Day02.input");
        _input = lines.Single(line => line.Length > 0);
    }

    [Fact]
    public void Part1()
    {
        var result = Day02.SolvePart1(_input);
        Assert.Equal(19128774598L, result);
    }

    [Fact]
    public void Part2()
    {
        var result = Day02.SolvePart2(_input);
        Assert.Equal(21932258645L, result);
    }

    [Fact]
    public void Part2_Example()
    {
        var result = Day02.SolvePart2("11-22,95-115,998-1012,1188511880-1188511890,222220-222224,1698522-1698528,446443-446449,38593856-38593862,565653-565659,824824821-824824827,2121212118-2121212124");
        Assert.Equal(4174379265L, result);
    }
}
