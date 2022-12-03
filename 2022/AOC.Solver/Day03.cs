using System.Linq;

namespace AOC.Solver;

public static class Day03
{
    private static int ItemToPriority(char item) => item - (item >= 'a' ? 'a' - 1 : 'A' - 27);

    public static int SolvePart1(string[] input)
    {
        int GetSharedItem(char[] backpack)
        {
            var a = backpack.Take(backpack.Length / 2);
            var b = backpack.Skip(backpack.Length / 2).Take(backpack.Length / 2);
            return ItemToPriority(a.Distinct().Intersect(b.Distinct()).Single());
        }

        return input.Select(b => GetSharedItem(b.ToCharArray())).Sum();
    }

    public static int SolvePart2(string[] input)
    {
        var total = 0;
        for (var i = 0; i < input.Length; i++)
        {
            var set = input[i].ToCharArray();
            for (var j = 0; j < 2; j++)
            {
                set = set.Intersect(input[++i].ToCharArray()).ToArray();
            }

            total += ItemToPriority(set.Single());
        }

        return total;
    }
}
