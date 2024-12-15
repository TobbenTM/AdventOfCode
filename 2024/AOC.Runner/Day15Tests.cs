using System;
using AOC.Solver;
using System.IO;
using AOC.Runner.Logging;
using Xunit;
using Xunit.Abstractions;

namespace AOC.Runner;

public class Day15Tests(ITestOutputHelper output)
{
    private readonly string[] _input = File.ReadAllLines("./Day15.input");

    [Fact]
    public void Part1()
    {
        var result = Day15.SolvePart1(_input);
        Assert.Equal(1438161, result);
    }

    [Fact]
    public void Part1_Example1()
    {
        var result = Day15.SolvePart1([
            "########",
            "#..O.O.#",
            "##@.O..#",
            "#...O..#",
            "#.#.O..#",
            "#...O..#",
            "#......#",
            "########",
            "",
            "<^^>>>vv<v>>v<<",
        ]);
        Assert.Equal(2028, result);
    }

    [Fact]
    public void Part2()
    {
        var result = Day15.SolvePart2(_input);
        Assert.Equal(1437981, result);
    }

    [Fact]
    public void Part2_Example1()
    {
        var result = Day15.SolvePart2([
            "#######",
            "#...#.#",
            "#.....#",
            "#..OO@#",
            "#..O..#",
            "#.....#",
            "#######",
            "",
            "<vv<<^^<<^^",
        ]);
        Assert.Equal(618, result);
    }

    [Fact]
    public void Part2_Example2()
    {
        Console.SetOut(new ConsoleWriter(output));
        var result = Day15.SolvePart2([
            "##########",
            "#..O..O.O#",
            "#......O.#",
            "#.OO..O.O#",
            "#..O@..O.#",
            "#O#..O...#",
            "#O..O..O.#",
            "#.OO.O.OO#",
            "#....O...#",
            "##########",
            "",
            "<vv>^<v^>v>^vv^v>v<>v^v<v<^vv<<<^><<><>>v<vvv<>^v^>^<<<><<v<<<v^vv^v>^",
            "vvv<<^>^v^^><<>>><>^<<><^vv^^<>vvv<>><^^v>^>vv<>v<<<<v<^v>^<^^>>>^<v<v",
            "><>vv>v^v^<>><>>>><^^>vv>v<^^^>>v^v^<^^>v^^>v^<^v>v<>>v^v^<v>v^^<^^vv<",
            "<<v<^>>^^^^>>>v^<>vvv^><v<<<>^^^vv^<vvv>^>v<^^^^v<>^>vvvv><>>v^<<^^^^^",
            "^><^><>>><>^^<<^^v>>><^<v>^<vv>>v>>>^v><>^v><<<<v>>v<v<v>vvv>^<><<>^><",
            "^>><>^v<><^vvv<^^<><v<<<<<><^v<<<><<<^^<v<^^^><^>>^<v^><<<^>>^v<v^v<v^",
            ">^>>^v>vv>^<<^v<>><<><<v<<v><>v<^vv<<<>^^v^>^^>>><<^v>>v^v><^^>>^<>vv^",
            "<><^^>^^^<><vvvvv^v<v<<>^v<v>v<<^><<><<><<<^^<<<^<<>><<><^^^>^^<>^>v<>",
            "^^>vv<^v^v<vv>^<><v<^v>^^^>>>^^vvv^>vvv<>>>^<^>>>>>^<<^v>^vvv<>^<><<v>",
            "v^^>>><<^^<>>^v^<v^vv<>v^<<>^<^v^v><^<<<><<^<v><v<>vv>>v><v^<vv<>v^<<^",
        ]);
        Assert.Equal(9021, result);
    }
}
