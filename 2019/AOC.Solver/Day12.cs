using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace AOC.Solver
{
    public static class Day12
    {
        private class Moon
        {
            public int X { get; set; }

            public int Y { get; set; }

            public int Z { get; set; }

            public int VelocityX { get; set; }

            public int VelocityY { get; set; }

            public int VelocityZ { get; set; }

            public int PotentialEnergy => Math.Abs(X) + Math.Abs(Y) + Math.Abs(Z);

            public int KineticEnergy => Math.Abs(VelocityX) + Math.Abs(VelocityY) + Math.Abs(VelocityZ);

            public int TotalEnergy => PotentialEnergy * KineticEnergy;

            public Moon(string input)
            {
                var numbers = input.Split('=').Skip(1).Select(g => g.Split(',', '>')[0]).Select(int.Parse).ToArray();
                X = numbers[0];
                Y = numbers[1];
                Z = numbers[2];
            }

            public void EvaluateGravity(Moon other)
            {
                if (X > other.X)
                {
                    VelocityX -= 1;
                    other.VelocityX += 1;
                }
                else if (X < other.X)
                {
                    VelocityX += 1;
                    other.VelocityX -= 1;
                }
                if (Y > other.Y)
                {
                    VelocityY -= 1;
                    other.VelocityY += 1;
                }
                else if (Y < other.Y)
                {
                    VelocityY += 1;
                    other.VelocityY -= 1;
                }
                if (Z > other.Z)
                {
                    VelocityZ -= 1;
                    other.VelocityZ += 1;
                }
                else if (Z < other.Z)
                {
                    VelocityZ += 1;
                    other.VelocityZ -= 1;
                }
            }

            public void ApplyVelocity()
            {
                X += VelocityX;
                Y += VelocityY;
                Z += VelocityZ;
            }
        }

        public static int SolvePart1(string[] input, int time)
        {
            var moons = input.Select(s => new Moon(s)).ToArray();

            for (var i = 0; i < time; i++)
            {
                UpdateGravityForMoons(moons);

                foreach (var moon in moons)
                {
                    moon.ApplyVelocity();
                }
            }

            return moons.Aggregate(0, (acc, moon) => acc + moon.TotalEnergy);
        }

        public static async Task<long> SolvePart2(string[] input)
        {
            var cycles = await Task.WhenAll(
                FindPlaneCycle(input.Select(s => new Moon(s)).ToArray(), moon => string.Join("+", moon.X, moon.VelocityX)),
                FindPlaneCycle(input.Select(s => new Moon(s)).ToArray(), moon => string.Join("+", moon.Y, moon.VelocityY)),
                FindPlaneCycle(input.Select(s => new Moon(s)).ToArray(), moon => string.Join("+", moon.Z, moon.VelocityZ)));

            return LCF(cycles);
        }

        private static Task<long> FindPlaneCycle(Moon[] moons, Func<Moon, string> selector)
        {
            return Task.Factory.StartNew(() =>
            {
                var time = 0L;
                var history = new HashSet<string>();
                while (true)
                {
                    UpdateGravityForMoons(moons);

                    foreach (var moon in moons)
                    {
                        moon.ApplyVelocity();
                    }

                    var positions = string.Join(",", moons.Select(selector));
                    if (history.Contains(positions))
                    {
                        return time;
                    }
                    history.Add(positions);

                    time += 1;
                }
            });
        }

        private static void UpdateGravityForMoons(Moon[] moons)
        {
            moons[0].EvaluateGravity(moons[1]);
            moons[0].EvaluateGravity(moons[2]);
            moons[0].EvaluateGravity(moons[3]);

            moons[1].EvaluateGravity(moons[2]);
            moons[1].EvaluateGravity(moons[3]);

            moons[2].EvaluateGravity(moons[3]);
        }

        private static long GCD(long a, long b)
        {
            while (a != 0 && b != 0)
            {
                if (a > b)
                    a %= b;
                else
                    b %= a;
            }

            return a == 0 ? b : a;
        }

        private static long LCF(params long[] args)
        {
            return args.Aggregate((a, b) => (a * b) / GCD(a, b));
        }
    }
}
