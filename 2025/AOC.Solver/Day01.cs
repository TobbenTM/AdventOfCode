namespace AOC.Solver;

public static class Day01
{
    public static int SolvePart1(string[] input)
    {
        var result = 0;
        var dial = 50;
        foreach (var line in input)
        {
            var direction = line[0];
            var clicks = int.Parse(line[1..]);
            (dial, _) = TurnDial(dial, clicks, direction);
            if (dial == 0) result++;
        }

        return result;
    }

    public static int SolvePart2(string[] input)
    {
        var result = 0;
        var dial = 50;
        foreach (var line in input)
        {
            var direction = line[0];
            var clicks = int.Parse(line[1..]);

            (dial, var zeroes) = TurnDial(dial, clicks, direction);
            result += zeroes;
        }

        return result;
    }

    public static (int dial, int zeroes) TurnDial(int current, int clicks, char direction)
    {
        var newDial = current;
        var zeroes = 0;

        // Horribly inefficient, but I'm lazy and short on time
        for (; clicks > 0; clicks--)
        {
            newDial += direction == 'L' ? -1 : 1;
            if (newDial > 99)
                newDial = 0;
            if (newDial < 0)
                newDial = 99;
            if (newDial == 0) zeroes++;
        }

        return (newDial, zeroes);
    }
}
