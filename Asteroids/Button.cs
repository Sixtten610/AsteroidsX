using System.Collections.Generic;
using System.Numerics;
using System;
using Raylib_cs;

namespace Asteroids
{
    public class Button
    {
        static protected List<Button> Widgets = new List<Button>();
        protected private int widgetID;

        protected Rectangle hitbox = new Rectangle();
        protected int textSize;
        protected Color textColor;
        protected Color buttonStaticColor;
        protected Color buttonHighlightColor;
        protected string caption;
        protected int textMarginX;
        protected int textMarginY;
        static Vector2 mousePosition;

        
        private static void Update()
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
        public virtual bool IsPressed()
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
