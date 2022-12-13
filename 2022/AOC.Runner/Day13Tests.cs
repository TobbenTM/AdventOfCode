using System.IO;
using AOC.Solver;
using Xunit;

namespace AOC.Runner;

public class Day13Tests
{
    private readonly string _input;

    public Day13Tests()
    {
        _input = File.ReadAllText("./Day13.input");
    }

    [Fact]
    public void Part1()
    {
        var result = Day13.SolvePart1(_input);
        Assert.Equal(5529, result);
    }

    [Fact]
    public void Part1_ExampleData()
    {
        var input = @"[1,1,3,1,1]
[1,1,5,1,1]

[[1],[2,3,4]]
[[1],4]

[9]
[[8,7,6]]

[[4,4],4,4]
[[4,4],4,4,4]

[7,7,7,7]
[7,7,7]

[]
[3]

[[[]]]
[[]]

[1,[2,[3,[4,[5,6,7]]]],8,9]
[1,[2,[3,[4,[5,6,0]]]],8,9]";
        var result = Day13.SolvePart1(input);
        Assert.Equal(13, result);
    }

    [Theory]
    [InlineData("[]", "[1,2,3]", true)]
    [InlineData("[1,2,3]", "[]", false)]
    [InlineData("[5,6,7]", "[5,6,0]", false)]
    [InlineData("[4,[5,6,7]]", "[4,[5,6,0]]", false)]
    public void Part1_ShouldHandleCases(string left, string right, bool expectedCorrectness)
    {
        var result = Day13.SolvePart1($"{left}\n{right}");
        if (expectedCorrectness)
        {
            Assert.Equal(1, result);
        }
        else
        {
            Assert.Equal(0, result);
        }
    }

    [Fact]
    public void Part2()
    {
        var result = Day13.SolvePart2(_input);
        Assert.Equal(27690, result);
    }

    [Fact]
    public void Part2_ExampleData()
    {
        var input = @"[1,1,3,1,1]
[1,1,5,1,1]

[[1],[2,3,4]]
[[1],4]

[9]
[[8,7,6]]

[[4,4],4,4]
[[4,4],4,4,4]

[7,7,7,7]
[7,7,7]

[]
[3]

[[[]]]
[[]]

[1,[2,[3,[4,[5,6,7]]]],8,9]
[1,[2,[3,[4,[5,6,0]]]],8,9]";
        var result = Day13.SolvePart2(input);
        Assert.Equal(140, result);
    }
}
