using System.Numerics;
using System;
using Raylib_cs;

namespace Asteroids
{
    public class TitleScreen : ObjectScreen
    {
        // BUTTONS ###########################################
        Button singlePlayer = new Button(45, 300, 35, Color.WHITE, Color.WHITE, Color.LIGHTGRAY, 350, 400, "SINGLEPLAYER", 16, 6);
        Button multiPlayer = new Button(45, 300, 35, Color.WHITE, Color.WHITE, Color.LIGHTGRAY, 350, 450, "MULTIPLAYER", 26, 6);
        Button difficulty = new Button(45, 300, 35, Color.WHITE, Color.WHITE, Color.LIGHTGRAY, 350, 500, "DIFFICULTY", 42, 6);
        Button settings = new Button(45, 300, 35, Color.WHITE, Color.WHITE, Color.LIGHTGRAY, 350, 550, "SETTINGS", 56, 6);
        Button quit = new Button(45, 300, 35, Color.WHITE, Color.WHITE, Color.LIGHTGRAY, 350, 600, "QUIT", 106, 6);
        


        public override void Update()
        {
            
        }

        public override void Draw()
        {
            Raylib.DrawText("ASTEROIDS II", 325, 250, 50, Color.WHITE);

            Button.DrawAll();

            if ()
        }
        
    }
}
