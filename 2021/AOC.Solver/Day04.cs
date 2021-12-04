using System;
using System.Collections.Generic;
using System.Linq;

namespace AOC.Solver
{
    public static class Day04
    {
        public static int SolvePart1(string[] input)
        {
            var numbersDrawn = input[0].Split(",").Select(int.Parse);

            var boards = new List<BingoBoard>();
            for (int i = 2; i < input.Length; i++)
            {
                var boardValues = new List<int[]>();
                for (var j = 0; j < 5; j++, i++)
                {
                    boardValues.Add(input[i].Split(" ").Where(num => !string.IsNullOrEmpty(num)).Select(int.Parse).ToArray());
                }
                boards.Add(new BingoBoard(boardValues.ToArray()));
            }

            foreach (var num in numbersDrawn)
            {
                foreach (var board in boards)
                {
                    if (board.MarkValue(num))
                    {
                        return board.SumOfUnmarkedNumbers * num;
                    }
                }
            }

            throw new ApplicationException("Shouldn't reach this point ever.");
        }

        public static int SolvePart2(string[] input)
        {
            var numbersDrawn = input[0].Split(",").Select(int.Parse);

            var boards = new List<BingoBoard>();
            for (int i = 2; i < input.Length; i++)
            {
                var boardValues = new List<int[]>();
                for (var j = 0; j < 5; j++, i++)
                {
                    boardValues.Add(input[i].Split(" ").Where(num => !string.IsNullOrEmpty(num)).Select(int.Parse).ToArray());
                }
                boards.Add(new BingoBoard(boardValues.ToArray()));
            }

            foreach (var num in numbersDrawn)
            {
                var boardsToBeRemoved = new List<BingoBoard>();
                foreach (var board in boards)
                {
                    if (board.MarkValue(num))
                    {
                        boardsToBeRemoved.Add(board);
                    }
                }
                boardsToBeRemoved.ForEach(board => boards.Remove(board));

                if (!boards.Any())
                {
                    return boardsToBeRemoved.Last().SumOfUnmarkedNumbers * num;
                }
            }

            throw new ApplicationException("Shouldn't reach this point ever.");
        }

        private class BingoBoard
        {
            private readonly int[][] _boardValues;
            private readonly bool[,] _boardMarks = new bool[5, 5];

            public int SumOfUnmarkedNumbers
            {
                get
                {
                    var sum = 0;
                    for (var row = 0; row < 5; row++)
                    {
                        for (var col = 0; col < 5; col++)
                        {
                            if (!_boardMarks[row, col])
                            {
                                sum += _boardValues[row][col];
                            }
                        }
                    }
                    return sum;
                }
            }

            public BingoBoard(int[][] values)
            {
                _boardValues = values;
            }

            public bool MarkValue(int value)
            {
                for (var row = 0; row < 5; row++)
                {
                    for (var col = 0; col < 5; col++)
                    {
                        if (_boardValues[row][col] == value)
                        {
                            _boardMarks[row, col] = true;
                            return RowIsCompletelyFilled(row) || ColIsCompletelyFilled(col);
                        }
                    }
                }
                return false;
            }

            private bool RowIsCompletelyFilled(int row)
            {
                for (var col = 0; col < 5; col++)
                {
                    if (!_boardMarks[row, col]) return false;
                }
                return true;
            }

            private bool ColIsCompletelyFilled(int col)
            {
                for (var row = 0; row < 5; row++)
                {
                    if (!_boardMarks[row, col]) return false;
                }
                return true;
            }
        }
    }
}
