using System.Collections.Generic;
using System;
using Raylib_cs;

namespace Asteroids
{
    public class ObjectGame
    {
        protected bool isGameOn = true;

        public static void Clear()
        {
            Lazer.LazerList.Clear();
            Asteroid.AsteroidList.Clear();
            Spaceship.SpaceshipList.Clear();
        }

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
