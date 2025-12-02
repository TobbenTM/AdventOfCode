using System.Collections.Generic;
using System.Linq;

namespace AOC.Solver;

public static class Day02
{
    public static long SolvePart1(string input)
    {
        var ranges = input.Split(",").Select(str => str.Split("-").Select(long.Parse).ToArray()).ToArray();
        var result = 0L;

        foreach (var range in ranges)
        {
            for (var i = range[0]; i <= range[1]; i++)
            {
                var number = i.ToString();
                if (number.Length % 2 == 0 && number[..(number.Length / 2)] == number[(number.Length / 2)..])
                {
                    result += i;
                }
            }
        }

        return result;
    }

    public static long SolvePart2(string input)
    {
        var ranges = input.Split(",").Select(str => str.Split("-").Select(long.Parse).ToArray()).ToArray();
        var result = 0L;

        foreach (var range in ranges)
        {
            for (var i = range[0]; i <= range[1]; i++)
            {
                var number = i.ToString();
                for (var j = 2; j <= number.Length; j++)
                {
                    if (number.Length % j != 0) continue;
                    var size = number.Length / j;
                    var parts = new List<string>();
                    for (var k = 0; (k + 1) * size <= number.Length; k++)
                    {
                        parts.Add(number.Substring(k * size, size));
                    }
                    if (parts.All(str => str == parts.First()))
                    {
                        result += i;
                        break;
                    }
                }
            }
        }

        return result;
    }
}
