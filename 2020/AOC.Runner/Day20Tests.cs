using AOC.Solver;
using Xunit;

namespace AOC.Runner
{
    public class Day20Tests
    {
        [Fact]
        public void Part1()
        {
            var result = Day20.SolvePart1(_input);
            Assert.Equal(68781323018729, result);
        }

        [Fact]
        public void Part2()
        {
            var result = Day20.SolvePart2(_input);
            Assert.Equal(1629, result);
        }

        [Fact]
        public void Part2_WithExampleData_FindsMonsters()
        {
            var input = @"Tile 2311:
..##.#..#.
##..#.....
#...##..#.
####.#...#
##.##.###.
##...#.###
.#.#.#..##
..#....#..
###...#.#.
..###..###

Tile 1951:
#.##...##.
#.####...#
.....#..##
#...######
.##.#....#
.###.#####
###.##.##.
.###....#.
..#.#..#.#
#...##.#..

Tile 1171:
####...##.
#..##.#..#
##.#..#.#.
.###.####.
..###.####
.##....##.
.#...####.
#.##.####.
####..#...
.....##...

Tile 1427:
###.##.#..
.#..#.##..
.#.##.#..#
#.#.#.##.#
....#...##
...##..##.
...#.#####
.#.####.#.
..#..###.#
..##.#..#.

Tile 1489:
##.#.#....
..##...#..
.##..##...
..#...#...
#####...#.
#..#.#.#.#
...#.#.#..
##.#...##.
..##.##.##
###.##.#..

Tile 2473:
#....####.
#..#.##...
#.##..#...
######.#.#
.#...#.#.#
.#########
.###.#..#.
########.#
##...##.#.
..###.#.#.

Tile 2971:
..#.#....#
#...###...
#.#.###...
##.##..#..
.#####..##
.#..####.#
#..#.#..#.
..####.###
..#.#.###.
...#.#.#.#

Tile 2729:
...#.#.#.#
####.#....
..#.#.....
....#..#.#
.##..##.#.
.#.####...
####.#.#..
##.####...
##..#.##..
#.##...##.

Tile 3079:
#.#.#####.
.#..######
..#.......
######....
####.#..#.
.#...#.##.
#.#####.##
..#.###...
..#.......
..#.###...";
            var result = Day20.SolvePart2(input);
            Assert.Equal(273, result);
        }

        private readonly string _input = @"Tile 1559:
.......#.#
#.#.......
#.#.......
#.#.......
..........
#.#..#..#.
...##..#.#
..........
#.#....##.
..##......

Tile 3253:
##....####
#......#..
##.......#
#..##.....
#.........
....#.....
....#....#
###.####.#
#####...#.
.#..#.#..#

Tile 1307:
......####
.##.#....#
##..#.....
#.#..#..#.
.#.#......
#.##......
..#......#
###.#...##
#..#....##
.#.#..##.#

Tile 2999:
..#....#.#
#...#.....
#.#..#....
........##
#....#...#
##.....#.#
.##......#
##..#....#
......##.#
#...#..###

Tile 1847:
..#...#.#.
#..#.##.##
..##.#...#
.......###
.......#.#
##.##..#..
.....##...
#.....#..#
#.#......#
.#.##.####

Tile 2731:
#..#....##
.....#...#
#.........
#...#.....
.#....#..#
....#.....
#...##..#.
##.....###
#.........
.#.##...##

Tile 1453:
.##..#.#..
#.......#.
.........#
.........#
..#.......
......#...
#####.#...
...#.#...#
..........
#.#.###...

Tile 1093:
.###..####
#.......##
.....##..#
....#....#
#....#...#
........##
.....#....
.....#....
......#.#.
.#....##..

Tile 1913:
.#..##....
...##.....
#.........
#........#
##....#..#
#....#....
.....##..#
....#...#.
#.#......#
...#....#.

Tile 3463:
.##...#.#.
#..##.....
#.#.#.#...
###...#..#
...#.#..##
#......###
.##..##..#
.#.##....#
..#..##.##
.....#..##

Tile 3581:
.######...
##..#....#
##...#..#.
##........
#.......#.
.....#...#
#.#.###...
#....#...#
###.......
...##.#...

Tile 3923:
..##....##
.#...#.#.#
....#...#.
......#...
#........#
#......##.
....##...#
#...#.....
......##..
#.###...#.

Tile 3613:
..#.#.....
.........#
..........
##.......#
#.#..#...#
##.....#.#
#...#.....
.#..#.....
........##
###...###.

Tile 3931:
#..#......
...##....#
#...##..#.
..#.......
###...#..#
##.....##.
.##......#
..........
#.........
###...##.#

Tile 3407:
###.#...##
.##..#..#.
#.#....#.#
#.........
#.........
#.#......#
.#....##..
#..##....#
#...##....
.....#.#.#

Tile 1823:
###..#...#
....#..#.#
#........#
..........
......#.#.
...#....#.
###.......
#.....#...
#.###....#
...######.

Tile 1709:
.#...#...#
#........#
#...#...##
.#.......#
.#....#..#
#.#...###.
....#.....
#....#..#.
#........#
.#..#..#.#

Tile 1097:
#.#.#.#...
#..#....##
#..#......
#..#......
...#.#....
..#......#
.###.....#
..#....#.#
#...#.....
...#.##.#.

Tile 2339:
....#..##.
#......###
##........
.#......##
..#......#
#.#......#
.#.#.....#
...#......
.##.#..#..
#.###...#.

Tile 2791:
.##.#####.
#.#...#..#
....###..#
#....#....
.........#
#..##..##.
##.#.#.#..
#.....#..#
......####
..#######.

Tile 1637:
#.##.#.##.
###.....#.
#..##.....
.......##.
#.......##
......####
#.#.#.....
#.......#.
#........#
#..#...#..

Tile 2843:
####.#####
.........#
..........
#.#.....#.
.#.......#
......##.#
#....#...#
..#.......
...#......
.#...####.

Tile 1109:
.###..#..#
##.##.....
...#......
#........#
.....##..#
..#.#....#
.#.#.#...#
#.##......
.#.#..#..#
...#.#.#..

Tile 3061:
.#..#.#.#.
##...###.#
#..####...
#....#.#.#
......#..#
..#.......
#........#
##.#.##..#
.....##..#
.#.##.##..

Tile 3517:
.....##.##
#......#.#
#.#..#..#.
.........#
#..##.....
#......#.#
.##.....##
#.....#..#
.#......#.
..###.....

Tile 3833:
..##.####.
#.........
#...#.#..#
#.........
#.###....#
#.....##.#
...#....#.
#....##.##
#.#...#.##
###.#.....

Tile 1129:
##.#......
..#.....##
##....##.#
#....#...#
..#.......
...#.#....
#........#
...#.....#
.........#
.#..###..#

Tile 1951:
.#..##.###
..####...#
.####..#..
....#...#.
#...#.#...
...##....#
#........#
......#.#.
.........#
.#.##...##

Tile 2039:
....#..#..
..........
...#.#....
...##....#
........#.
.......#..
#.##....#.
##..#..#..
#.#.......
.#..#..##.

Tile 3643:
.#..#..#..
#.........
...#....#.
......#..#
...#......
#.........
.........#
....#.....
#....#...#
#..#....##

Tile 2711:
.#..#.#.##
#..#..#..#
.......#.#
#..##....#
#.#.......
#...#.#...
.#.#......
...#......
.#...#...#
#.#..####.

Tile 2423:
#.#.#.....
...#......
..#......#
..........
##.....#..
###.#.#..#
.......#.#
#..#.#..#.
...#...#..
##.#.#####

Tile 1663:
..##.....#
#....#...#
.##....#.#
...#..##.#
#...##..#.
####..#...
##........
#........#
#...#.....
######..##

Tile 1861:
##...#.#..
.........#
......#.##
.....#...#
....#....#
........#.
...#......
..........
..#.......
..######.#

Tile 3659:
..#.##.###
.#....#...
##.#.#...#
#.##.#..##
.#...###.#
###......#
#.#......#
..#..#...#
#.....#.##
..#.#.....

Tile 1733:
.....#.###
..#..#...#
#........#
...#..#..#
.#.#...#.#
###.......
#........#
.#.#...#..
#....##..#
...#......

Tile 3271:
###.####.#
#......#..
.#....#..#
..........
#.#...#.##
......#...
.......##.
#....#....
##....##.#
.....#.##.

Tile 3761:
..#...##..
.......#.#
...#..#.##
#...#....#
...#......
.........#
#...#.....
.......#..
.#..#.....
##.####.#.

Tile 3449:
..###.#...
#...#....#
...##....#
#..##..#..
#.#.......
#.........
#..#.#...#
#...#....#
.###.#....
#.....##..

Tile 2861:
#.#....###
.........#
#.#..#.#.#
#....##...
#........#
#..##.....
#.......##
#....#...#
#........#
##...####.

Tile 1877:
..#.#.###.
#...##...#
.......##.
#...#...#.
..#.......
#........#
....#.###.
#...#....#
#.........
#.##.#.#.#

Tile 1091:
###...#.##
..#......#
.#..#.#...
#.......#.
......#..#
....#..#.#
#..#.##.##
..###....#
#.........
.#.###..#.

Tile 1741:
..####.##.
#.....##..
#....##...
#...##...#
#...##....
#.#..#....
#....#...#
......#...
#.....#..#
##..##.##.

Tile 2789:
...#.#....
#.......##
#.........
#.#......#
..#..#...#
#......#.#
#...#..#..
#........#
#.....##..
#.###.#.##

Tile 2017:
#..##...#.
#.#.......
#.........
#......#..
##....#...
.........#
......#..#
#..#.....#
#...#....#
.#.##..#.#

Tile 2357:
.###....#.
#..#......
.......##.
.....#..##
....#.#.##
...#...#..
#.........
#....#....
........#.
##..###.##

Tile 3803:
.#.#.#..##
..........
.#.#......
##.#.###..
.#.##..#..
#.###....#
........##
##..#.....
.#.......#
...###...#

Tile 1223:
.###...#.#
#....#...#
..........
###...#...
#..###....
.#.....#.#
.#.......#
....#....#
.#......#.
.#.#.###..

Tile 1657:
##.##.#..#
#.......#.
#........#
....##...#
#.#.#..#..
.........#
..#..#...#
..#......#
#.#.......
.###.###.#

Tile 3187:
##..#....#
#..#......
.........#
#.#...#...
#.........
#....#.#..
#..#.##.#.
.....#.#.#
....##...#
.###....##

Tile 2341:
###..#....
.......#.#
..........
..#..#..##
.......#..
#.........
#....#.#.#
#........#
##..#....#
...##.#...

Tile 3461:
#..#.#....
...##....#
#........#
......#.#.
.......#.#
#......#..
.........#
......#...
#..#....##
########..

Tile 2767:
#..#####.#
..#.##.##.
.##.##..#.
..#.......
#...##.###
.......###
#..#.#....
...#...#.#
...#......
.##......#

Tile 3137:
##...####.
.#........
.........#
##......##
........##
#...##...#
#......#.#
.#......##
...##...##
...#..#.##

Tile 3011:
#..##....#
..#.....##
#......##.
.#..###...
.#..#..###
.#.#.##..#
#.#....#.#
........##
#........#
####.##...

Tile 3677:
#...###.#.
#..#...#.#
##........
..#....#..
#.#.......
...#....#.
#..#..#.##
.##...###.
#.........
#...###.##

Tile 3559:
#.#..#...#
####....#.
....####.#
..##.#...#
#....##...
#.....#...
#..##.....
##.....#.#
##...#....
.###.##.##

Tile 1259:
..####.#.#
..##.#..#.
##.#....##
#.#.#...##
#..#.#....
...##.#...
..#.#.....
...#.#....
#####..#.#
..#...###.

Tile 3019:
#...#.##.#
##.....#.#
#.#...#..#
#.........
#........#
#.........
.....#....
.#.#.....#
.......#..
##.###..#.

Tile 2377:
##..#.#..#
.....#.#.#
#...#....#
#..#......
..#..#.#.#
...##...##
...#.#..##
....#.#..#
.......###
....##.#.#

Tile 1889:
.###......
......#..#
.##......#
#.#....#..
#..#.....#
.#.##.....
##.#.....#
..........
#......#.#
###.#.###.

Tile 2677:
#.#....#..
#.........
#.........
#.........
.........#
....##.#.#
....#..###
#...#..#.#
......#..#
...#.#####

Tile 3539:
#.##...###
...#...#..
........#.
..#..#..#.
##.....#.#
.#...#....
...#...#.#
##....####
....#...#.
#.##.#.###

Tile 1283:
.####.#..#
..#.......
##.##....#
##....#...
#.....#..#
.#.......#
..#.#....#
..#.#..#..
.#..#.....
..###..#.#

Tile 1181:
######.#.#
.##......#
....###...
#...##..##
....#....#
#....#...#
#......#..
#..#.#...#
...#.#...#
.#..##.###

Tile 1721:
.#.#...##.
#.........
...#.....#
......#...
#..#...###
...#..###.
#..#.#.#..
#.#......#
.#..#....#
##.#.#..#.

Tile 3533:
##..#.#.##
#........#
#.....##.#
#.....##..
#.........
.........#
#........#
....#..#..
#........#
.#..##.##.

Tile 1871:
.####.##.#
..#.#.....
...#......
.......#.#
....#....#
#........#
#.......##
#........#
#......#.#
..###...##

Tile 2239:
...###....
###.#.#.##
###.......
..#....###
..##..#..#
#.#.#.##..
.......#.#
.#.#......
#.##..#..#
#.......#.

Tile 3491:
####.#...#
#.###...##
#...#.....
...#....##
.#......##
.#......#.
#...#....#
.........#
#....#.###
###..#..##

Tile 3389:
##.#......
.......#.#
..#.......
#..##.....
#....#..##
#........#
......#...
#.........
..#...#..#
###..###.#

Tile 1423:
...#.###.#
#.....#...
##........
.....#....
#.#.##..##
##...###..
..........
.##.......
#.#..#....
.##..#..#.

Tile 2251:
##....###.
#..##....#
...#.....#
#....#...#
.##.#....#
#..##...##
#..###...#
..........
.##...##..
.....#...#

Tile 2417:
.......##.
#........#
.#........
#..#.....#
#.#..###..
##.......#
#........#
###......#
...#.....#
.#.#.#.#..

Tile 2113:
.##.#..#.#
#.........
#.#......#
#......#.#
.......#..
#...#.####
#.....##..
.....#..#.
#.........
#.##..#.#.

Tile 2297:
.#...#..#.
#.........
#...#.....
.......#..
..#.....#.
#.......#.
........#.
.....#....
...##..#..
######.###

Tile 3631:
#....###.#
.....#...#
.........#
#........#
#..#...#..
#........#
##.#......
..#....#.#
##....#..#
######.#..

Tile 1277:
.#.#.#.###
#.#.#..#..
##..###...
#....#...#
......#..#
.........#
#..#...#..
##...#....
.........#
...####..#

Tile 1051:
##.##.#.##
#..##...##
..#.#..#..
....#....#
#.#.....##
..#......#
#.......##
..#......#
##....#..#
.#...#.##.

Tile 2137:
#.#..#.##.
...##.....
..#.....#.
#......#.#
.........#
#.........
#.......##
#.#......#
......#..#
.#.###.#.#

Tile 2089:
##.#.###..
.#.#..#..#
#.#..#..#.
...#..#...
#.#..#..##
#..##....#
##.......#
#.#...##.#
#........#
#.##.#....

Tile 3433:
.##..##...
##.......#
..........
.##..#...#
#..#...#..
#..#....#.
..#...#..#
#........#
.....#....
..##...##.

Tile 2099:
###.....#.
#..#.##...
#.....#..#
#.#..#.#..
..#....#..
...#....##
#.##.#...#
.#.......#
#..#......
..#.#.#.##

Tile 2179:
...#.##..#
..#....#.#
#.....#...
....#.....
#...#.#.#.
#.........
...#.#..#.
.......###
........#.
.#.#.##...

Tile 3229:
.##...#..#
#.......#.
#.#..##..#
.##.......
..........
.#.....#.#
.....#..##
#.#.#...##
#.#.#.#..#
##..#...##

Tile 1327:
.####..#.#
...#...#.#
........##
....#....#
........#.
#...#..#..
.#.#......
......#..#
.#......##
..##.#....

Tile 2503:
#..####.##
#...#.....
...#.....#
.#.......#
.........#
##......#.
..#....###
#..#...##.
..........
#.#..#.###

Tile 2351:
.##..##...
#.#.......
....#.#..#
...#.....#
..#.......
.#.......#
#....##...
...#.....#
#...#.....
#....#.###

Tile 1019:
...##..#..
..#.#....#
##.#..#..#
.#.....#..
.........#
##.....#.#
......#..#
#.........
....#..#.#
.#...#..##

Tile 2521:
#...#.#.#.
..#.###..#
#.#...##..
.........#
##........
#..#..#..#
##........
.#........
..#..#....
.#...####.

Tile 1627:
.#...##.#.
###......#
......#...
.##.......
#......#.#
.......#.#
...#....#.
#.#......#
...#.#....
######..#.

Tile 2347:
#.##.#.##.
...##.....
.#..#.#.##
.#........
#.....#...
...#....#.
#.........
...#..#...
.###.#.#.#
..###..###

Tile 3413:
#.##..#...
....#..#..
#....#.###
.#..#....#
..#...#...
#........#
#.....##..
#........#
..#..#...#
.#..#####.

Tile 2647:
.####.#.#.
#.........
#..#.....#
#....#....
..........
#........#
#..#.#....
#...#....#
......#.##
##.#####.#

Tile 1039:
##..####.#
#....#.#.#
..#..#...#
#...#.....
..........
#...#..#..
#.......#.
.......#.#
#.#......#
....#.##..

Tile 2053:
##.##.#...
#.#.......
..###....#
##.#......
#.#..#...#
..####..#.
.#..##.#..
#...#.....
.........#
.....##.#.

Tile 2909:
#.#######.
##...#...#
..........
##.#.#...#
.#..#.....
###....#..
#.#......#
...####...
##.###....
.#.#.##..#

Tile 1567:
.....##.##
.....##..#
#.###.....
.......#.#
.###.....#
#..#.....#
###.......
..###....#
#....#...#
....##..##

Tile 2687:
####...##.
#..#.#...#
#.........
.....#...#
#.........
.......#.#
##..#...##
.....###..
#.....#.#.
#...#.####

Tile 3121:
#.####...#
###.......
#...##...#
#..#....##
#....#...#
.....#....
...##..#.#
.#........
.#....#.##
#.#...#.##

Tile 3547:
.##.###...
#.##..#...
#........#
#.##......
#..#.##...
##...#....
.##.#.#.#.
........##
.#.......#
..####..#.

Tile 1787:
##.###.##.
...#...#.#
##.......#
#..##....#
.#...#.#..
.........#
##.....#..
#.........
#.........
.###.#####

Tile 1811:
####.##.#.
#..#...##.
.#.......#
........##
#........#
##.#.....#
..#.....#.
.#.....#.#
#.....##.#
.#..#.....

Tile 2293:
#..##..#..
#...#....#
.........#
...##....#
#......#..
......#..#
#........#
#..#......
#.#.....#.
...##..#..

Tile 1933:
#.#...####
#......#..
..........
.....#....
#..#.....#
.........#
..#.##...#
.##..##..#
.......#.#
..#..###..

Tile 2659:
####.##.##
#...#.....
...#.#....
#.........
.#.......#
#..##.#..#
#...##...#
##..#.##..
#.#...#..#
.#.#.#...#

Tile 2069:
#..#......
#.#......#
###.....#.
....#....#
........##
#....#....
#.#..#....
#....#...#
#....##...
##..###.##

Tile 2879:
####.####.
#.......#.
.#.#....##
#.##.....#
...#......
#.........
#...##....
......#...
#..#.#.#.#
###..##.##

Tile 2957:
#.#.####..
#.#..#...#
#.........
#...#....#
#....#.#..
......#..#
.....##..#
#....#.#.#
##.....#..
###.##.#.#

Tile 2029:
#.#..###.#
.....#..##
...#......
..#..#..##
.#...##...
...#....##
####..#...
..#....#..
.........#
.#####.###

Tile 1607:
##.##.#...
......#..#
.........#
..#...#.##
...#......
##........
...#.....#
#...#..#..
#......#.#
#....###..

Tile 3943:
.##.####.#
#..#..#...
#.....#..#
###.#....#
..###...##
#.......##
#..##.....
.....##.#.
....#..#..
.###.#...#

Tile 3593:
..#.#.#.#.
##......##
.##......#
....#....#
....#...##
#...#....#
..........
#......##.
#......##.
#..#...#..

Tile 1583:
##...#..##
#..#.....#
.#.......#
#.....#.#.
##.....#..
##........
..........
...#..#...
#...#.....
.##.......

Tile 3709:
#..#...###
##..##...#
..##....##
#.....#..#
##..#.#..#
#......#.#
#.#.......
.....#...#
#.......#.
..#..###..

Tile 1667:
..##......
##........
..##.#...#
#......###
.......##.
........##
.###.....#
#.#.#...##
......#..#
#..#.####.

Tile 3851:
###.#.#...
..#......#
....#.....
.........#
##.###...#
#........#
...##..#.#
..##......
..........
..#..####.

Tile 3083:
..#.#...##
#...#.....
##.....#..
#.#......#
..##......
###.#.#..#
#.........
#.........
###......#
..#..###.#

Tile 2927:
#.##.####.
#.........
#.....###.
#.#..#...#
..#......#
.#........
..........
#..#......
........#.
.....#####

Tile 2837:
#.###.#..#
#.##....##
#..#..#..#
.........#
....#.....
.#.#......
#..####..#
.##.......
.#...#..##
####.#####

Tile 1499:
..#.##....
##.#......
#.#####..#
....#..##.
..#..#...#
..#.#.....
##.......#
#........#
#..#.#....
....###...

Tile 2857:
.#...#...#
.....##...
.........#
..#.......
#........#
#...#.....
..........
#........#
#....#....
.###...#..

Tile 1237:
..#######.
#.....###.
#.#...#...
#.#.......
###......#
..#...#..#
..........
........##
.#.#...#.#
.#....###.

Tile 3221:
.####.####
........##
.....#....
..........
..#...#..#
..##.#.###
#..##.....
##.#.#...#
........##
##.#.#.#..

Tile 2531:
....###.#.
#...##...#
#...##....
#...#....#
#.....#...
..#..#..#.
.#.###..#.
#.....#..#
#.......#.
#.###..###

Tile 2689:
#.#.#..#.#
.......##.
#.#..#..#.
#........#
#.##......
##.......#
##......##
........#.
..#..#..##
###.#.####

Tile 2953:
##.##..#..
#....#...#
...#.....#
#...#.....
...#.....#
.##.##..##
...##....#
......#..#
#.....#.##
.#.##...#.

Tile 3191:
.#.#....#.
#..#.#...#
#...#....#
###.#.#.#.
.##.......
#..#......
.#.#......
#.##.#...#
..........
.#..#.#.#.

Tile 2797:
#....#####
.........#
.#.....#.#
....#.....
.......#.#
..........
#....##...
.#...#..#.
.........#
#.###.##.#

Tile 3767:
.#..###..#
...##.#..#
.##....#.#
.....#...#
...#....##
..........
#..#.#...#
#.........
##........
#..##...#.

Tile 2207:
.#.##.#...
#....#....
..........
#.........
....#.....
#........#
#...#.....
#.........
.....##...
#..#...##.

Tile 1171:
##.##...##
.........#
..........
#.##......
.........#
#........#
...#..#...
..#.......
..........
....#..#..

Tile 2267:
#.####..##
#..#.....#
#.....#..#
...#......
..##.#.#.#
..#...#..#
.#..#.....
..#......#
.....#.#..
.#........

Tile 2213:
##.#####.#
.......###
.....#...#
#......#..
......#..#
..#.......
.....##..#
..##....##
..#.......
#..##....#

Tile 2011:
#..##..###
#.......##
.#......##
#.#..#.#.#
#.....#..#
..##.#.##.
.#.###.#.#
.......#.#
........#.
###..##.##

Tile 3877:
..#..#.#.#
.......#.#
.......#.#
##........
........##
#.##.#...#
..##.##..#
###.#..###
........#.
#.##.#..#.

Tile 1427:
.#.....#.#
#..###.##.
#.###...#.
#..#.....#
.#...#.##.
#.#..#..#.
...##.####
.......#.#
##.##....#
.#.###....

Tile 1021:
.##.###...
.##.#....#
#......#..
#..#.....#
#....#..##
#....###..
#......#.#
.........#
#..#.....#
.#........

Tile 1523:
##..##.#.#
#.#..#.#.#
#..#...#.#
#.##..#...
#...#....#
#......#.#
..#.###...
.....#..##
..........
#####..#.#

Tile 1319:
##..######
#....#...#
##........
#.......#.
#.#.....#.
#..#...#.#
#...#....#
....######
...#.....#
..####.###

Tile 1543:
..##....#.
#.........
#.........
.........#
#.........
#.........
....#.#..#
#.........
.#..##...#
####..#.#.

Tile 1697:
...#....#.
#......#..
......#..#
...#......
.#.#...#.#
.##.......
###......#
.........#
##.###.##.
.##.#.....

Tile 3391:
.##.#.####
##..#....#
#..##....#
#..#..#...
#.........
##...##.##
..........
.........#
.......#..
#.#####.#.

Tile 2833:
.#.#...###
......#..#
#..####..#
.........#
....#....#
#...#...#.
##....#.##
#...###..#
#..#......
...#.#..##";
    }
}