using System;
using System.Collections.Generic;
using System.Linq;

namespace AOC.Solver;

public static class Day07
{
    private record Directory
    {
        public Directory? Parent { get; init; }

        public Dictionary<string, Directory> Directories = new();

        public Dictionary<string, long> Files = new();

        public long Size => Files.Values.Sum() + Directories.Values.Sum(d => d.Size);
    };

    private static (List<Directory> all, Directory root) ParseInput(string[] input)
    {

        var root = new Directory();
        var all = new List<Directory> { root };
        var pwd = root;

        foreach (var line in input)
        {
            if (line.StartsWith('$'))
            {
                var command = line.Split(' ');
                if (command[1] == "cd")
                {
                    if (command[2] == "/")
                    {
                        pwd = root;
                    }
                    else if (command[2] == "..")
                    {
                        if (pwd.Parent == null) throw new InvalidOperationException("Directory has no parent!");
                        pwd = pwd.Parent;
                    }
                    else
                    {
                        pwd = pwd.Directories[command[2]];
                    }
                }
            }
            else
            {
                if (line.StartsWith("dir"))
                {
                    var dir = new Directory
                    {
                        Parent = pwd,
                    };
                    pwd.Directories.Add(line.Split(' ').Last(), dir);
                    all.Add(dir);
                }
                else
                {
                    var file = line.Split(' ');
                    pwd.Files.Add(file.Last(), int.Parse(file.First()));
                }
            }
        }

        return (all, root);
    }

    public static long SolvePart1(string[] input)
    {
        var (all, _) = ParseInput(input);
        return all.Where(d => d.Size < 100_000l).Sum(d => d.Size);
    }

    public static long SolvePart2(string[] input)
    {
        var (all, root) = ParseInput(input);
        var sizeUsed = root.Size;
        var totalSize = 70_000_000;
        var unusedSize = totalSize - sizeUsed;
        var neededSize = 30_000_000;
        var minDeleteSize = neededSize - unusedSize;
        return all.Where(d => d.Size > minDeleteSize).OrderBy(d => d.Size).First().Size;
    }
}
