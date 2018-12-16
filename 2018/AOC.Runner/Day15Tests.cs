using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AOC.Solver;
using Xunit;
using Xunit.Abstractions;
using static AOC.Solver.Day15;

namespace AOC.Runner
{
    public class Day15Tests
    {
        private readonly string[] _input =
        {
            "################################",
            "#######..##########.##.G.##.####",
            "#######...#######........#..####",
            "#######..G.######..#...##G..####",
            "########..G###........G##...####",
            "######....G###....G....###.#####",
            "######....####..........##..####",
            "#######...###...........##..E..#",
            "#######.G..##...........#.#...##",
            "######....#.#.....#..GG......###",
            "#####..#..G...G........G.#....##",
            "##########.G.......G........####",
            "#########.G.G.#####EE..E...#####",
            "#########....#######.......#####",
            "#########...#########.......####",
            "########....#########...G...####",
            "#########...#########.#....#####",
            "##########..#########.#E...E####",
            "######....#.#########........#.#",
            "######..G.#..#######...........#",
            "#####.........#####.E......#####",
            "####........................####",
            "####.........G...####.....######",
            "##................##......######",
            "##..........##.##.........######",
            "#............########....E######",
            "####..........#######.E...######",
            "####........#..######...########",
            "########....#.E#######....######",
            "#########...####################",
            "########....####################",
            "################################",
        };

        [Fact]
        public void Part1()
        {
            var cave = new Cave(_input);
            var numRounds = 0;
            while (!cave.Act())
            {
                numRounds += 1;
            }

            Assert.Equal(0, numRounds * cave.SumHitpoints);
        }

        [Fact]
        public void Part2()
        {
        }

        [Fact]
        public void CaveShouldMoveCreatures()
        {
            var input = new[]
            {
                "#########",
                "#G..G..G#",
                "#.......#",
                "#.......#",
                "#G..E..G#",
                "#.......#",
                "#.......#",
                "#G..G..G#",
                "#########",
            };
            var numMoves = 3;
            var expectedResult = new[]
            {
                "#########",
                "#.......#",
                "#..GGG..#",
                "#..GEG..#",
                "#G..G...#",
                "#......G#",
                "#.......#",
                "#.......#",
                "#########",
            };

            var cave = new Cave(input);
            for (var i = 0; i < numMoves; i++)
            {
                cave.Act(allowAttacks: false);
            }

            var result = cave.GetState();
            Assert.Equal(expectedResult.Length, result.Length);
            for (var i = 0; i < expectedResult.Length; i++)
            {
                Assert.Equal(expectedResult[i], result[i]);
            }
        }

        private void TestCombat(
            string[] input,
            string[] expectedResult,
            int expectedRounds,
            int expectedHitpoints,
            int expectedScore)
        {
            var cave = new Cave(input);
            var numRounds = 0;
            while (!cave.Act())
            {
                numRounds += 1;
            }

            Assert.Equal(expectedRounds, numRounds);
            Assert.Equal(expectedHitpoints, cave.SumHitpoints);
            Assert.Equal(expectedScore, numRounds * cave.SumHitpoints);
            var result = cave.GetState();
            Assert.Equal(expectedResult.Length, result.Length);
            for (var i = 0; i < expectedResult.Length; i++)
            {
                Assert.Equal(expectedResult[i], result[i]);
            }
        }

        [Fact]
        public void CaveShouldAllowCombat()
        {
            var input = new[]
            {
                "#######",
                "#.G...#",
                "#...EG#",
                "#.#.#G#",
                "#..G#E#",
                "#.....#",
                "#######",
            };
            var expectedResult = new[]
            {
                "#######",
                "#G....#",
                "#.G...#",
                "#.#.#G#",
                "#...#.#",
                "#....G#",
                "#######",
            };
            var expectedRounds = 47;
            var expectedHitpoints = 590;
            var expectedScore = 27730;

            TestCombat(input, expectedResult, expectedRounds, expectedHitpoints, expectedScore);
        }

        [Fact]
        public void CaveShouldAllowCombateEx1()
        {
            var input = new[]
            {
                "#######",
                "#G..#E#",
                "#E#E.E#",
                "#G.##.#",
                "#...#E#",
                "#...E.#",
                "#######",
            };
            var expectedResult = new[]
            {
                "#######",
                "#...#E#",
                "#E#...#",
                "#.E##.#",
                "#E..#E#",
                "#.....#",
                "#######",
            };
            var expectedRounds = 37;
            var expectedHitpoints = 982;
            var expectedScore = 36334;

            TestCombat(input, expectedResult, expectedRounds, expectedHitpoints, expectedScore);
        }

        [Fact]
        public void CaveShouldAllowCombateEx2()
        {
            var input = new[]
            {
                "#######",
                "#E..EG#",
                "#.#G.E#",
                "#E.##E#",
                "#G..#.#",
                "#..E#.#",
                "#######",
            };
            var expectedResult = new[]
            {
                "#######",
                "#.E.E.#",
                "#.#E..#",
                "#E.##.#",
                "#.E.#.#",
                "#...#.#",
                "#######",
            };
            var expectedRounds = 46;
            var expectedHitpoints = 859;
            var expectedScore = 39514;

            TestCombat(input, expectedResult, expectedRounds, expectedHitpoints, expectedScore);
        }

        [Fact]
        public void CaveShouldAllowCombateEx3()
        {
            var input = new[]
            {
                "#######",
                "#E.G#.#",
                "#.#G..#",
                "#G.#.G#",
                "#G..#.#",
                "#...E.#",
                "#######",
            };
            var expectedResult = new[]
            {
                "#######",
                "#G.G#.#",
                "#.#G..#",
                "#..#..#",
                "#...#G#",
                "#...G.#",
                "#######",
            };
            var expectedRounds = 35;
            var expectedHitpoints = 793;
            var expectedScore = 27755;

            TestCombat(input, expectedResult, expectedRounds, expectedHitpoints, expectedScore);
        }

        [Fact]
        public void CaveShouldAllowCombateEx4()
        {
            var input = new[]
            {
                "#######",
                "#.E...#",
                "#.#..G#",
                "#.###.#",
                "#E#G#G#",
                "#...#G#",
                "#######",
            };
            var expectedResult = new[]
            {
                "#######",
                "#.....#",
                "#.#G..#",
                "#.###.#",
                "#.#.#.#",
                "#G.G#G#",
                "#######",
            };
            var expectedRounds = 54;
            var expectedHitpoints = 536;
            var expectedScore = 28944;

            TestCombat(input, expectedResult, expectedRounds, expectedHitpoints, expectedScore);
        }

        [Fact]
        public void CaveShouldAllowCombateEx5()
        {
            var input = new[]
            {
                "#########",
                "#G......#",
                "#.E.#...#",
                "#..##..G#",
                "#...##..#",
                "#...#...#",
                "#.G...G.#",
                "#.....G.#",
                "#########",
            };
            var expectedResult = new[]
            {
                "#########",
                "#.G.....#",
                "#G.G#...#",
                "#.G##...#",
                "#...##..#",
                "#.G.#...#",
                "#.......#",
                "#.......#",
                "#########",
            };
            var expectedRounds = 20;
            var expectedHitpoints = 937;
            var expectedScore = 18740;

            TestCombat(input, expectedResult, expectedRounds, expectedHitpoints, expectedScore);
        }

        [Fact]
        public void CaveShouldHandleEdgeCase1()
        {
            var input = new[]
            {
                "####",
                "##E#",
                "#GG#",
                "####",
            };
            var expectedResult = new[]
            {
                "####",
                "##.#",
                "#.G#",
                "####",
            };
            var expectedRounds = 67;
            var expectedHitpoints = 200;
            var expectedScore = 13400;

            TestCombat(input, expectedResult, expectedRounds, expectedHitpoints, expectedScore);
        }

        [Fact]
        public void CaveShouldHandleEdgeCase2()
        {
            var input = new[]
            {
                "#####",
                "#GG##",
                "#.###",
                "#..E#",
                "#.#G#",
                "#.E##",
                "#####",
            };
            var expectedResult = new[]
            {
                "#####",
                "#..##",
                "#G###",
                "#...#",
                "#.#.#",
                "#..##",
                "#####",
            };
            var expectedRounds = 71;
            var expectedHitpoints = 197;
            var expectedScore = 13987;

            TestCombat(input, expectedResult, expectedRounds, expectedHitpoints, expectedScore);
        }
    }
}
