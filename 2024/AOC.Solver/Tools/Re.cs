using System;
using System.Text.RegularExpressions;

namespace AOC.Solver.Tools;

public static class Re
{
    public static (T1, T2)? Match<T1, T2>(this string input, Regex pattern)
    {
        var match = pattern.Match(input);
        if (!match.Success) return null;
        return (
            (T1)Convert.ChangeType(match.Groups[1].Value, typeof(T1)),
            (T2)Convert.ChangeType(match.Groups[2].Value, typeof(T2))
        );
    }

    public static (T1, T2, T3)? Match<T1, T2, T3>(this string input, Regex pattern)
    {
        var match = pattern.Match(input);
        if (!match.Success) return null;
        return (
            (T1)Convert.ChangeType(match.Groups[1].Value, typeof(T1)),
            (T2)Convert.ChangeType(match.Groups[2].Value, typeof(T2)),
            (T3)Convert.ChangeType(match.Groups[3].Value, typeof(T3))
        );
    }

    public static (T1, T2, T3, T4)? Match<T1, T2, T3, T4>(this string input, Regex pattern)
    {
        var match = pattern.Match(input);
        if (!match.Success) return null;
        return (
            (T1)Convert.ChangeType(match.Groups[1].Value, typeof(T1)),
            (T2)Convert.ChangeType(match.Groups[2].Value, typeof(T2)),
            (T3)Convert.ChangeType(match.Groups[3].Value, typeof(T3)),
            (T4)Convert.ChangeType(match.Groups[4].Value, typeof(T4))
        );
    }
}
