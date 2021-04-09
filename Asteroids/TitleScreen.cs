using System.Numerics;
using System;
using Raylib_cs;

namespace Asteroids
{
    public class TitleScreen : ObjectScreen
    {
        // BUTTONS ###########################################
        ButtonSingle singlePlayer = new ButtonSingle(45, 300, 35, Color.WHITE, Color.WHITE, Color.LIGHTGRAY, 350, 400, "SINGLEPLAYER", 16, 6, 1);
        ButtonSingle multiPlayer = new ButtonSingle(45, 300, 35, Color.WHITE, Color.WHITE, Color.LIGHTGRAY, 350, 450, "MULTIPLAYER", 26, 6, 1);
        ButtonSingle difficulty = new ButtonSingle(45, 300, 35, Color.WHITE, Color.WHITE, Color.LIGHTGRAY, 350, 500, "DIFFICULTY", 42, 6, 1);
        ButtonSingle settings = new ButtonSingle(45, 300, 35, Color.WHITE, Color.WHITE, Color.LIGHTGRAY, 350, 550, "SETTINGS", 56, 6, 1);
        ButtonSingle quit = new ButtonSingle(45, 300, 35, Color.WHITE, Color.WHITE, Color.LIGHTGRAY, 350, 600, "QUIT", 106, 6, 1);
        


        public override void Update()
        {
            if (quit.IsPressed())
            {
                Environment.Exit(0);
            }
        }

        public override void Draw()
        {
            Raylib.DrawText("ASTEROIDS II", 325, 250, 50, Color.WHITE);

            Button.DrawAll(1);
        }

        public bool isSinglePlayerPressed
        {
            get
            {
                return singlePlayer.IsPressed();
            }
        }
        public bool isMultiPlayerPressed
        {
            get
            {
                return multiPlayer.IsPressed();
            }
        }
        public bool isDifficultyPressed
        {
            get
            {
                return difficulty.IsPressed();
            }
        }


        
    }
}
