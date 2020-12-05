using System;
using System.Linq;

namespace AOC.Solver
{
    public static class Day05
    {
        public static int SolvePart1(string[] input)
        {
            var max = 0;
            foreach (var seat in input)
            {
                var location = LocateSeat(seat);
                if (location.id > max) max = location.id;
            }
            return max;
        }

        public static int SolvePart2(string[] input)
        {
            var map = input.Select(s => LocateSeat(s)).OrderBy(x => x.id).ToArray();
            for (var i = 0; i < map.Length; i++)
            {
                if (map[i + 1].id != map[i].id + 1) return map[i].id + 1;
            }
            throw new InvalidOperationException("Shouldn't ever reach this point");
        }

        public static (int row, int column, int id) LocateSeat(string seat, int height = 128, int width = 8)
        {
            var rowData = seat.Substring(0, 7).ToCharArray();
            var colData = seat.Substring(7, 3).ToCharArray();

            var row = Locate(rowData, height);
            var col = Locate(colData, width);

            return (row, col, row * 8 + col);
        }

        private static int Locate(char[] data, int range)
        {
            var offset = 0;
            foreach (var ch in data)
            {
                range /= 2;
                if (ch == 'B' || ch == 'R')
                {
                    offset += range;
                }
            }
            return offset;
        }
    }
}
