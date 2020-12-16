using System.Linq;

namespace AOC.Solver
{
    public static class Day15
    {
        public static int Solve(string input, int iterations)
        {
            var parsedInput = input
                .Split(',')
                .Select((s, i) => (n: int.Parse(s), i));
            var numbers = parsedInput
                .Take(parsedInput.Count() - 1)
                .ToDictionary(x => x.n, x => x.i);

            var next = parsedInput.Last().n;
            for (var i = parsedInput.Last().i; i < iterations - 1; i++)
            {
                if (numbers.ContainsKey(next))
                {
                    var distance = i - numbers[next];
                    numbers[next] = i;
                    next = distance;
                }
                else
                {
                    numbers[next] = i;
                    next = 0;
                }
            }
            return next;
        }
    }
}
