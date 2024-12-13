using System;
using System.Text.RegularExpressions;
using AOC.Solver.Tools;

namespace AOC.Solver;

public static class Day13
{
    public static int SolvePart1(string[] input)
    {
        var re = new Regex(@"X(?:\+|=)(\d+), Y(?:\+|=)(\d+)");
        var result = 0;
        for (var i = 0; i < input.Length; i++)
        {
            if (input[i] == string.Empty) continue;

            var matchA = re.Match(input[i++]);
            var buttonA = (int.Parse(matchA.Groups[1].Value), int.Parse(matchA.Groups[2].Value));
            var matchB = re.Match(input[i++]);
            var buttonB = (int.Parse(matchB.Groups[1].Value), int.Parse(matchB.Groups[2].Value));
            var matchPrize = re.Match(input[i]);
            var prize = (int.Parse(matchPrize.Groups[1].Value), int.Parse(matchPrize.Groups[2].Value));

            var bestResult = (Tokens: int.MaxValue, Presses: int.MaxValue);
            var maxB = Math.Min(prize.Item1 / buttonB.Item1, prize.Item2 / buttonB.Item2);
            for (var b = maxB; b >= 0; b--)
            {
                var pos = buttonB.Multiply(b);
                var diff = prize.Subtract(pos);
                var maxA = Math.Min(diff.Item1 / buttonA.Item1, diff.Item2 / buttonA.Item2);
                if (pos.Add(buttonA.Multiply(maxA)) == prize && b  <= 100 && maxA <= 100 && b + maxA * 3 < bestResult.Tokens)
                {
                    bestResult = (b + maxA * 3, b + maxA);
                }
            }

            if (bestResult.Tokens < int.MaxValue)
            {
                result += bestResult.Tokens;
            }
        }

        return result;
    }

    public static long SolvePart2(string[] input)
    {
        var re = new Regex(@"X(?:\+|=)(\d+), Y(?:\+|=)(\d+)");
        var result = 0L;
        for (var i = 0; i < input.Length; i++)
        {
            if (input[i] == string.Empty) continue;

            var matchA = re.Match(input[i++]);
            var buttonA = (int.Parse(matchA.Groups[1].Value), int.Parse(matchA.Groups[2].Value));
            var matchB = re.Match(input[i++]);
            var buttonB = (int.Parse(matchB.Groups[1].Value), int.Parse(matchB.Groups[2].Value));
            var matchPrize = re.Match(input[i]);
            var prize = (int.Parse(matchPrize.Groups[1].Value) + 10_000_000_000_000L, int.Parse(matchPrize.Groups[2].Value) + 10_000_000_000_000L);

            var aPresses = (prize.Item1 * buttonB.Item2 - prize.Item2 * buttonB.Item1) / (buttonA.Item1 * buttonB.Item2 - buttonA.Item2 * buttonB.Item1);
            var bPresses = (prize.Item2 * buttonA.Item1 - prize.Item1 * buttonA.Item2) / (buttonA.Item1 * buttonB.Item2 - buttonA.Item2 * buttonB.Item1);
            if (buttonA.Multiply(aPresses).Add(buttonB.Multiply(bPresses)) == prize)
            {
                result += aPresses * 3 + bPresses;
            }
        }

        return result;
    }
}
