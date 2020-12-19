using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace AOC.Solver
{
    public static class Day19
    {
        public static int SolvePart1(string input)
        {
            var inputSections = input.Split(new[] { "\n\n" }, StringSplitOptions.None);
            var rules = inputSections
                .First()
                .Split('\n')
                .Select(line => new Rule(line))
                .ToDictionary(r => r.Number, r => r);
            return inputSections
                .Last()
                .Split('\n')
                .Select(line => rules[0].IsValid(rules, line))
                .Count(x => x.valid && x.next.Length == 0);
        }

        public static int SolvePart2(string input, string[] replacementRulesInput)
        {
            var inputSections = input.Split(new[] { "\n\n" }, StringSplitOptions.None);
            var rules = inputSections
                .First()
                .Split('\n')
                .Select(line => new Rule(line))
                .ToDictionary(r => r.Number, r => r);
            var replacementRules = replacementRulesInput
                .Select(line => new Rule(line));
            foreach (var rule in replacementRules)
            {
                rules[rule.Number] = rule;
            }
            return inputSections
                .Last()
                .Split('\n')
                .Select(line => rules[0].IsValid(rules, line))
                .Count(x => x.valid && x.next.Length == 0);
        }

        private class Rule
        {
            public int Number { get; }
            private readonly char? _matchingChar;
            private readonly int[]? _sublistA;
            private readonly int[]? _sublistB;

            public Rule(string rule)
            {
                var re = new Regex(@"^(\d+): (?:(?:""(\w)"")|(?:([\d ]+)\|?([\d ]+)?))$");
                var match = re.Match(rule);
                Number = int.Parse(match.Groups[1].Value);
                _matchingChar = match.Groups[2].Success
                    ? match.Groups[2].Value.SingleOrDefault()
                    : null;
                _sublistA = match.Groups[3].Success
                    ? match.Groups[3].Value.Trim().Split(' ').Select(int.Parse).ToArray()
                    : null;
                _sublistB = match.Groups[4].Success
                    ? match.Groups[4].Value.Trim().Split(' ').Select(int.Parse).ToArray()
                    : null;
            }

            public (bool valid, string next) IsValid(Dictionary<int, Rule> rules, string input)
            {
                if (input.Length == 0)
                {
                    return (false, input);
                }
                if (_matchingChar != null)
                {
                    return (input[0] == _matchingChar, input.Substring(1));
                }
                var a = IsValidChain(_sublistA!, rules, input);
                if (!a.valid && _sublistB != null)
                {
                    return IsValidChain(_sublistB, rules, input);
                }
                return a;
            }

            private (bool valid, string next) IsValidChain(int[] chain, Dictionary<int, Rule> rules, string input)
            {
                foreach (var ruleNum in chain)
                {
                    var result = rules[ruleNum].IsValid(rules, input);
                    if (!result.valid) return (false, string.Empty);
                    input = result.next;
                }
                return (true, input);
            }
        }
    }
}
