using System.Collections.Generic;
using System.Linq;

namespace AOC.Solver
{
    public static class Day08
    {
        public static int SolvePart1(string[] input)
        {
            return input
                .SelectMany(line => line.Split("|")[1].Split(" "))
                .Count(output => output.Length is > 0 and (<= 4 or 7));
        }

        public static int SolvePart2(string[] input)
        {
            var entries = input.Select(entry => new Entry(entry)).ToList();
            return entries.Sum(entry => entry.Output);
        }

        private class Entry
        {
            public int Output { get; }

            public Entry(string entry)
            {
                var input = entry.Split("|")[0].Split(" ").Where(display => display.Length > 0).ToList();
                var output = entry.Split("|")[1].Split(" ").Where(display => display.Length > 0).ToList();
                var allSignatures = input
                    .Concat(output)
                    .Select(display => display.OrderBy(ch => ch).ToArray())
                    .ToList();

                var signatures = new Dictionary<int, char[]>
                {
                    { 1, allSignatures.First(sig => sig.Length == 2) },
                    { 7, allSignatures.First(sig => sig.Length == 3) },
                    { 4, allSignatures.First(sig => sig.Length == 4) },
                    { 8, allSignatures.First(sig => sig.Length == 7) },
                };

                var numberOfMutualSegments = (char[] a, char[] b) => a.Intersect(b).Count();

                foreach (var signature in allSignatures)
                {
                    if (signatures.Values.Contains(signature)) continue;

                    if (signature.Length == 6
                        && numberOfMutualSegments(signature, signatures[1]) == 2
                        && numberOfMutualSegments(signature, signatures[4]) == 3
                        && numberOfMutualSegments(signature, signatures[7]) == 3)
                    {
                        signatures[0] = signature;
                        continue;
                    }
                    if (signature.Length == 5
                               && numberOfMutualSegments(signature, signatures[1]) == 1
                               && numberOfMutualSegments(signature, signatures[4]) == 2
                               && numberOfMutualSegments(signature, signatures[7]) == 2)
                    {
                        signatures[2] = signature;
                        continue;
                    }
                    if (signature.Length == 5
                               && numberOfMutualSegments(signature, signatures[1]) == 2
                               && numberOfMutualSegments(signature, signatures[4]) == 3
                               && numberOfMutualSegments(signature, signatures[7]) == 3)
                    {
                        signatures[3] = signature;
                        continue;
                    }
                    if (signature.Length == 5
                               && numberOfMutualSegments(signature, signatures[1]) == 1
                               && numberOfMutualSegments(signature, signatures[4]) == 3
                               && numberOfMutualSegments(signature, signatures[7]) == 2)
                    {
                        signatures[5] = signature;
                        continue;
                    }
                    if (signature.Length == 6
                               && numberOfMutualSegments(signature, signatures[1]) == 1
                               && numberOfMutualSegments(signature, signatures[4]) == 3
                               && numberOfMutualSegments(signature, signatures[7]) == 2)
                    {
                        signatures[6] = signature;
                        continue;
                    }
                    if (signature.Length == 6
                               && numberOfMutualSegments(signature, signatures[1]) == 2
                               && numberOfMutualSegments(signature, signatures[4]) == 4
                               && numberOfMutualSegments(signature, signatures[7]) == 3)
                    {
                        signatures[9] = signature;
                    }
                }

                for (int i = 0, t = 1000; i < output.Count; i++, t /= 10)
                {
                    Output += signatures.First(kv => kv.Value.SequenceEqual(output[i].OrderBy(ch => ch).ToArray())).Key * t;
                }
            }
        }
    }
}
