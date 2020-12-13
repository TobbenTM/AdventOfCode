using System.Linq;
using System.Numerics;

namespace AOC.Solver
{
    public static class Day13
    {
        public static int SolvePart1(string[] input)
        {
            var earliest = int.Parse(input[0]);
            var fastestBus = input[1]
                .Split(',')
                .Where(id => id != "x")
                .Select(int.Parse)
                .Select<int, (int id, int wait)>(id => (id, id - earliest % id))
                .OrderBy(x => x.wait)
                .First();
            return fastestBus.id * fastestBus.wait;
        }

        public static long SolvePart2(string[] input)
        {
            var busIds = input[1]
                .Split(',')
                .Select<string, (string busId, int index)>((s, i) => (s, i))
                .Where(x => x.busId != "x")
                .Select<(string busId, int index), (long mod, long remainder)>(
                    x => (long.Parse(x.busId), long.Parse(x.busId) - x.index))
                .ToArray();
            return CRT(busIds);
        }

        private static long CRT((long m, long r)[] busses)
        {
            var n = busses.Select(b => b.m).Aggregate((a, b) => a * b);
            var x = busses.Select(b => b.r * n / b.m * (long)BigInteger.ModPow(n / b.m, b.m - 2, b.m)).Sum();
            return x % n;
        }
    }
}
