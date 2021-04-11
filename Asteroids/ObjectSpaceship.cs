using System.Collections.Generic;
using System.Numerics;
using System;
using Raylib_cs;

namespace Asteroids
{
    public class ObjectSpaceship
    {
        // TRIANGLE #########################################################
        private Vector2[] pointTriangle = new Vector2[3];

        private int xPlanePos = 500;
        private int yPlanePos = 500;

        private int planeMoveSpeed = 2; 
        private double rotation = 1.565;
        private double moveConstantOfDegrees = 0.08;

        private double[] xCircle = {0, 0};
        private double[] yCircle = {0, 0};

        private float pointTrianglesDistanceFromCenter = 40;

        // LINE #############################################################

        private Vector2[] pointLine = new Vector2[2];
        private double[] xLine = {0, 0};
        private double[] yLine = {0, 0};
        
        // KEY INPUTS ########################################################

        protected KeyboardKey[] keyInput;

        public ObjectSpaceship(KeyboardKey up, KeyboardKey down, KeyboardKey left, KeyboardKey right, KeyboardKey rotateLeft, KeyboardKey rotateRight, KeyboardKey shoot)
        {
            keyInput = new KeyboardKey[7];

            keyInput[0] = up;
            keyInput[1] = down;
            keyInput[2] = left;
            keyInput[3] = right;
            keyInput[4] = rotateLeft;
            keyInput[5] = rotateRight;
            keyInput[6] = shoot;

        }

        public void Update()
        {
            for (int i = 0; i < 3; i++)
            {
                pointTriangle[i].X = (xPlanePos);
                pointTriangle[i].Y = (yPlanePos);

                if (i > 0)
                {
                    pointTriangle[i].X += (pointTrianglesDistanceFromCenter * ToFloat(xCircle[i - 1]));
                    pointTriangle[i].Y += (pointTrianglesDistanceFromCenter * ToFloat(yCircle[i - 1]));
                }

                if (i < 2)
                {
                    pointLine[i].X = (xPlanePos);
                    pointLine[i].Y = (yPlanePos);
                }
                if (i == 1)
                {
                    pointLine[i].X += (pointTrianglesDistanceFromCenter * ToFloat(xLine[i]));
                    pointLine[i].Y += (pointTrianglesDistanceFromCenter * ToFloat(yLine[i]));
                }
            }
        }

        public void Draw()
        {
            Raylib.DrawTriangleLines(pointTriangle[0], pointTriangle[1], pointTriangle[2], Color.RED);

            Raylib.DrawLineV(pointLine[0], pointLine[1], Color.MAGENTA);
        }

        public void Mechanics()
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
                rotation -= moveConstantOfDegrees;
            }
            else if (Raylib.IsKeyDown(keyInput[5]))
            {
                rotation += moveConstantOfDegrees;
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
                System.Console.WriteLine("Shoot");
                return true;
            }
            else
            {
                return false;
            }
        }

        //private List<Asteroid2> asteroidList = Asteroid2.GetAsteroids;

        public void Alive()
        {
            if (Delete())
            {
                System.Console.WriteLine("YOU DIED");
                Console.ReadLine();
            }

        }
        protected bool Delete()
        {
            Vector2[] point = new Vector2[3];

            for (int index = 0; index < 3; index++)
            {
                System.Console.WriteLine(index);
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
            
            // for (int index = asteroidList.Count - 1; index > 0; index--)
            // {
            //     for (int i = 0; i < 3; i++)
            //     {
            //         if (Raylib.CheckCollisionPointCircle(point[i], asteroidList[index].GetCirclePos, 60))
            //         {
            //             return true;
            //         }
            //     }
            // }            

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
