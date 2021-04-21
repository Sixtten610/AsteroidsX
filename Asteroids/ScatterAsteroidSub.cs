using System;
using Raylib_cs;
using System.Numerics;
using System.Collections.Generic;

namespace Asteroids
{
    public class ScatterAsteroidSub : Asteroid
    {
        private Vector2 spawnLocation;
        public ScatterAsteroidSub(Vector2 location)
        {
            spawnLocation = location;

            asteroidColor = Color.PINK;
        }

        protected override void SpawnLocation()
        {
            OriginX = spawnLocation.X;
            OriginY = spawnLocation.Y;
        }
    }
}
