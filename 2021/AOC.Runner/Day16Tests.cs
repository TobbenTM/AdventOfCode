using System;
using System.Collections.Generic;
using AOC.Solver;
using System.IO;
using System.Linq;
using Xunit;

namespace AOC.Runner
{
    public class Day16Tests
    {
        private readonly string _input;

        public Day16Tests()
        {
            var lines = File.ReadAllLines("./Day16.input");
            _input = lines.Single();
        }

        [Fact]
        public void Part1()
        {
            var result = Day16.SolvePart1(_input);
            Assert.Equal(895, result);
        }

        [Theory]
        [InlineData("8A004A801A8002F478", 16)]
        [InlineData("620080001611562C8802118E34", 12)]
        [InlineData("C0015000016115A2E0802F182340", 23)]
        [InlineData("A0016C880162017C3686B18A3D4780", 31)]
        public void Part1_WithExampleInput_ReturnsExpectedAnswer(string input, int expectedOutput)
        {
            var result = Day16.SolvePart1(input);
            Assert.Equal(expectedOutput, result);
        }

        [Fact]
        public void ReadPacket_WithExample1_HasTwoSubPackets()
        {
            var input = "38006F45291200";
            var stream = new Queue<char>(input.SelectMany(ch => Convert.ToString(Convert.ToInt32(ch.ToString(), 16), 2).PadLeft(4, '0').ToCharArray()));
            var result = Day16.ReadPacket(stream);
            Assert.IsType<Day16.PacketOperatorPayload>(result.Payload);
            var payload = result.Payload as Day16.PacketOperatorPayload;
            Assert.NotNull(payload);
            Assert.Equal(2, payload.SubPackets.Length);
            Assert.Equal(10, (payload.SubPackets[0].Payload as Day16.PacketLiteralPayload)!.Value);
            Assert.Equal(20, (payload.SubPackets[1].Payload as Day16.PacketLiteralPayload)!.Value);
        }

        [Fact]
        public void ReadPacket_WithExample2_HasThreeSubPackets()
        {
            var input = "EE00D40C823060";
            var stream = new Queue<char>(input.SelectMany(ch => Convert.ToString(Convert.ToInt32(ch.ToString(), 16), 2).PadLeft(4, '0').ToCharArray()));
            var result = Day16.ReadPacket(stream);
            Assert.IsType<Day16.PacketOperatorPayload>(result.Payload);
            var payload = result.Payload as Day16.PacketOperatorPayload;
            Assert.NotNull(payload);
            Assert.Equal(3, payload.SubPackets.Length);
            Assert.Equal(1, (payload.SubPackets[0].Payload as Day16.PacketLiteralPayload)!.Value);
            Assert.Equal(2, (payload.SubPackets[1].Payload as Day16.PacketLiteralPayload)!.Value);
            Assert.Equal(3, (payload.SubPackets[2].Payload as Day16.PacketLiteralPayload)!.Value);
        }

        [Fact]
        public void Part2()
        {
            var result = Day16.SolvePart2(_input);
            Assert.Equal(1148595959144, result);
        }

        [Theory]
        [InlineData("C200B40A82", 3)]
        [InlineData("04005AC33890", 54)]
        [InlineData("880086C3E88112", 7)]
        [InlineData("CE00C43D881120", 9)]
        [InlineData("D8005AC2A8F0", 1)]
        [InlineData("F600BC2D8F", 0)]
        [InlineData("9C005AC2F8F0", 0)]
        [InlineData("9C0141080250320F1802104A08", 1)]
        public void Part2_WithExampleInput_ReturnsExpectedAnswer(string input, int expectedOutput)
        {
            var result = Day16.SolvePart2(input);
            Assert.Equal(expectedOutput, result);
        }
    }
}
