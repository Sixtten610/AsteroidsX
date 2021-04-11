using System.Collections.Generic;
using System.Numerics;
using System;
using Raylib_cs;

namespace Asteroids
{
    
    public class RegularSpaceship : Spaceship
    {
        public RegularSpaceship(KeyboardKey up, KeyboardKey down, KeyboardKey left, KeyboardKey right, KeyboardKey rotateLeft, KeyboardKey rotateRight, KeyboardKey shoot)
        {
            keyInput = new KeyboardKey[7];

            keyInput[0] = up;
            keyInput[1] = down;
            keyInput[2] = left;
            keyInput[3] = right;
            keyInput[4] = rotateLeft;
            keyInput[5] = rotateRight;
            keyInput[6] = shoot;

            spaceshipList.Add(this);
        }
    }
}
