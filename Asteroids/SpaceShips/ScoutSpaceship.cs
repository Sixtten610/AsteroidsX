using System;
using Raylib_cs;

namespace Asteroids
{
    public class ScoutSpaceship : Spaceship
    {
        public ScoutSpaceship(int id, KeyboardKey up, KeyboardKey down, KeyboardKey left, KeyboardKey right, KeyboardKey rotateLeft, KeyboardKey rotateRight, KeyboardKey shoot) : base(id)
        {
            keyInput = new KeyboardKey[7];

            keyInput[0] = up;
            keyInput[1] = down;
            keyInput[2] = left;
            keyInput[3] = right;
            keyInput[4] = rotateLeft;
            keyInput[5] = rotateRight;
            keyInput[6] = shoot;

            this.spaceshipSize = 30;
            this.rotationSpeed = 0.09;
            this.damage = 8;
            this.planeMoveSpeed = 3;

            spaceshipList.Add(this);
        }

        public override bool Shoot()
        {
            if (Raylib.IsKeyDown(keyInput[6]))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
