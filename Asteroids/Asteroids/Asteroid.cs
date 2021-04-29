using System;
using Raylib_cs;
using System.Numerics;
using System.Collections.Generic;

namespace Asteroids
{
    public class Asteroid
    {
        // lista med alla astroieder & en static random eftersom det är onödigt att skapa en ny varje gång
        protected static List<Asteroid> asteroidList = new List<Asteroid>();
        protected List<Lazer> lazerList = Lazer.LazerList;
        static Random generator = new Random();

        // rectangle och Vector2 för själva astroiden & position
        protected Rectangle rectangle = new Rectangle();
        protected Vector2 centerOfRect;

        protected float randDegree = generator.Next(0, 360);
        protected float originX;
        protected float originY;
        
        protected double x;
        protected double y;
        protected double asteroidMoveSpeed;
        
        // hp & hur mycket poäng som ska tilldelas när astroiden dör
        protected int hp;
        protected int worth;


        protected Vector2 circlePos;
        protected Color asteroidColor;

        // konstruktor för klassen Asteroid, bestämmer storlek, färg, fart och hp/worth och sedan lägger till i listan
        public Asteroid()
        {
            rectangle.width = rectangle.height = 50;

            centerOfRect = new Vector2(rectangle.width/2, rectangle.width/2);

            asteroidColor = Color.WHITE;

            asteroidMoveSpeed = 1;

            hp = worth = 50;
            
            SpawnLocation();

            asteroidList.Add(this);
        }
        // SpawnLocation metoden bestämmer plats astroiden skapas (ett spann på 100px, 100px utanför kanten av spelskärmen) 
        protected virtual void SpawnLocation()
        {
            int randomConst = generator.Next(0,4);
            switch (randomConst)
            {
                case 0:
                originX = generator.Next(-200, -100);
                originY = generator.Next(0, 1000);
                break;

                case 1:
                originX = generator.Next(1100, 1200);
                originY = generator.Next(0, 1000);
                break;
                
                case 2:
                originY = generator.Next(-200, -100);
                originX = generator.Next(0, 1000);
                break;

                case 3:
                originY = generator.Next(1100, 1200);
                originX = generator.Next(0, 1000);
                break;
            }
        }
        // UpdateAll metodens syfte är att uppdatera alla asteroids i listan. 
        // static eftersom onödig att skapa för varje klass
        public static void UpdateAll()
        {
            // går igenom x"asteroidList.Count" antal astroider 
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
        
        // hämtar in lista med skott
        // syftet med metoden är att checka om ett skott(Line) kolliderar med en asteroid
        protected virtual void CollisionWithLine(int asteroidIndex)
        {
            // för varje instans av Lazer tittar om kollision med astroid;
            for (int index = lazerList.Count - 1; index > -1; index--)
            {
                // om skott krockar med astroid
                if (Raylib.CheckCollisionCircleRec(asteroidList[asteroidIndex].GetCirclePos, asteroidList[asteroidIndex].GetAsteroidHitboxSize, lazerList[index].GetRect))
                {  
                    // - skott dmg && ta bort skott && + score för spaceship
                    asteroidList[asteroidIndex].Hp -= lazerList[index].GetDamage; 

                    // om hp efter -dmg >=0 ta bort astroid också
                    if (asteroidList[asteroidIndex].Hp <= 0)
                    {
                        // lägger till poäng för asteroid
                        Spaceship.AddToScore(lazerList[index].GetID, asteroidList[asteroidIndex].worth);
                        // tar bort instans av astroid
                        asteroidList.Remove(asteroidList[asteroidIndex]);
                    }
                    // tar bort skott(index)
                    Lazer.RemoceInstanceOfLine(index);
                }
            }            
        }
        
        // ritar alla asteroider på skärrmen, som UpdateAll är DrawAll också static eftersom onödigt att skapa en flör varje klass
        public static void DrawAll()
        {
            for (int index = asteroidList.Count - 1; index > -1; index--)
            {
                asteroidList[index].Draw();
            }
        }

        // draw metoden specifik för varje asteroid-klass, metodens syfte är att rita ut instansen när tillkallad av DrawAll
        protected virtual void Draw()
        {
            Raylib.DrawRectanglePro(rectangle, centerOfRect, randDegree, asteroidColor);

            Raylib.DrawText(this.hp.ToString(), (int)circlePos.X - 20, (int)circlePos.Y - 10, 28, Color.BLACK);
        }

        // om asteroiden är utanför ett visst område -> ta bort annars inte
        private bool OutOfBounds(int index)
        {
            if (asteroidList[index].x > 1250 || asteroidList[index].y > 1250 || asteroidList[index].x < -250 || asteroidList[index].y < -250)
            {
                return true;
            }
            return false;
        }
        
        // klassmetoden uppdaterar position för instansen av asteroid
        protected virtual void Update()
        {
            asteroidMoveSpeed -= 1;

            // x & y är kordinater i ett 2d plan. randDegree är en slumpad float (vinkeln)
            // asteroidMoveSpeed kan antas som hypotenusan. Med detta kan x & y beräknas
            x = ((Math.Cos(randDegree) * asteroidMoveSpeed) + originX);
            y = ((Math.Sin(randDegree) * asteroidMoveSpeed) + originY);

            rectangle.x = (float)x;
            rectangle.y = (float)y;

            circlePos = new Vector2((float)x,(float)y);
        }

        // properties för att returnera olika saker i.e listor position eller hitbox storlek
        public static List<Asteroid> AsteroidList
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
        public float GetAsteroidHitboxSize
        {
            get
            {
                return rectangle.width/1.7f;
            }
        }
        // Hp skiljer sig från de andra då den också har en set som ändrar på int-hp
        public int Hp
        {
            get
            {
                return hp;
            }
            set
            {
                hp = Math.Max(value, 0);
            }
        }
    }
}
