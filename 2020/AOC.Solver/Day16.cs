using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace AOC.Solver
{
    public static class Day16
    {
        public static int SolvePart1(string input)
        {
            var parsed = ParseInput(input);
            return parsed.otherTickets
                .SelectMany(arr => arr)
                .Where(n => !parsed.rules.Any(r => r.Valid(n)))
                .Sum();
        }

        public static long SolvePart2(string input)
        {
            var parsed = ParseInput(input);
            var validOtherTickets = parsed.otherTickets
                .Where(arr => arr.All(n => parsed.rules.Any(r => r.Valid(n))))
                .ToArray();
            foreach (var ticket in validOtherTickets)
            {
                var ruleMatches = parsed.rules
                    .Select(rule => (rule, indexes: ticket.Select((n, i) => (i, valid: rule.Valid(n)))
                    .Where(x => x.valid)
                    .Select(x => x.i)
                    .ToArray()));
                foreach (var (rule, indexes) in ruleMatches)
                {
                    rule.PossibleFieldIndexes = rule.PossibleFieldIndexes.Intersect(indexes).ToArray();
                }
            }
            var lockedIndexes = new List<int>();
            while (parsed.rules.Any(r => r.FieldIndex == -1))
            {
                foreach (var rule in parsed.rules.Where(r => r.FieldIndex == -1))
                {
                    if (rule.PossibleFieldIndexes.Except(lockedIndexes).Count() == 1)
                    {
                        rule.FieldIndex = rule.PossibleFieldIndexes.Except(lockedIndexes).Single();
                        lockedIndexes.Add(rule.FieldIndex);
                    }
                }
            }
            return parsed.rules
                .Where(r => r.Field.StartsWith("departure"))
                .Select(r => (long)parsed.ticket[r.FieldIndex])
                .Aggregate((a, b) => a * b);
        }

        private static (Rule[] rules, int[] ticket, int[][] otherTickets) ParseInput(string input)
        {
            var sections = input.Split(new[] { "\n\n" }, StringSplitOptions.RemoveEmptyEntries);
            var rules = sections[0].Split('\n').Select(line => new Rule(line)).ToArray();
            var ticket = sections[1].Split('\n').Last().Split(',').Select(int.Parse).ToArray();
            var otherTickets = sections[2]
                .Split('\n')
                .Skip(1)
                .Select(line => line.Split(',').Select(int.Parse).ToArray())
                .ToArray();
            return (rules, ticket, otherTickets);
        }

        private class Rule
        {
            public int FieldIndex { get; set; } = -1;
            public int[] PossibleFieldIndexes { get; set; } = Enumerable.Range(0, 100).ToArray();

            public string Field { get; }
            public (int from, int to) LowerRange { get; }
            public (int from, int to) UpperRange { get; }

            public Rule(string line)
            {
                var re = new Regex(@"^([^:]+): (\d+)-(\d+) or (\d+)-(\d+)");
                var matches = re.Match(line);
                Field = matches.Groups[1].Value;
                LowerRange = (int.Parse(matches.Groups[2].Value), int.Parse(matches.Groups[3].Value));
                UpperRange = (int.Parse(matches.Groups[4].Value), int.Parse(matches.Groups[5].Value));
            }

            public bool Valid(int number)
            {
                return number >= LowerRange.from && number <= LowerRange.to
                    || number >= UpperRange.from && number <= UpperRange.to;
            }
        }
    }
}
