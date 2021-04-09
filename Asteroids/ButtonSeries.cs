using System;
using Raylib_cs;
using System.Collections.Generic;

namespace Asteroids
{
    public class ButtonSeries : Button
    {
        protected static List<ButtonSeries> seriesWidgets = new List<ButtonSeries>();
        int seriesID;
        public ButtonSeries
        (
            int height, int width, int textSize, Color textColor, Color buttonStaticColor, Color buttonHighlightColor, 
            int xPos, int yPos, string caption, int textMarginX, int textMarginY, int widgetID, int seriesID
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
            this.seriesID = seriesID;

            widgets.Add(this);
            seriesWidgets.Add(this);
        }
        static Color buttonSeriesSelectedColor = new Color(200,200,200, 50);
        bool buttonIsSelected = false;
        private void ButtonIsSelected()
        {
            Raylib.DrawRectangle((int)hitbox.x, (int)hitbox.y, (int)hitbox.width, (int)hitbox.height, buttonSeriesSelectedColor);
        }
        protected override void Draw()
        {
            if (IfHover())
            {
                Raylib.DrawRectangle((int)hitbox.x, (int)hitbox.y, (int)hitbox.width, (int)hitbox.height, buttonHighlightColor);
            }
            Raylib.DrawRectangleLines((int)hitbox.x, (int)hitbox.y, (int)hitbox.width, (int)hitbox.height, buttonStaticColor);

            Raylib.DrawText(caption, (int)hitbox.x + textMarginX, (int)hitbox.y + textMarginY, textSize, textColor);
            if (buttonIsSelected)
            {
                ButtonIsSelected();
            }
        }
        public static void UpdateSeries(int idWidget, int idSeries)
        {
            Update();

            for (int index = seriesWidgets.Count - 1; index > -1; index--)
            {
                if (seriesWidgets[index].widgetID == idWidget && seriesWidgets[index].seriesID == idSeries && seriesWidgets[index].IsPressed())
                {
                    seriesWidgets[index].buttonIsSelected = true;
                }
                else
                {
                    seriesWidgets[index].buttonIsSelected = false;
                }
            }
        }
        
    }
}
