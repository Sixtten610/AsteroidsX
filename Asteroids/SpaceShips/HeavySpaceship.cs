using System;
using Raylib_cs;

namespace Asteroids
{
    public class HeavySpaceship : Spaceship
    {
        public HeavySpaceship(int id, KeyboardKey up, KeyboardKey down, KeyboardKey left, KeyboardKey right, KeyboardKey rotateLeft, KeyboardKey rotateRight, KeyboardKey shoot) : base(id)
        {
            keyInput = new KeyboardKey[7];

            keyInput[0] = up;
            keyInput[1] = down;
            keyInput[2] = left;
            keyInput[3] = right;
            keyInput[4] = rotateLeft;
            keyInput[5] = rotateRight;
            keyInput[6] = shoot;

            this.spaceshipSize = 60;
            this.rotationSpeed = 0.04;
            this.damage = 300;
            this.planeMoveSpeed = 1;
            
            spaceshipList.Add(this);
        }
    }
}
