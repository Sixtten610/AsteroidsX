using System;
using Raylib_cs;
using System.Numerics;
using System.Collections.Generic;

namespace Asteroids
{
    public class ScatterAsteroidSub : Asteroid
    {
        private Vector2 spawnLocation;
        public ScatterAsteroidSub(Vector2 spawnLocation)
        {
            this.spawnLocation = spawnLocation;

            centerOfRect = new Vector2(rectangle.width/2, rectangle.width/2);

            asteroidColor = Color.PINK;

            SpawnLocation();

            asteroidList.Add(this);
        }

        protected override void SpawnLocation()
        {
            OriginX = spawnLocation.X;
            OriginY = spawnLocation.Y;
        }
    }
}
