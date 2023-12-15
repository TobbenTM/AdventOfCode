using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace AOC.Solver;

public static class Day15
{
    public static int SolvePart1(string input) => input.Split(",").Select(Hash).Sum();

    public static int SolvePart2(string input)
    {
        var boxes = Enumerable.Range(0, 256).Select(_ => new List<(string Label, int FocalLength)>()).ToArray();
        foreach (var step in input.Split(","))
        {
            var match = new Regex("(\\w+)(-|=[0-9])").Match(step);
            var label = match.Groups[1].Value;
            var box = Hash(label);
            if (match.Groups[2].Value == "-")
            {
                boxes[box].RemoveAll(x => x.Label == label);
            }
            else
            {
                var existingIndex = boxes[box].FindIndex(x => x.Label == label);
                if (existingIndex >= 0)
                {
                    boxes[box][existingIndex] = (label, int.Parse(match.Groups[2].Value[1..]));
                }
                else
                {
                    boxes[box].Add((label, int.Parse(match.Groups[2].Value[1..])));
                }
            }
        }

        var result = 0;
        for (var i = 0; i < boxes.Length; i++)
        {
            for (var j = 0; j < boxes[i].Count; j++)
            {
                result += (i + 1) * (j + 1) * boxes[i][j].FocalLength;
            }
        }

        return result;
    }

    private static int Hash(string input)
    {
        var result = 0;
        foreach (var ch in input)
        {
            result += ch;
            result *= 17;
            result %= 256;
        }

        return result;
    }
}
