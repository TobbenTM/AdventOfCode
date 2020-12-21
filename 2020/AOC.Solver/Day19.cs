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
            var re = new Regex($"^{rules[0].ToRegex(rules)}$", RegexOptions.Multiline);
            return inputSections
                .Last()
                .Split('\n')
                .Count(line => re.IsMatch(line));
        }

        public static int SolvePart2(string input)
        {
            var inputSections = input.Split(new[] { "\n\n" }, StringSplitOptions.None);
            var rules = inputSections
                .First()
                .Split('\n')
                .Select(line => new Rule(line))
                .ToDictionary(r => r.Number, r => r);
            var re = new Regex($"^({rules[42].ToRegex(rules)})+(?<Balance>{rules[42].ToRegex(rules)})+(?<-Balance>{rules[31].ToRegex(rules)})+(?(Balance)(?!))$", RegexOptions.Multiline);
            return inputSections
                .Last()
                .Split('\n')
                .Count(line => re.IsMatch(line));
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

            public string ToRegex(Dictionary<int, Rule> rules)
            {
                if (_matchingChar != null)
                {
                    return _matchingChar.ToString();
                }
                var re = $"{string.Join("", _sublistA.Select(r => rules[r].ToRegex(rules)))}";
                if (_sublistB != null)
                {
                    re = $"({re}|{string.Join("", _sublistB.Select(r => rules[r].ToRegex(rules)))})";
                }
                return re;
            }
        }
    }
}
