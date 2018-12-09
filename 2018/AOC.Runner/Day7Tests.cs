﻿using System;
using AOC.Solver;
using Xunit;

namespace AOC.Runner
{
    public class Day7Tests
    {
        [Fact]
        public void Part1()
        {
            var result = Day7.SolvePart1(_input);
            Assert.Equal("LAPFCRGHVZOTKWENBXIMSUDJQY", result);
        }

        [Fact]
        public void Part2()
        {
            var result = Day7.SolvePart2(_input);
            Assert.Equal(936, result);
        }

        private readonly string[] _input =
        {
            "Step L must be finished before step A can begin.",
            "Step P must be finished before step F can begin.",
            "Step V must be finished before step U can begin.",
            "Step F must be finished before step S can begin.",
            "Step A must be finished before step J can begin.",
            "Step R must be finished before step K can begin.",
            "Step Z must be finished before step T can begin.",
            "Step G must be finished before step W can begin.",
            "Step H must be finished before step K can begin.",
            "Step T must be finished before step U can begin.",
            "Step K must be finished before step B can begin.",
            "Step C must be finished before step Y can begin.",
            "Step W must be finished before step N can begin.",
            "Step E must be finished before step M can begin.",
            "Step N must be finished before step J can begin.",
            "Step B must be finished before step S can begin.",
            "Step O must be finished before step D can begin.",
            "Step X must be finished before step D can begin.",
            "Step M must be finished before step Q can begin.",
            "Step S must be finished before step J can begin.",
            "Step U must be finished before step Y can begin.",
            "Step I must be finished before step J can begin.",
            "Step D must be finished before step J can begin.",
            "Step Q must be finished before step Y can begin.",
            "Step J must be finished before step Y can begin.",
            "Step Z must be finished before step D can begin.",
            "Step K must be finished before step E can begin.",
            "Step U must be finished before step J can begin.",
            "Step I must be finished before step Y can begin.",
            "Step A must be finished before step B can begin.",
            "Step B must be finished before step Q can begin.",
            "Step Z must be finished before step S can begin.",
            "Step F must be finished before step E can begin.",
            "Step B must be finished before step I can begin.",
            "Step C must be finished before step S can begin.",
            "Step O must be finished before step S can begin.",
            "Step V must be finished before step O can begin.",
            "Step C must be finished before step B can begin.",
            "Step G must be finished before step M can begin.",
            "Step O must be finished before step Y can begin.",
            "Step H must be finished before step N can begin.",
            "Step D must be finished before step Y can begin.",
            "Step Z must be finished before step O can begin.",
            "Step K must be finished before step W can begin.",
            "Step M must be finished before step Y can begin.",
            "Step O must be finished before step J can begin.",
            "Step P must be finished before step E can begin.",
            "Step C must be finished before step Q can begin.",
            "Step I must be finished before step D can begin.",
            "Step F must be finished before step I can begin.",
            "Step W must be finished before step B can begin.",
            "Step W must be finished before step M can begin.",
            "Step N must be finished before step D can begin.",
            "Step Z must be finished before step M can begin.",
            "Step M must be finished before step U can begin.",
            "Step R must be finished before step I can begin.",
            "Step S must be finished before step Y can begin.",
            "Step L must be finished before step B can begin.",
            "Step S must be finished before step D can begin.",
            "Step R must be finished before step G can begin.",
            "Step U must be finished before step D can begin.",
            "Step C must be finished before step N can begin.",
            "Step R must be finished before step T can begin.",
            "Step K must be finished before step U can begin.",
            "Step W must be finished before step E can begin.",
            "Step H must be finished before step E can begin.",
            "Step X must be finished before step M can begin.",
            "Step G must be finished before step I can begin.",
            "Step C must be finished before step U can begin.",
            "Step N must be finished before step B can begin.",
            "Step X must be finished before step S can begin.",
            "Step G must be finished before step H can begin.",
            "Step T must be finished before step X can begin.",
            "Step P must be finished before step N can begin.",
            "Step B must be finished before step Y can begin.",
            "Step S must be finished before step Q can begin.",
            "Step C must be finished before step E can begin.",
            "Step F must be finished before step D can begin.",
            "Step H must be finished before step J can begin.",
            "Step B must be finished before step U can begin.",
            "Step B must be finished before step J can begin.",
            "Step P must be finished before step I can begin.",
            "Step N must be finished before step X can begin.",
            "Step M must be finished before step J can begin.",
            "Step X must be finished before step I can begin.",
            "Step L must be finished before step P can begin.",
            "Step T must be finished before step B can begin.",
            "Step T must be finished before step K can begin.",
            "Step D must be finished before step Q can begin.",
            "Step W must be finished before step X can begin.",
            "Step A must be finished before step Y can begin.",
            "Step G must be finished before step D can begin.",
            "Step R must be finished before step Z can begin.",
            "Step U must be finished before step Q can begin.",
            "Step G must be finished before step O can begin.",
            "Step G must be finished before step Q can begin.",
            "Step G must be finished before step Y can begin.",
            "Step P must be finished before step Y can begin.",
            "Step I must be finished before step Q can begin.",
            "Step F must be finished before step C can begin.",
            "Step L must be finished before step K can begin.",
        };
    }
}
