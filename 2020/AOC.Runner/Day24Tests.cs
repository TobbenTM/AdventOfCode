using AOC.Solver;
using Xunit;

namespace AOC.Runner
{
    public class Day24Tests
    {
        [Fact]
        public void Part1()
        {
            var result = Day24.SolvePart1(_input);
            Assert.Equal(479, result);
        }

        [Fact(Skip = "Hella slow")]
        public void Part2()
        {
            var result = Day24.SolvePart2(_input);
            Assert.Equal(4135, result);
        }

        [Fact]
        public void Part1_WithExampleData_ReturnsBlackedTiles()
        {
            var input = new[]
            {
                "sesenwnenenewseeswwswswwnenewsewsw",
                "neeenesenwnwwswnenewnwwsewnenwseswesw",
                "seswneswswsenwwnwse",
                "nwnwneseeswswnenewneswwnewseswneseene",
                "swweswneswnenwsewnwneneseenw",
                "eesenwseswswnenwswnwnwsewwnwsene",
                "sewnenenenesenwsewnenwwwse",
                "wenwwweseeeweswwwnwwe",
                "wsweesenenewnwwnwsenewsenwwsesesenwne",
                "neeswseenwwswnwswswnw",
                "nenwswwsewswnenenewsenwsenwnesesenew",
                "enewnwewneswsewnwswenweswnenwsenwsw",
                "sweneswneswneneenwnewenewwneswswnese",
                "swwesenesewenwneswnwwneseswwne",
                "enesenwswwswneneswsenwnewswseenwsese",
                "wnwnesenesenenwwnenwsewesewsesesew",
                "nenewswnwewswnenesenwnesewesw",
                "eneswnwswnwsenenwnwnwwseeswneewsenese",
                "neswnwewnwnwseenwseesewsenwsweewe",
                "wseweeenwnesenwwwswnew",
            };
            var result = Day24.SolvePart1(input);
            Assert.Equal(10, result);
        }

        [Fact(Skip = "Hella slow")]
        public void Part2_WithExampleData_ReturnsBlackedTiles()
        {
            var input = new[]
            {
                "sesenwnenenewseeswwswswwnenewsewsw",
                "neeenesenwnwwswnenewnwwsewnenwseswesw",
                "seswneswswsenwwnwse",
                "nwnwneseeswswnenewneswwnewseswneseene",
                "swweswneswnenwsewnwneneseenw",
                "eesenwseswswnenwswnwnwsewwnwsene",
                "sewnenenenesenwsewnenwwwse",
                "wenwwweseeeweswwwnwwe",
                "wsweesenenewnwwnwsenewsenwwsesesenwne",
                "neeswseenwwswnwswswnw",
                "nenwswwsewswnenenewsenwsenwnesesenew",
                "enewnwewneswsewnwswenweswnenwsenwsw",
                "sweneswneswneneenwnewenewwneswswnese",
                "swwesenesewenwneswnwwneseswwne",
                "enesenwswwswneneswsenwnewswseenwsese",
                "wnwnesenesenenwwnenwsewesewsesesew",
                "nenewswnwewswnenesenwnesewesw",
                "eneswnwswnwsenenwnwnwwseeswneewsenese",
                "neswnwewnwnwseenwseesewsenwsweewe",
                "wseweeenwnesenwwwswnew",
            };
            var result = Day24.SolvePart2(input);
            Assert.Equal(2208, result);
        }

        private readonly string[] _input =
        {
            "swswswswseswswseseswswnwsesw",
            "nwewsewneswenwesenesenw",
            "neeeenwseseewwnenenesweeeeene",
            "seseewnwseseseneswseeseseseesesesese",
            "swseswswswswswswswswweneswswsw",
            "seswsesesenwsesenesenwseseseseseseseesew",
            "nwneenwneswnwneneneseneswnwnewnwsenene",
            "wswswwwswswsewneswnwnwsenwswswewesw",
            "eeseeneeneeeneew",
            "swnewnwneneeneneseneneneneneneenenenene",
            "seewswnwseneswnenenwww",
            "eneneswnenenwnwwneneneseneneneswneswne",
            "nwewswesewseseeewneseseseseeese",
            "enwsenesweswwsesewsesesesesewnewsene",
            "wseeseseseseseseseseswsesenesesesesesese",
            "nenewnenenesenwsenewneneneswneesw",
            "eseeneseneesesesesweseseeseewsewe",
            "nenenenenenewneneneneneseeneswnenenenenee",
            "nwsenwnwnwnwnweneeswnwenenwwnwnwwnw",
            "neewnewneeeneneseeneseneeneneneeww",
            "neswswswneswseswwwnwwwwswseswsewnene",
            "wnwnwenwwewswwnwnwwneswwsenwese",
            "wnwsewewwwnenwwwwnwnwnwswnwnwnwnw",
            "wewwwwwwswwnwsewwnwnw",
            "wsenenewsewwnese",
            "wnenenwswseesweene",
            "nwnwnwnenenwnwnwnwnwnwnwnweswnwswnenwnwnenw",
            "swseeewnenweenwenenwswsenesw",
            "wswswswswnwsewswneswswseswneswneswsesww",
            "seswneseswswswseswwwseswswneseswswswnesw",
            "sesweseswnwswsweseswswwnenwnesenwsew",
            "newwseneseeseeseseseseseesesesewse",
            "swswewwswsweswswswwwwswwnwswsewnesw",
            "seneeeeeseeseeseseeeesesesw",
            "swsesenwnwseswwseswswseseseseseswseseswne",
            "wswwwneesewnesenwwswwnwwswnw",
            "eneeeneeeeeneneneneneneeesewwnene",
            "swswswsweswnwswswswswswswswswswneswswsw",
            "sweswwswswwswswswswswswswswswneneswwsw",
            "wswwswswenenwewnesweesenesesenenwe",
            "sweneneswnwnweswneneeneeneswneeee",
            "swwsweswswnwswswswswsw",
            "nenewnwsenenenenenenenesewnenenenenene",
            "nwenenenenwnwneneenenwnwswswnenewnenw",
            "seswwsweswseneswswnwswwnenenenwswsewswse",
            "seneswsenwnwnwnenwnwnew",
            "esweseneeewseweeseenesenwnwswe",
            "wswswsenewenwswwwwwnewswswesewwsw",
            "seesewenweeeweseswwseseeneese",
            "wwwswwnewswwewwsenwneswwwwsesw",
            "wseseseseneneseswswseseseseswe",
            "enenenenenewswneneneeneneneenweew",
            "ewseneseenwneseneswsewnww",
            "ewwwwswwwswwswwwwswwswwwnw",
            "neewseswesesesewsewwnwseseseeswe",
            "swwswwswswwwswswswwswswnwwswswsewe",
            "wneesenesweenwsenwsweneeeeseew",
            "wseneseenenwwwneesweewnenenenese",
            "seenwwneneenesenewswnenesewnesenesew",
            "nwnenwsenwnwenenwnenww",
            "nwnwneeswnwnwewnwwswswnwnewnwsenwnenw",
            "swswwwwneswswsweswswneswswsewswswwsw",
            "eneneeeeewneee",
            "seswswswesweswwswswswswsenwsw",
            "wswswseswwwnesweswsweswswwswwwsww",
            "eeesweeneeewnwneeseeesweneeee",
            "nenenenenenenwneswnenenenwnenenenenesenene",
            "nwwnwwwwwwwwwwew",
            "eseseseswswsewswsesenwswswseswsweseswse",
            "nwwswnenenenwneneneneenesenenenenenesene",
            "seseseseswneseswswnwseneseneweeneswse",
            "nenewnwnwnwwnwwnwwwnwsenwnwsenwnwnw",
            "wwwswnwnwwnwnwewnw",
            "neswsenesewsesesesesesesesesesewsesese",
            "esesesweseeseeeseseeeenwesewese",
            "wnewewnwwnwswnenwswwswwnw",
            "wnenesenwnenenenwsenenwswnesenenenenene",
            "eneseeeeneeneenwneneneeweswenee",
            "seswnwwswneswseswseswseseswswswesesesw",
            "nwswseseeswswewswswsesenwwswwswesesw",
            "wewsenwnwwnwnwnwnwwenwwwwnwew",
            "enwwnwnwnwnwnwnwnwnwwnwswnwnwnwnenwsenw",
            "nwsewewwnwnwswnwnwswwnwsenwnwneee",
            "wwewwswsesenwwwswewwneeeneww",
            "wnewsewsenwwwnwwwnwnwwwwwwnewsw",
            "wnewnwnweewnwsenwnwnewswswnenwswenwnw",
            "wnwwswswwwnwwwwwnewnweww",
            "wwswseswwwswwswnwwwnenewwenww",
            "wswwswwenwwswwswwswswwswswswesw",
            "ewswwwwenwwsenewnwwww",
            "sewnwneswseswseswwswsewswneswnwswseswnee",
            "neenwswewsenwwswnwswswwswneewswwe",
            "wwwnwwwwnewewwwnwwwswwww",
            "esesenwseseeeswseeeseenweseesesese",
            "esesesewseseseneseeseeswseesesesesese",
            "seseseseseseseneseswseseseswsesesesewse",
            "sesesewseeseseneeseseseeeewnesesese",
            "swswswswswswswnwswswswwnwswweeswswsw",
            "seseseswwseseseseseseseenesewseeenew",
            "neeswnwswneewnenenenenenenwneswne",
            "nenwnwenwnwnwnwnwnwnwnwnwnwnwswnwnwnwnw",
            "sweeeeseeeeenweeeseenweseeee",
            "nenwseneneeenenesweneesenenenwneenene",
            "wwneswswwwwwswwswnewwseswwwwsw",
            "swsenenwseswnwseseseneswnesesesesenewsenww",
            "nweswwseseseseswnwnwsesesesenesesesesesw",
            "eneseseswwsweseswswsesewseeswswswnw",
            "nwnwnwwnwwnewwnenwnwsewnwseesewnw",
            "seseeeeeesewnweeeeesweesese",
            "eeeswneneneneswnenenenenenenwneeene",
            "nwseseseseseseseseseeseseswseseseseesenw",
            "swewwwnwswsweeswnwwwnwwwseww",
            "nenenewewseswneneeneneswneenenene",
            "sewnewwwwwwwwnwwwwnwwwsweww",
            "nesenewneneneneneneneneswenwweeenesw",
            "swswwwneswnesewseswswwswswnwwswsww",
            "nenwnwnenwsenwnwnenwnwnwnwnwwnwnwneewswne",
            "eenweeeeswseeenwseeseseseeesee",
            "seewenenenenwswseneeneenwwneewnee",
            "seseseeeeeseneseseseesesesewseese",
            "wwwenwseswswswswswswewswswswwnew",
            "swwwsewnwesewswneewwesenwnwwne",
            "neseesenwneswenweeesew",
            "nenwesewwneswseseeswseeseeeseese",
            "wwwnwnwwswnewwnwww",
            "eseseseeenwseeeeeeseeeseenewee",
            "nwsenenewnwnwnwnenwnene",
            "swswswswswseswswwweswseswseneseswswsw",
            "nwnenwnenesenwnwnwsenenenwsenwwenwww",
            "neswwwwwwswswnewswswsww",
            "nenwsenenewwnwnwnenwnenwseseenwnenewne",
            "wnwwwwsewnwnwnwnwewwwswnenwww",
            "nwnwwnwnwnwsesenwnwnwnese",
            "wwwnwwwewwwnwweswnwwswnwwnwnwnw",
            "nwnenwnwnwneenwneswnwnwnenwneeswnenenwnw",
            "sesewswswswneneswnwwsewswswnwswwnee",
            "nwneneneneenenesweneeneneneeswnenee",
            "neeswenenwweesenwseneswee",
            "nenenwneswnenwnenenesw",
            "nwwwnwswsewwnwwewewsenwnwnwwnw",
            "nwnenwenenenenenwwnenenwnenwnwswneenene",
            "wwnwwwwwwnwnwwwwwwewwwwe",
            "eeneeeeeeeeweseeesweswnwnene",
            "enenenenenenenenenwwnewnenenenenenwe",
            "esweeswsenenenwswswswwwseswneswswsww",
            "eeeesweneeneeweeeneeee",
            "nwseseswswswwwnwenewnenwsw",
            "sweeeswnwseneeeeeesweeneseweee",
            "swswswswneweswswswswswsw",
            "swwsewnwsweneswweswnwswwseswswswww",
            "nwnenenenenenenenwnwnwsenenenwnesewnwnenw",
            "swseeeseweseseseseseesesesenwsewnee",
            "neneneswnenenwnenenenwnwsenewenwswseswsw",
            "sweseseswnwswenwsesweseeeseesenenese",
            "seewenwsesenweeeseeneseeseseeswee",
            "eneeeseseeeeeseeswweeseeeswenw",
            "wwswswswneswswswwwswwswswswswsw",
            "eeneenenwneeeneneeeeneeswenene",
            "swwswwwnwswwseewswswwswswwswswswwnw",
            "nenenwnenenewnwnenwnenwnesenenenene",
            "neeswnweswneneewneeneeeeeee",
            "swneneswseswswseswswwswswswswswnwneswsw",
            "enwenwnweeseeweswswnwsweeenweswe",
            "newswnenesewwwsweswwswswwswswswsww",
            "nwwwwwnewwwwwsewwwwwwewse",
            "eneeenenenwneneeeneseswnenenenenene",
            "wswwneswnwwsewswseww",
            "nwnwnwnwsenwsenwnwenwwnwwnwewnwnwwnw",
            "wseneneenewnweenewwnenenenwsenwne",
            "eswneneneneenenenenwnenwnenwnenwnwwnenene",
            "swseneseseswsweswseswsewseseseseseswsese",
            "swswswwswwwswswswsewswwswswswsweswnw",
            "swneewenenwneewnweseswnwwnw",
            "wswwwwwewwwwwwwww",
            "nenenenenenenenwswnenewswnwneneneneese",
            "sewsesewsesesenwseneneseseeesesewe",
            "swswswswewswswswswswswswnwswswswwwsw",
            "wnwsenenesewnenenesewnwnenenenenenenenene",
            "newwwsewsenwnwnwwwnwnw",
            "neswswwswneswswswneswswseswswswwswww",
            "nwsewwwswweswswwwwswnewswswwwwsw",
            "seseseswseseswneswswseseseseswsesesesenw",
            "senwwwseswswseseswwswnesewnwnenene",
            "eneeeeeswneneeneesweeneenenene",
            "eeeeeeeeeneeweeeeesee",
            "nesenwneneenenenwnenwswnenenenenwnwnene",
            "neenwnenenwwnwswnwnenwwswenwnwnwswnw",
            "neeneneeneeneeeneeneneenwewenesw",
            "nwseswswnweenewwnenwnwnwswneeswwnw",
            "swnewwwnwnwseewweswwnwwsww",
            "nwsesweweewwnwwwsenewnewwwnwwsw",
            "seeswsenwnwwswseswswsenwesweenwsese",
            "nwwseeeeeeeeeeeeeeeeeene",
            "swneswswswseswswwseswneswswswseseswswsww",
            "esesesesesesenwseseswsesenesewwsesesw",
            "eneeneneneneeneewneeneneneneene",
            "wwnwnwnwwnwnwsewnwnwenwwnwww",
            "seeseseesesesesesesesenwnwseseswse",
            "nwwnwewseswnwwswwnwnwwnwsenenwsese",
            "nwneswnwnenwnwnwnwwnwnwwnwnwnwnwnwseenw",
            "wsenwnewswwwneseweswnwwwsenenwnew",
            "swesesewsewswswsweswswswenwswseswswsw",
            "eweeseneeeeseeeseeeeee",
            "swwwsweweewneswswnwsenwswswwswswsw",
            "sweswnewnwneenwswweseeeneseseseew",
            "nenenesenenenwneneseneneswnenenwnenenenwnw",
            "swswswsweswwswswswswswseswswswnwswswnwsw",
            "eeweeeseneeneeneeeneswwsee",
            "ewwwwwnenwwwwwwwsewwwwnww",
            "nenwswnenenenenenenenwnwnenweseneswnewnw",
            "wswwnwwswwswnwwwwwwwswesesw",
            "sweeneneswsewneeeneneneneneenenene",
            "enenwnwsenwwnwswnwnenenweswne",
            "eenwswwnwenwenwesweswnweswswsesww",
            "swwseseswnwsesweseswseseswswswnwnesesese",
            "seeeeeeeeeeswnee",
            "newsesesenesesweswsesesesesewne",
            "enwnenwnwnwwnwwswwnwsenenwnwnwnwnwsw",
            "nwswseneeseswwnwswnwsweenwneswnene",
            "neswswswseswswswwewsww",
            "seseseseseseswseseseseseswnenwseseseesesese",
            "seswseeneswnwswsewswseswseneswswswseswnw",
            "neneesweeneenenwneseesweneeneneenw",
            "swsenwswsenwseneesw",
            "wnwwwswwswwwswswswswsewwneswswsw",
            "wswwwswwwnwwwwwnesewswwwwe",
            "swseswseneswsenesesewswseswseswwsenwe",
            "newnweneneneneneneneseeneneneneneewe",
            "eseseseseneeseswsenwsesesesesewenwew",
            "wseeenwseseneseewswseenwseseseseese",
            "wswwnewewseswwswwswnewwwneswsww",
            "wsenenenwesenewewnwewseeeseswswsese",
            "nenenenenesenenenesenenenenenwenwnenenene",
            "eweseneneeewewne",
            "seseswsenwesesesenwweeeseseeeesese",
            "swenwwneseseweseneweswswseseswnwswswse",
            "seeewnwnenwwswnwnwnwenewnwwswsene",
            "seneswswneseeswnesesesenesesewnewseesese",
            "swnenwnweneeswnwnwnwnw",
            "nenenenwneenesenene",
            "swsweswsenwseseswnwseneseseseswseseseswse",
            "swneswswswswwswwswswnwewswsweswnwsw",
            "nwenenewnwnwseeeseseswewnenenwswswnew",
            "eeneseweseseseseewee",
            "nwseseseswswwseswneseseseseseswse",
            "nwwswswswwswwwwswnwswewwsewswe",
            "eeeseewseeeeeeeeeeneeee",
            "eweeeeseneeneneeneeneneeewew",
            "nwsenwnenenenwnwnenenenwnwnwnwnenenewne",
            "swswswswseswswseswswswswswswswswswnwnwswsw",
            "swswswseswseseswseswswseswsenwnwswsesesesw",
            "swnenenenenwneneneneneneneswneneneneneenene",
            "neneneeeenenesenewneeneeneenenee",
            "eesesesesesesesenwwnwseeesenwswswse",
            "senwswnenwseneeswwseswe",
            "eeeweeewseneneneeeeneeneee",
            "eeeeneeenesweewenew",
            "nwswwwenwsenwsenenwswwweswsewwnwne",
            "swswswseswneseseneswnwseseswsesesweswswswsw",
            "eneenwneneeeneseneneneeeesenwnee",
            "swwnwwnwsenwswwswseenesewseenewwe",
            "eeseseweeeewsenesesesewee",
            "nwsenwnwnwnwnwnwnwwwwnwwwnwnwnwwenw",
            "neneswneenenenesenenenenenenwnenwnwnesew",
            "eseseeeseswswweesweeeneesenwne",
            "swswswseswwswsenwneneseseseeswseswnwsw",
            "nwnwnwnwwnwwnwnwwswnwnwnwnwnwnwenwnwe",
            "wnenwnwnesenwnwswneneenenwwneenwnwnene",
            "seewseseseseeeenweeeeneseseswsee",
            "swsenwsenwnwseseseswesweseswnw",
            "swseswswswsweswswseswswswswseswsenewswsw",
            "seswseseseswwesesesesesesesesesenwswnese",
            "wswnewwseswswwswwwswswneswswwseswsw",
            "nwwsesweeseseeseenesesenweeeesesese",
            "neseeeseewseeseseesewseeese",
            "nwnwnenwnenenenwnenwnenenenwswnwsenenenw",
            "eseeseeseeswseneseseseeeseew",
            "swswswswsesweswsesesenwswseswsesesesesw",
            "wnenwneseseesenwwnenwswswneneweee",
            "newnenenenwnwenwenwswneneseneneswnene",
            "nwwnenwneneneswnwneenenwnenenwnese",
            "eweewwwwwnewwwewwwwnwwswse",
            "ewsweenenwnwswswnwnwnwswwnwnw",
            "esenwnwnenwnwwnwnwwwwewseswwwnwsene",
            "wseeeeeeseseseenwseeeseeseswee",
            "sesesesesenwnwsewswseswseeeseseswnewne",
            "neneneeneswnenenenenewnenwnenenesenenene",
            "wseneseweneeeeew",
            "sesewseseeseswsenewsesewsesenesese",
            "neeneneswseneesweeseeneneneenwnwe",
            "swswseswswswswwneswswswswswswswswswsw",
            "wwwwsewswwswswwswneswwwwswww",
            "seseseseswneseseseseseeseseswsesewsesesew",
            "nwnwnwswnwnwnwnwnesenwnwnwsweenwnwnwswnwnw",
            "seesewnwswneweeenweeseeeseseneswe",
            "seesesesesesewseneewesesesesesesese",
            "nwneeeewewneneeenenesenwswswswe",
            "seseewneneeneneneneneneswwnwneewse",
            "sesweeswwnweseeeenweeeenwee",
            "wwswwswwwnewsewwwnewswweww",
            "swswswnwswnenweseseswswswnenwswswseswswsw",
            "eseswneeeeeneseeenenweeswesesesw",
            "seseseseswswseswseswswswsenwswesesesesw",
            "sweeenenenenwswnwsweeneneswnweeesee",
            "wnenwnwnenwnwwswnenwnwseee",
            "newweneeeeeseneeneswneweneenee",
            "wswswsweseeswneseswswswenewnewwse",
            "swswswweeneswenwswnw",
            "swswsenwswseswswsesenwsesesesesesesesee",
            "nwnwsenwnwnwnwnwwnwnwnwnwnenwnwsenwnw",
            "seswenwnenwsewnwwnenwsewwnwnwesene",
            "enwseweenweseseseeswswseneswesene",
            "newnesenewneneseneneneneswnewneneneenee",
            "swwwswwnwewneswwwwswswwseswww",
            "sesenwweneneeswesenwwewnenw",
            "seneseeseswseseneseswsesesesesesesesee",
            "neneeeeneseneweneneneseseewewwe",
            "eseeseseseseseeswswseseneseneseesee",
            "eseneswnewswneswwsenenenwnwsenwwsww",
            "nwnwsenenenwnwnwnwnenwnwnwswnenwnwnenenenw",
            "nenwenwnwnwswnenenenwnenenwwnenwesenenenw",
            "swswswseswswswswswswneneseswswswseswwnwnw",
            "eeeewneeeeeneeneswnwesesw",
            "eneneneeesenenesenwnwneeeeseeenew",
            "seswseswsweswswswswseswswnwseswswse",
            "nenwswwswswswswwswnewswwswswwwswwe",
            "nwwnwswseewwwwnwwnewswweenwnwnw",
            "wsenwnwswnwnwwnwsenwenwwnwnwnwnwwwnenw",
            "swsweswswseswswswnwswswswswswnwseeswneswsw",
            "swneswswwswwswswneswswwseswseswswneswswsw",
            "wwwnwwwnwwseewewwnwwswweswne",
            "wwnwnewsenwnwwwwwnwnwnwnwnwnwnwnw",
            "swnwnwnwneneneneeneenwswnwnenwnenenese",
            "nenwsenenenenenewnenwnenenenenene",
            "swswswwwwswswene",
            "neneeneeneneswneswnwnesewneenwnwnenesw",
            "wswwwwswwswneswswwseeswswwwww",
            "nenenwswsenwnwsesenwnenenenwnwnwsene",
            "nwenwseeeenesweswseweseseseenwnesee",
            "esenwsesesewseseneseseseseswseseseswsese",
            "eeeweenwnewseeeeseswsenenwesesese",
            "weeeeneewseeneeeeesweeswne",
            "seseswsenesesesesesewsesesesesesesesese",
            "neneenwneweseseeeeweeeeeneeee",
            "eeesweeenwneeswnenweeeeeeenee",
            "ewwnwwnewweswnwwsewewwnweww",
            "eseneeeweeeeeeeeenesweenene",
            "swswswswswwwwwswwneswneswswswswswww",
            "sweeeeeneeeeeeeeeeneswsee",
            "swseswseswneswswswseswswswswswswswswwsw",
            "swnwsenwnenwnwwnwnwnwnwwsenenwenenwnenenw",
            "nwseseswseseseeswnwswseswseswseswsenwse",
            "swswenwnwswwseswnwsewseeneswseneswswnw",
            "newseseesewnwsweneseeseseewseseew",
            "wwwwnwwwwwwwwwewewwwww",
            "nwswnenwwnwwnwnweesewnwnenwnenwnwnwnw",
            "swneeseewsesewseewseseneneseseeeee",
            "senweswnwswesesweswsewseeswswnwse",
            "neeneeeeeeneswneneeweeseeneee",
            "nwwnwwnwwswwwnesenwnwwwwwnwwnwse",
            "nenwnewnwnenenwsenenenwnwnwnwewnwnwne",
            "wnenwnwwnwwwewswswnwwwwnwnwwwww",
            "neneseneneswnenenwwneneneeeneeneeenew",
            "swswwswswswneseswswswswswnwswnwesweswsw",
            "eweweeeeeeneseeewee",
            "nwwswwwsenwnewswwseswnewswnweww",
            "swswsesewsweseneeswswswsweswnwnwnwswwsw",
            "swseswswswswseseseseswswseseswnwnesesesw",
            "nwsenesweswnwnwsesweeswewsesesenesese",
            "nwseseswseseneswsesenwseseseswsesesesenwe",
            "seseeseseseseseseeseseesew",
            "nenwnenenewnenenwnenwneneeneswenenwnenw",
            "wnewwswswseswnenweswswswswswnwswswswswe",
            "neenwswwnenenenwnwswenwenwnene",
            "nwnwnwenwnwnwnwnwnenwswnwnwswnwnwnwnwne",
            "seewwsenwwwwweswswwnwwwwswww",
            "nwnwwwnwnwsesenwneenwsenenwswwnwsenwne",
            "nwnewnwenwwneswwnewwswswwnwwnwswnwnw",
            "seeeeeeeswseseseseeseeenwsesee",
            "wnesenwwwwwnewwwsewwswwwwww",
            "nwnwnenwnenwnwnwnwnwnwwnwnwnesenwnwne",
            "nenewnwnenwswsenwenwnwnwnwneewnenwne",
            "neeenwneneeneswweeeeneeeneeeee",
            "nwswenenwnwnwswnenenwnwnwnwnenwnenwnwne",
            "neeswswswswswswswwswnwswwswswswswesw",
            "nwnwnwnwnwnwswnwenwnwswnwnenwnwnwnwnwnwnwnw",
            "newwnwwsewwwwsewwewwwswsenwsw",
            "nwseswneswwswswwswwwswswwwwseswwsw",
            "wwswswwwwwwsewswwnewwwwww",
            "seseseesesesesewsesewsene",
            "wswswswewswswwewwwswswnwwswnwww",
            "swswseswswswnwswswswswwswswswswswswsw",
            "nwsesesweewnwneswwnenwnwnwsenenwswsenw",
            "swswseseseswswseseseseseswswsesesene",
            "nwesewwnwneseeseneswsesesweneseenwswsw",
            "eeseeesenwnweesweeeseeeesesw",
            "neeswwnenwnenenenwneenenenenwneswsesw",
            "nwwwesenwwnwnwwwnwwnw",
            "nwwswwwwenwwnesesesewenewswsww",
            "swswwwwswsewwswneswswswwwsewneswswsw",
            "eneeneneswnwnenewseeneseneesenenewene",
            "nwwswwnwnwwnwnwnwewwnewnwnwnwwnwe",
            "nwsweswnewwwwsweswswwesw",
            "nwneenenenenenenewswsewenenewsenenene",
            "seswseeseseseneewsesweseseneseesesese",
            "swswswsweeneeewewnewwnwswnewsw",
            "wneswswwsewswneseswswswswwsw",
            "eneneeneeeneseneneswneenwneneenene",
            "enwnenwswsweneeswenwwseeee",
            "nwnwnwnwnenenwenwnwswnenwnwnwsenwnwnwnenwnw",
            "sesewsenwseseesewnwsenesesesesesesese",
            "nesenwneneswenenenenewnesesenwewsenew",
            "seseswnewswesenwneswwewwneeseeswse",
            "wseeseenweeeeeeeewswneeee",
            "nwsesesweswsewseseswsesesesewswseneese",
            "nwnwwwwswwwnesewneewsw",
            "nwwnwsenenwneneneswnenenwnwnwswnwnw",
            "swnwnesewwwnwwwwnwwneenwswwwwww",
            "seseseswwneswswsenewneswswwswseswswse",
            "eseseweenenewseneseseseseswseesew",
            "seswswswnwseseswswseseswswswswsenwsenwnwe",
            "swswswwweswwswswwswswwwswswswsw",
            "wnwwnwwwnwwseenwesenwwnwswnwnenw",
            "nwnwnwnwenwnwnenwnwnwwnenwneenwnenwswnenw",
            "nwwsesesenwweesese",
            "nwswnwnwnenewsewse",
            "eswswneswwwwwwwwwnewwwwswnew",
            "wwwswsewwwwwnww",
            "swswswwwwwewnwwsewswwnwewswnee",
            "nenwewneswnenwswnwswewneneneseswenwene",
            "wnewwwewswsewwwwswnwwwwwwwsw",
            "seeseseesenwewseseseseseseseesesee",
            "wwnwwwnwwwwsewnwwwswwnwnwwe",
            "ewsenenenwswswswswnweseewnwswsesenwsw",
            "wwewwwwwsewswwwnwswwnwwwww",
            "neswsweneseneswwwenesewswswewwsw",
            "neneenenwnwnwswneswneswneneneneswneene",
            "seswnwsesweswsewswnwnwneswnwswnwseswnesw",
            "neswnwnwnenwnwnenenenesenwneneenenenwswne",
            "esenwsesweseneswesewswenweswnesewne",
            "enwnwnwnwnwnwswnwnwnwnwnwswnwneneenene",
            "eneeneswnwneeweneseeesweneneenene",
            "seseweeneswnwseseenwseseseseseeese",
            "eswenwneeenwneseeneeneee",
            "seseswseseseseneeseseswwswwswseseesese",
            "nwseswswswswseseseseneswseseseseseseswswse",
            "nenwswnwswnwnwnwnenwnwnwnenwenwnwnwnwsene",
            "seswwesesweswswswsenwnewwsweswsww",
            "eeeeseseeseeeeesenweesweese",
            "eesenwesweeeeneenweeseeeeee",
            "esesesesweseeesesenesewseseeesee",
            "neneeeneenewnenenenenenesewse",
            "nenwsenwnwwnwenwnenwnwswnwenwnwnwnwnw",
            "wwseneneswnenwneswnwsesenwweseenewnw",
            "swwswnwswwsewswswswswwswsewswswnesw",
            "seeeeneesweweeneeeeneneneeenee",
            "swswswnwseswswswswswnwswswswneswseswesw",
            "wnenwwnesewwswwwsewwwnw",
            "nwsenenwnwwnesweseswnesenwnwnenewsew",
            "ewnwswswwwswwswwnwswesweewww",
            "seeseswsesenwsesenwnweswswswswsewswsene",
            "nwnwnwswnenwnenwnwnenenwnesenwesenwwnew",
            "nwnwwnwnwnwnwwenwsenwnwwwnwnwwnwnwnw",
            "wwwnwwwwseewwwwewewnewww",
            "neswwwswwwswswsenewswswwwwwswwsw",
            "swsewseeseeswseswwswswsesw",
            "swswwswesewswnwswswswwsww",
            "swseswswseswswsweseseseseswnwseswswswsw",
            "wsesesesesesesesesesesesesesee",
            "wnwwswseseneneneenesenenenenenenwee",
            "ewsweswsenwseswwwnweenwnewnwnesew",
            "nwsewneswwwwswneeswwsw",
            "nwnwnwnwnenwnwenwnwneeswnwnwnwnwswnwnwnwnw",
            "ewneneswesenesenwnwnewseww",
            "nwnenwnwnwnenwnwsenwnwnwnenenw",
            "eeeeeeenweseenweeeenwseseesw",
            "wswwswewswwswwswwsw",
            "nweesewseweseenwseseee",
            "nwnenwnwnenenenwnwswnenwsenwnenwnwnwwnenw",
            "nwnenwnwnwnwsenwnwnwsewnwnwnwnwnwnwnwnw",
            "nenwnwnwnwswnenwnwnwnwenwnwnwnwnwnenenw",
            "sweeeeeneneweeeeeeneeeenw",
            "neswsewnenwneswnenenenenwnwenenwnwnenwne",
            "nwwnwswnwswnwnwnwnwnwnwnwnwnenwnwnwnenw",
            "wsweenwenwewneeweeswswwewee",
            "sweswnwwswswswnweswswneswseswswswsesw",
            "swneswswwwswwswewewwswwwwwnese",
            "nwswswswswswswswswswseswswnewswswswsw",
            "nenwnewweewnwnwswnwwsewwwswsenw",
            "seseeewewseseseseseseesesesesesesese",
            "swseswseswswseseswnwseneseeswnweswsesw",
            "wenwnwnwnwnwnwsenwnwnwwwwnwwnwnwswne",
            "nenenenenwnenwnewnenwswnwneneneneneenenw",
            "nwnenenenesenwsenewnewnenwnesenenwnenenw",
            "neneneneeneesweeeneneneneeswenwne",
            "neneenwneeneneeswneeeeenenenenene",
            "swseswseswneswswseseswsesesewnesewneseswsw",
            "swneseewneseswnwneenwswseseseeswese",
            "nwswnwnwnwwnwnwnwnwnwwnwnwewnwnwnwse",
            "nwswnwwnwwnwwwewwnwwwewseenwnw",
            "eeewneneneneeeswseneeweneenew",
            "nwswswswswswswswswswswswwswneseeneswswsw",
            "nwwwnwnwwnwswswnwneewwnwnwnwnwnwnwnw",
            "swswseseeswseswseswswsesew",
            "seesesesesesesesesewseswseseseseene",
            "eesweseeneseswnweseweenwseesesee",
            "enwenwswnenwnwnenwwnenenenewnwswesenwnw",
            "enwweeseenweseeeeswesweeeneee",
            "nwnwseswnewenwnewwsesenwnewnwnwnenwnw",
            "swswswseswweswswswswseeseswneseswsenwne",
            "nenwnwnenwnwnenenesenewneenenenwnewne",
            "swnwwnwswewnwwnenwsewewwwnwnwwww",
            "swneswswwwswnesww",
            "eeeswwnweseweseneeeswsesesesesee",
            "swswwseeseswswswswswsenesenwswswsesenesw",
            "swnewwesenwneswenwenwe",
            "wnwnewwwsewwwwswseswwwswwwsww",
            "swwnwenwnwwnwnwsewwnenwnwwnwwww",
            "nwnwnwnwnenenewnwnenwnwsenenwnwnwnenwne",
            "nwnwnwnwswnwnwnwnwswnwwwenwnwnwsenenwnw",
            "neneneswneseswneeneswnwnenewenwenwswnwne",
            "sweeneseseeseseeneswnweeseseseeee",
            "enesesewwenwwwnewneswsewsewnwnw",
            "swseseseseseseeseseseenwenwswswenwnw",
            "swseseseeneseseswswseseseseswsewsesesese",
            "nweseneswseesenwseswseseswse",
            "swewswseseswwwseneswnesesene",
            "sesesesweseseeneeseeseseseswenwsese",
            "nenwwnenwnwwswwswswwnwnewnwwwnwnww",
            "swswswswwsweswswewswswwswswnwswsww",
            "swwnwswseswsweseswswnwnenwnwsweswee",
            "nesewnwnwnwenwnwwnwwswnwnwnwnwnwnwnwnw",
            "newnenenenenwnenenenenenenwnenenesenene",
            "wwswewwwwswswwwswwnwwwewsw",
            "seeeseeseeeseeseeseeesenwsesesw",
            "neneswseeneneenenwnwnenwnenesenenenewne",
            "nwwneneseswnenenesw",
            "nwnwnwswnwnwnwnenenenwnwnwnwnwnwnwsenwsw",
            "swnwwwnwewwwnwnwwnewwwwnwwnw",
        };
    }
}
