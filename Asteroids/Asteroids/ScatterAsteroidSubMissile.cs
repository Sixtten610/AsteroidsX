using System;
using Raylib_cs;
using System.Numerics;
using System.Collections.Generic;

namespace Asteroids
{
    public class ScatterAsteroidSubMissile : ScatterAsteroidSub
    {
        private List<Spaceship> spaceshipList = Spaceship.SpaceshipList;
        protected Random random = new Random();
        private int followShip;

        public ScatterAsteroidSubMissile(Vector2 location, Color color, int hp) : base (location, color)
        {
            asteroidMoveSpeed = 0.5 * ButtonSeries.GetSelectedMultiplier(2);

            this.hp = hp;

            asteroidColor = color;

            originX = location.X;
            originY = location.Y;

            followShip = random.Next(0, spaceshipList.Count);
        }
        protected override void Update()
        {
            for (int index = spaceshipList.Count - 1; index > -1; index--)
            {
                if (followShip == index)
                {

                    if (originX > spaceshipList[index].GetSpaceshipX)
                    {
                        originX -= (float)asteroidMoveSpeed;
                    }
                    else if (originX < spaceshipList[index].GetSpaceshipX)
                    {
                        originX += (float)asteroidMoveSpeed;
                    }

                    if (originY > spaceshipList[index].GetSpaceshipY)
                    {
                        originY -= (float)asteroidMoveSpeed;
                    }
                    else if (originY < spaceshipList[index].GetSpaceshipY)
                    {
                        originY += (float)asteroidMoveSpeed;
                    }

                    rectangle.x = originX;
                    this.x = originX;
                    rectangle.y = originY;
                    this.y = originY;
                    circlePos = new Vector2((float)x,(float)y);

                }
                
            }
        }
    }
}
