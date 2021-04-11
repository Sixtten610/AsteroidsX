using System.Numerics;
using System;
using Raylib_cs;

namespace Asteroids
{
    public class DifficultyScreen : ObjectScreen
    {
        // BUTTONS ###########################################

        // single player
        ButtonSeries easy = new ButtonSeries(45, 300, 35, Color.WHITE, Color.WHITE, Color.LIGHTGRAY, 350, 400, "EASY", 16, 6, 2, 2, 0);
        ButtonSeries medium = new ButtonSeries(45, 300, 35, Color.WHITE, Color.WHITE, Color.LIGHTGRAY, 350, 450, "MEDIUM", 16, 6, 2, 2, 1);
        ButtonSeries hard = new ButtonSeries(45, 300, 35, Color.WHITE, Color.WHITE, Color.LIGHTGRAY, 350, 500, "HARD", 16, 6, 2, 2, 2);
        ButtonSeries impossible = new ButtonSeries(45, 300, 35, Color.WHITE, Color.WHITE, Color.LIGHTGRAY, 350, 550, "IMPOSSIBLE", 16, 6, 2, 2, 3);
        Button back = new ButtonSingle(45, 120, 35, Color.WHITE, Color.WHITE, Color.LIGHTGRAY, 50, 850, "BACK", 13, 6, 2);


        public override void Update()
        {
            ButtonSeries.UpdateSeries(2);
        }

        public override void Draw()
        {
            Raylib.DrawText("DIFFICULTY", 375, 250, 40, Color.WHITE);

            Button.DrawAll(2);
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
