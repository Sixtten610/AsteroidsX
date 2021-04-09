using System.Collections.Generic;
using System.Numerics;
using System;
using Raylib_cs;

namespace Asteroids
{
    public class Button
    {
        protected static List<Button> widgets = new List<Button>();
        protected int widgetID;

        protected Rectangle hitbox = new Rectangle();
        protected int textSize;
        protected Color textColor;
        protected Color buttonStaticColor;
        protected Color buttonHighlightColor;
        protected string caption;
        protected int textMarginX;
        protected int textMarginY;
        static Vector2 mousePosition;

        
        protected static void Update()
        {
            mousePosition = Raylib.GetMousePosition();
        }

        protected virtual void Draw()
        {
            if (IfHover())
            {
                Raylib.DrawRectangle((int)hitbox.x, (int)hitbox.y, (int)hitbox.width, (int)hitbox.height, buttonHighlightColor);
            }
            Raylib.DrawRectangleLines((int)hitbox.x, (int)hitbox.y, (int)hitbox.width, (int)hitbox.height, buttonStaticColor);

            Raylib.DrawText(caption, (int)hitbox.x + textMarginX, (int)hitbox.y + textMarginY, textSize, textColor);
        }

        public static void DrawAll(int idWidget)
        {
            Update();

            for (int index = widgets.Count - 1; index > -1; index--)
            {
                if (widgets[index].widgetID == idWidget)
                {
                    widgets[index].Draw();
                }
            }
        }

        protected bool IfHover()
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
