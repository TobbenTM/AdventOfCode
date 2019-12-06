using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AOC.Solver
{
    public static class Day06
    {
        public class Orbit
        {
            public string Id { get; set; }

            public Orbit Orbiting { get; set; }

            public List<Orbit> Orbitals { get; } = new List<Orbit>();
        }

        public static int SolvePart1(string[] input)
        {
            var map = BuildMap(input);

            var result = 0;
            foreach (var orbit in map.Values)
            {
                var currentOrbit = orbit.Orbiting;
                while (currentOrbit != null)
                {
                    currentOrbit = currentOrbit.Orbiting;
                    result += 1;
                }
            }
            return result;
        }

        public static async Task<int> SolvePart2(string[] input)
        {
            var map = BuildMap(input);

            var start = map["YOU"].Orbiting;
            var goal = map["SAN"].Orbiting;

            var pathFinders = new List<Task<int>>();
            var currentTransfers = 0;
            var currentOrbit = start;
            while (currentOrbit != null)
            {
                pathFinders.Add(FindPath(currentOrbit, goal, currentTransfers));
                currentOrbit = currentOrbit.Orbiting;
                currentTransfers += 1;
            }

            var results = await Task.WhenAll(pathFinders.ToArray());

            return results.Where(c => c > 0).Min();
        }

        public static async Task<int> FindPath(Orbit start, Orbit goal, int currentTransfers)
        {
            if (start == goal) return currentTransfers;
            if (start.Orbitals.Count == 0) return -1;
            var subtasks = start.Orbitals.Select(o => FindPath(o, goal, currentTransfers + 1));
            var results = await Task.WhenAll(subtasks.ToArray());
            var result = results.Where(c => c > 0).Select(i => (int?)i).Min();
            return result.HasValue ? result.Value : -1;
        }

        public static Dictionary<string, Orbit> BuildMap(string[] input)
        {
            var result = new Dictionary<string, Orbit>();

            foreach (var orbit in input)
            {
                var parent = orbit.Split(')')[0];
                var child = orbit.Split(')')[1];

                if (!result.TryGetValue(parent, out var parentObject))
                {
                    parentObject = new Orbit
                    {
                        Id = parent,
                    };
                    result.Add(parent, parentObject);
                }

                if (!result.TryGetValue(child, out var childObject))
                {
                    childObject = new Orbit
                    {
                        Id = child,
                    };
                    result.Add(child, childObject);
                }

                childObject.Orbiting = parentObject;
                parentObject.Orbitals.Add(childObject);
            }

            return result;
        }
    }
}
