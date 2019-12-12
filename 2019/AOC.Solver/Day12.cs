using System;
using System.Collections.Generic;
using System.Linq;

namespace AOC.Solver
{
    public static class Day12
    {
        private class Moon
        {
            private readonly HashSet<(int x, int y, int z, int vx, int vy, int vz)> _history = new HashSet<(int x, int y, int z, int vx, int vy, int vz)>();

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
                _history.Add((X, Y, Z, 0, 0, 0));
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

            public void RecordPosition()
            {
                if (!HasBeenHereBefore())
                {
                    _history.Add((X, Y, Z, VelocityX, VelocityY, VelocityZ));
                }
            }

            public bool HasBeenHereBefore() => _history.Contains((X, Y, Z, VelocityX, VelocityY, VelocityZ));
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

        public static int SolvePart2(string[] input)
        {
            var moons = input.Select(s => new Moon(s)).ToArray();

            var time = 0;

            while (true)
            {
                UpdateGravityForMoons(moons);

                foreach (var moon in moons)
                {
                    moon.ApplyVelocity();
                }

                if (moons.All(moon => moon.HasBeenHereBefore()))
                {
                    return time;
                }

                foreach (var moon in moons)
                {
                    moon.RecordPosition();
                }

                time += 1;
            }
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
    }
}
