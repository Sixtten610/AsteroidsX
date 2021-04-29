using System;
using Raylib_cs;

namespace Asteroids
{
    public class SettingScreen : ObjectScreen
    {
        ButtonSeries on = new ButtonSeries(45, 300, 35, Color.WHITE, Color.WHITE, Color.GREEN, 350, 400, "ON", 16, 6, 7, 4, 0, 0);
        ButtonSeries off = new ButtonSeries(45, 300, 35, Color.WHITE, Color.WHITE, Color.RED, 350, 450, "OFF", 16, 6, 7, 4, 1, 0);
        Button back = new ButtonSingle(45, 120, 35, Color.WHITE, Color.WHITE, Color.LIGHTGRAY, 50, 850, "BACK", 13, 7, 7);




        public override void Update()
        {
            ButtonSeries.UpdateSeries(4);
        }

        public override void Draw()
        {
            Raylib.DrawText("SETTINGS", 396, 250, 40, Color.WHITE);

            Raylib.DrawText("ELIMINATION ZONE", 405, 350, 20, Color.WHITE);



            Button.DrawAll(7);
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
