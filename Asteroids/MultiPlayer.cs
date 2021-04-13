using System;
using Raylib_cs;

namespace Asteroids
{
    public class MultiPlayer : ObjectScreen
    {
        // BUTTONS ###########################################

        // PLAYER 1

        ButtonSeries scout1 = new ButtonSeries(45, 200, 35, Color.WHITE, Color.WHITE, Color.LIGHTGRAY, 100, 400, "SCOUT", 16, 6, 5, 4, 1, 0);
        ButtonSeries fighter1 = new ButtonSeries(45, 200, 35, Color.WHITE, Color.WHITE, Color.LIGHTGRAY, 100, 450, "FIGHTER", 16, 6, 5, 4, 0, 0);
        ButtonSeries heavy1 = new ButtonSeries(45, 200, 35, Color.WHITE, Color.WHITE, Color.LIGHTGRAY, 100, 500, "HEAVY", 16, 6, 5, 4, 2, 0);

        ButtonSeries lite1 = new ButtonSeries(100, 100, 35, Color.WHITE, Color.WHITE, Color.LIGHTGRAY, 100, 600, "LITE", 10, 30, 5, 4, 0, 0);
        ButtonSeries blue1 = new ButtonSeries(100, 100, 35, Color.BLUE, Color.BLUE, Color.LIGHTGRAY, 220, 600, "BLUE", 5, 30, 5, 4, 1, 0);
        ButtonSeries red1 = new ButtonSeries(100, 100, 35, Color.RED, Color.RED, Color.LIGHTGRAY, 340, 600, "RED", 16, 30, 5, 4, 2, 0);

        // PLAYER 2

        ButtonSeries scout2 = new ButtonSeries(45, 200, 35, Color.WHITE, Color.WHITE, Color.LIGHTGRAY, 700, 400, "SCOUT", 16, 6, 5, 5, 1, 0);
        ButtonSeries fighter2 = new ButtonSeries(45, 200, 35, Color.WHITE, Color.WHITE, Color.LIGHTGRAY, 700, 450, "FIGHTER", 16, 6, 5, 5, 0, 0);
        ButtonSeries heavy2 = new ButtonSeries(45, 200, 35, Color.WHITE, Color.WHITE, Color.LIGHTGRAY, 700, 500, "HEAVY", 16, 6, 5, 5, 2, 0);

        ButtonSeries lite2 = new ButtonSeries(100, 100, 35, Color.WHITE, Color.WHITE, Color.LIGHTGRAY, 100, 600, "LITE", 10, 30, 5, 5, 0, 0);
        ButtonSeries yellow2 = new ButtonSeries(100, 100, 35, Color.YELLOW, Color.YELLOW, Color.LIGHTGRAY, 220, 600, "GOLD", 5, 30, 5, 5, 1, 0);
        ButtonSeries green2 = new ButtonSeries(100, 100, 35, Color.GREEN, Color.GREEN, Color.LIGHTGRAY, 340, 600, "GREEN", 5, 30, 5, 5, 2, 0);

        Button play = new ButtonSingle(300, 300, 70, Color.WHITE, Color.WHITE, Color.LIGHTGRAY, 600, 400, "PLAY", 60, 110, 5);
        Button back = new ButtonSingle(45, 120, 35, Color.WHITE, Color.WHITE, Color.LIGHTGRAY, 50, 850, "BACK", 13, 6, 5);



        public override void Update()
        {
            ButtonSeries.UpdateSeries(4);
            ButtonSeries.UpdateSeries(5);
        }    

        public override void Draw()
        {
            Raylib.DrawText("MULTIPLAYER", 375, 250, 40, Color.WHITE);

            DrawStats(0);

            DrawStats(600);


            Button.DrawAll(5);
        }
        private void DrawStats(int margin)
        {
            Raylib.DrawText("SPEED", margin + 310, 400, 15, Color.WHITE);
            Raylib.DrawText("...", margin + 380, 332, 100, Color.WHITE);
            Raylib.DrawText("DAMAGE", margin + 310, 430, 15, Color.WHITE);
            Raylib.DrawText(".", margin + 380, 362, 100, Color.WHITE);

            Raylib.DrawText("SPEED", margin + 310, 450, 15, Color.WHITE);
            Raylib.DrawText("..", margin + 380, 382, 100, Color.WHITE);
            Raylib.DrawText("DAMAGE", margin + 310, 480, 15, Color.WHITE);
            Raylib.DrawText("..", margin + 380, 412, 100, Color.WHITE);

            Raylib.DrawText("SPEED", margin + 310, 500, 15, Color.WHITE);
            Raylib.DrawText(".", margin + 380, 432, 100, Color.WHITE);
            Raylib.DrawText("DAMAGE", margin + 310, 530, 15, Color.WHITE);
            Raylib.DrawText("...", margin + 380, 462, 100, Color.WHITE);
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
