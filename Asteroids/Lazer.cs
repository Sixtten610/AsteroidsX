using System;
using Raylib_cs;
using System.Numerics;
using System.Collections.Generic;

namespace Asteroids
{
    public class Lazer
    {
        // lista med skott
        protected static List<Lazer> lazerList = new List<Lazer>();
        Rectangle rect = new Rectangle();
        Vector2 rectCenterPointVector = new Vector2();

        // position och rotation
        private double OriginX;
        private double OriginY;
        private double x;
        private double y;
        private double v;
        private double r;
        // skotthastighet
        protected double lazerSpeed = 1;
        // skada
        protected int damage = 100;
        // färg
        protected Color color;
        protected int lazerID;

        // konstruktor som tar in position rotatrion och skada samt id för skottet när en ny instans av Lazer skapas
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
        // property som returnerar skottID
        public int GetID
        {
            get
            {
                return lazerID;
            }
        }

        // metod som uppdaterar skottets position
        private void Update()
        {
            color = ButtonSeries.GetSelectedColor(3);

            lazerSpeed -= 15;

            x = ((Math.Cos(v) * lazerSpeed) + OriginX);
            y = ((Math.Sin(v) * lazerSpeed) + OriginY);

            rect.x = ToFloat(x);
            rect.y = ToFloat(y);  
        }
        // metod som ritar ut skottet
        private void Draw()
        {
            Raylib.DrawRectanglePro(rect, rectCenterPointVector, ToFloat(r), color);
        }

        // tittar om skottet är utanför en gräns, om: ta bort instans av skott, om inte gör inget
        private bool Delete()
        {
            if (x > 1000 || y > 1000 || x < 0 || y < 0)
            {
                return true;
            }
            return false;
        }
        // uppdaterar alla instanser och kör delete metoden för index Lazer
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
        // ritar all skott
        public static void DrawAll()
        {
            for (int index = lazerList.Count - 1; index > -1; index--)
            {
                lazerList[index].Draw();
            }
        }

        // fler properties:
        public static List<Lazer> LazerList
        {
            get
            {
                return lazerList;
            }
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

        // publik metod för att ta bort en specifik instans av skott
        public static void RemoceInstanceOfLine(int index)
        {
            lazerList.Remove(lazerList[index]);
        }

        // konverterar doubles till floats
        static float ToFloat(double value)
        {
            return (float)value;
        }
    }
}
