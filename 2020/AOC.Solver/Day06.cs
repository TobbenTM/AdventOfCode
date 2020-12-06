using System;
using System.Linq;

namespace AOC.Solver
{
    public static class Day06
    {
        public static int SolvePart1(string input)
        {
            return input.Split(new[] { "\n\n" }, StringSplitOptions.RemoveEmptyEntries)
                .Select(group => group.Replace("\n", "").ToCharArray().Distinct().Count())
                .Sum();
        }

        public static int SolvePart2(string input)
        {
            return input.Split(new[] { "\n\n" }, StringSplitOptions.RemoveEmptyEntries)
                .Select(group => group.Replace("\n", "")
                    .ToCharArray()
                    .GroupBy(q => q)
                    .Count(g => g.Count() == group.Split('\n').Count()))
                .Sum();
        }
    }
}
