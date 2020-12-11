using System.Collections.Generic;
using System.Linq;

namespace AOC.Solver
{
    public static class Day11
    {
        public static int SolvePart1(string[] input)
        {
            var seatMap = input.Select(line => line.ToCharArray()).ToArray();
            while (MutatePart1(seatMap)) { /* noop */ }
            return seatMap.SelectMany(c => c).Count(c => c == '#');
        }

        public static int SolvePart2(string[] input)
        {
            var seatMap = input.Select(line => line.ToCharArray()).ToArray();
            while (MutatePart2(seatMap)) { /* noop */ }
            return seatMap.SelectMany(c => c).Count(c => c == '#');
        }

        private static bool MutatePart1(char[][] seatMap)
        {
            var queuedChanges = new List<(int x, int y, char state)>();

            for (var y = 0; y < seatMap.Length; y++)
            {
                for (var x = 0; x < seatMap[y].Length; x++)
                {
                    if (seatMap[y][x] == 'L' && NumberOfFreeAdjacentSeats(seatMap, x, y) == 8)
                    {
                        queuedChanges.Add((x, y, '#'));
                    }
                    else if (seatMap[y][x] == '#' && NumberOfFreeAdjacentSeats(seatMap, x, y) <= 4)
                    {
                        queuedChanges.Add((x, y, 'L'));
                    }
                }
            }

            foreach (var (x, y, state) in queuedChanges)
            {
                seatMap[y][x] = state;
            }

            return queuedChanges.Any();
        }

        private static int NumberOfFreeAdjacentSeats(char[][] seatMap, int x, int y)
        {
            var total = 0;

            if (y == 0 || seatMap[y - 1][x] != '#') total += 1;
            if (y == seatMap.Length - 1 || seatMap[y + 1][x] != '#') total += 1;
            if (x == 0 || seatMap[y][x - 1] != '#') total += 1;
            if (x == seatMap[y].Length - 1 || seatMap[y][x + 1] != '#') total += 1;

            if (y == 0 || x == 0 || seatMap[y - 1][x - 1] != '#') total += 1;
            if (y == 0 || x == seatMap[y].Length - 1 || seatMap[y - 1][x + 1] != '#') total += 1;
            if (y == seatMap.Length - 1 || x == 0 || seatMap[y + 1][x - 1] != '#') total += 1;
            if (y == seatMap.Length - 1 || x == seatMap[y].Length - 1 || seatMap[y + 1][x + 1] != '#') total += 1;

            return total;
        }

        private static bool MutatePart2(char[][] seatMap)
        {
            var queuedChanges = new List<(int x, int y, char state)>();

            for (var y = 0; y < seatMap.Length; y++)
            {
                for (var x = 0; x < seatMap[y].Length; x++)
                {
                    if (seatMap[y][x] == 'L' && NumberOfFreeLineOfSightSeats(seatMap, x, y) == 8)
                    {
                        queuedChanges.Add((x, y, '#'));
                    }
                    else if (seatMap[y][x] == '#' && NumberOfFreeLineOfSightSeats(seatMap, x, y) <= 3)
                    {
                        queuedChanges.Add((x, y, 'L'));
                    }
                }
            }

            foreach (var (x, y, state) in queuedChanges)
            {
                seatMap[y][x] = state;
            }

            return queuedChanges.Any();
        }

        private static int NumberOfFreeLineOfSightSeats(char[][] seatMap, int x, int y)
        {
            var total = 0;

            if (!SeatCanSeeOccupiedSeat(seatMap, x, y, 0, -1)) total += 1;
            if (!SeatCanSeeOccupiedSeat(seatMap, x, y, -1, 0)) total += 1;
            if (!SeatCanSeeOccupiedSeat(seatMap, x, y, 0, 1)) total += 1;
            if (!SeatCanSeeOccupiedSeat(seatMap, x, y, 1, 0)) total += 1;

            if (!SeatCanSeeOccupiedSeat(seatMap, x, y, -1, -1)) total += 1;
            if (!SeatCanSeeOccupiedSeat(seatMap, x, y, 1, -1)) total += 1;
            if (!SeatCanSeeOccupiedSeat(seatMap, x, y, -1, 1)) total += 1;
            if (!SeatCanSeeOccupiedSeat(seatMap, x, y, 1, 1)) total += 1;

            return total;
        }

        private static bool SeatCanSeeOccupiedSeat(char[][] seatMap, int x, int y, int dx, int dy)
        {
            y += dy;
            x += dx;
            while (y >= 0 && y <= seatMap.Length - 1 && x >= 0 && x <= seatMap[y].Length - 1)
            {
                if (seatMap[y][x] == '#') return true;
                if (seatMap[y][x] == 'L') return false;
                y += dy;
                x += dx;
            }
            return false;
        }
    }
}
