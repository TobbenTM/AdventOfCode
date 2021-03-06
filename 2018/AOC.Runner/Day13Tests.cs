﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using AOC.Solver;
using Xunit;
using Xunit.Abstractions;
using static AOC.Solver.Day13;

namespace AOC.Runner
{
    public class Day13Tests
    {
        [Fact]
        public void Part1()
        {
            var tracks = new MineTracks(_input);
            var collision = tracks.MoveAllCartsTillCollision();
            Assert.Equal((118, 66), collision);
        }

        [Fact]
        public void Part2()
        {
            var tracks = new MineTracks(_input);
            var lastCart = tracks.MoveAllCartsTillOneLeft();
            Assert.Equal((70, 129), lastCart);
        }

        private readonly string[] _input =
        {
            @"                                      /<------------->-----------------------------------\        /---------------------------------------------\     ",
            @"                                      |     /--------------------------------------------+--------+-----------------<----------\                |     ",
            @"                                /-----+-----+-------------\                 /------------+--------+----------------------------+----------\     |     ",
            @"          /---------------------+-----+-----+-------------+-------\         |            |        |                            |          |     |     ",
            @"/---------+---------------------+-----+----\|             |       |         |            |        |  /-------------------------+--\       |     |     ",
            @"|         |         /-----------+-----+----++-\           |       |    /----+------------+--------+--+------\   /-----------\  |  |       |     |     ",
            @"|         |         |           |     |    || |           |       |    |    |            |       /+--+------+---+-----------+-\|  |       |     |     ",
            @"|         |         |     /-----+-----+----++-+-----------+-------+----+----+------------+-------++--+------+---+-----------+-++-\|       |     |     ",
            @"|         |  /------+-----+-----+-----+----++-+-----------+-------+---\|    |            |       || /+------+---+-----------+-++-++-------+-----+-\   ",
            @"|         |  |      |     |/----+-----+----++-+-----------+-------+---++----+------------+-----\ || ||      |   |           | || ||       |     | |   ",
            @"|         |  |      |    /++----+-----+----++-+-----------+---\   |   ||    |            |     | || ||      |   |           | || ||      /+-----+-+-\ ",
            @"|/--------+--+------+----+++----+-----+----++-+-----------+---+---+---++\   |            |     | || ||      |   |           | || ||      ||     | | | ",
            @"||        |  |      |/---+++----+---\ |/---++-+-----------+---+---+---+++---+------------+-----+-++-++------+---+-----------+-++-++------++-\   | | | ",
            @"||        |  |      ||   |||    |   | ||   || |           |   |   |   |||   |            |     | || ||      |   |           | || ||      || |   | | | ",
            @"||        |  |      ||   |||    |/--+-++---++-+\         /+---+---+---+++---+------------+-----+-++-++----\ |   |    /------+-++-++-----\|| |   | | | ",
            @"||        |  |      ||   |||    ||  | ||   || ||         ||   |   |   |||   |            |     | || ||    | |   |    |      | || ||     ||| |   | | | ",
            @"||        |  |      ||   |||/---++--+-++---++-++---------++---+---+--\|||   | /----------+-----+-++-++----+-+---+----+---\  | || ||     ||| |   | | | ",
            @"\+--------+--+------++---++++---++--+-++---/| ||         ||   |   |  ||||   | |          |     | || ||    | |   |    |   |  | || ||     ||| |   | | | ",
            @" |        |  |      ||   ||||  /++--+-++----+-++---------++---+---+--++++---+-+----------+-----+-++-++----+-+---+----+---+-\| || ||     ||| |   | | | ",
            @" |       /+--+------++---++++--+++--+-++----+-++---------++---+---+\ ||||   | |          |     | || ||    | |   |    |   | || || ||     ||| |   | | | ",
            @" |       ||  |      ||   ||||  |||  | ||    | ||         ||   |   || ||||   | |          |     | || ||    | |   |    |   | || || ||     ||| |   | | | ",
            @" | /-----++--+------++---++++--+++\ | ||    | ||         ||   |   || ||||   | |          |     | \+-++----+-+---+----+---+-++-/| ||     ||| |   | | | ",
            @" | |     ||  |      ||   ||||  |||| | ||    | ||         ||   |   || ||||   | |   /------+---\ | /+-++----+-+--\|    |   | ||  | ||     ||| |   | | | ",
            @" | |     ||  |   /--++---++++--++++-+-++----+-++---------++---+---++-++++---+-+---+------+---+\| || ||    | |  ||    |   | ||  | ||     ||| |   | | | ",
            @" | |     ||  |   |  ||   ||||  |||| | ||   /+-++---------++---+---++-++++---+-+---+------+---+++-++-++----+-+--++----+---+-++--+-++-\   ||| |   | | | ",
            @" | |     ||  |   |  ||   |\++--++++-+-++---++-++---------++---+---++-++++---+-+---+------+---+++-++-++----+-+--++----+---+-++--+-/| |   ||| |   | | | ",
            @" | |     ||  |   |  || /-+-++--++++-+-++---++-++---------++---+---++-++++---+-+\  |      |   ||| |\-++----+-+--++----+---+-++--+--+-+---+++-+---/ | | ",
            @" | |     ||  |   |  || | | ||  |||| | ^|   || ||         ||   |   || ||||   | ||  |      |   ||| |  ||    | |  ||    |   | ||  |  | |   ||| |     | | ",
            @" | |     |\--+---+--++-+-+-++--++++-+-++---++-++---------++---+---/| ||||   | ||  |      |   ||| |  || /--+-+--++--\ |   | ||  |  | |   ||| |     | | ",
            @" | |     |   |/--+--++-+-+-++--++++-+-++---++-++---------++---+----+-++++---+-++--+-----\|   ||| |  \+-+--+-+--++--+-+---+-++--+--+-+---+++-+-----/ | ",
            @" | |     |   ||  |  || | | ||  |||| | ||   || ||         ||   |/---+-++++---+-++--+-----++---+++-+---+-+--+-+--++--+-+---+-++--+--+-+---+++-+-------+\",
            @" | |     |   ||  |  || | | ||  |||| | ||   || ||      /--++---++---+-++++---+-++--+-----++---+++-+---+-+--+-+--++--+-+---+-++--+--+\|   ||| |       ||",
            @" | |     |   ||  |  || | | ||  |||| | ||   || ||      |  \+---++---+-++++---+-++--+-----++---+++-+---+-+--/ |  ||  | |   | ||  |  |||   ||| |       ||",
            @" | |     |/--++--+--++-+\| ||  |||| | ||   || ||  /---+---+---++---+-++++---+-++--+-----++---+++-+--\| |    |  ||  | |   | ||  |  |||   ||| |       ||",
            @" | |     ||  ||  |  || ||| ||  |||| |/++---++-++--+---+---+---++---+-++++---+-++--+-----++---+++-+--++-+----+--++--+-+---+-++--+--+++---+++-+-\     ||",
            @" | |     ||  ||  |  || ||| ||  |||| ||||   || ||  |   |   |   ||   | ||||   | ||  |     ||  /+++-+--++-+----+--++--+-+---+-++--+--+++\  ||| | |     ||",
            @" | |     ||  ||  |  || ||| |\--++++-++++---++-++->+---+---+---++---+-/|||   | ||  |     ||  |||| |  || |    |  ||  | |   v ||  |  ||||  ||| | |     ||",
            @" | |   /-++--++--+--++\||| |   |||| ||||   || ||  |/--+---+---++---+--+++---+-++--+-----++--++++-+--++-+----+\ ||  | |   | ||  |  ||||  ||| | |     ||",
            @" | |   | ||  ||  |  |||||| |   |||| ||||   || ||  ||  |   |   ||  /+--+++---+-++--+-\   ||  |||| |  || |    || ||  | |   | ||  |  ||||  ||| | |     ||",
            @" | |   | ||  ||  |  |||||| |   |||| ||||   || ||  ||  |   |   ||  ||  |||   |/++--+-+---++\/++++-+--++-+----++-++--+-+---+-++\ | /++++--+++\| |     ||",
            @" | |   | ||  ||  |  |||||| |   |||| ||||/--++-++--++--+---+---++--++--+++---++++--+-+---++++++++-+--++-+----++\||  | |   | ||| | |||||  ||||| |     ||",
            @" | |   | ||/-++--+--++++++-+---++++-+++++--++-++--++--+---+---++--++--+++---++++--+-+---++++++++-+--++-+----+++++-\| |   | ||| | |||||  ||||| |     ||",
            @" | |   | ||| ||  | /++++++-+---++++-+++++--++-++--++--+---+---++--++--+++---++++--+-+---++++++++-+--++\|    ||||| || |   | ||| | |||||  ||||| |     ||",
            @" | |/--+-+++-++--+-+++++++-+---++++-+++++--++-++--++--+---+---++--++--+++---++++\ | |   |||||||| |  ||||    ||||| || |   | ||| | |||||  ||||| |     ||",
            @" \-++--+-+++-++--+-+++++++-+<--++++-+++++--++-++--++--+---+---++--++--++/   ||||| | |   |||||||| |  |\++----+++++-++-+---+-+++-+-+/|||  ||||| |     ||",
            @"   ||  | ||| ||  | ||||||| |   \+++-+++++--++-++--++--+---+---++--++--++----+++++-+-+---++++++++-+--+-++----+++++-++-+---+-/|| | | |||  ||||| |     ||",
            @"   ||  | ||| ||  | ||||||| |    ||| |||||  || ||/-++--+---+---++--++--++--\ ||||| | |   ||||||||/+--+-++----+++++-++\|   |  || | | |||  ||||| |     ||",
            @"   ||  | ||| \+--+-+++++++-+----+++-+++++--++-+++-++--+---+---++--++--/|  | ||||| | |   ||||||||||  | ||    ||||\-++++---+--/| | | |||  ||||| |     ||",
            @"   ||  | |||  |  | ||||||\-+----+++-+++++--++-+++-++--+---+---/|  ||   |  | ||||| | |   ||||||||||  | |\----++++--+/||   |   | | | |||  |\+++-+-----/|",
            @"   ||  | ||^  |  | ||||||  |    |||/+++++--++-+++-++--+---+----+--++---+--+\||||| | |/--++++++++++--+-+-----++++--+-++---+---+-+-+\|||  | ||| |      |",
            @"   ||  | |||  |  | ||||||  |    |||||||||  || ||| ||  |   |    |  ||   \--+++++++-+-++--++++++++++--+-+-----/|||  | v|   |   | | |||||  | ||| |      |",
            @"   ||  | |||  |  | ||||||  |   /+++++++++--++-+++-++--+---+----+--++------+++++++-+-++--++++++++++--+-+------+++--+-++---+---+-+-+++++-\| ||| |      |",
            @"   ||  | |||  |  | |\++++--+---++++++++++--++-/|| ||  |   |    |  ||      ||||||| | ||  ||||||||||  | |      |||  | ||/--+---+-+\||||| || ||| |      |",
            @"   ||/-+-+++--+--+-+-++++--+---++++++++++--++--++-++--+---+----+-\||      ||||||| | ||  ||||||||||  | |      |||  | |||  |   | ||||||| || ||| |      |",
            @"   ||| | |||  |  | | ||||  |   ||||||||||/-++--++-++--+---+----+-+++------+++++++-+-++--++++++++++--+-+------+++--+-+++--+---+-+++++++-++-+++-+-----\|",
            @"   ||| | |||  |  | | |||v  |   ||||||||||| ||  ||/++--+---+\   | |||      ||||||| | ||  ||||||||||  | |      |||  | |||  |   | ||||||| || ||| |     ||",
            @"   ||| | |||  |  | | ||||  |   |||||||\+++-++--+++++--+---++---+-+++------+++++++-+-++--+/||||||||  | |      |||  | |||  |   | ||||||| || ||| |     ||",
            @"   ||| | |||  |  | | ||||  |   ||||||| ||| ||/-+++++--+---++---+-+++------+++++++\| ||  | ||||||||  | |      |||  | |||  |   | ||||||| || ||| |     ||",
            @"   ||| | |||  |  | | ||||/-+---+++++++-+++-+++-+++++--+---++---+-+++------+++++++++-++--+-++++++++--+-+------+++--+-+++\ |   | ||||||| || ||| |     ||",
            @"   ||| | |||  |  | | ||||| \---+++++++-+++-+++-+++++--+---++---+-+++------+++++++++-++--+-+++++/||  | |      |||  | |||| |   | ||||||| || ||| |     ||",
            @"   ||| | |||  |  \-+-+++++-----+++++++-+++-+++-+++++--+---++---+-+++------+++++++++-++--+-++++/ ||  | |      |||  | |||| |   | ||||||| || ||| |     ||",
            @"   ||| | |||  |    | |||||     ||||||| ||| ||| |||||  |   ||   | |||      ||||||||| ||  | ||||  ||  | |      |||  | |||| |   | ||||||| || ||| |     ||",
            @"   ||| | |||  |    | |||||     ||||\++-+++-+++-+++++--+---++---+-+++------+/||\++++-++--+-++++--++--+-+------+++--+-++++-/   | ||||||| || ||| |     ||",
            @"/--+++-+-+++--+----+-+++++-----++++-++-+++-+++-+++++--+---++\  | |||     /+-++-++++-++--+-++++--++--+-+------+++--+-++++-----+-+++++++-++-+++\|     ||",
            @"|  ||| | |||  |    | |||||     |||| || ||| ||| |||||  |   |||  | |||     || || |||| ||  | ||||  ||  | |      |||  | ||||     | ||||||| || |||||     ||",
            @"|  ||| | |||  |    | |||||     |\++-++-+++-+++-+++++--+---/||  | |||     || \+-++++-++--+-++++--++--+-+------+++--+-++++-----+-+++++++-++-/||||     ||",
            @"|  ||| | |||  |/---+-+++++-\   | || || ||| ||| ||||| /+----++--+-+++-----++--+-++++-++--+-++++--++--+\|      |||  | |\++-----+-+++++++-+/  ||||     ||",
            @"|  ||| | |||  ||   | ||||| |   | || || ||| ||| ||||| ||    ||  | |||     ||  | |||| ||  | ||||  ||  |||      |||  | | ||     | ||||||| |   ||||     ||",
            @"|  ||| | |||  ||   | ||||| |   | ||/++-+++-+++-+++++-++----++--+-+++-----++--+-++++-++--+-++++--++--+++----\ |||  | | ||     | ||||||| |   ||||     ||",
            @"| /+++-+-+++--++---+-+++++-+---+-+++++-+++-+++-+++++-++----++--+-+++-----++--+-++++-++\ | ||||  ||  |||    | |||  | | ||     | ||||||| |   ||||     ||",
            @"| |||| |/+++--++--\| ||||| |   | ||||| ||| ||| ||\++-++----/|  | |||     ||  \-++++-+++-+-/|||  ||  |||    | |||  | | ||     | ||||||| |   ||||     ||",
            @"| |||| |||||  ||  || ||||| |   | ||||| ||| ||| || || ||     | /+-+++-----++----++++-+++-+--+++--++--+++----+-+++--+-+-++\    | ||||||| |   ||||     ||",
            @"| |||| |||||  ||  || ||||| |   | ||||| ||| |\+-++-++-++-----+-++-+++-----++----++++-+++-+--+++--++--+++----+-+++--+-+-+++----+-/|||||| |   ||||     ||",
            @"| |||| |||||  ||  || ||||| |   | ||||| ||| | | || || ||     | || |||     ||/---++++-+++-+--+++--++--+++----+-+++-\| | |||    |  |||||| |   ||||     ||",
            @"| |||| |v|||  ||  || ||||| |   | ||||| ||| | | || || ||     | || |||     |||  /++++-+++-+--+++-\||  |||    | ||| || | |||    |  |||||| |   ||||     ||",
            @"| |||| |||||  ||  || ||||| |   | ||||| ||| | | || || ||     | || |||     |||  ||||| ||| |  ||| |||  |||    | ||| || | |||    |  |||||| |   ||||     ||",
            @"| |||| |||||  ||  || ||||| |   | ||||| ||| | | || || ||     | || |||     |||  ||||| ||| |  \++-+++--+++----+-+++-++-+-+++----/  |||||| |   ||||     ||",
            @"| |||| |||||  ||  || ||||| |   | ||||| ||| | | || || ||     | || |||     |||  ||||| ||| |   || |||  |||    | ||| || | |||       |||||| |   ||||     ||",
            @"| |||\-+++++--++--++-+++++-+---+-+++++-+++-+-+-++-++-++-----+-++-/||     |||  ||||| ||| |   || |||  |||    | ||| || | |||       |||||| |   ||||     ||",
            @"| |||  ||\++--++--++-+++++-+---+-+++++-+++-+-+-++-++-++-----+-++--+/     |||  ||||| ||| |   || |||  |||    |/+++-++-+-+++-------++++++-+--\||||     ||",
            @"| |||  || ||  ||  || ||||| |   | ||||| ||| \-+-++-++-++-----+-++--+------+++--+++++-+++-+---++-+++--+++----+++++-++-+-+++-------++++/| |  |||||     ||",
            @"| |||  || ||  ||  || ||||| |   | ||||| |||   | || || ||     | ||  |      |||  ||||| ||| |   || |\+--+++----+++++-++-/ \++-------/||| | |  |||||     ||",
            @"| |||  || ||  ||  || ||||| |   | ||||| |||/--+-++-++-++-----+-++--+\     |||  ||||| ||| |   || | |  |||    ||||| ||    ||        ||| | |  |||||     ||",
            @"| |||  || ||/-++--++-+++++-+-\ | ||||| ||||  | || || ||     | ||  ||     |||  \++++-+++-+---++-/ |  |||    ||||| ||    ||        ||| | |  |||||     ||",
            @"| |||  || ||| \+--++-+++++-+-+-+-+++++-++++--+-++-++-++-----+-++--++-----+++---++++-+++-/   ||   |  |||    ||||| ||    ||        ||| | |  |||||     ||",
            @"| |||  || |||  |  || \++++-+-+-+-+++/| ||||  | || || ||     | ||  ||     |||   |||| |||     ||   |  |||    ||||| ||    ||        ||| | |  |||||     ||",
            @"| |||  || |||  |  || /++++-+-+-+-+++-+-++++--+-++-++\||     | ||  ||     |||   |||| |||     ||   |  ||| /--+++++-++----++--\     ||| | |  |||||     ||",
            @"| |||  |\-+++--+--/| ||||| | | | ||| | ||||  | || |||||     | |\--++-----+++---++++-+++-----++---+--+++-+--+++++-++----++--+-----+++-+-+--+++++-----+/",
            @"| |||  |  |||  |   | ||||| | | | ||| | ||||  | || |||||     | |   ||     |||   |||| |||     ||   |  ||| |  ||||| ||    ||  |     ||| | |  |||||     | ",
            @"| |||  | /+++--+---+-+++++-+-+-+-+++-+-++++--+-++-+++++-----+-+---++-\   |||   |||| |||     ||   |  ||| |  ||||| ||    ||  |     ||| | |  |||||     | ",
            @"| |||  | ||||  |   | ||||| | | | ||| | ||||  | || |||\+-----+-+---++-+---+++---++++-+++-----++---+--+/| |  ||||| ||    ||  |     ||| | |  |||||     | ",
            @"| |||  | ||||  |   | ||||| |/+-+-+++-+-++++--+-++-+++-+-----+-+---++-+---+++---++++-+++-----++---+--+-+-+--+++++-++\   ||  |     ||| | |  |||||     | ",
            @"| |||  | ||||  |   | ||||| ||| | ||| | ||||  | || ||| |     | |   ||/+---+++---++++-+++-----++---+--+-+-+-\||||| |||   ||  |/----+++-+\|  |||||     | ",
            @"| |||  | ||v|  |   | ||||| ||| | ||| | ||||  | || ||| |     | |   ||||   |||/--++++-+++-----++-\ |  | | | |||||| |||   ||  ||   /+++-+++-\|||||     | ",
            @"| ||| /+-++++--+---+-+++++-+++-+-+++-+-++++--+-++-+++-+-----+-+---++++---++++--++++-+++--\  || | |  | | | |||||| |||   || /++---++++-+++-++++++--\  | ",
            @"| ||| || ||||  |   | |||v| ||| | ||| | ||||  | || ||| |     | |   ||||   ||||  |||| |||  |  || | |  | | | |||||| |||   || |||   |\++-+++-++/|||  |  | ",
            @"| ||| || ||||  |   | ||||| ||| | ||| | ||\+--+-++-+++-+-----+-+---++++---++++--++++-+++--+--++-+-+--+-+-+-++++++-+++---++-+++---+-++-+++-++-+++--+--/ ",
            @"| ||| || ||||  |   | ||||| ||| | ||| | || |  | || ||| |     | |   ||||   ||||  |||| |||  |  || | |  | | | |||||| |||   || |||   | || ||| || |||  |    ",
            @"| ||| || ||||  |   | ||||| ||| | ||| | || |  | || ||| |     | |   ||||   ||||  |||| |||  |  || | |  | | | |||||| |||   || |||   | || ||| || |||  |    ",
            @"| ||| || ||||  |   | ||||| ||| | ||| | \+-+--+-++-+++-+-----+-+---++++---++++--++++-+++--+--++-+-+--+-+-+-++++++-+++---++-+++---+-++-+++-++-/||  |    ",
            @"| ||| || ||||  |   \-+++++-+++-+-+++-+--+-+--+-++-+++-+-----+-+---++++---++++--++++-+++--+--++-+-+--+-/ | |||||| |||   || |||   | || ||| ||  ||  |    ",
            @"| ||| |\-++++--+-----+/||| ||| | ||| |  | |  | || |\+-+-----+-+---++++---++++--++++-+++--+--++-+-+--+---+-+++/|| |||   || |||   | || ||| ||  ||  |    ",
            @"| ||| |  ||||  |     | ||\-+++-+-+++-+--+-+--+-++-+-+-+-----+-+---++++---++++--++++-+++--+--++-+-+--+---+-+++-++-+++---/| ||\---+-++-+/| ||  ||  |    ",
            @"| ||| |  ||||  |     | ||  ||| | ||| \--+-+--+-++-+-+-+-----+-+---++++---++++--++++-+++--+--++-+-+--+---+-+++-++-+++----+-++----+-++-+-+-++--+/  |    ",
            @"| ||| |  ||||  |     | ||  ||| | |||    | \--+-++-+-+-+-----+-+---+/|| /-++++--++++-+++-\|  || | |  |   | ||| || |||    | ||    | || | | ||  |   |    ",
            @"| |\+-+--++++--+-----+-++--+++-+-+/|    |    | || | | |     | |   | || | ||||  |||| ||| ||  || | | /+---+-+++-++-+++--\ | ||    | || | | ||  |   |    ",
            @"| | \-+--++++--+-----+-++--+++-+-+-+----+----+-++-+-+-+-----+-+---+-++-+-++++--+/|| ||| ||  || | | ||   | ||| || |||  | | ||    | || | | ||  |   |    ",
            @"| |   |  ||||  |     | ||  ||| | | |    |    | || | | |     | |   | || | ||||  | || ||| ||  || |/+-++---+-+++-++-+++--+-+-++----+-++-+\| ||  |   |    ",
            @"| |   |  ||||  |     | ||  ||| | | |    |    | || | | \-----+-+---+-++-+-++++--+-++-+++-++--++-+++-++---+-+++-++-+++--+-+-++----+-+/ ||| ||  |   |    ",
            @"| |   |  ||||  |     | ||  ||| | | |    |    | || | |       | |   | || | ||||  |/++-+++-++--++-+++-++---+-+++-++\|||  | | ||    \-+--+++-/|  |   |    ",
            @"| |   |  ||||  |     | ||  ||| | | |    \----+>++-+-+-------+-+---+-++-+-++++--++++-+++-++--++-+++-++---+-+++-/|||||  | | ||      |  |||  |  |   |    ",
            @"|/+---+--++++--+-----+-++--+++-+-+-+---------+-++-+-+-------+-+---+-++-+-++++--++++-+++-++--++\||| ||   | |||  |||||  | | ||      |  |||  |  |   |    ",
            @"|||   |  ||||  |     | ||  ||| | \-+---------+-/| | |       | |   | || | ||||  |||\-+++-++--+/|||\-++---+-+++--/||||  | | \+------+--+++--+--+---/    ",
            @"|||   |  ||||  |     | ||  ||| |   \---------+--+-+-+-------+-+---+-++-+-++++--+++--+++-++--+-+++--++---+-+/|   ||||  | |  |      |  |||  |  |        ",
            @"|||  /+--++++--+-----+-++--+++-+----------\  |  | | |       | |   | || | ||\+--+++--+++-++--+-+++--++---+-+-+---+/||  | |  |      |  |||  |  |        ",
            @"|||/<++--++++--+-----+-++--+++-+----------+--+--+\| |       | |   | || | || |  |||  ||| ||  | |||  ||   \-+-+---+-++--+-+--/      |  |||  |  |        ",
            @"|||| ||  |||| /+-----+-++--+++-+-------\  |  |  ||| |  /----+-+---+-++-+-++-+--+++--+++-++--+-+++--++-----+-+---+-++--+-+---------+--+++--+-\|        ",
            @"\+++-++--++++-++-----+-++--+++-+-------+--+--+--+++-+--+----/ |   | || | || |  |||  ||| ||  \-+++--++-----+-+---+-++--+-+---------+--/||  | ||        ",
            @" ||| ||  |||| ||     | ||  ||| \-------+--+--+--+++-+--+------+---+-++-+-++-+--+++--+++-++----+++--++-----+-+---+-++--+-+---------+---+/  | ||        ",
            @" ||| ||  ||\+-++-----+-++--+++---------+--+--+--+++-+--+------+---+-++-+-++-+--+++--+++-++----+++--++-----+-+---+-/|  | |         |   |   | ||        ",
            @" ||| ||  || | ||     | ||  |||         |  |  |  ||| |  |      |   | || | || \--+++--+++-++----+/|  ||     | |   |  |  | |         |   |   | ||        ",
            @" |||/++--++-+-++-----+-++--+++-\       |  |  \--+++-+--+------+---+-++-+<++----++/  ||| ||    | |  ||     | |   |  |  | |         |   |   | ||        ",
            @" ||||||  || | ||     | ||  ||| |       |  |     ||| |  |      |   | || | ||    ||   ||| ||    | \--++-----+-+---+--+--+-+---------+---/   | ||        ",
            @" ||||||  || | ||     | ||  ||| |       |  |     ||| |  |      |   | \+-+-++----++---+++-++----+----++-----/ |   |  |  | |         |       | ||        ",
            @" ||||||  || | ||     | ||  ||| |       |  |     ||| |  |      |   |  | | ||    ||   ||| ||    |    ||       |/--+--+--+-+---------+-------+-++-----\  ",
            @" \+++++--++-+-++-----+-++--+++-+-------+--+-----+++-+--+------+---+--+-+-++----++---+++-++----/    ||       ||  |  |  | |         |       | ||     |  ",
            @"  |||||  ||/+-++-----+-++--+++-+-------+--+-----+++-+--+------+---+--+\| ||    ||   ||| ||         ||       ||  |/-+--+-+---------+---\   | ||     |  ",
            @"  |||||  |||| ||     | ||  ||| |       |  |     ||| |  |      |   |  ||| ||    ||   ||| ||         ||       ||  || |  | |         |   |   | ||     |  ",
            @"  |||||  |||| \+-----+-++--+++-+-------/  |     ||| |  |      |   |  ||| ||    ||   ||| ||         ||       ||  || |  | |         |   |   | ||     |  ",
            @"  |||||  ||||  |     | ||  |\+-+----------+-----+++-+--+------+---+--+++-++----++---+++-++---------++-------++--++-/  | |         |   |   | ||     |  ",
            @"  \++++--++++--+-----+-++--+-+-+----------+-----+++-+--+------+---+--+++-++----++---++/ ||         ||       \+--++----+-+---------+---+---/ ||     |  ",
            @"   ||||  ||||  |     | ||  | | |       /--+-----+++-+--+------+---+--+++-++----++---++--++---------++---\    |  ||    | |         |   |     ||     |  ",
            @"   ||\+--++++--+-----+-++--+-+-+-------+--/     ||| |  |      |   |  ||| ||    ||   ||  ||         ||   |    |  ||    | |         |   |     ||     |  ",
            @"   || |  ||||  |     | \+--+-+-+-------+--------+++-+--+------+---+--+++-++----/|   |\--++---------++---+----+--++----+-+---------/   |     ||     |  ",
            @"   || |  ||||  |     |  |  | | |       |        ||\-+--+------+---+--+++-++-----+---+---++---------+/   |    \--++----+-+-------------+-----++-----/  ",
            @"   || |  ||||  |     |  |  | | |       |        ||  |  |      |   |  ||| ||     |   |   ||         |    |       ||    | |             |     ||        ",
            @"   || |  ||||  |     |  |  | | |       |        \+--+--+------+---+--+++-+/     |   |   ||         |    |       ||    | |             |     ||        ",
            @"   \+-+--++++--+-----+--+--+-+-+-------+---------/  |  |      \---+--+++-+------+---+---++---------+----+-------++----+-/             |     ||        ",
            @"    \-+--++++--+-----+--+--+-+-/       |            |  |     /----+--+++-+------+---+---++---\     \----+-------++----/               |     ||        ",
            @"      |  ||||  |     |  |  | |         |            |  |     |    |  ||| |      \---+---++---+----------+-------/|                    |     ||        ",
            @"      |  |\++--+-----+--/  | |         |            |  |     |    |  ||| |          |   ||   |          |        \--------------------/     ||        ",
            @"      |  | ||  |     |     | |         |            |  |     |    \--+++-+----------/   ||   |          |                                   ||        ",
            @"      |  | ||  |     |     | |         |            |  |     |       ||\-+--<-----------/|   |          |                                   ||        ",
            @"      |  | |\--+-----+-----+-/         \------------+--+-----+-------++--+---------------+---+----------/                                   ||        ",
            @"      \--+-+---+-----+-----+------------------------+--+-----+-------++--+---------------/   |                                              ||        ",
            @"         | |   \-----+-----/                        |  \-----+-------++--+-------------------+----------------------------------------------/|        ",
            @"         \-+---------+------------------------------+--------+-------/|  \-------------------+-----------------------------------------------/        ",
            @"           \---------+------------------------------+--------+--------/                      |                                                        ",
            @"                     \------------------------------/        |                               |                                                        ",
            @"                                                             \-------------------------------/                                                        ",
        };
    }
}
