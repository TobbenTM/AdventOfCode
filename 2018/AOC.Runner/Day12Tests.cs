using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using AOC.Solver;
using Xunit;
using Xunit.Abstractions;
using static AOC.Solver.Day12;

namespace AOC.Runner
{
    public class Day12Tests
    {
        private readonly char[] _initialState = "######....##.###.#..#####...#.#.....#..#.#.##......###.#..##..#..##..#.##..#####.#.......#.....##..".ToCharArray();
        private readonly Dictionary<string, char> _rules = new Dictionary<string, char>
        {
            { "...##", '#' },
            { "###..", '.' },
            { "#.#.#", '.' },
            { "#####", '.' },
            { "....#", '.' },
            { "##.##", '.' },
            { "##.#.", '#' },
            { "##...", '#' },
            { "#..#.", '#' },
            { "#.#..", '.' },
            { "#.##.", '.' },
            { ".....", '.' },
            { "##..#", '.' },
            { "#..##", '.' },
            { ".##.#", '#' },
            { "..###", '#' },
            { "..#.#", '#' },
            { ".####", '#' },
            { ".##..", '.' },
            { ".#..#", '#' },
            { "..##.", '.' },
            { "#....", '.' },
            { "#...#", '.' },
            { ".###.", '.' },
            { "..#..", '.' },
            { "####.", '#' },
            { ".#.##", '.' },
            { "###.#", '.' },
            { "#.###", '#' },
            { ".#...", '#' },
            { ".#.#.", '.' },
            { "...#.", '.' },
        };

        private readonly ITestOutputHelper _output;

        public Day12Tests(ITestOutputHelper output)
        {
            _output = output;
        }

        [Fact]
        public void Part1()
        {
            var plants = new PlantGeneration(_initialState, _rules);
            while (plants.Generation < 20)
            {
                plants = plants.Evolve();
            }
            Assert.Equal(3059, plants.SumPlants);
        }

        [Fact(Skip = "Takes too long, need to optimize or find alternative solution")]
        public void Part2()
        {
            var sw = Stopwatch.StartNew();
            var plants = new PlantGeneration(_initialState, _rules);
            var targetGeneration = 50000000000;
            while (plants.Generation < targetGeneration)
            {
                if (plants.Generation % 10000 == 0)
                {
                    Debug.WriteLine($"Reached evolution {plants.Generation} in {sw.ElapsedMilliseconds} ms! ({(100 / targetGeneration) * plants.Generation}% done)");
                }
                plants = plants.Evolve();
            }
            Assert.Equal(0, plants.SumPlants);
        }
    }
}
