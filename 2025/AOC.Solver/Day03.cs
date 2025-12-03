using System;
using System.Linq;

namespace AOC.Solver;

public static class Day03
{
    public static int SolvePart1(int[][] input)
    {
        var result = 0;
        foreach (var bank in input)
        {
            var max = 0;
            for (var i = 0; i < bank.Length - 1; i++)
            {
                for (var j = i + 1; j < bank.Length; j++)
                {
                    var joltage = bank[i] * 10 + bank[j];
                    if (joltage > max) max = joltage;
                }
            }

            result += max;
        }

        return result;
    }

    public static long SolvePart2(int[][] input)
    {
        var result = 0L;
        foreach (var bank in input)
        {
            var initialIndex = bank
                .Zip(Enumerable.Range(0, bank.Length))
                .OrderByDescending(t => t.First)
                .ThenBy(t => t.Second)
                .First(t => t.Second < bank.Length - 12)
                .Second;
            var currentIndex = initialIndex;
            var max = bank[currentIndex++] * (long)Math.Pow(10, 12 - 1);
            for (var n = 11; n > 0; n--)
            {
                var bestCandidate = (value: bank[currentIndex], Index: currentIndex);

                for (var i = 1; i + currentIndex <= bank.Length - n; i++)
                {
                    if (bank[i + currentIndex] > bestCandidate.value)
                    {
                        bestCandidate = (value: bank[i + currentIndex], Index: i + currentIndex);
                    }
                }

                max += bestCandidate.value * (long)Math.Pow(10, n - 1);
                currentIndex = bestCandidate.Index + 1;
            }

            result += max;
        }

        return result;
    }
}
