using System;
using Raylib_cs;
using System.Numerics;
using System.Collections.Generic;

namespace Asteroids
{
    public class ScatterAsteroidSub : Asteroid
    {
        public ScatterAsteroidSub()
        {
            centerOfRect = new Vector2(rectangle.width/2, rectangle.width/2);

            asteroidColor = Color.PINK;

            SpawnLocation();

            asteroidList.Add(this);
        }

        protected override void SpawnLocation()
        {
            OriginX = 0;
            OriginY = 0;
        }
    }
}
