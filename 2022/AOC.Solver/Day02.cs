using System;
using System.Linq;

namespace AOC.Solver;

public static class Day02
{
    private static bool[,] _rps = new bool[3, 3]
    {
        { false, true, false },
        { false, false, true },
        { true, false, false },
    };

    public static int SolvePart1(string[] input)
    {
        Func<char[], int> resolve = (g) =>
        {
            var a = g[0] switch
            {
                'A' => 1,
                'B' => 2,
                _ => 3,
            };
            var b = g[1] switch
            {
                'X' => 1,
                'Y' => 2,
                _ => 3,
            };
            return b + (a == b ? 3 : _rps[a - 1,b - 1] ? 6 : 0);
        };
        return input.Select(game => resolve(game.Split(" ").Select(s => s[0]).ToArray())).Sum();
    }

    public static int SolvePart2(string[] input)
    {
        Func<char[], int> resolve = (g) =>
        {
            var a = g[0] switch
            {
                'A' => 1,
                'B' => 2,
                _ => 3,
            };
            if (g[1] == 'Y')
            {
                return a + 3;
            }
            for (var i = 1; i <= 3; i++)
            {
                if (g[1] == 'X' && !_rps[a - 1, i - 1] && a != i || g[1] != 'X' && _rps[a - 1, i - 1])
                {
                    return (g[1] != 'X' ? 6 : 0) + i;
                }
            }
            throw new InvalidOperationException();
        };
        return input.Select(game => resolve(game.Split(" ").Select(s => s[0]).ToArray())).Sum();
    }
}
