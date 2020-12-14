using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace AOC.Solver
{
    public static class Day14
    {
        public static long SolvePart1(string[] input)
        {
            var re = new Regex(@"^mem\[(\d+)\] = (\d+)$");
            var mem = new Dictionary<int, long>();
            var zeroMask = 0L;
            var oneMask = 0L;

            foreach (var line in input)
            {
                if (line.StartsWith("mask = "))
                {
                    var rawMask = line.Substring(7);
                    zeroMask = Convert.ToInt64(rawMask.Replace('X', '1'), 2);
                    oneMask = Convert.ToInt64(rawMask.Replace('X', '0'), 2);
                }
                else
                {
                    var matches = re.Match(line);
                    var addr = int.Parse(matches.Groups[1].Value);
                    var val = long.Parse(matches.Groups[2].Value);
                    mem[addr] = val & zeroMask | oneMask;
                }
            }

            return mem.Values.Sum();
        }

        public static long SolvePart2(string[] input)
        {
            var re = new Regex(@"^mem\[(\d+)\] = (\d+)$");
            var mem = new Dictionary<long, long>();
            var mask = "";

            foreach (var line in input)
            {
                if (line.StartsWith("mask = "))
                {
                    mask = line.Substring(7);
                }
                else
                {
                    var matches = re.Match(line);
                    var addr = int.Parse(matches.Groups[1].Value);
                    var val = long.Parse(matches.Groups[2].Value);
                    foreach (var (zeroMask, oneMask) in GetPossibleMasks(mask))
                    {
                        mem[addr & zeroMask | oneMask] = val;
                    }
                }
            }

            return mem.Values.Sum();
        }

        public static IEnumerable<(long zeroMask, long oneMask)> GetPossibleMasks(string mask)
        {
            var floatingBits = mask.ToCharArray().Count(c => c == 'X');
            var iterations = Math.Pow(2, floatingBits);
            for (var i = 0; i < iterations; i++)
            {
                var bits = Convert.ToString(i, 2).PadLeft(floatingBits, '0');

                var bitc = bits.Length;
                var zeroMask = mask
                    .Replace('0', '1')
                    .ToCharArray()
                    .Aggregate("", (a, c) => a + (c == 'X' ? bits[--bitc] : c));
                bitc = bits.Length;
                var oneMask = mask
                    .ToCharArray()
                    .Aggregate("", (a, c) => a + (c == 'X' ? bits[--bitc] : c));

                yield return (Convert.ToInt64(zeroMask, 2), Convert.ToInt64(oneMask, 2));
            }
        }
    }
}
