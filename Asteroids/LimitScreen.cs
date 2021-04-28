using System.Collections.Generic;
using System.Numerics;
using System;
using Raylib_cs;

namespace Asteroids
{
    public class LimitScreen
    {
        static List<LimitScreen> limitList = new List<LimitScreen>();

        static Random random = new Random();
        int side;

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

            activeTime = 300 * (int)ButtonSeries.GetSelectedMultiplier(2);

            limitList.Add(this);
        }

        private Color clearRed = new Color(255,0,0,100);
        private int deltaTime = 0;
        private int rounds = 0;
        private  int activeTime;
        static bool active = false;




        public static void UpdateAll()
        {
            for (int index = limitList.Count - 1; index > -1; index--)
            {
                limitList[index].Update();
            }
        }

        private void Update()
        {
            if (active == false)
            {
                DrawWarning();

                if (rounds == 5)
                {
                    active = true;
                }
            }
            else if (active && activeTime > 0)
            {
                activeTime--;
                DrawRectangle();
            }
            // else if (activeTime == 0)
            // {
            //     limitList.Remove(this);
            // }
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
                deltaTime++;
            }
            else if (deltaTime == 120)
            {
                deltaTime = 0;
                rounds++;
            }
        }



        public Rectangle LimitRectangle
        {
            get
            {
                return rectangle;
            }
        }
        public static List<LimitScreen> LimitList
        {
            get
            {
                return limitList;
            }
        }






    }
}
