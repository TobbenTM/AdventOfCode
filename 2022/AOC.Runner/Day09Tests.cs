using AOC.Solver;
using System.IO;
using System.Linq;
using Xunit;

namespace AOC.Runner;

public class Day09Tests
{
    private readonly string[] _input;

    public Day09Tests()
    {
        var lines = File.ReadAllLines("./Day09.input");
        _input = lines
            .Where(line => line.Length > 0)
            .ToArray();
    }

    [Fact]
    public void Part1()
    {
        var result = Day09.SolvePart1(_input);
        Assert.Equal(6470, result);
    }

    [Fact]
    public void Part1_ExampleData()
    {
        var input = @"R 4
U 4
L 3
D 1
R 4
D 1
L 5
R 2";
        var result = Day09.SolvePart1(input.Split('\n').ToArray());
        Assert.Equal(13, result);
    }

    [Fact]
    public void Part2()
    {
        var result = Day09.SolvePart2(_input);
        Assert.Equal(2658, result);
    }

    [Fact]
    public void Part2_ExampleData()
    {
        var input = @"R 4
U 4
L 3
D 1
R 4
D 1
L 5
R 2";
        var result = Day09.SolvePart2(input.Split('\n').ToArray());
        Assert.Equal(1, result);
    }

    [Fact]
    public void Part2_ExampleData2()
    {
        var input = @"R 5
U 8
L 8
D 3
R 17
D 10
L 25
U 20";
        var result = Day09.SolvePart2(input.Split('\n').ToArray());
        Assert.Equal(36, result);
    }
}
