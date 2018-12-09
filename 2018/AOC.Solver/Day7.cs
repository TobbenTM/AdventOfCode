using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;

namespace AOC.Solver
{
    public static class Day7
    {
        public static string SolvePart1(string[] input)
        {
            var graph = GraphNodeFactory.ParseGraph(input);

            // Eval loop
            var result = "";
            while (graph.Count > 0)
            {
                var current = graph.OrderBy(n => n.Id).Where(n => n.Ready).First();
                graph.AddRange(current.Next);
                current.Done = true;
                result += current.Id;
                graph.RemoveAll(n => n.Done);
            }

            return result;
        }

        public static int SolvePart2(string[] input)
        {
            var graph = GraphNodeFactory.ParseGraph(input);

            // Eval loop
            var iteration = 0;
            var workersAvailable = 5;
            while (graph.Count > 0)
            {
                if (workersAvailable > 0) {
                    var readyTasks = graph
                        .OrderBy(n => n.Id)
                        .Where(n => n.Ready && !n.Working)
                        .Take(workersAvailable);
                    workersAvailable -= readyTasks.Count();
                    foreach (var task in readyTasks) {
                        task.Working = true;
                        task.StartedTimestamp = iteration;
                    }
                }

                iteration += 1;

                var finishedTasks = graph
                    .OrderBy(n => n.Id)
                    .Where(n => n.Working && n.StartedTimestamp + n.Duration == iteration);

                foreach (var task in finishedTasks) {
                    task.Done = true;
                    graph.AddRange(task.Next);
                    workersAvailable += 1;
                }

                graph.RemoveAll(n => n.Done);
            }

            return iteration;
        }

        private class GraphNode
        {
            internal char Id { get; set; }
            internal bool Done { get; set; }
            internal bool Working { get; set; }
            internal bool Ready => Deps.All(d => d.Done);
            internal int Duration => Id - 'A' + 61;
            internal int StartedTimestamp { get; set; }
            internal List<GraphNode> Deps { get; set; }
            internal List<GraphNode> Next { get; set; }
        }

        private class GraphNodeFactory
        {
            private readonly List<GraphNode> _cache;
            private readonly Dictionary<char, (char[] deps, char[] next)> _steps;

            internal GraphNodeFactory(Dictionary<char, (char[] deps, char[] next)> steps)
            {
                _cache = new List<GraphNode>();
                _steps = steps;
            }

            internal GraphNode Create(char id)
            {
                var node = _cache.FirstOrDefault(n => n.Id == id);
                var step = _steps.First(kv => kv.Key == id);
                if (node == null)
                {
                    node = new GraphNode{ Id = id };
                    _cache.Add(node);
                }
                // var children = step.Value.next.Concat(step.Value.deps).Distinct();
                foreach (var child in step.Value.next)
                {
                    // We need this in cache
                    Create(child);
                }
                return node;
            }

            internal static List<GraphNode> ParseGraph(string[] input)
            {
                var graph = new List<GraphNode>();
                var steps = new Dictionary<char, (char[] deps, char[] next)>();

                // Parse input
                var re = new Regex("Step (\\w) must be finished before step (\\w) can begin.");
                foreach (var instruction in input)
                {
                    var match = re.Match(instruction);
                    if (!match.Success) throw new ArgumentException($"Could not evaluate instruction: {instruction}");
                    if (match.Groups.Count != 3) throw new ArgumentException($"Could not parse instruction: {instruction}");
                    var dep = char.Parse(match.Groups[1].Value);
                    var task = char.Parse(match.Groups[2].Value);

                    // Going task -> deps
                    if (!steps.ContainsKey(task))
                    {
                        steps[task] = (new char[0], new char[0]);
                    }
                    steps[task] = (steps[task].deps.Concat(new[] { dep }).ToArray(), steps[task].next);

                    // Going deps -> tasks
                    if (!steps.ContainsKey(dep))
                    {
                        steps[dep] = (new char[0], new char[0]);
                    }
                    steps[dep] = (steps[dep].deps, steps[dep].next.Concat(new[] { task }).ToArray());

                }

                // Unflatten
                var factory = new GraphNodeFactory(steps);
                foreach (var kv in steps.Where(kv => kv.Value.deps.Length == 0))
                {
                    graph.Add(factory.Create(kv.Key));
                }
                factory.CreateLinks();

                return graph;
            }

            private void CreateLinks()
            {
                foreach (var node in _cache) {
                    node.Deps = _steps[node.Id].deps.Select(v => Create(v)).ToList();
                    node.Next = _steps[node.Id].next.Select(v => Create(v)).ToList();
                }
            }
        }
    }
}
