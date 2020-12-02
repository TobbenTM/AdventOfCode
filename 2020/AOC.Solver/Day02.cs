using System;
using System.Linq;

namespace AOC.Solver
{
    public static class Day02
    {
        public static int SolvePart1(string[] input)
        {
            var parsed = ParseInput(input);
            return parsed.Count(line => IsValid1(line.a, line.b, line.ch, line.pass));
        }

        public static int SolvePart2(string[] input)
        {
            var parsed = ParseInput(input);
            return parsed.Count(line => IsValid2(line.a, line.b, line.ch, line.pass));
        }

        private static (int a, int b, char ch, string pass)[] ParseInput(string[] input)
        {
            return input
                .Select(str => str.Split(new[] { '-', ' ', ':' }, StringSplitOptions.RemoveEmptyEntries))
                .Select(arr => (int.Parse(arr[0]), int.Parse(arr[1]), arr[2][0], arr[3]))
                .ToArray();
        }

        private static bool IsValid1(int min, int max, char ch, string pass)
        {
            var count = pass.ToCharArray().Count(c => c == ch);
            return count >= min && count <= max;
        }

        private static bool IsValid2(int min, int max, char ch, string pass)
        {
            return pass[min-1] == ch ^ pass[max-1] == ch;
        }
    }
}
