using System.Collections.Generic;
using System.Linq;
using System.Text;

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
                for (var i = 0; i < ImageData.Length; i++)
                {
                    ImageData[i] = -1;
                }
            }

            public void AddPixel(int column, int row, int pixel)
            {
                ImageData2D[column, row] = pixel;
                ImageData[(row * _width) + column] = pixel;
            }

            public void AddPixelUnderneath(int column, int row, int pixel)
            {
                var current = ImageData[(row * _width) + column];
                if (current == -1 || current == 2)
                {
                    ImageData2D[column, row] = pixel;
                    ImageData[(row * _width) + column] = pixel;
                }
            }

            public override string ToString()
            {
                var builder = new StringBuilder();
                for (var row = 0; row < _height; row++)
                {
                    for (var col = 0; col < _width; col++)
                    {
                        builder.Append(ImageData2D[col, row] == 0 ? ' ' : 'X');
                    }

                    if (row < _height - 1)
                    {
                        builder.Append('\n');
                    }
                }
                return builder.ToString();
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

        public static string SolvePart2(IEnumerable<int> input, int width, int height)
        {
            var image = new Layer(width, height);

            var index = 0;
            foreach (var pixel in input)
            {
                var column = index % width;
                var row = (index % (width * height)) / width;

                image.AddPixelUnderneath(column, row, pixel);
                index += 1;
            }

            return image.ToString();
        }
    }
}
