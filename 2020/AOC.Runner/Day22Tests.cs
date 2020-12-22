using AOC.Solver;
using Xunit;

namespace AOC.Runner
{
    public class Day22Tests
    {
        [Fact]
        public void Part1()
        {
            var result = Day22.SolvePart1(_input);
            Assert.Equal(34664, result);
        }

        [Fact(Skip = "Kinda slow (~3s)")]
        public void Part2()
        {
            var result = Day22.SolvePart2(_input);
            Assert.Equal(32018, result);
        }

        [Fact]
        public void Part2_WithExampleDecks_PlaysGame()
        {
            var input = @"Player 1:
9
2
6
3
1

Player 2:
5
8
4
7
10";
            var result = Day22.SolvePart2(input);
            Assert.Equal(291, result);
        }

        private readonly string _input = @"Player 1:
29
25
9
1
17
28
12
49
8
15
41
31
39
24
40
23
6
21
13
45
20
2
42
47
10

Player 2:
46
27
44
18
30
50
37
11
43
35
34
4
22
7
33
16
36
26
48
19
38
14
5
3
32";
    }
}
