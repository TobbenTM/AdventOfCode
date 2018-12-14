using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AOC.Solver
{
    public static class Day14
    {
        public class KakaoBrewery
        {
            private readonly int _targetIterations;
            private List<int> _scores;
            private (int elf1, int elf2) _elfs = (0, 1);

            public KakaoBrewery(int targetIterations = 0)
            {
                _targetIterations = targetIterations;
                _scores = new List<int>((targetIterations + 10) * 2)
                {
                    3,
                    7,
                };
            }

            public int[] EvaluateNextTen()
            {
                while (_scores.Count < _targetIterations + 10)
                {
                    // Make new recipies
                    var newRecipe = _scores[_elfs.elf1] + _scores[_elfs.elf2];
                    if (newRecipe >= 10)
                    {
                        _scores.Add(1);
                        _scores.Add(newRecipe % 10);
                    }
                    else
                    {
                        _scores.Add(newRecipe);
                    }

                    // Move elfs
                    _elfs.elf1 = (_elfs.elf1 + 1 + _scores[_elfs.elf1]) % _scores.Count;
                    _elfs.elf2 = (_elfs.elf2 + 1 + _scores[_elfs.elf2]) % _scores.Count;
                }
                return _scores.Skip(_targetIterations).Take(10).ToArray();
            }

            // This has potentially the most ugly matching process ever, but I'm on vacation so whatever
            public int EvaluateUntilMatch(string target)
            {
                var parsedTarget = target.Select(c => int.Parse(c.ToString())).ToArray();
                var currentMatchIndex = 0;
                while (true)
                {
                    // Make new recipies
                    var newRecipe = _scores[_elfs.elf1] + _scores[_elfs.elf2];
                    if (newRecipe >= 10)
                    {
                        _scores.Add(1);
                        _scores.Add(newRecipe % 10);

                        // Try match
                        if (parsedTarget[currentMatchIndex] == 1)
                        {
                            // Matched first, check if done or second
                            if (currentMatchIndex + 1 == parsedTarget.Length)
                            {
                                return _scores.Count - parsedTarget.Length - 1;
                            }
                            else if (parsedTarget[currentMatchIndex + 1] == newRecipe % 10)
                            {
                                currentMatchIndex += 2;
                            }
                            else if (parsedTarget[0] == newRecipe % 10)
                            {
                                currentMatchIndex = 1;
                            }
                            else
                            {
                                currentMatchIndex = 0;
                            }
                        }
                        else if (parsedTarget[0] == 1)
                        {
                            // Matched first, check second
                            if (parsedTarget[1] == newRecipe % 10)
                            {
                                currentMatchIndex = 2;
                            }
                            else
                            {
                                currentMatchIndex = 0;
                            }
                        }
                        else
                        {
                            // Reset
                            if (parsedTarget[0] == newRecipe % 10)
                            {
                                currentMatchIndex = 1;
                            }
                            else
                            {
                                currentMatchIndex = 0;
                            }
                        }
                    }
                    else
                    {
                        _scores.Add(newRecipe);

                        // Try match
                        if (parsedTarget[currentMatchIndex] == newRecipe)
                        {
                            currentMatchIndex += 1;
                        }
                        else if (parsedTarget[0] == newRecipe)
                        {
                            currentMatchIndex = 1;
                        }
                        else
                        {
                            currentMatchIndex = 0;
                        }
                    }

                    // Move elfs
                    _elfs.elf1 = (_elfs.elf1 + 1 + _scores[_elfs.elf1]) % _scores.Count;
                    _elfs.elf2 = (_elfs.elf2 + 1 + _scores[_elfs.elf2]) % _scores.Count;

                    // Check regular match
                    if (currentMatchIndex == parsedTarget.Length)
                    {
                        return _scores.Count - parsedTarget.Length;
                    }
                }
            }
        }
    }
}
