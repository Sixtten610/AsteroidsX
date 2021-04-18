using System;
using Raylib_cs;
using System.Numerics;
using System.Collections.Generic;

namespace Asteroids
{
    public class Lazer
    {
        protected static List<Lazer> lazerList = new List<Lazer>();
        Rectangle rect = new Rectangle();
        Vector2 rectCenterPointVector = new Vector2();

        private double OriginX;
        private double OriginY;
        private double x;
        private double y;
        private double v;
        private double r;
        protected double lazerSpeed = 1;

        protected int damage = 100;
        protected Color color;
        protected int lazerID;

        public Lazer(int xI, int yI, double vI, double rI, int damage, int id)
        {
            OriginX = xI;
            OriginY = yI;
            v = vI;
            r = rI;
            rect.x = ToFloat(OriginX);
            rect.y = ToFloat(OriginY);

            rect.width = 7;
            rect.height = 1;

            this.damage = damage;
            this.lazerID = id;

            lazerList.Add(this);
        }
        public int GetID
        {
            get
            {
                return lazerID;
            }
        }

        private void Update()
        {
            color = ButtonSeries.GetSelectedColor(3);

            lazerSpeed -= 15;

            x = ((Math.Cos(v) * lazerSpeed) + OriginX);
            y = ((Math.Sin(v) * lazerSpeed) + OriginY);

            rect.x = ToFloat(x);
            rect.y = ToFloat(y);  
        }
        private void Draw()
        {
            Raylib.DrawRectanglePro(rect, rectCenterPointVector, ToFloat(r), color);
        }

        private bool Delete()
        {
            if (x > 1000 || y > 1000 || x < 0 || y < 0)
            {
                return true;
            }
            return false;
        }
        public static void UpdateAll()
        {
            for (int index = lazerList.Count - 1; index > -1; index--)
            {
                lazerList[index].Update();
                if (lazerList[index].Delete() == true)
                {
                    lazerList.Remove(lazerList[index]);
                }
            }
        }
        public static void DrawAll()
        {
            for (int index = lazerList.Count - 1; index > -1; index--)
            {
                lazerList[index].Draw();
            }
        }

        public static List<Lazer> LazerList
        {
            get
            {
                return lazerList;
            }
            // set
            // {
            //     lazerList.Clear();
            // }
        }
        public Rectangle GetRect
        {
            get
            {
                return rect;
            }
        }
        public int GetDamage
        {
            get
            {
                return damage;
            }
        }

        public static void RemoceInstanceOfLine(int index)
        {
            lazerList.Remove(lazerList[index]);
        }

        static float ToFloat(double value)
        {
            return (float)value;
        }
    }
}
