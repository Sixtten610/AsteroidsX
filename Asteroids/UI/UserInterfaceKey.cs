using System.Collections.Generic;
using System.Numerics;
using System;
using Raylib_cs;

namespace Asteroids
{
    public class UserInterfaceKey
    {
        static List<UserInterfaceKey> keyList = new List<UserInterfaceKey>();
        KeyboardKey key = new KeyboardKey();
        Rectangle keyRectangle = new Rectangle();
        string keyText;
        Color rectangleColorInt;
        Color textColor = Color.WHITE;
        int colorInt;
        Color highlightColor1;
        Color highlightColor2;
        Vector2 keyPosition = new Vector2();
        bool highlightKey;

        public UserInterfaceKey(int xPos, int yPos, KeyboardKey key, string keyText, int colorInt)
        {
            keyPosition.X = xPos;
            keyPosition.Y = yPos;

            this.key = key;
            this.keyText = keyText;

            highlightColor1 = new(255,255,255,90);
            highlightColor2 = new(0,0,0,90);
            this.colorInt = colorInt;

            keyList.Add(this);
            keyRectangle.height = keyRectangle.width = 60;
        }
        public static void UpdateAll()
        {
            for (int index = keyList.Count - 1; index > -1; index--)
            {
                keyList[index].Update();
            }
        }
        private void Update()
        {
            rectangleColorInt = ButtonSeries.GetSelectedColor(colorInt);

            if(ButtonSeries.GetSelectedButtonID(3) == 0)
            {
                textColor = Color.BLACK;
            }

            if(Raylib.IsKeyDown(key))
            {
                highlightKey = true;
            }
            else
            {
                highlightKey = false;
            }
        }
        public static void DrawAll()
        {
            for (int index = keyList.Count - 1; index > -1; index--)
            {
                keyList[index].Draw();
            }
        }
        private void Draw()
        {
            Raylib.DrawRectangle((int)keyPosition.X, (int)keyPosition.Y, (int)keyRectangle.width, (int)keyRectangle.height, rectangleColorInt);
            if (highlightKey && ButtonSeries.GetSelectedButtonID(3) == 0)
            {
                Raylib.DrawRectangle((int)keyPosition.X, (int)keyPosition.Y, (int)keyRectangle.width, (int)keyRectangle.height, highlightColor2);
            }
            else if (highlightKey)
            {
                Raylib.DrawRectangle((int)keyPosition.X, (int)keyPosition.Y, (int)keyRectangle.width, (int)keyRectangle.height, highlightColor1);
            }   
            Raylib.DrawText(keyText, (int)keyPosition.X + 15, (int)keyPosition.Y + 7, 50, textColor);     
        }
    }
}
