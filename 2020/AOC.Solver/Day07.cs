using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace AOC.Solver
{
    public static class Day07
    {
        public static int SolvePart1(string[] input)
        {
            var outerRe = new Regex(@"^([\w\s]+) bags contain ((?:\d+ \w+ \w+ bags?,?\s?)+)");
            var innerRe = new Regex(@"\d+ (\w+ \w+) bags?");
            var canBeCarriedIn = new Dictionary<string, List<string>>();
            foreach (var rule in input)
            {
                if (outerRe.IsMatch(rule))
                {
                    var main = outerRe.Matches(rule)[0].Groups[1].Value;
                    var result = outerRe.Matches(rule)[0].Groups[2].Value
                        .Split(',')
                        .Select(s => innerRe.Matches(s)[0].Groups[1].Value)
                        .ToArray();
                    for (var i = 0; i < result.Length; i++)
                    {
                        if (!canBeCarriedIn.ContainsKey(result[i])) canBeCarriedIn.Add(result[i], new List<string>());
                        canBeCarriedIn[result[i]].Add(main);
                    }
                }
            }
            return GetAllPossibleParents(canBeCarriedIn, "shiny gold").Distinct().Count();
        }

        private static IEnumerable<string> GetAllPossibleParents(Dictionary<string, List<string>> rules, string target)
        {
            foreach (var outer in rules[target])
            {
                yield return outer;
                if (!rules.ContainsKey(outer)) continue;
                foreach (var inner in rules[outer])
                {
                    yield return inner;
                    if (!rules.ContainsKey(inner)) continue;
                    foreach (var innerParent in GetAllPossibleParents(rules, inner))
                    {
                        yield return innerParent;
                    }
                }
            }
        }

        public static int SolvePart2(string[] input)
        {
            var outerRe = new Regex(@"^([\w\s]+) bags contain ((?:\d+ \w+ \w+ bags?,?\s?)+)");
            var innerRe = new Regex(@"(\d+) (\w+ \w+) bags?");
            var rules = new Dictionary<string, List<(string color, int quantity)>>();
            foreach (var rule in input)
            {
                if (outerRe.IsMatch(rule))
                {
                    var main = outerRe.Matches(rule)[0].Groups[1].Value;
                    var result = outerRe.Matches(rule)[0].Groups[2].Value
                        .Split(',')
                        .Select(s => (innerRe.Matches(s)[0].Groups[2].Value, int.Parse(innerRe.Matches(s)[0].Groups[1].Value)))
                        .ToArray();
                    for (var i = 0; i < result.Length; i++)
                    {
                        if (!rules.ContainsKey(main)) rules.Add(main, new List<(string color, int quantity)>());
                        rules[main].Add(result[i]);
                    }
                }
            }

            return GetNumberOfInnerBags(rules, "shiny gold");
        }

        private static int GetNumberOfInnerBags(Dictionary<string, List<(string color, int quantity)>> rules, string target)
        {
            var total = 0;
            foreach (var rule in rules[target])
            {
                total += rule.quantity;
                if (!rules.ContainsKey(rule.color)) continue;
                total += rule.quantity * GetNumberOfInnerBags(rules, rule.color);
            }
            return total;
        }
    }
}
