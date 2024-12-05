using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace AOC.Solver;

public static class Day03
{
    public static int SolvePart1(string[] input)
    {
        var re = new Regex(@"mul\((\d+),(\d+)\)");
        return input
            .SelectMany(l => re.Matches(l)
                .Select(m => int.Parse(m.Groups[1].Value) * int.Parse(m.Groups[2].Value)))
            .Aggregate((a, b) => a + b);
    }

    public static int SolvePart2(string[] input)
    {
        var disabled = new Regex(@"don't\(\).*?($|(do\(\)))");
        var re = new Regex(@"mul\((\d+),(\d+)\)");
        var allInput = input.Aggregate(string.Empty, (a, b) => a + b);
        return re.Matches(disabled.Replace(allInput, string.Empty))
            .Select(m => int.Parse(m.Groups[1].Value) * int.Parse(m.Groups[2].Value))
            .Aggregate((a, b) => a + b);
    }
}
