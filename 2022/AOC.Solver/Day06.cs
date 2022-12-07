using System;
using System.Linq;

namespace AOC.Solver;

public static class Day06
{
    public static int SolvePart1(string input)
    {
        for (var i = 3; i < input.Length; i++)
        {
            if (input.Skip(i - 4).Take(4).Distinct().Count() == 4)
            {
                return i;
            }
        }

        throw new InvalidOperationException();
    }

    public static int SolvePart2(string input)
    {
        for (var i = 13; i < input.Length; i++)
        {
            if (input.Skip(i - 14).Take(14).Distinct().Count() == 14)
            {
                return i;
            }
        }

        throw new InvalidOperationException();
    }
}
