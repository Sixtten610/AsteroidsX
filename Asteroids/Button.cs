using System.Collections.Generic;
using System.Numerics;
using System;
using Raylib_cs;

namespace Asteroids
{
    public class Button
    {
        static protected List<Button> Widgets = new List<Button>();
        private int widgetID;

        Rectangle hitbox = new Rectangle();
        int textSize;
        Color textColor;
        Color buttonStaticColor;
        Color buttonHighlightColor;
        string caption;
        int textMarginX;
        int textMarginY;
        static Vector2 mousePosition;

        public Button 
        (
            int height, int width, int textSize, Color textColor, Color buttonStaticColor, Color buttonHighlightColor, 
            int xPos, int yPos, string caption, int textMarginX, int textMarginY, int widgetID
        )
        {
            hitbox.height = height;
            hitbox.width = width;
            hitbox.x = xPos;
            hitbox.y = yPos;

            this.textSize = textSize;
            this.textColor = textColor;
            this.buttonStaticColor = buttonStaticColor;
            this.buttonHighlightColor = buttonHighlightColor;
            this.caption = caption;
            this.textMarginX = textMarginX;
            this.textMarginY = textMarginY;
            this.widgetID = widgetID;

            Widgets.Add(this);
        }
        private static void Update()
        {
            mousePosition = Raylib.GetMousePosition();
        }

        private void Draw()
        {
            if (IfHover())
            {
                Raylib.DrawRectangle((int)hitbox.x, (int)hitbox.y, (int)hitbox.width, (int)hitbox.height, buttonHighlightColor);
            }
            Raylib.DrawRectangleLines((int)hitbox.x, (int)hitbox.y, (int)hitbox.width, (int)hitbox.height, buttonStaticColor);

            Raylib.DrawText(caption, (int)hitbox.x + textMarginX, (int)hitbox.y + textMarginY, textSize, textColor);
        }

        public static void DrawAll(int id)
        {
            Update();

            for (int index = Widgets.Count - 1; index > -1; index--)
            {
                if (Widgets[index].widgetID == id)
                {
                    Widgets[index].Draw();
                }
            }
        }

        private bool IfHover()
        {
            if(Raylib.CheckCollisionPointRec(mousePosition, hitbox))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool IsPressed()
        {
            if (IfHover() && Raylib.IsMouseButtonReleased(MouseButton.MOUSE_LEFT_BUTTON))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
