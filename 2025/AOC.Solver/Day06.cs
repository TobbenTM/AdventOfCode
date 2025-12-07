using System;
using System.Collections.Generic;
using System.Linq;

namespace AOC.Solver;

public static class Day06
{
    public static long SolvePart1(string[] input)
    {
        var result = 0L;
        var tokens = input.Select(line => line.Split(" ", StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries)).ToArray();

        for (var i = 0; i < tokens[0].Length; i++)
        {
            var problem = tokens.Select(line => line[i]).ToArray();
            switch (problem.Last())
            {
                case "*":
                    result += problem[..^1].Select(long.Parse).Aggregate((a, b) => a * b);
                    break;
                case "+":
                    result += problem[..^1].Select(long.Parse).Aggregate((a, b) => a + b);
                    break;
            }
        }

        return result;
    }

    public static long SolvePart2(string[] input)
    {
        var result = 0L;

        var numbers = new List<long>();
        for (var x = input[0].Length - 1; x >= 0; x--)
        {
            var currentNumber = "";
            for (var y = 0; y < input.Length - 1; y++)
            {
                currentNumber += input[y][x];
            }
            if (currentNumber.Trim() != "")
                numbers.Add(long.Parse(currentNumber.Trim()));

            var op = input.Last()[x];
            switch (op)
            {
                case '*':
                    result += numbers.Aggregate((a, b) => a * b);
                    numbers.Clear();
                    break;
                case '+':
                    result += numbers.Sum();
                    numbers.Clear();
                    break;
            }
        }

        var tokens = input.Select(line => line.Split(" ", StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries)).ToArray();

        for (var i = 0; i < tokens[0].Length; i++)
        {
            var problem = tokens.Select(line => line[i]).ToArray();
        }

        return result;
    }
}
