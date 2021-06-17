using System;
using Raylib_cs;

namespace Asteroids
{
    public class MultiPlayerScreen : ObjectScreen
    {
        // BUTTONS ###########################################

        // PLAYER 1

        ButtonSeries scout1 = new ButtonSeries(45, 200, 35, Color.WHITE, Color.WHITE, Color.LIGHTGRAY, 100, 400, "SCOUT", 16, 6, 5, 4, 1, 0);
        ButtonSeries fighter1 = new ButtonSeries(45, 200, 35, Color.WHITE, Color.WHITE, Color.LIGHTGRAY, 100, 450, "FIGHTER", 16, 6, 5, 4, 0, 0);
        ButtonSeries heavy1 = new ButtonSeries(45, 200, 35, Color.WHITE, Color.WHITE, Color.LIGHTGRAY, 100, 500, "HEAVY", 16, 6, 5, 4, 2, 0);
        ButtonSeries sniper1 = new ButtonSeries(45, 200, 35, Color.WHITE, Color.WHITE, Color.LIGHTGRAY, 100, 550, "SNIPER", 16, 6, 5, 4, 3, 0);

        ButtonSeries lite1 = new ButtonSeries(100, 100, 35, Color.WHITE, Color.WHITE, Color.LIGHTGRAY, 100, 600, "LITE", 10, 30, 5, 5, 0, 0);
        ButtonSeries blue1 = new ButtonSeries(100, 100, 35, Color.DARKBLUE, Color.DARKBLUE, Color.BLUE, 226, 600, "BLUE", 5, 30, 5, 5, 1, 0);
        ButtonSeries red1 = new ButtonSeries(100, 100, 35, Color.MAROON, Color.MAROON, Color.RED, 352, 600, "RED", 16, 30, 5, 5, 2, 0);




        // PLAYER 2

        ButtonSeries scout2 = new ButtonSeries(45, 200, 35, Color.WHITE, Color.WHITE, Color.LIGHTGRAY, 700, 400, "SCOUT", 16, 6, 5, 6, 1, 0);
        ButtonSeries fighter2 = new ButtonSeries(45, 200, 35, Color.WHITE, Color.WHITE, Color.LIGHTGRAY, 700, 450, "FIGHTER", 16, 6, 5, 6, 0, 0);
        ButtonSeries heavy2 = new ButtonSeries(45, 200, 35, Color.WHITE, Color.WHITE, Color.LIGHTGRAY, 700, 500, "HEAVY", 16, 6, 5, 6, 2, 0);
        ButtonSeries sniper2 = new ButtonSeries(45, 200, 35, Color.WHITE, Color.WHITE, Color.LIGHTGRAY, 700, 550, "SNIPER", 16, 6, 5, 6, 3, 0);

        ButtonSeries lite2 = new ButtonSeries(100, 100, 35, Color.WHITE, Color.WHITE, Color.LIGHTGRAY, 548, 600, "LITE", 10, 30, 5, 7, 0, 0);
        ButtonSeries skyblue2 = new ButtonSeries(100, 100, 35, Color.DARKGREEN, Color.DARKGREEN, Color.LIME, 674, 600, "LIME", 9, 30, 5, 7, 1, 0);
        ButtonSeries purple2 = new ButtonSeries(100, 100, 35, Color.VIOLET, Color.VIOLET, Color.PURPLE, 800, 600, "LONE", 5, 30, 5, 7, 2, 0);

        Button play = new ButtonSingle(300, 300, 70, Color.WHITE, Color.WHITE, Color.LIGHTGRAY, 10000, 400, "PLAY", 60, 110, 5);
        Button back = new ButtonSingle(45, 120, 35, Color.WHITE, Color.WHITE, Color.LIGHTGRAY, 50, 850, "BACK", 13, 6, 5);



        public override void Update()
        {
            ButtonSeries.UpdateSeries(4);
            ButtonSeries.UpdateSeries(5);
            ButtonSeries.UpdateSeries(6);
            ButtonSeries.UpdateSeries(7);
        }    

        public override void Draw()
        {
            Raylib.DrawText("MULTIPLAYER", 350, 250, 40, Color.WHITE);

            Raylib.DrawText("P1", 264, 350, 40, Color.WHITE);

            Raylib.DrawText("P2", 700, 350, 40, Color.WHITE);

            DrawStats(0);

            DrawStats(600);


            Button.DrawAll(5);
        }
        private void DrawStats(int margin)
        {   
            // Player 1

            Raylib.DrawText("SPEED", 310, 400, 15, Color.WHITE);
            Raylib.DrawText("....", 380, 332, 100, Color.WHITE);
            Raylib.DrawText("DAMAGE", 310, 430, 15, Color.WHITE);
            Raylib.DrawText(".", 380, 362, 100, Color.WHITE);

            Raylib.DrawLine(310, 447, 453, 447, Color.WHITE);

            Raylib.DrawText("SPEED", 310, 450, 15, Color.WHITE);
            Raylib.DrawText("...", 380, 382, 100, Color.WHITE);
            Raylib.DrawText("DAMAGE", 310, 480, 15, Color.WHITE);
            Raylib.DrawText("..", 380, 412, 100, Color.WHITE);

            Raylib.DrawLine(310, 497, 453, 497, Color.WHITE);

            Raylib.DrawText("SPEED", 310, 500, 15, Color.WHITE);
            Raylib.DrawText(".", 380, 432, 100, Color.WHITE);
            Raylib.DrawText("DAMAGE", 310, 530, 15, Color.WHITE);
            Raylib.DrawText("...", 380, 462, 100, Color.WHITE);

            Raylib.DrawLine(310, 547, 453, 547, Color.WHITE);

            Raylib.DrawText("SPEED", 310, 550, 15, Color.WHITE);
            Raylib.DrawText("...", 380, 482, 100, Color.WHITE);
            Raylib.DrawText("DAMAGE", 310, 580, 15, Color.WHITE);
            Raylib.DrawText("....", 380, 512, 100, Color.WHITE);

            // Player 2

            Raylib.DrawText("SPEED", 548, 400, 15, Color.WHITE);
            Raylib.DrawText("....", 618, 332, 100, Color.WHITE);
            Raylib.DrawText("DAMAGE", 548, 430, 15, Color.WHITE);
            Raylib.DrawText(".", 618, 362, 100, Color.WHITE);

            Raylib.DrawLine(548, 447, 691, 447, Color.WHITE);

            Raylib.DrawText("SPEED", 548, 450, 15, Color.WHITE);
            Raylib.DrawText("...", 618, 382, 100, Color.WHITE);
            Raylib.DrawText("DAMAGE", 548, 480, 15, Color.WHITE);
            Raylib.DrawText("..", 618, 412, 100, Color.WHITE);

            Raylib.DrawLine(548, 497, 691, 497, Color.WHITE);

            Raylib.DrawText("SPEED", 548, 500, 15, Color.WHITE);
            Raylib.DrawText(".", 618, 432, 100, Color.WHITE);
            Raylib.DrawText("DAMAGE", 548, 530, 15, Color.WHITE);
            Raylib.DrawText("...", 618, 462, 100, Color.WHITE);

            Raylib.DrawLine(548, 547, 691, 547, Color.WHITE);

            Raylib.DrawText("SPEED", 548, 550, 15, Color.WHITE);
            Raylib.DrawText("...", 618, 482, 100, Color.WHITE);
            Raylib.DrawText("DAMAGE", 548, 580, 15, Color.WHITE);
            Raylib.DrawText("....", 618, 512, 100, Color.WHITE);
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
