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

        [Fact]
        public void Part2()
        {
            var plants = new PlantGeneration(_initialState, _rules);
            var targetGeneration = 50000000000;

            var lastCycleGrowth = 0L;
            var lastCycle = plants.SumPlants;
            var stagnatedCycles = 0;

            while (plants.Generation < targetGeneration)
            {
                plants = plants.Evolve();
                var tmpSum = plants.SumPlants;
                var tmpDiff = tmpSum - lastCycle;
                if (tmpDiff == lastCycleGrowth)
                {
                    if (stagnatedCycles >= 5)
                    {
                        // Stagnated
                        break;
                    }
                    stagnatedCycles += 1;
                }
                else
                {
                    stagnatedCycles = 0;
                }
                lastCycle = tmpSum;
                lastCycleGrowth = tmpDiff;
            }

            var remainingGenerations = targetGeneration - plants.Generation;
            var result = plants.SumPlants + (remainingGenerations * lastCycleGrowth);
            Assert.Equal(3650000001776L, result);
        }
    }
}
