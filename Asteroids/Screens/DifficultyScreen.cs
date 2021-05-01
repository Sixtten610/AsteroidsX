using System.Numerics;
using System;
using Raylib_cs;

namespace Asteroids
{
    public class DifficultyScreen : ObjectScreen
    {
        // BUTTONS ###########################################

        // single player
        ButtonSeries easy = new ButtonSeries(45, 300, 35, Color.WHITE, Color.WHITE, Color.LIGHTGRAY, 350, 400, "SUPER EASY", 16, 6, 2, 2, 1, 1f);
        ButtonSeries medium = new ButtonSeries(45, 300, 35, Color.WHITE, Color.WHITE, Color.LIGHTGRAY, 350, 450, "EASY", 16, 6, 2, 2, 0, 1.5f);
        ButtonSeries hard = new ButtonSeries(45, 300, 35, Color.WHITE, Color.WHITE, Color.LIGHTGRAY, 350, 500, "MEDIUM", 16, 6, 2, 2, 2, 2f);
        ButtonSeries impossible = new ButtonSeries(45, 300, 35, Color.WHITE, Color.WHITE, Color.LIGHTGRAY, 350, 550, "HARD", 16, 6, 2, 2, 3, 3f);
        ButtonSeries infinity = new ButtonSeries(45, 300, 35, Color.WHITE, Color.WHITE, Color.LIGHTGRAY, 350, 600, "IMPOSSIBLE", 16, 6, 2, 2, 4, 3.5f);
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
