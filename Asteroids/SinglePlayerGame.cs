using System;
using Raylib_cs;
using System.Collections.Generic;

namespace Asteroids
{
    public class SinglePlayerGame : ObjectGame
    {
        RegularSpaceship regularSpaceship;
        public SinglePlayerGame()
        {
            regularSpaceship = new RegularSpaceship(KeyboardKey.KEY_W, KeyboardKey.KEY_S, KeyboardKey.KEY_A, KeyboardKey.KEY_D, KeyboardKey.KEY_LEFT, KeyboardKey.KEY_RIGHT, KeyboardKey.KEY_SPACE);
        }

        public override void Update()
        {
            base.Update();

            if (regularSpaceship.Shoot())
            {

            }
        }
    }
}
