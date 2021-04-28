using System.Collections.Generic;
using System.Numerics;
using System;
using Raylib_cs;

namespace Asteroids
{
    public class Spaceship
    {
        static protected List<Spaceship> spaceshipList = new List<Spaceship>();

        // SPACESHIP #########################################################
        // p-position för kanter av triangl
        private Vector2[] pointTriangle = new Vector2[3];
        private bool isAlive = true;

        // spawn
        private int xPlanePos = 500;    
        private int yPlanePos = 500;

        // move speed
        protected int planeMoveSpeed = 2; 
        private double rotation = 1.565;

        protected double rotationSpeed = 0.08;

        private double[] xCircle = {0, 0};
        private double[] yCircle = {0, 0};
        
        // storlek, skada och färg
        protected float spaceshipSize = 40;
        protected int damage = 100;
        private Color color;

        // id för spaceship klassen
        protected int spaceshipID;
        protected int score = 0;

        // LINE #############################################################

        // information för skott
        private Vector2[] pointLine = new Vector2[2];
        private double[] xLine = {0, 0};
        private double[] yLine = {0, 0};
        
        // KEY INPUTS ########################################################

        protected KeyboardKey[] keyInput;

        // i konstruktorn deklareras ett ID
        public Spaceship(int ID)
        {
            this.spaceshipID = ID;
        }

        // property för att returnera ID
        public int GetID
        {
            get
            {
                return spaceshipID;
            }
        }

        // återger rymdskeppets poäng när tillkallad
        public static int GetSpaceshipScore(int id)
        {
            for (int index = spaceshipList.Count - 1; index > -1; index--)
            {
                if(spaceshipList[index].GetID == id)
                {
                    return spaceshipList[index].GetShipScore;
                }
            }
            return 0;
        }
        private int GetShipScore
        {
            get
            {
                return score;
            }
        }
        
        // lägger till poäng för skepp, tar emot två parametrar, en int för id(specifika skeppet)
        // samt ytterligare en int för hur mycket poäng som ska adderas
        public static void AddToScore(int id, int score)
        {
            for (int index = spaceshipList.Count - 1; index > -1; index--)
            {
                if(spaceshipList[index].GetID == id)
                {
                    spaceshipList[index].AddScore(score);
                }
            }
        }
        private void AddScore(int score)
        {
            this.score += score;
        }

        // uppdaterar alla rymdskepp, (spaceship är anpassad för multiplayer)
        static public void UpdateAll()
        {
            for (int index = spaceshipList.Count - 1; index > -1; index--)
            {
                spaceshipList[index].Update();
            }
        }
        // Update uppdaterar trianglens rotation och placering på planet
        // samt tillkallar Alive() metoden för att titta om spelaren lever
        private void Update()
        {
            Alive();

            CheckKeyInput();

            color = ButtonSeries.GetSelectedColor(3);

            for (int i = 0; i < 3; i++)
            {
                pointTriangle[i].X = (xPlanePos);
                pointTriangle[i].Y = (yPlanePos);

                if (i > 0)
                {
                    pointTriangle[i].X += (spaceshipSize * ToFloat(xCircle[i - 1]));
                    pointTriangle[i].Y += (spaceshipSize * ToFloat(yCircle[i - 1]));
                }

                if (i < 2)
                {
                    pointLine[i].X = (xPlanePos);
                    pointLine[i].Y = (yPlanePos);
                }
                if (i == 1)
                {
                    pointLine[i].X += (spaceshipSize * ToFloat(xLine[i]));
                    pointLine[i].Y += (spaceshipSize * ToFloat(yLine[i]));
                }
            }
        }
        // ritar alla rymdskepp
        static public void DrawAll()
        {
            for (int index = spaceshipList.Count - 1; index > -1; index--)
            {
                spaceshipList[index].Draw();
            }
        }
        // ritat triangeln (rymdskeppet) för instansen
        private void Draw()
        {
            Raylib.DrawTriangleLines(pointTriangle[0], pointTriangle[1], pointTriangle[2], color);
        }

        // tittar om spelaren trycker ned någon knapp, om trycker ned knapp. förflytta spelaren isåfall
        private void CheckKeyInput()
        {
            if (Raylib.IsKeyDown(keyInput[0]) && yPlanePos > 0)
            {
                yPlanePos -= planeMoveSpeed;
            }
            else if (Raylib.IsKeyDown(keyInput[1]) && yPlanePos < 1000)
            {
                yPlanePos += planeMoveSpeed;
            }
            if (Raylib.IsKeyDown(keyInput[2]) && xPlanePos > 0)
            {
                xPlanePos -= planeMoveSpeed;
            }
            else if (Raylib.IsKeyDown(keyInput[3]) && xPlanePos < 1000)
            {
                xPlanePos += planeMoveSpeed;
            }

            if (Raylib.IsKeyDown(keyInput[4]))
            {
                rotation -= rotationSpeed;
            }
            else if (Raylib.IsKeyDown(keyInput[5]))
            {
                rotation += rotationSpeed;
            }
            // tillkallar positionsmetod därefter
            Math1();
        }

        // räknar ut position för de tre kanterna av trianglen samt skottvinkel
        private void Math1()
        {
            int invert = 1;

            for (int i = 0; i < 2; i++)
            {
                if (i == 1)
                {
                    invert = -1;
                }

                xCircle[i] = Math.Cos(rotation + invert * 170);
                yCircle[i] = Math.Sin(rotation + invert * 170); 
            }

            xLine[1] = Math.Cos(rotation);
            yLine[1] = Math.Sin(rotation);
        }
        // om spelaren trycket på skjutknappen returnera true
        public virtual bool Shoot()
        {
            if (Raylib.IsKeyPressed(keyInput[6]))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        // hämtar lista med asteroider
        private List<Asteroid> asteroidList = Asteroid.AsteroidList;
        // Alive chackar om spelaren lever, om inte ta bort instans av spaceship
        private void Alive()
        {
            if (Delete())
            {
                spaceshipList.Remove(this);
                isAlive = false;
            }

        }
        // ta-bort-instans-av-spaceship metod
        protected bool Delete()
        {
            Vector2[] point = new Vector2[3];
            // lägger in de tre hörnen i en vector2 array med tre plattser
            for (int index = 0; index < 3; index++)
            {
                if (index == 0)
                {
                    point[index].X = xPlanePos;
                    point[index].Y = yPlanePos;
                }
                else
                {
                    point[index].X = pointTriangle[index].X;
                    point[index].Y = pointTriangle[index].Y;
                }
                               
            }
            // tittar om någon av de tre hörnen kolliderar med asteroiden,
            // detta görs för alla asteroider i listan asteroidList
            for (int index = asteroidList.Count - 1; index > -1; index--)
            {
                for (int i = 0; i < 3; i++)
                {
                    if (Raylib.CheckCollisionPointCircle(point[i], asteroidList[index].GetCirclePos, asteroidList[index].GetAsteroidHitboxSize))
                    {
                        return true;
                    }
                }
            }

            if (LimitScreen.isActive && Raylib.CheckCollisionPointRec(pointTriangle[0], LimitScreen.LimitRectangle))
            {
                return true;
            }

            return false;
        }
        // fler properties: med syftet att ge instanser av skott information om spelaren
        // för att beräkna skottvinkel mm:
        public int TriangleX
        {
            get
            {
                return xPlanePos;
            }
        }
        public int TriangleY
        {
            get
            {
                return yPlanePos;
            }
        }
        public double TriangleV
        {
            get
            {
                return rotation;
            }
        }
        public double TriangleR
        {
            get
            {
                return TriangleRot();
            }
        }
        public int Damage
        {
            get
            {
                return damage;
            }
        }

        public bool isSpaceshipAlive
        {
            get
            {
                return isAlive;
            }
        }
        
        static public List<Spaceship> SpaceshipList
        {
            get
            {
                return spaceshipList;
            }
        }

        public int GetSpaceshipX
        {
            get
            {
                return xPlanePos;
            }
        }
        public int GetSpaceshipY
        {
            get
            {
                return yPlanePos;
            }
        }
        // återger vinkel som spacehip är roterad i
        private double TriangleRot()
        {
            double mycalcInRadians = Math.Acos(xLine[1]);
            
            double rotation = ConvertRadiansToDegrees(mycalcInRadians);

            if (yLine[1] < 0)
            {
                return -rotation;
            }

            return rotation;
        }

        // "https://www.oreilly.com/library/view/c-cookbook/0596003390/ch01s03.html"
        // denna metod använde jag från lkänken ovan eftersom det är ett mycket
        // bra och effektivt sätt att konvertera radianer till vinklar
        private double ConvertRadiansToDegrees(double radians)
        {
            double degrees = (180 / Math.PI) * radians;
            
            return (degrees);
        }

        // koverterar double värden till floats
        private float ToFloat(double value)
        {
            return (float)value;
        }
    }
}
