using System;
using System.Collections.Generic;
using System.Linq;

namespace AOC.Solver
{
    public static class Day08
    {
        public class Layer
        {
            private readonly int _width;
            private readonly int _height;

            public int[,] ImageData2D { get; private set; }

            public int[] ImageData { get; private set; }

            public Layer(int width, int height)
            {
                _width = width;
                _height = height;
                ImageData2D = new int[width, height];
                ImageData = new int[width * height];
            }

            public void AddPixel(int column, int row, int pixel)
            {
                ImageData2D[column, row] = pixel;
                ImageData[(row * _width) + column] = pixel;
            }
        }

        public static int SolvePart1(IEnumerable<int> input, int width, int height)
        {
            var layers = new List<Layer>();

            var index = 0;
            Layer currentLayer = null;
            foreach (var pixel in input)
            {
                var column = index % width;
                var row = (index % (width * height)) / width;

                if (row == 0 && column == 0)
                {
                    currentLayer = new Layer(width, height);
                    layers.Add(currentLayer);
                }

                currentLayer.AddPixel(column, row, pixel);
                index += 1;
            }

            var result = layers
                .OrderBy(layer => layer.ImageData.Count(p => p == 0))
                .First();

            return result.ImageData.Count(p => p == 1) * result.ImageData.Count(p => p == 2);
        }

        public static int SolvePart2()
        {
            throw new NotImplementedException("Part 2 not implemented yet!");
        }
    }
}
