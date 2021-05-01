using System;
using Raylib_cs;

namespace Asteroids
{
    public class SniperSpaceship : RegularSpaceship
    {
        private int cooldownSet;
        private int cooldown;
        public SniperSpaceship(int id, KeyboardKey up, KeyboardKey down, KeyboardKey left, KeyboardKey right, KeyboardKey rotateLeft, KeyboardKey rotateRight, KeyboardKey shoot, int cooldown) : base(id, up, down, left, right, rotateLeft, rotateRight, shoot)
        {
            this.spaceshipSize = 50;
            this.cooldown = cooldownSet = cooldown;
            this.damage = 400;
        }

        public override bool Shoot()
        {
            if (Raylib.IsKeyDown(keyInput[6]) && cooldown <= 0)
            {
                cooldown = cooldownSet;
                return true;
            }
            else
            {
                cooldown--;
                return false;
            }
        }
    }
}
