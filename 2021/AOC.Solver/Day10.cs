using System.Collections.Generic;
using System.Linq;

namespace AOC.Solver
{
    public static class Day10
    {
        public static int SolvePart1(string[] input)
        {
            return input.Select(ScoreCorruption).Sum();
        }

        private static int ScoreCorruption(string line)
        {
            var stack = new Stack<char>();
            foreach (var ch in line)
            {
                switch (ch)
                {
                    case '(':
                    case '[':
                    case '{':
                    case '<':
                        stack.Push(ch);
                        break;
                    case ')':
                        if (stack.Pop() != '(')
                        {
                            return 3;
                        }
                        break;
                    case ']':
                        if (stack.Pop() != '[')
                        {
                            return 57;
                        }
                        break;
                    case '}':
                        if (stack.Pop() != '{')
                        {
                            return 1197;
                        }
                        break;
                    case '>':
                        if (stack.Pop() != '<')
                        {
                            return 25137;
                        }
                        break;
                }
            }

            return 0;
        }

        public static long SolvePart2(string[] input)
        {
            var scores = input
                .Select(ScoreAutocompletion)
                .Where(score => score > 0)
                .OrderBy(score => score)
                .ToList();
            var middle = scores.Count / 2;
            return scores[middle];
        }

        private static long ScoreAutocompletion(string line)
        {
            var stack = new Stack<char>();
            foreach (var ch in line)
            {
                switch (ch)
                {
                    case '(':
                    case '[':
                    case '{':
                    case '<':
                        stack.Push(ch);
                        break;
                    case ')':
                        if (stack.Pop() != '(')
                        {
                            return 0;
                        }
                        break;
                    case ']':
                        if (stack.Pop() != '[')
                        {
                            return 0;
                        }
                        break;
                    case '}':
                        if (stack.Pop() != '{')
                        {
                            return 0;
                        }
                        break;
                    case '>':
                        if (stack.Pop() != '<')
                        {
                            return 0;
                        }
                        break;
                }
            }

            var score = 0L;

            while (stack.Any())
            {
                score *= 5;
                score += stack.Pop() switch
                {
                    '(' => 1,
                    '[' => 2,
                    '{' => 3,
                    '<' => 4,
                    _ => 0,
                };
            }

            return score;
        }
    }
}
