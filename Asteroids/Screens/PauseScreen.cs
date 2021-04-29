using System;
using Raylib_cs;

namespace Asteroids
{
    public class PauseScreen : ObjectScreen
    {
        // BUTTONS 
        ButtonSingle resumeGame = new ButtonSingle(45, 300, 35, Color.WHITE, Color.WHITE, Color.LIGHTGRAY, 350, 400, "RESUME GAME", 23, 6, 6);
        ButtonSingle mainMenu = new ButtonSingle(45, 300, 35, Color.WHITE, Color.WHITE, Color.LIGHTGRAY, 350, 450, "MAIN MENU", 50, 6, 6);
        ButtonSingle quit = new ButtonSingle(45, 300, 35, Color.WHITE, Color.WHITE, Color.LIGHTGRAY, 350, 500, "QUIT", 106, 6, 6);

        // är spelet pausat?
        private bool paused = false;
        


        public bool GetIfPaused
        {
            get
            {
                return paused;
            }
        }

        public void isPaused()
        {
            if (Raylib.IsKeyPressed(KeyboardKey.KEY_P))
            {
                paused = true;
            }
        }

        public override void Update()
        {
            if (resumeGame.IsPressed())
            {
                paused = false;
            }
            else if (quit.IsPressed())
            {
                Environment.Exit(0);
            }
        }
        public new void Draw()
        {
            Raylib.DrawRectangleGradientV(300, 300, 400, 400, ButtonSeries.GetSelectedColor(3), new Color(0,0,0,0));
            Button.DrawAll(6);
            Raylib.DrawText("Pause", 410, 330, 60, Color.BLACK);
        }

        public bool isMainMenuPressed()
        {
            if (mainMenu.IsPressed())
            {
                paused = false;
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
