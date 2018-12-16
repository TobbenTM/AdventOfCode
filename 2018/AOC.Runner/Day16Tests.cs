using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using AOC.Solver;
using Xunit;
using Xunit.Abstractions;
using static AOC.Solver.Day16;

namespace AOC.Runner
{
    public class Day16Tests
    {

        [Fact]
        public void Part1()
        {
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "Day16Tests.Input");
            var inputFile = File.ReadAllText(filePath);

            var parser = PrepareParser(inputFile);

            Assert.Equal(646, parser.diffuseSamples);
        }

        [Fact]
        public void Part2()
        {
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "Day16Tests.Input");
            var inputFile = File.ReadAllText(filePath);

            var parser = PrepareParser(inputFile);
            var intermediateMapping = new Dictionary<string, List<int>>();

            foreach (var potentialMapping in parser.potentialCodes)
            {
                foreach (var opcode in potentialMapping.Value)
                {
                    if (!intermediateMapping.ContainsKey(opcode))
                    {
                        intermediateMapping[opcode] = new List<int>{ potentialMapping.Key };
                    }
                    else
                    {
                        intermediateMapping[opcode].Add(potentialMapping.Key);
                    }
                }
            }

            var opMapping = new Dictionary<int, string>();

            while (intermediateMapping.Any())
            {
                var singleMappings = intermediateMapping.Where(kv => kv.Value.Count == 1).ToList();
                foreach (var mapping in singleMappings)
                {
                    opMapping[mapping.Value[0]] = mapping.Key;
                    intermediateMapping.Remove(mapping.Key);
                    foreach (var other in intermediateMapping.Values)
                    {
                        other.Remove(mapping.Value[0]);
                    }
                }
            }

            var program = inputFile.Split("\n\n\n\n")[1].Trim()
                .Split("\n")
                .Select(inst => inst.Split(" ").Select(int.Parse).ToArray())
                .Select(inst => new Instruction
                {
                    OpCode = opMapping[inst[0]],
                    A = inst[1],
                    B = inst[2],
                    C = inst[3],
                })
                .ToArray();

            var result = program.Aggregate(new long[]{0, 0, 0, 0}, (r, i) => TimeTravellingDevice.Execute(r, i));

            Assert.Equal(681, result[0]);
        }

        private (int diffuseSamples, Dictionary<int, List<string>> potentialCodes) PrepareParser(string inputFile)
        {
            var re = new Regex("Before: \\[(\\d+), (\\d+), (\\d+), (\\d+)\\]\\n(\\d+) (\\d+) (\\d+) (\\d+)\\nAfter:  \\[(\\d+), (\\d+), (\\d+), (\\d+)\\]", RegexOptions.Multiline);
            var match = re.Match(inputFile);
            var potentialCodes = new Dictionary<int, List<string>>();
            var matchNo = -1;
            var diffuseSamples = 0;
            do
            {
                matchNo += 1;
                Debug.WriteLine($"Evaluating match #{matchNo}..");
                var parsedGroups = match.Groups.Skip(1).Select(i => int.Parse(i.Value)).ToArray();
                var input = new long[]
                {
                    parsedGroups[0],
                    parsedGroups[1],
                    parsedGroups[2],
                    parsedGroups[3],
                };
                var op = parsedGroups[4];
                var instruction = new Instruction
                {
                    A = parsedGroups[5],
                    B = parsedGroups[6],
                    C = parsedGroups[7],
                };
                var output = new long[]
                {
                    parsedGroups[8],
                    parsedGroups[9],
                    parsedGroups[10],
                    parsedGroups[11],
                };
                if (!potentialCodes.ContainsKey(op))
                {
                    potentialCodes[op] = new List<string>(TimeTravellingDevice.OpCodes);
                }

                var matchingOpcodes = new List<string>();
                foreach (var opcode in TimeTravellingDevice.OpCodes)
                {
                    var result = TimeTravellingDevice.Execute(input, new Instruction
                    {
                        OpCode = opcode,
                        A = instruction.A,
                        B = instruction.B,
                        C = instruction.C,
                    });
                    if (Enumerable.SequenceEqual(result, output))
                    {
                        matchingOpcodes.Add(opcode);
                    }
                }
                potentialCodes[op] = potentialCodes[op].Intersect(matchingOpcodes).ToList();

                if (matchingOpcodes.Count >= 3)
                {
                    diffuseSamples += 1;
                }

                Debug.WriteLine($"Match #{matchNo} [{op}] has {potentialCodes[op].Count} possible mappings ({matchingOpcodes.Count} matches found for this sample)");
            } while ((match = match.NextMatch()).Success);

            return (diffuseSamples, potentialCodes);
        }
    }
}
