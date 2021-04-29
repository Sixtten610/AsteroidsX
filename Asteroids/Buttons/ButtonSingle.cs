using System;
using Raylib_cs;

namespace Asteroids
{
    public class ButtonSingle : Button
    {
        public ButtonSingle 
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

            widgets.Add(this);
        }
    }
}
