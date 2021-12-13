using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace AOC.Solver
{
    public static class Day13
    {
        public static int SolvePart1(string[] input)
        {
            var (paper, folds) = ParseInput(input);
            FoldPaper(paper, folds.First().x, folds.First().y);
            return paper.Count;
        }

        public static string SolvePart2(string[] input)
        {
            var (paper, folds) = ParseInput(input);
            foreach (var fold in folds)
            {
                FoldPaper(paper, fold.x, fold.y);
            }

            return PaperToString(paper);
        }

        private static string PaperToString(HashSet<(int x, int y)> paper)
        {
            var width = paper.Max(pos => pos.x);
            var height = paper.Max(pos => pos.y);

            var builder = new StringBuilder();
            for (var y = 0; y <= height; y++)
            {
                for (var x = 0; x <= width; x++)
                {
                    builder.Append(paper.Contains((x, y)) ? '#' : '.');
                }

                builder.Append('\n');
            }

            return builder.ToString();
        }

        private static (HashSet<(int x, int y)> paper, List<(int? x, int? y)> folds) ParseInput(string[] input)
        {
            var paper = new HashSet<(int x, int y)>();
            var folds = new List<(int? x, int? y)>();

            foreach (var line in input)
            {
                if (line.Contains(','))
                {
                    var coords = line.Split(",").Select(int.Parse).ToArray();
                    paper.Add((coords[0], coords[1]));
                }
                else
                {
                    var tuple = line.Remove(0, 11).Split('=').ToArray();
                    if (tuple[0] == "y")
                    {
                        folds.Add((null, int.Parse(tuple[1])));
                    }
                    else
                    {
                        folds.Add((int.Parse(tuple[1]), null));
                    }
                }
            }

            return (paper, folds);
        }

        private static void FoldPaper(HashSet<(int x, int y)> paper, int? x, int? y)
        {
            if (x.HasValue)
            {
                var fold = paper.Where(spot => spot.x > x).ToArray();
                foreach (var spot in fold)
                {
                    paper.Add((x.Value - (spot.x - x.Value), spot.y));
                    paper.Remove(spot);
                }
            }
            if (y.HasValue)
            {
                var fold = paper.Where(spot => spot.y > y).ToArray();
                foreach (var spot in fold)
                {
                    paper.Add((spot.x, y.Value - (spot.y - y.Value)));
                    paper.Remove(spot);
                }
            }
        }
    }
}
