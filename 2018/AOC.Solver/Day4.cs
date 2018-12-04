using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace AOC.Solver
{
    public static class Day4
    {
        public static int SolvePart1(string[] input)
        {
            var guards = ProcessEvents(input);

            var heaviestSleeper = guards.OrderByDescending(g => g.SleepTime.Sum(t => t.Ticks)).First();
            var sleepiestMinute = heaviestSleeper.SleepStats.ToList().IndexOf(heaviestSleeper.SleepStats.Max());

            return heaviestSleeper.GuardId * sleepiestMinute;
        }

        public static int SolvePart2(string[] input)
        {
            var guards = ProcessEvents(input);

            var recurringSleeper = guards.OrderByDescending(g => g.SleepStats.Max()).First();
            var sleepiestMinute = recurringSleeper.SleepStats.ToList().IndexOf(recurringSleeper.SleepStats.Max());
            
            return recurringSleeper.GuardId * sleepiestMinute;
        }

        private static IEnumerable<Guard> ProcessEvents(string[] input)
        {
            var events = input
                .Select(GuardEvent.ParseEvent)
                .OrderBy(e => e.Timestamp)
                .EnrichEvents();

            var guards = new Dictionary<int, Guard>();

            DateTime fellAsleep = DateTime.MinValue;
            foreach (var evnt in events)
            {
                switch (evnt.EventType)
                {
                    case GuardEventType.StartsShift:
                        if (!guards.ContainsKey(evnt.GuardId))
                        {
                            guards.Add(evnt.GuardId, new Guard(evnt));
                        }
                        break;
                    case GuardEventType.FallsAsleep:
                        fellAsleep = evnt.Timestamp;
                        break;
                    case GuardEventType.WakesUp:
                        var guard = guards[evnt.GuardId];
                        guard.RecordSleep(fellAsleep, evnt.Timestamp);
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }

            return guards.Values;
        }

        public enum GuardEventType
        {
            StartsShift,
            FallsAsleep,
            WakesUp,
        }

        public class Guard
        {
            public Guard(GuardEvent evnt)
            {
                GuardId = evnt.GuardId;
            }

            public int GuardId { get; set; }
            public List<TimeSpan> SleepTime { get; set; } = new List<TimeSpan>();
            public int[] SleepStats { get; set; } = new int[60];

            public void RecordSleep(DateTime fellAsleep, DateTime wokeUp)
            {
                SleepTime.Add(wokeUp - fellAsleep);
                for (var i = fellAsleep.Minute; i < wokeUp.Minute; i++)
                {
                    SleepStats[i] += 1;
                }
            }
        }

        public struct GuardEvent
        {
            public GuardEventType EventType { get; set; }
            public DateTime Timestamp { get; set; }
            public int GuardId { get; set; }

            public static GuardEvent ParseEvent(string evnt)
            {
                var rx = new Regex("\\[([\\d-:\\s]+)\\] (.*)");
                var match = rx.Match(evnt);
                if (!match.Success) throw new ArgumentException($"Could not parse event '{evnt}'!");
                if (match.Groups.Count != 3) throw new ArgumentException($"Could not parse event '{evnt}'!");
                var description = match.Groups[2].Value;

                GuardEventType type;
                int guardId = -1;

                if (description.Equals("falls asleep"))
                {
                    type = GuardEventType.FallsAsleep;
                }
                else if (description.Equals("wakes up"))
                {
                    type = GuardEventType.WakesUp;
                }
                else
                {
                    type = GuardEventType.StartsShift;
                    var idRx = new Regex("Guard #(\\d+) begins shift");
                    guardId = Int32.Parse(idRx.Match(description).Groups[1].Value);
                }
                return new GuardEvent
                {
                    EventType = type,
                    Timestamp = DateTime.Parse(match.Groups[1].Value),
                    GuardId = guardId,
                };
            }
        }

        /// <summary>
        /// Will enrich all events with the correct guard id
        /// </summary>
        private static IEnumerable<GuardEvent> EnrichEvents(this IEnumerable<GuardEvent> events)
        {
            var currentId = -1;
            foreach (var evnt in events)
            {
                if (evnt.GuardId > -1)
                {
                    currentId = evnt.GuardId;
                    yield return evnt;
                }
                else
                {
                    var mutableEvent = evnt;
                    mutableEvent.GuardId = currentId;
                    yield return mutableEvent;
                }
            }
        }
    }
}
