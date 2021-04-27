using System;
using Raylib_cs;
using System.Numerics;
using System.Collections.Generic;

namespace Asteroids
{
    public class MissileAsteroid : Asteroid
    {
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

        protected List<Spaceship> spaceshipList = Spaceship.SpaceshipList;
        protected override void Update()
        {
            for (int index = spaceshipList.Count - 1; index > -1; index--)
            {
                if (followShip == index)
                {

                    if (OriginX > spaceshipList[index].GetSpaceshipX)
                    {
                        OriginX -= (float)asteroidMoveSpeed;
                    }
                    else if (OriginX < spaceshipList[index].GetSpaceshipX)
                    {
                        OriginX += (float)asteroidMoveSpeed;
                    }

                    if (OriginY > spaceshipList[index].GetSpaceshipY)
                    {
                        OriginY -= (float)asteroidMoveSpeed;
                    }
                    else if (OriginY < spaceshipList[index].GetSpaceshipY)
                    {
                        OriginY += (float)asteroidMoveSpeed;
                    }

                    rectangle.x = OriginX;
                    this.x = OriginX;
                    rectangle.y = OriginY;
                    this.y = OriginY;
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
