using AOC.Solver;
using Xunit;

namespace AOC.Runner
{
    public class Day10Tests
    {
        [Fact]
        public void Part1()
        {
            var result = Day10.SolvePart1(_input);
            Assert.Equal(1755, result);
        }

        [Fact]
        public void Part2()
        {
            var result = Day10.SolvePart2(_input);
            Assert.Equal(4049565169664, result);
        }

        private readonly int[] _input =
        {
            95,
            43,
            114,
            118,
            2,
            124,
            120,
            127,
            140,
            21,
            66,
            103,
            102,
            132,
            136,
            93,
            59,
            131,
            32,
            9,
            20,
            141,
            94,
            109,
            143,
            142,
            65,
            73,
            27,
            83,
            133,
            104,
            60,
            110,
            89,
            29,
            78,
            49,
            76,
            16,
            34,
            17,
            105,
            98,
            15,
            106,
            4,
            57,
            1,
            67,
            71,
            14,
            92,
            39,
            68,
            125,
            113,
            115,
            26,
            33,
            61,
            45,
            46,
            11,
            99,
            7,
            25,
            130,
            42,
            3,
            10,
            54,
            44,
            139,
            50,
            8,
            58,
            86,
            64,
            77,
            35,
            79,
            72,
            36,
            80,
            126,
            28,
            123,
            119,
            51,
            22,
        };
    }
}
