using System.Numerics;
using System;
using Raylib_cs;

namespace Asteroids
{
    public class DifficultyScreen : ObjectScreen
    {
        // BUTTONS ###########################################
        ButtonSeries easy = new ButtonSeries(45, 300, 35, Color.WHITE, Color.WHITE, Color.LIGHTGRAY, 350, 450, "EASY", 16, 6, 2, 1);
        ButtonSeries medium = new ButtonSeries(45, 300, 35, Color.WHITE, Color.WHITE, Color.LIGHTGRAY, 350, 500, "MEDIUM", 16, 6, 2, 1);
        ButtonSeries hard = new ButtonSeries(45, 300, 35, Color.WHITE, Color.WHITE, Color.LIGHTGRAY, 350, 550, "HARD", 16, 6, 2, 1);
        ButtonSeries impossible = new ButtonSeries(45, 300, 35, Color.WHITE, Color.WHITE, Color.LIGHTGRAY, 350, 600, "IMPOSSIBLE", 16, 6, 2, 1);

        Button back = new ButtonSingle(45, 120, 35, Color.WHITE, Color.WHITE, Color.LIGHTGRAY, 50, 850, "BACK", 13, 6, 2);








        public override void Update()
        {
            
        }

        public override void Draw()
        {
            
            ButtonSeries.UpdateSeries(2,1);
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
