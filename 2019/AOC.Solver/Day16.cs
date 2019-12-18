using System;
using System.Collections.Generic;
using System.Linq;

namespace AOC.Solver
{
    public static class Day16
    {
        public static string FFT(string input, int phases)
        {
            var numbers = input.ToCharArray().Select(c => int.Parse(c.ToString())).ToArray();
            var basePattern = new[] { 0, 1, 0, -1 };
            var patterns = Enumerable.Range(0, numbers.Length).Select((cnt) =>
            {
                var pattern = new List<int>();
                foreach (var factor in basePattern)
                {
                    for (var i = 0; i < cnt + 1; i++)
                    {
                        pattern.Add(factor);
                    }
                }

                while (pattern.Count < numbers.Length)
                {
                    pattern.AddRange(pattern.ToArray());
                }

                pattern.RemoveAt(0);
                pattern.Add(basePattern[0]);

                return pattern.ToArray();
            }).ToArray();

            for (var phase = 1; phase <= phases; phase++)
            {
                var phaseOutput = new int[numbers.Length];
                for (var element = 0; element < numbers.Length; element++)
                {
                    var result = 0;

                    for (var i = 0; i < numbers.Length; i++)
                    {
                        result += numbers[i] * patterns[element][i];
                    }
                    phaseOutput[element] = Math.Abs(result) % 10;
                }
                numbers = phaseOutput;
            }

            return string.Join("", numbers.Take(8));
        }
    }
}
