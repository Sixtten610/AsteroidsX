using System;
using Raylib_cs;

namespace Asteroids
{
    public class PauseScreen : ObjectScreen
    {
        // BUTTONS 
        ButtonSingle mainMenu = new ButtonSingle(45, 300, 35, Color.WHITE, Color.WHITE, Color.LIGHTGRAY, 350, 400, "MAIN MENU", 50, 6, 6);
        ButtonSingle quit = new ButtonSingle(45, 300, 35, Color.WHITE, Color.WHITE, Color.LIGHTGRAY, 350, 450, "QUIT", 106, 6, 6);

        // är spelet pausat?
        private bool paused = false;


        public bool isPaused()
        {
            if (paused)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public override void Update()
        {
            if (quit.IsPressed())
            {
                Environment.Exit(0);
            }

            if (paused)
            {
                isPaused();
            }
            else if (Raylib.IsKeyReleased(KeyboardKey.KEY_P))
            {
                paused = !paused;
            }

        }
        public new void Draw()
        {
            Raylib.DrawRectangleGradientV(300, 300, 500, 400, Color.WHITE, ButtonSeries.GetSelectedColor(3));
            Button.DrawAll(6);
        }

        public bool isMainMenuPressed
        {
            get
            {
                return mainMenu.IsPressed();
            }
        }
    }
}
