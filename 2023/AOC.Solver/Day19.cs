using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace AOC.Solver;

public static class Day19
{
    public static long SolvePart1(string[] input)
    {
        var workflows = input.Where(l => !l.StartsWith("{")).Select(l => new Workflow(l)).ToDictionary(w => w.Name);
        var parts = input.Where(l => l.StartsWith("{")).Select(Part.Parse).ToArray();

        var result = 0L;

        foreach (var part in parts)
        {
            var workflow = workflows["in"];
            while (true)
            {
                var outcome = workflow.Run(part);
                if (outcome == "A")
                {
                    result += part.X + part.M + part.A + part.S;
                    break;
                }

                if (outcome == "R")
                {
                    break;
                }

                workflow = workflows[outcome];
            }
        }

        return result;
    }

    public static long SolvePart2(string[] input)
    {
        var workflows = input.Where(l => !l.StartsWith("{")).Select(l => new Workflow(l)).ToDictionary(w => w.Name);
        var validRanges = Visit(
            new PartRange((1, 4000), (1, 4000), (1, 4000), (1, 4000)),
            workflows["in"],
            workflows);
        return validRanges.Sum(r => r.Total);
    }

    private static IEnumerable<PartRange> Visit(PartRange range, Workflow workflow, IDictionary<string, Workflow> workflows)
    {
        foreach (var rule in workflow.Rules)
        {
            var relevantRange = range;
            if (rule.Condition != null)
            {
                relevantRange = range.Intersect(
                    key: rule.Condition.Value.Key,
                    greaterThan: rule.Condition.Value.GreaterThan,
                    value: rule.Condition.Value.Value,
                    remainder: out range);

            }
            if (rule.Target == "A") yield return relevantRange;
            else if (rule.Target != "R")
                foreach (var innerRange in Visit(relevantRange, workflows[rule.Target], workflows))
                    yield return innerRange;
        }
    }

    private record PartRange((int From, int To) X, (int From, int To) M, (int From, int To) A, (int From, int To) S)
    {
        public long Total => checked((long)(X.To - X.From + 1) * (M.To - M.From + 1) * (A.To - A.From + 1) * (S.To - S.From + 1));

        public PartRange Intersect(string key, bool greaterThan, int value, out PartRange remainder)
        {
            switch (key)
            {
                case "x":
                    remainder = this with
                    {
                        X = greaterThan ? (X.From, value) : (value, X.To),
                    };
                    return this with
                    {
                        X = greaterThan ? (value + 1, X.To) : (X.From, value - 1),
                    };
                case "m":
                    remainder = this with
                    {
                        M = greaterThan ? (M.From, value) : (value, M.To),
                    };
                    return this with
                    {
                        M = greaterThan ? (value + 1, M.To) : (M.From, value - 1),
                    };
                case "a":
                    remainder = this with
                    {
                        A = greaterThan ? (A.From, value) : (value, A.To),
                    };
                    return this with
                    {
                        A = greaterThan ? (value + 1, A.To) : (A.From, value - 1),
                    };
                case "s":
                    remainder = this with
                    {
                        S = greaterThan ? (S.From, value) : (value, S.To),
                    };
                    return this with
                    {
                        S = greaterThan ? (value + 1, S.To) : (S.From, value - 1),
                    };
                default:
                    throw new ArgumentOutOfRangeException(nameof(key));
            }
        }
    }

    private record Part(int X, int M, int A, int S)
    {
        public static Part Parse(string input)
        {
            var re = new Regex(@"\{x=(\d+),m=(\d+),a=(\d+),s=(\d+)\}");
            var match = re.Match(input);
            return new Part(int.Parse(match.Groups[1].Value), int.Parse(match.Groups[2].Value),
                int.Parse(match.Groups[3].Value), int.Parse(match.Groups[4].Value));
        }

        public int this[string key] =>
            key switch
            {
                "x" or "X" => X,
                "m" or "M" => M,
                "a" or "A" => A,
                "s" or "S" => S,
                _ => throw new ArgumentOutOfRangeException(nameof(key), key, null)
            };
    }

    private class Workflow
    {
        public readonly Rule[] Rules;

        public string Name { get; }

        public Workflow(string input)
        {
            var re = new Regex(@"(\w+){([^\}]+)}");
            var match = re.Match(input);
            Name = match.Groups[1].Value;
            var rules = match.Groups[2].Value.Split(",");
            Rules = rules.Select(r => new Rule(r)).ToArray();
        }

        public string Run(Part part)
        {
            foreach (var rule in Rules)
            {
                var result = rule.Run(part);
                if (result != null) return result;
            }

            throw new ApplicationException("No rules valid");
        }

        public class Rule
        {
            public readonly (string Key, Func<Part, int> Selector, bool GreaterThan, int Value)? Condition;
            public readonly string Target;

            public Rule(string rule)
            {
                var parts = rule.Split(':');
                if (parts.Length > 1)
                {
                    var re = new Regex(@"(\w)([<>])(\d+)");
                    var match = re.Match(parts.First());
                    Condition = (match.Groups[1].Value, ToSelector(match.Groups[1].Value), match.Groups[2].Value == ">", int.Parse(match.Groups[3].Value));
                }
                Target = parts.Last();
            }

            public string? Run(Part part)
            {
                if (Condition != null)
                {
                    var value = Condition.Value.Selector(part);
                    switch (Condition.Value.GreaterThan)
                    {
                        case true when Condition.Value.Value >= value:
                        case false when Condition.Value.Value <= value:
                            return null;
                    }
                }
                return Target;
            }

            private static Func<Part, int> ToSelector(string prop) => prop switch
            {
                "x" => p => p.X,
                "m" => p => p.M,
                "a" => p => p.A,
                "s" => p => p.S,
                _ => throw new ArgumentOutOfRangeException(nameof(prop), prop, null)
            };
        }
    }
}
