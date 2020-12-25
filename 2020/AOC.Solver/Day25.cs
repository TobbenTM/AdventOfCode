using System.Linq;

namespace AOC.Solver
{
    public static class Day25
    {
        public static long SolvePart1(int[] input)
        {
            var cardPublicKey = input.First();
            var cardLoopSize = 0;
            var cardValue = 1;
            while (cardValue != cardPublicKey)
            {
                cardLoopSize += 1;
                var subject = 7;
                cardValue *= subject;
                cardValue %= 20201227;
            }

            var doorPublicKey = input.Last();
            var value = 1L;
            for (var i = 0; i < cardLoopSize; i++)
            {
                value *= doorPublicKey;
                value %= 20201227;
            }

            return value;
        }
    }
}
