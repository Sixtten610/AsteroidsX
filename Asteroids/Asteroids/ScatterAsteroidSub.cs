using System;
using Raylib_cs;
using System.Numerics;
using System.Collections.Generic;

namespace Asteroids
{
    public class ScatterAsteroidSub : Asteroid
    {
        public ScatterAsteroidSub(Vector2 location, Color color)
        {
            asteroidMoveSpeed = 3;

            asteroidColor = color;

            originX = location.X;
            originY = location.Y;
        }
    }
}
