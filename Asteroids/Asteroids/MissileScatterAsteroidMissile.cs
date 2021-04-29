using System;
using Raylib_cs;
using System.Numerics;

namespace Asteroids
{
    public class MissileScatterAsteroidMissile : MissileScatterAsteroid
    {
        private Color lightPink = new Color(255,179,217,255);
        public MissileScatterAsteroidMissile()
        {
            rectangle.width = rectangle.height = 200;

            centerOfRect = new Vector2(rectangle.width/2, rectangle.width/2);

            asteroidColor = lightPink;

            asteroidMoveSpeed = 0.3 * ButtonSeries.GetSelectedMultiplier(2);

            hp = worth = 800;

            followShip = random.Next(0, spaceshipList.Count);
        }

        protected override void CollisionWithLine(int asteroidIndex)
        {
            for (int index = lazerList.Count - 1; index > -1; index--)
            {
                // om skott krockar med astroid
                if (Raylib.CheckCollisionCircleRec(asteroidList[asteroidIndex].GetCirclePos, asteroidList[asteroidIndex].GetAsteroidHitboxSize, lazerList[index].GetRect))
                {
                    // - skott dmg && ta bort skott && + score för spaceship
                    asteroidList[asteroidIndex].Hp -= lazerList[index].GetDamage; 
                    Spaceship.AddToScore(lazerList[index].GetID, lazerList[index].GetDamage);
                    Lazer.RemoceInstanceOfLine(index);

                    // om hp efter -dmg >=0 ta bort astroid också
                    if (asteroidList[asteroidIndex].Hp <= 0)    
                    {
                        for (int i = 0; i < 3 * ButtonSeries.GetSelectedMultiplier(2); i++)
                        {
                            ScatterAsteroidSubMissile scatterAsteroidSubMissile = new ScatterAsteroidSubMissile(asteroidList[asteroidIndex].GetCirclePos, Color.PINK, 100);   
                        }

                        asteroidList.Remove(asteroidList[asteroidIndex]);
                    }
                }
            }            
        }
        
    }
}