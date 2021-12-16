using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AOC.Solver
{
    public static class Day16
    {
        public static int SolvePart1(string input)
        {
            var stream = new Queue<char>(input.SelectMany(ch => Convert.ToString(Convert.ToInt32(ch.ToString(), 16), 2).PadLeft(4, '0').ToCharArray()));
            var root = ReadPacket(stream);
            var versionTotal = root.Version;

            if (root.Payload is PacketOperatorPayload rootOperatorPayload)
            {
                var packagesToTraverse = new Stack<Packet>(rootOperatorPayload.SubPackets);

                while (packagesToTraverse.TryPop(out var packet))
                {
                    versionTotal += packet.Version;
                    if (packet.Payload is PacketOperatorPayload operatorPayload)
                    {
                        foreach (var subPacket in operatorPayload.SubPackets)
                        {
                            packagesToTraverse.Push(subPacket);
                        }
                    }
                }
            }

            return versionTotal;
        }

        public static long SolvePart2(string input)
        {
            var stream = new Queue<char>(input.SelectMany(ch => Convert.ToString(Convert.ToInt32(ch.ToString(), 16), 2).PadLeft(4, '0').ToCharArray()));

            var root = ReadPacket(stream);
            return EvaluatePacket(root);
        }

        private static long EvaluatePacket(Packet packet)
        {
            if (packet.Payload is PacketLiteralPayload literalPayload)
            {
                return literalPayload.Value;
            }

            if (packet.Payload is not PacketOperatorPayload operatorPayload) throw new InvalidCastException("Payload malformed");
            return packet.Type switch
            {
                0 => operatorPayload.SubPackets.Sum(EvaluatePacket),
                1 => operatorPayload.SubPackets.Aggregate(1L, (product, child) => product * EvaluatePacket(child)),
                2 => operatorPayload.SubPackets.Min(EvaluatePacket),
                3 => operatorPayload.SubPackets.Max(EvaluatePacket),
                5 => EvaluatePacket(operatorPayload.SubPackets[0]) > EvaluatePacket(operatorPayload.SubPackets[1]) ? 1L : 0L,
                6 => EvaluatePacket(operatorPayload.SubPackets[0]) < EvaluatePacket(operatorPayload.SubPackets[1]) ? 1L : 0L,
                7 => EvaluatePacket(operatorPayload.SubPackets[0]) == EvaluatePacket(operatorPayload.SubPackets[1]) ? 1L : 0L,
                _ => throw new ArgumentOutOfRangeException(nameof(packet.Type))
            };
        }

        private static int DequeueInt(this Queue<char> queue, int bitSize)
        {
            var stringBuilder = new StringBuilder();
            for (int i = 0; i < bitSize && queue.Count > 0; i++)
            {
                stringBuilder.Append(queue.Dequeue());
            }
            return Convert.ToInt32(stringBuilder.ToString(), 2);
        }

        public static Packet ReadPacket(Queue<char> stream)
        {
            var version = stream.DequeueInt(3);
            var type = stream.DequeueInt(3);

            if (type == 4)
            {
                int groupHeader;
                long value = 0L;
                do
                {
                    groupHeader = stream.DequeueInt(1);
                    var group = stream.DequeueInt(4);
                    value <<= 4;
                    value += group;
                } while (groupHeader != 0);

                return new Packet(version, type, new PacketLiteralPayload(value));
            }

            var lengthTypeId = stream.DequeueInt(1);
            var subPackets = new List<Packet>();

            if (lengthTypeId == 0)
            {
                var length = stream.DequeueInt(15);
                var expectedEnd = stream.Count - length;
                while (expectedEnd < stream.Count)
                {
                    subPackets.Add(ReadPacket(stream));
                }
            }
            else
            {
                var length = stream.DequeueInt(11);
                for (var i = 0; i < length; i++)
                {
                    subPackets.Add(ReadPacket(stream));
                }
            }

            return new Packet(version, type, new PacketOperatorPayload(subPackets.ToArray()));
        }

        public interface IPacketPayload {}

        public record Packet(int Version, int Type, IPacketPayload Payload);

        public record PacketLiteralPayload(long Value) : IPacketPayload;

        public record PacketOperatorPayload(Packet[] SubPackets) : IPacketPayload;
    }
}
