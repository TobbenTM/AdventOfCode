using System;
using System.Linq;

namespace AOC.Solver;

public static class Day02
{
    private static bool Wins(int a, int b) => (a + 1) % 3 == b;

    public static int SolvePart1(string[] input)
    {
        int Resolve(char[] g)
        {
            var a = g[0] switch
            {
                'A' => 0,
                'B' => 1,
                _ => 2,
            };
            var b = g[1] switch
            {
                'X' => 0,
                'Y' => 1,
                _ => 2,
            };
            return b + 1 + (a == b ? 3 : Wins(a, b) ? 6 : 0);
        }

        return input.Select(game => Resolve(game.Split(" ").Select(s => s[0]).ToArray())).Sum();
    }

    public static int SolvePart2(string[] input)
    {
        int Resolve(char[] g)
        {
            var a = g[0] switch
            {
                'A' => 0,
                'B' => 1,
                _ => 2,
            };
            if (g[1] == 'Y')
            {
                return a + 4;
            }

            for (var i = 0; i < 3; i++)
            {
                if (g[1] == 'X' && !Wins(a, i) && a != i || g[1] != 'X' && Wins(a, i))
                {
                    return (g[1] != 'X' ? 7 : 1) + i;
                }
            }

            throw new InvalidOperationException();
        }

        return input.Select(game => Resolve(game.Split(" ").Select(s => s[0]).ToArray())).Sum();
    }
}
