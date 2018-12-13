using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AOC.Solver
{
    public static class Day12
    {
        public class PlantGeneration
        {
            private readonly long _generation;
            private readonly Dictionary<long, char> _state;
            private readonly Dictionary<string, char> _rules;

            public PlantGeneration(char[] initialState, Dictionary<string, char> rules)
            {
                _generation = 0;
                _rules = rules;
                _state = new Dictionary<long, char>(initialState.Select((c, i) => new KeyValuePair<long, char>(i, c)));
            }

            public PlantGeneration(long generation, Dictionary<long, char> state, Dictionary<string, char> rules)
            {
                _generation = generation;
                _state = state;
                _rules = rules;
            }

            public long SumPlants => _state.Sum(kv => kv.Value == '#' ? kv.Key : 0);

            public long Generation => _generation;

            public PlantGeneration Evolve()
            {
                var sw = Stopwatch.StartNew();
                var newGeneration = new Dictionary<long, char>();

                // We need to start 2 spaces to the left of the first plant and to the right of the last
                var startIndex = _state.First(kv => kv.Value == '#').Key - 2;
                var endIndex = _state.Last(kv => kv.Value == '#').Key + 2;

                var t1 = sw.ElapsedMilliseconds;

                for (var i = startIndex; i < endIndex; i++)
                {
                    var evolvedState = _rules[BuildArea(i, _state)];
                    newGeneration[i] = evolvedState;
                }

                var t2 = sw.ElapsedMilliseconds;

                return new PlantGeneration(_generation + 1, newGeneration, _rules);
            }

            private string BuildArea(long index, Dictionary<long, char> state)
            {
                var result = "";
                for (var i = index-2; i <= index + 2; i++)
                {
                    if (state.ContainsKey(i))
                    {
                        result += state[i];
                    }
                    else
                    {
                        result += ".";
                    }
                }
                return result;
            }
        }
    }
}
