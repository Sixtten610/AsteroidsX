// using System.Collections.Generic;
// using System;
// using Raylib_cs;

// namespace Asteroids
// {
//     public class ButtonSeriesColor : ButtonSeries
//     {
//         protected static List<ButtonSeries> seriesWidgets1 = ButtonSeries.SeriesWidgetsList;
//         public ButtonSeriesColor
//         (
//             int height, int width, int textSize, Color textColor, Color buttonStaticColor, Color buttonHighlightColor, 
//             int xPos, int yPos, string caption, int textMarginX, int textMarginY, int widgetID, int seriesID, int seriesIDofButtonSeries, float multiplier
//         ) : base(height, width, textSize, textColor, buttonStaticColor, buttonHighlightColor, 
//             xPos, yPos, caption, textMarginX, textMarginY, widgetID, seriesID, seriesIDofButtonSeries, multiplier)
//         {

//         }

//         public static Color GetSelectedColor1(int idSeries)
//         {
//             for (int index = ButtonSeries.SeriesWidgetsList.Count - 1; index > -1; index--)
//             {
//                 if (ButtonSeries.SeriesWidgetsList[index].buttonIsSelected && seriesWidgets1[index].seriesID == idSeries)
//                 {
//                     return seriesWidgets1[index].buttonStaticColor;
//                 }
//             }
//             return Color.WHITE;
//         }
//     }
// }
