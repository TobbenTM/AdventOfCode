using System.Linq;
using System.Text.RegularExpressions;

namespace AOC.Solver;

public static class Day08
{
    private static readonly Regex NodeRe = new(@"([A-Z]{3}) = \(([A-Z]{3}), ([A-Z]{3})\)");

    public static int SolvePart1(string[] input)
    {
        var turns = input[0].ToCharArray();
        var nodes = input.Skip(1).Select(Parse).ToDictionary(n => n.Id);

        var current = nodes["AAA"];
        var steps = 0;
        while (current.Id != "ZZZ")
        {
            current = turns[steps % turns.Length] == 'R'
                ? nodes[current.Right]
                : nodes[current.Left];
            steps++;
        }

        return steps;
    }

    public static ulong SolvePart2(string[] input)
    {
        var turns = input[0].ToCharArray();
        var nodes = input.Skip(1).Select(Parse).ToDictionary(n => n.Id);

        var current = nodes.Values.Where(n => n.IsStartingNode).ToArray();
        var goals = new ulong[current.Length];
        var steps = 0u;
        while (goals.Any(n => n == 0))
        {
            var turnRight = turns[steps++ % turns.Length] == 'R';
            for (var i = 0; i < current.Length; i++)
            {
                current[i] = nodes[turnRight ? current[i].Right : current[i].Left];
                if (current[i].IsGoalNode && goals[i] == 0)
                    goals[i] = steps;
            }
        }

        return goals.Aggregate(LeastCommonMultiple);
    }

    private record DayNode(string Id, string Left, string Right)
    {
        public bool IsStartingNode => Id.EndsWith("A");
        public bool IsGoalNode => Id.EndsWith("Z");
    }

    private static DayNode Parse(string input)
    {
        var match = NodeRe.Match(input);
        return new DayNode(match.Groups[1].Value, match.Groups[2].Value, match.Groups[3].Value);
    }

    private static ulong GreatestCommonDivisor(ulong a, ulong b)
    {
        while (a != 0 && b != 0)
        {
            if (a > b)
                a %= b;
            else
                b %= a;
        }

        return a | b;
    }

    private static ulong LeastCommonMultiple(ulong a, ulong b) => a / GreatestCommonDivisor(a, b) * b;
}
