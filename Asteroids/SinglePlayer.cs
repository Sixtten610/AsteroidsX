using System;
using Raylib_cs;

namespace Asteroids
{
    public class SinglePlayer : ObjectScreen
    {
        // BUTTONS ###########################################

        ButtonSeries light = new ButtonSeries(45, 200, 35, Color.WHITE, Color.WHITE, Color.LIGHTGRAY, 100, 400, "LIGHT", 16, 6, 3, 2, 1);
        ButtonSeries regular = new ButtonSeries(45, 200, 35, Color.WHITE, Color.WHITE, Color.LIGHTGRAY, 100, 450, "REGULAR", 16, 6, 3, 2, 0);
        ButtonSeries heavy = new ButtonSeries(45, 200, 35, Color.WHITE, Color.WHITE, Color.LIGHTGRAY, 100, 500, "HEAVY", 16, 6, 3, 2, 2);
        Button back = new ButtonSingle(45, 120, 35, Color.WHITE, Color.WHITE, Color.LIGHTGRAY, 50, 850, "BACK", 13, 6, 3);
        


        public override void Update()
        {
            ButtonSeries.UpdateSeries(3,2);
        }
        public override void Draw()
        {
            Raylib.DrawText("SINGLEPLAYER", 375, 250, 40, Color.WHITE);

            Button.DrawAll(3);
        }









        public bool isBackPressed
        {
            get
            {
                return back.IsPressed();
            }
        }
    }
}
