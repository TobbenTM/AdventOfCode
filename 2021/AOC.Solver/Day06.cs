using System.Linq;

namespace AOC.Solver
{
    public static class Day06
    {
        public static long SolvePart1(int[] input)
        {
            return ModelFish(input, 80);
        }

        public static long SolvePart2(int[] input)
        {
            return ModelFish(input, 256);
        }

        private static long ModelFish(int[] input, int days)
        {
            var fishies = Enumerable.Range(0, 9).ToDictionary(i => i, _ => 0L);

            foreach (var fishy in input)
            {
                fishies[fishy]++;
            }

            for (var day = 0; day < days; day++)
            {
                var newFishies = fishies[0];
                for (var i = 0; i < 8; i++)
                {
                    fishies[i] = fishies[i + 1];
                }

                fishies[6] += newFishies;
                fishies[8] = newFishies;
            }

            return fishies.Values.Sum();
        }
    }
}
