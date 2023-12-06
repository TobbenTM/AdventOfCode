using System;
using System.Linq;

namespace AOC.Solver;

public static class Day06
{
    public static long SolvePart1(string[] input)
    {
        var times = input[0].Split(' ', StringSplitOptions.RemoveEmptyEntries).Skip(1).Select(int.Parse).ToArray();
        var distances = input[1].Split(' ', StringSplitOptions.RemoveEmptyEntries).Skip(1).Select(int.Parse).ToArray();

        var result = 1L;
        for (var race = 0; race < times.Length; race++)
        {
            var combinations = 0;
            for (var i = 1; i < times[race] - 1; i++)
            {
                if (i * (times[race] - i) > distances[race]) combinations++;
                else
                {
                    if (i > times[race] / 2) break;
                }
            }

            result *= combinations;
        }

        return result;
    }

    public static long SolvePart2(string[] input)
    {
        var time = long.Parse(input[0][10..].Trim().Replace(" ", ""));
        var distance = long.Parse(input[1][10..].Trim().Replace(" ", ""));

        var combinations = 0L;
        for (var i = 1; i < time - 1; i++)
        {
            if (i * (time - i) > distance) combinations++;
            else
            {
                if (i > time / 2) break;
            }
        }

        return combinations;
    }
}
