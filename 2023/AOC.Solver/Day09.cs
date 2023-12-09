using System.Collections.Generic;
using System.Linq;

namespace AOC.Solver;

public static class Day09
{
    public static int SolvePart1(string[] input)
    {
        var histories = input.Select(line => line.Split(' ').Select(int.Parse).ToList()).ToArray();

        foreach (var history in histories)
        {
            var prediction = Predict(history);
            history.Add(history.Last() - prediction.Last());
        }

        return histories.Sum(h => h.Last());
    }

    public static int SolvePart2(string[] input)
    {
        var histories = input.Select(line => line.Split(' ').Select(int.Parse).ToList()).ToArray();

        foreach (var history in histories)
        {
            var prediction = Predict(history);
            history.Insert(0, history.First() + prediction.First());
        }

        return histories.Sum(h => h.First());
    }

    private static int[] Predict(List<int> input)
    {
        var differences = new List<int>();
        for (var i = 1; i < input.Count; i++)
        {
            differences.Add(input[i - 1] - input[i]);
        }

        if (!differences.Any() || differences.All(n => n == 0))
        {
            differences.Add(0);
            return differences.ToArray();
        }

        var inner = Predict(differences);
        differences.Add(differences.Last() - inner.Last());
        differences.Insert(0, differences.First() + inner.First());
        return differences.ToArray();
    }
}
