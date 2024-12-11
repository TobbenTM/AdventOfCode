using System.Collections.Generic;
using System.Linq;

namespace AOC.Solver;

public static class Day11
{
    public static long Solve(string input, int blinks)
    {
        var cache = new Dictionary<(string, int), long>();
        var stones = input.Split(' ').ToArray();
        return stones.Select(stone => Blink(stone, blinks, cache)).Sum();
    }

    private static long Blink(string stone, int blinks, Dictionary<(string, int), long> cache)
    {
        if (cache.TryGetValue((stone, blinks), out var result))
        {
            // We already computed this stone for this number of iterations
            return result;
        }

        if (blinks == 0)
        {
            // There are no more iterations to be done, it's only this stone
            return cache[(stone, blinks)] = 1;
        }

        // The total length is the length of all stones in the blinked set
        return cache[(stone, blinks)] = Blink(stone).Aggregate(0L, (a, b) => a + Blink(b, blinks - 1, cache));
    }

    private static string[] Blink(string stone) => stone switch
    {
        "0" => ["1"],
        _ when stone.Length % 2 == 0 =>
        [
            new string(stone.Take(stone.Length / 2).ToArray()),
            long.Parse(new string(stone.TakeLast(stone.Length / 2).ToArray())).ToString(),
        ],
        _ => [(long.Parse(stone) * 2024).ToString()]
    };
}
