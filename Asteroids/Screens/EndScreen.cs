using System;
using Raylib_cs;

namespace Asteroids
{
    public class EndScreen : ObjectScreen
    {
        // BUTTONS ###########################################
        ButtonSingle mainMenu = new ButtonSingle(45, 300, 35, Color.WHITE, Color.WHITE, Color.LIGHTGRAY, 350, 400, "MAIN MENU", 50, 6, 4);
        ButtonSingle quit = new ButtonSingle(45, 300, 35, Color.WHITE, Color.WHITE, Color.LIGHTGRAY, 350, 450, "QUIT", 106, 6, 4);


        public override void Update()
        {
            if (quit.IsPressed())
            {
                Environment.Exit(0);
            }
        }

        public override void Draw()
        {
            Raylib.DrawText("DEFEAT", 400, 250, 50, Color.WHITE);

            // Raylib.DrawText("TOTAL SCORE:", 350, 350, 20, Color.WHITE);

            // Raylib.DrawText(Spaceship.GetSpaceshipScore(1).ToString(), 510, 350, 20, ButtonSeries.GetSelectedColor(3));

            Button.DrawAll(4);
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
