using System;
using Raylib_cs;

namespace Asteroids
{
    public class SinglePlayerScreen : ObjectScreen
    {
        // BUTTONS ###########################################

        ButtonSeries scout = new ButtonSeries(45, 200, 35, Color.WHITE, Color.WHITE, Color.LIGHTGRAY, 100, 400, "SCOUT", 16, 6, 3, 1, 1, 0);
        ButtonSeries fighter = new ButtonSeries(45, 200, 35, Color.WHITE, Color.WHITE, Color.LIGHTGRAY, 100, 450, "FIGHTER", 16, 6, 3, 1, 0, 0);
        ButtonSeries heavy = new ButtonSeries(45, 200, 35, Color.WHITE, Color.WHITE, Color.LIGHTGRAY, 100, 500, "HEAVY", 16, 6, 3, 1, 2, 0);

        ButtonSeries lite = new ButtonSeries(100, 100, 35, Color.WHITE, Color.WHITE, Color.LIGHTGRAY, 100, 600, "LITE", 10, 33, 3, 3, 0, 0);
        ButtonSeries blue = new ButtonSeries(100, 100, 35, Color.BLUE, Color.BLUE, Color.SKYBLUE, 220, 600, "BLUE", 5, 33, 3, 3, 1, 0);
        ButtonSeries red = new ButtonSeries(100, 100, 35, Color.RED, Color.RED, Color.PINK, 340, 600, "RED", 16, 33, 3, 3, 2, 0);

        Button play = new ButtonSingle(300, 300, 70, Color.WHITE, Color.WHITE, Color.LIGHTGRAY, 600, 400, "PLAY", 60, 110, 3);
        Button back = new ButtonSingle(45, 120, 35, Color.WHITE, Color.WHITE, Color.LIGHTGRAY, 50, 850, "BACK", 13, 6, 3);
        


        public override void Update()
        {
            ButtonSeries.UpdateSeries(1);
            ButtonSeries.UpdateSeries(3);
        }
        public override void Draw()
        {
            Raylib.DrawText("SINGLEPLAYER", 375, 250, 40, Color.WHITE);

            Raylib.DrawText("SPEED", 310, 400, 15, Color.WHITE);
            Raylib.DrawText("...", 380, 332, 100, Color.WHITE);
            Raylib.DrawText("DAMAGE", 310, 430, 15, Color.WHITE);
            Raylib.DrawText(".", 380, 362, 100, Color.WHITE);

            Raylib.DrawText("SPEED", 310, 450, 15, Color.WHITE);
            Raylib.DrawText("..", 380, 382, 100, Color.WHITE);
            Raylib.DrawText("DAMAGE", 310, 480, 15, Color.WHITE);
            Raylib.DrawText("..", 380, 412, 100, Color.WHITE);

            Raylib.DrawText("SPEED", 310, 500, 15, Color.WHITE);
            Raylib.DrawText(".", 380, 432, 100, Color.WHITE);
            Raylib.DrawText("DAMAGE", 310, 530, 15, Color.WHITE);
            Raylib.DrawText("...", 380, 462, 100, Color.WHITE);

            Button.DrawAll(3);
        }

        public bool isPlayPressed
        {
            get
            {
                return play.IsPressed();
            }
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
