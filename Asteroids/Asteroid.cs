using System;
using Raylib_cs;
using System.Numerics;
using System.Collections.Generic;

namespace Asteroids
{
    public class Asteroid
    {
        protected static List<Asteroid> asteroidList = new List<Asteroid>();

        protected Rectangle rectangle = new Rectangle();

        Vector2 centerOfRect;
        static Random generator = new Random();

        float randDegree = generator.Next(0, 360);
        float OriginX;
        float OriginY;
        
        double x;
        double y;
        protected double asteroidMoveSpeed;
        protected int hp;

        Vector2 circlePos;
        protected Color asteroidColor;


        public Asteroid()
        {
            AsteroidSettings();
            
            SpawnLocation();

            asteroidList.Add(this);
        }
        
        protected virtual void AsteroidSettings()
        {
            rectangle.width = rectangle.height = 50;

            centerOfRect = new Vector2(rectangle.width/2, rectangle.width/2);

            asteroidColor = Color.WHITE;

            asteroidMoveSpeed = 10;

            hp = 100;
        }
        private void SpawnLocation()
        {
            int randomConst = generator.Next(0,4);
            switch (randomConst)
            {
                case 0:
                OriginX = generator.Next(-200, -100);
                OriginY = generator.Next(0, 1000);
                break;

                case 1:
                OriginX = generator.Next(1100, 1200);
                OriginY = generator.Next(0, 1000);
                break;
                
                case 2:
                OriginY = generator.Next(-200, -100);
                OriginX = generator.Next(0, 1000);
                break;

                case 3:
                OriginY = generator.Next(1100, 1200);
                OriginX = generator.Next(0, 1000);
                break;
            }
        }
        public static void UpdateAll()
        {
            for (int index = asteroidList.Count - 1; index > -1; index--)
            {
                // uppdatera position
                asteroidList[index].Update();

                // om utanför spelarea -> tabort instans av astroid
                if (asteroidList[index].OutOfBounds(index))
                {
                    asteroidList.Remove(asteroidList[index]);
                }
                // annars titta om kollision
                else
                {
                    asteroidList[index].CollisionWithLine(index);
                }
            }
        }

        private List<Lazer> lazerList = Lazer.GetLines;
        private void CollisionWithLine(int asteroidIndex)
        {
            for (int index = lazerList.Count - 1; index > -1; index--)
            {
                // om skott krockar med astroid
                if (Raylib.CheckCollisionCircleRec(asteroidList[asteroidIndex].circlePos, 60, lazerList[index].GetRect))
                {
                    // - skott dmg && ta bort skott && + score för spaceship
                    asteroidList[asteroidIndex].hp -= lazerList[index].GetDamage; 
                    Spaceship.AddToScore(lazerList[index].GetID, lazerList[index].GetDamage);
                    Lazer.RemoceInstanceOfLine(index);

                    // om hp efter -dmg >=0 ta bort astroid också
                    if (asteroidList[asteroidIndex].hp <= 0)
                    {
                        asteroidList.Remove(asteroidList[asteroidIndex]);
                    }
                }
            }            
        }
        
        public static void DrawAll()
        {
            for (int index = asteroidList.Count - 1; index > -1; index--)
            {
                asteroidList[index].Draw();
            }
        }

        protected virtual void Draw()
        {
            Raylib.DrawRectanglePro(rectangle, centerOfRect, randDegree, asteroidColor);

            Raylib.DrawText(this.hp.ToString(), (int)circlePos.X - 20, (int)circlePos.Y - 10, 28, Color.LIME);
        }


        private bool OutOfBounds(int index)
        {
            if (asteroidList[index].x > 1250 || asteroidList[index].y > 1250 || asteroidList[index].x < -250 || asteroidList[index].y < -250)
            {
                return true;
            }
            return false;
        }

        protected virtual void Update()
        {
            asteroidMoveSpeed -= 1;

            x = ((Math.Cos(randDegree) * asteroidMoveSpeed) + OriginX);
            y = ((Math.Sin(randDegree) * asteroidMoveSpeed) + OriginY);

            rectangle.x = (float)x;
            rectangle.y = (float)y;

            circlePos = new Vector2((float)x,(float)y);
        }



        public static List<Asteroid> GetAsteroids
        {
            get
            {
                return asteroidList;
            }
        }

        public Vector2 GetCirclePos
        {
            get
            {
                return circlePos;
            }
        }
    }
}
