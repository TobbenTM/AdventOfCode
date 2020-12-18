using System.Linq;
using System.Text.RegularExpressions;

namespace AOC.Solver
{
    public static class Day18
    {
        public static long SolvePart1(string[] input)
        {
            return input.Select(line => CalculateExpression(line)).Sum();
        }

        public static long SolvePart2(string[] input)
        {
            return input.Select(line => CalculateExpression(line, true)).Sum();
        }

        private static long CalculateExpression(string expression, bool considerPrecedence = false)
        {
            var re = new Regex(@"\([^\(\)]+\)");
            while (expression.Contains("("))
            {
                var match = re.Match(expression);
                var result = CalculateSimpleExpression(match.Value.Replace("(", "").Replace(")", ""), considerPrecedence);
                expression = expression.Replace(match.Value, result.ToString());
            }
            return CalculateSimpleExpression(expression, considerPrecedence);
        }

        private static long CalculateSimpleExpression(string expression, bool considerPrecedence = false)
        {
            var tokens = expression.Split(' ').ToList();
            if (!considerPrecedence)
            {
                var agg = long.Parse(tokens[0]);
                for (var i = 1; i < tokens.Count; i += 2)
                {
                    if (tokens[i] == "+") agg += long.Parse(tokens[i + 1]);
                    else agg *= long.Parse(tokens[i + 1]);
                }
                return agg;
            }
            else
            {
                while (tokens.Contains("+"))
                {
                    var index = tokens.FindIndex(t => t == "+");
                    var result = long.Parse(tokens[index - 1]) + long.Parse(tokens[index + 1]);
                    tokens.RemoveRange(index, 2);
                    tokens[index - 1] = result.ToString();
                }
                while (tokens.Contains("*"))
                {
                    var index = tokens.FindIndex(t => t == "*");
                    var result = long.Parse(tokens[index - 1]) * long.Parse(tokens[index + 1]);
                    tokens.RemoveRange(index, 2);
                    tokens[index - 1] = result.ToString();
                }
                return long.Parse(tokens.Single());
            }
        }
    }
}
