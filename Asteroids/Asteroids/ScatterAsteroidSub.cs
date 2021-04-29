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
            System.Console.WriteLine(location.X);
            System.Console.WriteLine(location.Y);

            asteroidMoveSpeed = 3;

            asteroidColor = color;

            OriginX = location.X;
            OriginY = location.Y;
        }
    }
}
