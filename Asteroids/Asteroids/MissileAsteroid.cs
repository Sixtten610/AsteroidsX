using System;
using Raylib_cs;
using System.Numerics;
using System.Collections.Generic;

namespace Asteroids
{
    public class MissileAsteroid : Asteroid
    {
        protected List<Spaceship> spaceshipList = Spaceship.SpaceshipList;
        protected static Random random = new Random();
        protected int followShip;

        public MissileAsteroid()
        {
            rectangle.width = rectangle.height = 70;

            centerOfRect = new Vector2(rectangle.width/2, rectangle.width/2);

            asteroidColor = Color.DARKGRAY;

            asteroidMoveSpeed = 1 * ButtonSeries.GetSelectedMultiplier(2);

            hp = worth = 200;

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

        protected override void Draw()
        {
            Raylib.DrawRectanglePro(rectangle, centerOfRect, randDegree, asteroidColor);

            Raylib.DrawText(this.hp.ToString(), (int)circlePos.X - 20, (int)circlePos.Y - 10, 28, Color.BLACK);
        }
    }
}
