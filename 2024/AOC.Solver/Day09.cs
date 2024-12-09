using System;
using System.Linq;

namespace AOC.Solver;

public static class Day09
{
    public static long SolvePart1(string input)
    {
        var map = input.Select(ch => int.Parse(ch.ToString())).ToArray();
        var disk = new int[map.Sum()];
        for (int i = 0, m = 0; i < map.Length; i++)
        {
            for (var j = 0; j < map[i]; j++)
            {
                if (i % 2 == 0)
                {
                    disk[m++] = i / 2;
                }
                else
                {
                    disk[m++] = -1;
                }
            }
        }

        for (int i = 0, j = disk.Length - 1; i < j; i++)
        {
            if (disk[i] != -1)
            {
                continue;
            }

            for (; j > i; j--)
            {
                if (disk[j] != -1)
                {
                    (disk[j], disk[i]) = (disk[i], disk[j]);
                    break;
                }
            }
        }

        return disk.Select((n, i) => n == -1 ? 0L : n * i).Sum();
    }

    public static long SolvePart2(string input)
    {
        var map = input.Select((ch, i) => (Length: int.Parse(ch.ToString()), Id: i % 2 == 0 ? i / 2 : -1)).ToList();
        var disk = new int[map.Sum(t => t.Length)];

        for (var i = map.Count - 1; i > 0; i--)
        {
            if (map[i].Id == -1) continue;
            for (var j = 0; j < i; j++)
            {
                if (map[j].Id != -1 || map[j].Length < map[i].Length) continue;
                var leftover = map[j].Length - map[i].Length;
                map[j] = (Length: map[i].Length, Id: map[i].Id);
                map[i] = (Length: map[i].Length, Id: -1);
                if (leftover == 0) break;

                if (map[j + 1].Id == -1)
                {
                    map[j + 1] = (Length: map[j + 1].Length + leftover, Id: -1);
                }
                else
                {
                    map.Insert(j + 1, (Length: leftover, Id: -1));
                }

                break;
            }
        }

        for (int i = 0, m = 0; i < map.Count; i++)
        {
            for (var j = 0; j < map[i].Length; j++)
            {
                disk[m++] = map[i].Id;
            }
        }

        return disk.Select((n, i) => n == -1 ? 0L : n * i).Sum();
    }
}
