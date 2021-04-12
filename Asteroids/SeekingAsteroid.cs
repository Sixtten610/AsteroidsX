using System.Collections.Generic;
using System;
using Raylib_cs;
using System.Numerics;

namespace Asteroids
{
    public class SeekingAsteroid : Asteroid
    {
        protected static Random random = new Random();
        protected float speed;
        int followShip;
        protected override void AsteroidSettings()
        {
            
            rectangle.width = rectangle.height = 70;

            centerOfRect = new Vector2(rectangle.width/2, rectangle.width/2);

            asteroidColor = Color.GRAY;

            hp = 200;

            speed = 1;

            followShip = random.Next(0, spaceshipList.Count);
        }
        protected List<Spaceship> spaceshipList = Spaceship.GetSpaceshipList;
        protected override void Update()
        {
            for (int index = spaceshipList.Count - 1; index > -1; index--)
            {
                if (followShip == index)
                {
                    System.Console.WriteLine("OriginX " + OriginX);
                    System.Console.WriteLine("OriginY " + OriginY);

                    if (OriginX > spaceshipList[index].GetSpaceshipX)
                    {
                        OriginX -= speed;
                    }
                    else if (OriginX < spaceshipList[index].GetSpaceshipX)
                    {
                        OriginX += speed;
                    }

                    if (OriginY > spaceshipList[index].GetSpaceshipY)
                    {
                        OriginY -= speed;
                    }
                    else if (OriginY < spaceshipList[index].GetSpaceshipY)
                    {
                        OriginY += speed;
                    }

                    rectangle.x = OriginX;
                    this.x = OriginX;
                    rectangle.y = OriginY;
                    this.y = OriginY;

                }
            }
        }
    }
}
