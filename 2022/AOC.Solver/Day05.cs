using System.Collections.Generic;
using System.Linq;

namespace AOC.Solver;

public static class Day05
{
    private static Stack<char>[] ParseStacks(string[] input)
    {
        var stacks = Enumerable.Range(0, 9).Select(_ => new Stack<char>()).ToArray();
        for (var i = 0; i < 8; i++)
        {
            for (int j = 1, s = 0; s < 9; j += 4, s++)
            {
                if (input[i][j] != ' ')
                {
                    stacks[s].Push(input[i][j]);
                }
            }
        }
        return stacks.Select(s => new Stack<char>(s)).ToArray();
    }

    private static (int NumberOfCrates, int FromIndex, int ToIndex) ParseMove(string input)
    {
        var parameters = input.Split(" ").Where(s => int.TryParse(s, out var _)).Select(int.Parse).ToArray();
        return (parameters[0], parameters[1] - 1, parameters[2] - 1);
    }

    public static string SolvePart1(string[] input)
    {
        var stacks = ParseStacks(input);

        foreach (var move in input.Skip(9))
        {
            var (NumberOfCrates, FromIndex, ToIndex) = ParseMove(move);
            for (var i = 0; i < NumberOfCrates; i++)
            {
                var crate = stacks[FromIndex].Pop();
                stacks[ToIndex].Push(crate);
            }
        }

        return string.Join("", stacks.Select(s => s.Pop()));
    }

    public static string SolvePart2(string[] input)
    {
        var stacks = ParseStacks(input);

        foreach (var move in input.Skip(9))
        {
            var (NumberOfCrates, FromIndex, ToIndex) = ParseMove(move);
            var crane = new Stack<char>();
            for (var i = 0; i < NumberOfCrates; i++)
            {
                var crate = stacks[FromIndex].Pop();
                crane.Push(crate);
            }
            foreach (var crate in crane)
            {
                stacks[ToIndex].Push(crate);
            }
        }

        return string.Join("", stacks.Select(s => s.Pop()));
    }
}
