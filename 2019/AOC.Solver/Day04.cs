using System.Linq;

namespace AOC.Solver
{
    public static class Day04
    {
        public static int SolvePart1(int from, int to)
        {
            return Enumerable.Range(from, to - from).Count(p => SatisfiesCriteria1(p));
        }

        public static bool SatisfiesCriteria1(int password)
        {
            var str = password.ToString();
            var hasPair = false;
            for (var i = 1; i < str.Length; i++)
            {
                if (str[i - 1] > str[i]) return false;
                if (str[i - 1] == str[i])
                {
                    hasPair = true;
                }
            }
            return hasPair;
        }

        public static int SolvePart2(int from, int to)
        {
            return Enumerable.Range(from, to - from).Count(p => SatisfiesCriteria2(p));
        }

        public static bool SatisfiesCriteria2(int password)
        {
            var str = password.ToString();
            var hasPair = false;
            for (var i = 1; i < str.Length; i++)
            {
                if (str[i - 1] > str[i]) return false;
                if (str[i - 1] == str[i]
                    && (i == 1 || str[i - 2] != str[i])
                    && (i == str.Length - 1 || str[i] != str[i + 1]))
                {
                    hasPair = true;
                }
            }
            return hasPair;
        }
    }
}
