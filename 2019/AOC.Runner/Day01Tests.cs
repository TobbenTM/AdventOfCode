using AOC.Solver;
using Xunit;

namespace AOC.Runner
{
    public class Day01Tests
    {
        [Theory]
        [InlineData(12, 2)]
        [InlineData(14, 2)]
        [InlineData(1969, 654)]
        [InlineData(100756, 33583)]
        public void CalculateFuel(int mass, int fuel) {
            Assert.Equal(fuel, Day01.CalculateFuel(mass));
        }

        [Theory]
        [InlineData(12, 2)]
        [InlineData(1969, 966)]
        [InlineData(100756, 50346)]
        public void CalculateFuelReccurring(int mass, int fuel) {
            Assert.Equal(fuel, Day01.CalculateFuelReccurring(mass));
        }

        [Fact]
        public void Part1()
        {
            var result = Day01.SolvePart1(_input);
            Assert.Equal(3291356, result);
        }

        [Fact]
        public void Part2()
        {
            var result = Day01.SolvePart2(_input);
            Assert.Equal(4934153, result);
        }

        private readonly int[] _input =
        {
            119965,
            69635,
            134375,
            71834,
            124313,
            109114,
            80935,
            146441,
            120287,
            85102,
            148451,
            69703,
            143836,
            75280,
            83963,
            108849,
            133032,
            109359,
            78119,
            104402,
            89156,
            116946,
            132008,
            131627,
            124358,
            56060,
            141515,
            75639,
            146945,
            95026,
            99256,
            57751,
            148607,
            100505,
            65002,
            78485,
            84473,
            112331,
            82177,
            111298,
            131964,
            125753,
            63970,
            77100,
            90922,
            119326,
            51747,
            104086,
            141344,
            54409,
            69642,
            70193,
            109730,
            73782,
            92049,
            90532,
            147093,
            62719,
            79829,
            142640,
            85242,
            128001,
            71403,
            75365,
            90146,
            147194,
            76903,
            68895,
            56817,
            142352,
            77843,
            64082,
            106953,
            115590,
            87224,
            58146,
            134018,
            127111,
            51996,
            134433,
            148768,
            103906,
            52848,
            108577,
            77646,
            95930,
            67333,
            98697,
            55870,
            78927,
            148519,
            68724,
            93076,
            73736,
            140291,
            121184,
            111768,
            71920,
            104822,
            87534,
        };
    }
}
