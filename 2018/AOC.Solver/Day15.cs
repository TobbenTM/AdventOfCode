using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AOC.Solver
{
    public static class Day15
    {
        public class Cave
        {
            private char[,] _map;
            private List<LivingEntity> _creatures;

            public int SumHitpoints => _creatures.Where(c => c.HP > 0).Sum(c => c.HP);

            public Cave(string[] input)
            {
                _map = new char[input[0].Length, input.Length];
                _creatures = new List<LivingEntity>();
                for (var y = 0; y < input.Length; y++)
                {
                    for (var x = 0; x < input[y].Length; x++)
                    {
                        switch (input[y][x])
                        {
                            case '#':
                            case '.':
                                _map[x, y] = input[y][x];
                                break;
                            case 'G':
                                _map[x, y] = '.';
                                _creatures.Add(new Goblin
                                {
                                    X = x,
                                    Y = y,
                                });
                                break;
                            case 'E':
                                _map[x, y] = '.';
                                _creatures.Add(new Elf
                                {
                                    X = x,
                                    Y = y,
                                });
                                break;
                            default: throw new ArgumentOutOfRangeException();
                        }
                    }
                }
            }

            public string[] GetState()
            {
                var result = new List<string>();
                for (var y = 0; y < _map.GetLength(1); y++)
                {
                    var row = "";
                    for (var x = 0; x < _map.GetLength(0); x++)
                    {
                        row += _creatures
                            .Where(c => c.HP > 0)
                            .FirstOrDefault(c => c.X == x && c.Y == y)?.ToChar() ?? _map[x, y];
                    }
                    result.Add(row);
                }
                return result.ToArray();
            }

            private void BuildDistanceMap(int x, int y, int[,] distanceMap, int distance = 0)
            {
                var actions = new List<Action>();

                if (distance > 0 && _creatures.Any(c => c.HP > 0 && c.X == x && c.Y == y)) return;

                distanceMap[x, y] = distance;

                distance += 1;
                // Up
                if (y > 0 && _map[x, y - 1] == '.' && (distanceMap[x, y - 1] == 0 || distanceMap[x, y - 1] > distance))
                {
                    actions.Add(() => BuildDistanceMap(x, y - 1, distanceMap, distance));
                }
                // Down
                if (y < _map.GetLength(1) - 1 && _map[x, y + 1] == '.' && (distanceMap[x, y + 1] == 0 || distanceMap[x, y + 1] > distance))
                {
                    actions.Add(() => BuildDistanceMap(x, y + 1, distanceMap, distance));
                }
                // Left
                if (x > 0 && _map[x - 1, y] == '.' && (distanceMap[x - 1, y] == 0 || distanceMap[x - 1, y] > distance))
                {
                    actions.Add(() => BuildDistanceMap(x - 1, y, distanceMap, distance));
                }
                // Right
                if (x < _map.GetLength(0) - 1 && _map[x + 1, y] == '.' && (distanceMap[x + 1, y] == 0 || distanceMap[x + 1, y] > distance))
                {
                    actions.Add(() => BuildDistanceMap(x + 1, y, distanceMap, distance));
                }

                foreach (var action in actions)
                {
                    action.Invoke();
                }
            }

            public bool Act(bool allowAttacks = true)
            {
                var orderedCreatures = _creatures.OrderBy(c => c.Y).ThenBy(c => c.X).ToList();

                foreach (var creature in orderedCreatures)
                {
                    if (creature.HP <= 0) continue;

                    var distanceMap = new int[_map.GetLength(0), _map.GetLength(1)];
                    if (creature is Goblin)
                    {
                        foreach (var elf in _creatures.OfType<Elf>())
                        {
                            BuildDistanceMap(elf.X, elf.Y, distanceMap);
                        }
                    }
                    else
                    {
                        foreach (var goblin in _creatures.OfType<Goblin>())
                        {
                            BuildDistanceMap(goblin.X, goblin.Y, distanceMap);
                        }
                    }
                    if (creature.Act(_map, _creatures, distanceMap, allowAttacks))
                    {
                        // End
                        return true;
                    }
                }

                Debug.WriteLine("Post-act map: ");
                var state = GetState();
                foreach (var row in state)
                {
                    Debug.WriteLine(row);
                }
                foreach (var creature in _creatures.OrderBy(c => c.Y).ThenBy(c => c.Y))
                {
                    Debug.WriteLine($"Creature at {creature.X},{creature.Y} has HP: {creature.HP}.");
                }

                _creatures.RemoveAll(c => c.HP <= 0);

                return false;
            }
        }

        public abstract class Entity
        {
            public int X { get; set; }
            public int Y { get; set; }
        }

        public abstract class LivingEntity : Entity
        {
            public int HP { get; set; } = 200;
            public int AttackPower { get; set; } = 3;

            private void Attack(List<LivingEntity> creatures)
            {
                var adjacentCreatures = creatures
                    .Where(c => c.HP > 0 && c.GetType() != this.GetType() && this.IsAdjacent(c))
                    .OrderBy(c => c.Y)
                    .ThenBy(c => c.X);
                var targetCreature = adjacentCreatures.First(c => c.HP == adjacentCreatures.Min(x => x.HP));
                targetCreature.HP -= AttackPower;
            }

            public bool Act(char[,] map, List<LivingEntity> creatures, int[,] distanceMap, bool allowAttacks = true)
            {
                if (!HasEnemies(creatures))
                {
                    // Finished
                    return true;
                }

                if (CanAttack(creatures))
                {
                    if (allowAttacks)
                    {
                        // Attack
                        Attack(creatures);
                    }
                }
                else
                {
                    // Move
                    (int weight, (int x, int y) pos) bestDirection = (999, (X, Y));
                    // Eval Up
                    if (Y > 0 && distanceMap[X, Y - 1] != 0 && distanceMap[X, Y - 1] < bestDirection.weight)
                    {
                        bestDirection = (distanceMap[X, Y - 1], (X, Y - 1));
                    }
                    // Eval Left
                    if (X > 0 && distanceMap[X - 1, Y] != 0 && distanceMap[X - 1, Y] < bestDirection.weight)
                    {
                        bestDirection = (distanceMap[X - 1, Y], (X - 1, Y));
                    }
                    // Eval Right
                    if (X < distanceMap.GetLength(0) && distanceMap[X + 1, Y] != 0 && distanceMap[X + 1, Y] < bestDirection.weight)
                    {
                        bestDirection = (distanceMap[X + 1, Y], (X + 1, Y));
                    }
                    // Eval Down
                    if (Y < distanceMap.GetLength(1) && distanceMap[X, Y + 1] != 0 && distanceMap[X, Y + 1] < bestDirection.weight)
                    {
                        bestDirection = (distanceMap[X, Y + 1], (X, Y + 1));
                    }
                    X = bestDirection.pos.x;
                    Y = bestDirection.pos.y;

                    if (CanAttack(creatures))
                    {
                        if (allowAttacks)
                        {
                            // Attack
                            Attack(creatures);
                        }
                    }
                }

                return false;
            }

            public bool IsAdjacent(LivingEntity other)
            {
                return Math.Abs(this.X - other.X) == 1 && this.Y == other.Y
                    || this.X == other.X && Math.Abs(this.Y - other.Y) == 1;
            }

            public bool CanAttack(List<LivingEntity> creatures)
            {
                return creatures.Any(e => e.HP > 0 && e.GetType() != this.GetType() && this.IsAdjacent(e));
            }

            public abstract bool HasEnemies(List<LivingEntity> creatures);
            public abstract char ToChar();
        }

        public class Goblin : LivingEntity
        {
            public override bool HasEnemies(List<LivingEntity> creatures)
            {
                if (creatures.OfType<Elf>().Count(c => c.HP > 0) == 0)
                {
                    return false;
                }
                return true;
            }

            public override char ToChar()
            {
                return 'G';
            }
        }

        public class Elf : LivingEntity
        {
            public override bool HasEnemies(List<LivingEntity> creatures)
            {
                if (creatures.OfType<Goblin>().Count(c => c.HP > 0) == 0)
                {
                    return false;
                }
                return true;
            }

            public override char ToChar()
            {
                return 'E';
            }
        }
    }
}
