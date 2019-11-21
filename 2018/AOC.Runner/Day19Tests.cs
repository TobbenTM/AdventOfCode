﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using AOC.Solver;
using Xunit;
using Xunit.Abstractions;
using static AOC.Solver.Day19;

namespace AOC.Runner
{
    public class Day19Tests
    {

        [Fact]
        public void Part1()
        {
            var device = new TimeTravellingDevice(_input);
            var result = device.DoWork();
            Assert.Equal(1302, result[0]);
        }

        [Fact]
        public void Part2()
        {
            var device = new TimeTravellingDevice(_input, new []{ 1L, 0L, 0L, 0L, 0L, 0L });
            var result = device.DoWork();
            Assert.Equal(0, result[0]);
        }

        private readonly string[] _input =
        {
            "#ip 5",
            "addi 5 16 5",
            "seti 1 3 1",
            "seti 1 1 2",
            "mulr 1 2 4",
            "eqrr 4 3 4",
            "addr 4 5 5",
            "addi 5 1 5",
            "addr 1 0 0",
            "addi 2 1 2",
            "gtrr 2 3 4",
            "addr 5 4 5",
            "seti 2 4 5",
            "addi 1 1 1",
            "gtrr 1 3 4",
            "addr 4 5 5",
            "seti 1 5 5",
            "mulr 5 5 5",
            "addi 3 2 3",
            "mulr 3 3 3",
            "mulr 5 3 3",
            "muli 3 11 3",
            "addi 4 8 4",
            "mulr 4 5 4",
            "addi 4 13 4",
            "addr 3 4 3",
            "addr 5 0 5",
            "seti 0 8 5",
            "setr 5 3 4",
            "mulr 4 5 4",
            "addr 5 4 4",
            "mulr 5 4 4",
            "muli 4 14 4",
            "mulr 4 5 4",
            "addr 3 4 3",
            "seti 0 8 0",
            "seti 0 4 5",
        };
    }
}
