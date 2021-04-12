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
        private Vector2[] pointTriangle = new Vector2[3];
        private bool isAlive = true;

        private int xPlanePos = 500;
        private int yPlanePos = 500;

        // regular 2
        protected int planeMoveSpeed = 2; 
        private double rotation = 1.565;
        // regular 0,08
        protected double rotationSpeed = 0.08;

        private double[] xCircle = {0, 0};
        private double[] yCircle = {0, 0};
        
        // regular 40
        protected float spaceshipSize = 40;
        // regular 20
        protected int damage = 100;
        private Color color;


        protected int spaceshipID;
        protected int score = 0;

        // LINE #############################################################

        private Vector2[] pointLine = new Vector2[2];
        private double[] xLine = {0, 0};
        private double[] yLine = {0, 0};
        
        // KEY INPUTS ########################################################

        protected KeyboardKey[] keyInput;

        public Spaceship(int ID)
        {
            this.spaceshipID = ID;
        }


        public int GetID
        {
            get
            {
                return spaceshipID;
            }
        }
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

        static public void UpdateAll()
        {
            for (int index = spaceshipList.Count - 1; index > -1; index--)
            {
                spaceshipList[index].Update();
            }
        }
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
        static public void DrawAll()
        {
            for (int index = spaceshipList.Count - 1; index > -1; index--)
            {
                spaceshipList[index].Draw();
            }
        }
        private void Draw()
        {
            Raylib.DrawTriangleLines(pointTriangle[0], pointTriangle[1], pointTriangle[2], color);
        }

        private void CheckKeyInput()
        {
            if (Raylib.IsKeyDown(keyInput[0]))
            {
                yPlanePos -= planeMoveSpeed;
            }
            else if (Raylib.IsKeyDown(keyInput[1]))
            {
                yPlanePos += planeMoveSpeed;
            }
            if (Raylib.IsKeyDown(keyInput[2]))
            {
                xPlanePos -= planeMoveSpeed;
            }
            else if (Raylib.IsKeyDown(keyInput[3]))
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

            Math1();
        }

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

        public bool Shoot()
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

        private List<Asteroid> asteroidList = Asteroid.GetAsteroids;

        private void Alive()
        {
            if (Delete())
            {
                isAlive = false;
            }

        }
        protected bool Delete()
        {
            Vector2[] point = new Vector2[3];

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
            
            for (int index = asteroidList.Count - 1; index > 0; index--)
            {
                for (int i = 0; i < 3; i++)
                {
                    if (Raylib.CheckCollisionPointCircle(point[i], asteroidList[index].GetCirclePos, asteroidList[index].GetAsteroidHitboxSize))
                    {
                        return true;
                    }
                }
            }            

            return false;
        }

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
        
        static public List<Spaceship> GetSpaceshipList
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
        private double ConvertRadiansToDegrees(double radians)
        {
            double degrees = (180 / Math.PI) * radians;
            
            return (degrees);
        }

        private float ToFloat(double value)
        {
            return (float)value;
        }
    }
}
