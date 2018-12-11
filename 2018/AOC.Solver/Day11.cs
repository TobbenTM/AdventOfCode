using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AOC.Solver
{
    public static class Day11
    {
        public class PowerGrid
        {
            private readonly PowerCell[,] _cells;
            private readonly int _width;
            private readonly int _height;

            public PowerGrid(int width, int height, int serialNumber)
            {
                _width = width;
                _height = height;
                _cells = new PowerCell[width, height];
                for (var y = 1; y <= height; y++)
                {
                    for (var x = 1; x <= width; x++)
                    {
                        _cells[x - 1, y - 1] = new PowerCell(x, y, serialNumber);
                    }
                }
            }

            public (int x, int y) EvaluateBestLocation()
            {
                var bestLocation = (0, 0);
                var bestPower = -999;

                for (var x = 1; x < _width-1; x++)
                {
                    for (var y = 1; y < _height-1; y++)
                    {
                        var power = 0;

                        for (var i = 0; i < 3; i++)
                        {
                            for (var j = 0; j < 3; j++)
                            {
                                power += _cells[x-1+i, y-1+j].PowerLevel;
                            }
                        }

                        if (power > bestPower) {
                            bestPower = power;
                            bestLocation = (x, y);
                        }
                    }
                }

                return bestLocation;
            }

            public async Task<(int x, int y, int dimension)> EvaluateBestDynamicLocation()
            {
                var tasks = new List<Task<(int power, (int x, int y, int dimension) bestPosition)>>();

                for (var x = 1; x <= _width; x++)
                {
                    for (var y = 1; y <= _height; y++)
                    {
                        var x1 = x;
                        var y1 = y;
                        tasks.Add(Task.Factory.StartNew(() => EvaluateAllDimensions(x1, y1)));
                    }
                }

                var results = await Task.WhenAll(tasks);
                var bestResult = results.Max(a => a.power);

                return results.First(a => a.power == bestResult).bestPosition;
            }

            private (int power, (int x, int y, int dimension) bestPosition) EvaluateAllDimensions(int x, int y)
            {
                var bestPower = _cells[x - 1, y - 1].PowerLevel;
                var bestDimension = 1;
                var spaceAvailable = Math.Min(_width - x + 1, _height - y + 1);

                var currentPower = bestPower;

                for (var dimension = 2; dimension <= spaceAvailable; dimension++)
                {
                    var bottomCoord = (y - 1) + (dimension - 1);
                    var rightCoord = (x - 1) + (dimension - 1);
                    // We just need to add the new cells (bottom and right rows)
                    for (var i = 0; i < dimension; i++) {
                        try 
                        {
                            if (i == dimension - 1)
                            {
                                // Just add the single corner
                                currentPower += _cells[x - 1 + i, y - 1 + i].PowerLevel;
                            }
                            else
                            {
                                // Add both: bottom then right
                                currentPower += _cells[x - 1 + i, bottomCoord].PowerLevel;
                                currentPower += _cells[rightCoord, y - 1 + i].PowerLevel;
                            }
                        }
                        catch
                        {
                            throw;
                        }
                    }

                    if (currentPower > bestPower)
                    {
                        bestPower = currentPower;
                        bestDimension = dimension;
                    }
                }
                return (bestPower, (x, y, bestDimension));
            }
        }

        public class PowerCell
        {
            public int X { get; set; }
            public int Y { get; set; }
            public int RackId { get; set; }
            public int PowerLevel { get; set; }
            
            public PowerCell(int x, int y, int serialNumber)
            {
                X = x;
                Y = y;
                RackId = x + 10;
                PowerLevel = EvaluatePowerLevel(serialNumber);
            }
            
            private int EvaluatePowerLevel(int serialNumber)
            {
                var step2 = RackId * Y;
                var step3 = step2 + serialNumber;
                var step4 = step3 * RackId;
                var step5 = step4 < 100 ? 0 : Math.Abs(step4/100%10);
                var step6 = step5 - 5;
                
                return step6;
            }
        }
    }
}
