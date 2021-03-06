using System.Numerics;
using System;
using Raylib_cs;
using System.Collections.Generic;

namespace Asteroids
{
    public class ButtonSeries : Button
    {
        protected static List<ButtonSeries> seriesWidgets = new List<ButtonSeries>();
        static Color buttonSeriesSelectedColor = new Color(200,200,200, 100);
        protected bool buttonIsSelected = false;
        protected int seriesID;
        protected int seriesIDofButtonSeries;
        protected float multiplier;

        public ButtonSeries
        (
            int height, int width, int textSize, Color textColor, Color buttonStaticColor, Color buttonHighlightColor, 
            int xPos, int yPos, string caption, int textMarginX, int textMarginY, int widgetID, int seriesID, int seriesIDofButtonSeries, float multiplier
        )
        {
            // HITBOX
            hitbox.height = height;
            hitbox.width = width;
            hitbox.x = xPos;
            hitbox.y = yPos;

            // BUTTON SETTINGS
            SetButtonInButtonSeriesIsPressed(seriesID, 0);
            this.textSize = textSize;
            this.textColor = textColor;
            this.buttonStaticColor = buttonStaticColor;
            this.buttonHighlightColor = buttonHighlightColor;
            this.caption = caption;
            this.textMarginX = textMarginX;
            this.textMarginY = textMarginY;
            this.multiplier = multiplier;

            // BUTTON TAGS
            this.widgetID = widgetID;
            this.seriesID = seriesID;
            this.seriesIDofButtonSeries = seriesIDofButtonSeries;

            // ADD TO LISTS
            widgets.Add(this);
            seriesWidgets.Add(this);
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
        
        private void ButtonIsSelected()
        {
            Raylib.DrawRectangle((int)hitbox.x, (int)hitbox.y, (int)hitbox.width, (int)hitbox.height, buttonSeriesSelectedColor);
        }

        public static void UpdateSeries(int idSeries)
        {
            if (IsButtonPressedOfThisID(idSeries))
            {
                for (int index = seriesWidgets.Count - 1; index > -1; index--)
                {
                    if (seriesWidgets[index].seriesID == idSeries)
                    {
                        seriesWidgets[index].buttonIsSelected = false;
                    }
                }

                for (int index = seriesWidgets.Count - 1; index > -1; index--)
                {
                    if (seriesWidgets[index].IsPressed() && seriesWidgets[index].seriesID == idSeries)
                    {
                        SetButtonInButtonSeriesIsPressed(idSeries, seriesWidgets[index].seriesIDofButtonSeries);
                    }
                    
                }
            }
            
        }

        protected static void SetButtonInButtonSeriesIsPressed(int seriesID, int seriesIDofButtonSeries)
        {
            for (int index = seriesWidgets.Count - 1; index > -1; index--)
            {
                if (seriesWidgets[index].seriesID == seriesID && seriesWidgets[index].seriesIDofButtonSeries == seriesIDofButtonSeries)
                {
                    seriesWidgets[index].buttonIsSelected = true;
                }
                    
            }

        }

        private static bool IsButtonPressedOfThisID(int idSeries)
        {
            for (int index = seriesWidgets.Count - 1; index > -1; index--)
            {
                if (seriesWidgets[index].IsPressed() && seriesWidgets[index].seriesID == idSeries)
                {
                    return true;
                }
            }
            return false;
        }
        public static int GetSelectedButtonID(int idSeries)
        {
            for (int index = seriesWidgets.Count - 1; index > -1; index--)
            {
                if (seriesWidgets[index].buttonIsSelected && seriesWidgets[index].seriesID == idSeries)
                {
                    return seriesWidgets[index].seriesIDofButtonSeries;
                }
            }
            return 0;
        }
        public static Color GetSelectedColor(int idSeries)
        {
            for (int index = seriesWidgets.Count - 1; index > -1; index--)
            {
                if (seriesWidgets[index].buttonIsSelected && seriesWidgets[index].seriesID == idSeries)
                {
                    return seriesWidgets[index].buttonStaticColor;
                }
            }
            return Color.WHITE;
        }
        public static float GetSelectedMultiplier(int idSeries)
        {
            for (int index = seriesWidgets.Count - 1; index > -1; index--)
            {
                if (seriesWidgets[index].buttonIsSelected && seriesWidgets[index].seriesID == idSeries)
                {
                    return seriesWidgets[index].ButtonSeriesMultiplier();
                }
            }
            return 1;
        }
        protected virtual float ButtonSeriesMultiplier()
        {
            return multiplier;
        }
        
    }
}
