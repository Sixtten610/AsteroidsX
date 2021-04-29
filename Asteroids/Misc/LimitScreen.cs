using System.Collections.Generic;
using System.Numerics;
using System;
using Raylib_cs;

namespace Asteroids
{
    public class LimitScreen
    {
        private static List<LimitScreen> limitList = new List<LimitScreen>();

        private static Random random = new Random();
        private int side;
        private Rectangle rectangle = new Rectangle();
        private static Color clearRed = new Color(255,0,0,100);
        private int deltaTime = 0;
        private int rounds = 0;
        private  int activeTime;
        private bool active = false;


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

            activeTime = 200 * (int)ButtonSeries.GetSelectedMultiplier(2);

            limitList.Add(this);
        }

        public static void UpdateAll()
        {
            for (int index = limitList.Count - 1; index > -1; index--)
            {
                limitList[index].Update();
            }
        }

        private void Update()
        {
            if (!active)
            {

                if (rounds == 6)
                {
                    active = true;
                }
                else
                {
                    DrawWarning();
                }
            }
            else if (active && activeTime > 0)
            {
                activeTime--;
                DrawRectangle();
            }
            else if (activeTime == 0)
            {
                limitList.Remove(this);
            }
        }

        private void DrawRectangle()
        {
            Raylib.DrawRectangleRec(rectangle, Color.RED);
        }

        private void DrawWarning()
        {
            deltaTime++;

            if (deltaTime < 30)
            {
                Raylib.DrawRectangleRec(rectangle, clearRed);
                Raylib.DrawText("ELIMINATION ZONE", 380, 70, 30, Color.RED);
            }
            else if (deltaTime == 60)
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

        public bool LimitActive
        {
            get
            {
                return active;
            }
        }

    }
}
