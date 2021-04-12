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
        Color rectangleColor;
        Color highlightColor;
        Vector2 keyPosition = new Vector2();

        public UserInterfaceKey(int xPos, int yPos, KeyboardKey key, string keyText, Color rectColor)
        {
            keyPosition.X = xPos;
            keyPosition.Y = yPos;

            this.key = key;
            this.keyText = keyText;

            rectangleColor = rectColor;
            highlightColor = new(255,255,255,70);

            keyList.Add(this);
            keyRectangle.height = keyRectangle.width = 100;
        }
        public static void UpdateAll()
        {
            for (int index = keyList.Count - 1; index > -1; index--)
            {
                keyList[index].Update();
            }
        }
        bool highlightKey;
        private void Update()
        {
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
            if (highlightKey)
            {
                Raylib.DrawRectangle((int)keyPosition.X, (int)keyPosition.Y, (int)keyRectangle.width, (int)keyRectangle.height, highlightColor);
            }
            Raylib.DrawRectangle((int)keyPosition.X, (int)keyPosition.Y, (int)keyRectangle.width, (int)keyRectangle.height, rectangleColor);
        }
    }
}
