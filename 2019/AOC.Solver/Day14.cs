using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace AOC.Solver
{
    public static class Day14
    {
        public class Recipe
        {
            public Dictionary<string, int> Inputs { get; } = new Dictionary<string, int>();

            public string OutputType { get; set; }

            public int OutputAmount { get; set; }

            public Recipe(string recipe)
            {
                var re = new Regex(@"(\d+) (\w+)");
                var input = recipe.Split(new[] { "=>" }, StringSplitOptions.RemoveEmptyEntries)[0];
                var output = recipe.Split(new[] { "=>" }, StringSplitOptions.RemoveEmptyEntries)[1];

                foreach (Match match in re.Matches(input))
                {
                    Inputs.Add(match.Groups[2].Value, int.Parse(match.Groups[1].Value));
                }
                OutputType = re.Match(output).Groups[2].Value;
                OutputAmount = int.Parse(re.Match(output).Groups[1].Value);
            }
        }

        public class NanoFactory
        {
            public Dictionary<string, Recipe> Recipes { get; } = new Dictionary<string, Recipe>();

            public NanoFactory(string[] input)
            {
                var recipes = input.Select(r => new Recipe(r)).ToList();
                foreach (var recipe in recipes)
                {
                    Recipes.Add(recipe.OutputType, recipe);
                }
            }

            public int CalculateOreDemand()
            {
                var requirements = new Dictionary<string, int>
                {
                    { "FUEL", 1 }
                };
                while (requirements.Any(kv => kv.Key != "ORE" && kv.Value > 0))
                {
                    var next = requirements.First(kv => kv.Key != "ORE" && kv.Value > 0);
                    var recipe = Recipes[next.Key];
                    var amount = next.Value;

                    var requiredIterations = (int)Math.Ceiling(amount / (decimal)recipe.OutputAmount);
                    requirements[recipe.OutputType] -= recipe.OutputAmount * requiredIterations;
                    foreach (var input in recipe.Inputs)
                    {
                        if (!requirements.ContainsKey(input.Key))
                        {
                            requirements.Add(input.Key, 0);
                        }
                        requirements[input.Key] += input.Value * requiredIterations;
                    }
                }
                return requirements["ORE"];
            }

            public int CalculateMaxFuelProduction()
            {
                var excess = new Dictionary<string, long>
                {
                    { "ORE", 1_000_000_000_000L }
                };
                throw new NotImplementedException();
            }
        }

        public static int SolvePart1(string[] input)
        {
            var factory = new NanoFactory(input);
            return factory.CalculateOreDemand();
        }

        public static int SolvePart2(string[] input)
        {
            var factory = new NanoFactory(input);
            return factory.CalculateMaxFuelProduction();
        }
    }
}
