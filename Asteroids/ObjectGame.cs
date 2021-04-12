using System.Collections.Generic;
using System;
using Raylib_cs;

namespace Asteroids
{
    public class ObjectGame
    {

        public virtual void Draw()
        {
            Spaceship.DrawAll();
        }
        public virtual void Update()
        {
            Spaceship.UpdateAll();
        }
    }
}
