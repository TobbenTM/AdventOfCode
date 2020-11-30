using System.Linq;
using AOC.Solver;
using Xunit;

namespace AOC.Runner
{
    public class Day16Tests
    {
        [Fact]
        public void Part1()
        {
            var result = Day16.FFT(_input, 100);
            Assert.Equal("58672132", result);
        }

        [Theory]
        [InlineData("23845678", "12345678")]
        [InlineData("24176176", "80871224585914546619083218645595")]
        [InlineData("73745418", "19617804207202209144916044189917")]
        [InlineData("52432133", "69317163492948606335995924319873")]
        public void ShouldSolveExamples(string expectedOutput, string input)
        {
            var result = Day16.FFT(input, 100);
            Assert.Equal(expectedOutput, result);

        }

        [Fact(Skip = "Optimize me")]
        public void Part2()
        {
            var result = Day16.FFT(string.Concat(Enumerable.Repeat(_input, 10_000)), 100);
            Assert.Equal("UNKNOWN", result);
        }

        private readonly string _input = "59717238168580010599012527510943149347930742822899638247083005855483867484356055489419913512721095561655265107745972739464268846374728393507509840854109803718802780543298141398644955506149914796775885246602123746866223528356493012136152974218720542297275145465188153752865061822191530129420866198952553101979463026278788735726652297857883278524565751999458902550203666358043355816162788135488915722989560163456057551268306318085020948544474108340969874943659788076333934419729831896081431886621996610143785624166789772013707177940150230042563041915624525900826097730790562543352690091653041839771125119162154625459654861922989186784414455453132011498";
    }
}