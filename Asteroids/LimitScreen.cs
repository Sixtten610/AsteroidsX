using System.Numerics;
using System;
using Raylib_cs;

namespace Asteroids
{
    public class LimitScreen
    {
        static Random random = new Random();
        int side;
        Vector2 position = new Vector2();

        static Rectangle rectangle = new Rectangle();

        public LimitScreen()
        {
            side = random.Next(1, 5);

            switch (side)
            {
                case 1:
                rectangle.x = 0;
                rectangle.y = 0;

                rectangle.width = 500;
                rectangle.height = 1000;
                break;
                
                case 2:
                rectangle.x = 500;
                rectangle.y = 0;

                rectangle.width = 500;
                rectangle.height = 1000;
                break;

                case 3:
                rectangle.x = 0;
                rectangle.y = 0;

                rectangle.width = 1000;
                rectangle.height = 500;
                break;

                case 4:
                rectangle.x = 0;
                rectangle.y = 500;

                rectangle.width = 1000;
                rectangle.height = 500;
                break;
            }

            beginDrawWarning = true;
        }

        Color clearRed = new Color(255,0,0,100);

        private int deltaTime;
        private int rounds;
        private  int activeTime = 300 * (int)ButtonSeries.GetSelectedMultiplier(2);
        static bool active;
        private bool beginDrawWarning;

        public void Update()
        {
            if (!active && beginDrawWarning)
            {
                DrawWarning();
            }
            else if (active && activeTime != 0)
            {
                activeTime--;
                DrawRectangle();
            }
        }

        private void DrawRectangle()
        {
            Raylib.DrawRectangleRec(rectangle, Color.RED);
        }

        private void DrawWarning()
        {
            if (deltaTime < 60)
            {
                Raylib.DrawRectangleRec(rectangle, clearRed);
            }
            else if (deltaTime <= 120)
            {
                deltaTime = 0;
                rounds++;
            }
            else
            {
                deltaTime++;
            }
        }



        public static Rectangle LimitRectangle
        {
            get
            {
                return rectangle;
            }
        }
        public static bool isActive
        {
            get
            {
                return active;
            }
        }






    }
}
