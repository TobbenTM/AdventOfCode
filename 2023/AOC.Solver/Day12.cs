using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC.Solver;

public static class Day12
{
    public static int SolvePart1(string[] input)
    {
        var result = 0;
        foreach (var line in input)
        {
            var row = line.Split(' ')[0];
            var groups = line.Split(' ')[1].Split(',').Select(int.Parse).ToArray();
            result += NumberOfValidPermutations(row, groups);
        }

        return result;
    }

    public static long SolvePart2(string[] input)
    {

        var result = 0L;
        foreach (var line in input)
        {
            var row = line.Split(' ')[0];
            var groups = line.Split(' ')[1].Split(',').Select(int.Parse).ToArray();
            result += NumberOfValidPermutations($"{row}?{row}?{row}?{row}?{row}", groups.Concat(groups).Concat(groups).Concat(groups).Concat(groups).ToArray());
        }

        return result;
    }

    private static int NumberOfValidPermutations(string row, int[] groups)
    {
        if (row.Contains('?'))
        {
            if (row.Count(c => c is '?' or '#') < groups.Sum()) return 0;
            if (row.Count(c => c is '#') > groups.Sum()) return 0;

            var index = row.IndexOf('?');
            var a = new StringBuilder(row)
            {
                [index] = '.'
            };
            var aTask = Task.Run(() => NumberOfValidPermutations(a.ToString(), groups));
            var b = new StringBuilder(row)
            {
                [index] = '#'
            };
            var bTask = Task.Run(() => NumberOfValidPermutations(b.ToString(), groups));

            return aTask.Result + bTask.Result;
        }

        var result = row.Split('.', StringSplitOptions.RemoveEmptyEntries).Select(s => s.Length);
        return result.SequenceEqual(groups) ? 1 : 0;
    }
}
