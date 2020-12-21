using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace AOC.Solver
{
    public static class Day21
    {
        public static int SolvePart1(string[] input)
        {
            var parsedInput = input.Select(line => ParseInput(line));
            var ingredientCombinations = DeduceCombinations(parsedInput);
            return parsedInput.Select(x => x.ingredients.Except(ingredientCombinations.Keys).Count()).Sum();
        }

        public static string SolvePart2(string[] input)
        {
            var parsedInput = input.Select(line => ParseInput(line));
            var ingredientCombinations = DeduceCombinations(parsedInput);
            return string.Join(",", ingredientCombinations.OrderBy(kv => kv.Value).Select(kv => kv.Key));
        }

        private static (string[] ingredients, string[] allergens) ParseInput(string line)
        {
            var re = new Regex(@"^([\w ]+)(?:\(contains ([\w ,]+)\))?$");
            var match = re.Match(line);
            return (
                match.Groups[1].Value.Split(' ').Where(i => i.Length > 0).ToArray(),
                match.Groups[2].Value.Split(',').Select(a => a.Trim()).ToArray());
        }

        private static Dictionary<string, string> DeduceCombinations(IEnumerable<(string[] ingredients, string[] allergens)> parsedInput)
        {
            var allergenMap = new Dictionary<string, List<string>>();
            var lockedCombinations = new Dictionary<string, string>();

            foreach (var (ingredients, allergens) in parsedInput)
            {
                foreach (var allergen in allergens)
                {
                    if (!allergenMap.ContainsKey(allergen))
                    {
                        allergenMap.Add(allergen, ingredients.ToList());
                    }
                    else
                    {
                        allergenMap[allergen] = allergenMap[allergen].Intersect(ingredients).ToList();
                    }
                }
            }

            while (allergenMap.Values.Any(ingredients => ingredients.Except(lockedCombinations.Keys).Count() == 1))
            {
                var kv = allergenMap.First(kv => kv.Value.Except(lockedCombinations.Keys).Count() == 1);
                lockedCombinations.Add(kv.Value.Except(lockedCombinations.Keys).Single(), kv.Key);
            }

            return lockedCombinations;
        }
    }
}
