using System.Collections.Generic;
using System;
using Raylib_cs;

namespace Asteroids
{
    public class ObjectGame
    {
        protected bool isGameOn = true;

        public virtual void Draw()
        {
            Spaceship.DrawAll();
            Lazer.DrawAll();
            Asteroid.DrawAll();
        }
        public virtual void Update()
        {
            Spaceship.UpdateAll();
            Lazer.UpdateAll();
            Asteroid.UpdateAll();
        }
    }
}
