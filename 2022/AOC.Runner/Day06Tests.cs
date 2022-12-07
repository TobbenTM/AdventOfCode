using AOC.Solver;
using System.IO;
using System.Linq;
using Xunit;

// ReSharper disable StringLiteralTypo
namespace AOC.Runner;

public class Day06Tests
{
    private readonly string _input;

    public Day06Tests()
    {
        var lines = File.ReadAllLines("./Day06.input");
        _input = lines.Single(line => line.Length > 0);
    }

    [Fact]
    public void Part1()
    {
        var result = Day06.SolvePart1(_input);
        Assert.Equal(1598, result);
    }

    [Theory]
    [InlineData("bvwbjplbgvbhsrlpgdmjqwftvncz", 5)]
    [InlineData("nppdvjthqldpwncqszvftbrmjlhg", 6)]
    [InlineData("nznrnfrfntjfmvfwmzdfjlvtqnbhcprsg", 10)]
    [InlineData("zcfzfwzzqfrljwzlrfnpqdbhtmscgvjw", 11)]
    public void Part1_ExampleData(string input, int expectedResult)
    {
        var result = Day06.SolvePart1(input);
        Assert.Equal(expectedResult, result);
    }

    [Fact]
    public void Part2()
    {
        var result = Day06.SolvePart2(_input);
        Assert.Equal(2414, result);
    }

    [Theory]
    [InlineData("mjqjpqmgbljsphdztnvjfqwrcgsmlb", 19)]
    [InlineData("bvwbjplbgvbhsrlpgdmjqwftvncz", 23)]
    [InlineData("nppdvjthqldpwncqszvftbrmjlhg", 23)]
    [InlineData("nznrnfrfntjfmvfwmzdfjlvtqnbhcprsg", 29)]
    [InlineData("zcfzfwzzqfrljwzlrfnpqdbhtmscgvjw", 26)]
    public void Part2_ExampleData(string input, int expectedResult)
    {
        var result = Day06.SolvePart2(input);
        Assert.Equal(expectedResult, result);
    }
}
