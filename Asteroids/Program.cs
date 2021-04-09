using System;
using Raylib_cs;

namespace Asteroids
{
    
    
    class Program
    {
        enum GameState
        {                
            title,
            game,
            end
        }
        
        static void Main(string[] args)
        {
            Raylib.InitWindow(1000, 1000, "Asteroids");
            Raylib.SetTargetFPS(60);

            TitleScreen titleScreen = new TitleScreen();

            Game game = new Game();

            EndScreen endScreen = new EndScreen();

            GameState screen = GameState.title;

            while (!Raylib.WindowShouldClose())
            {
                Raylib.BeginDrawing();
                Raylib.ClearBackground(Color.BLACK);

                if (screen == GameState.title)
                {
                    
                }
                else if (screen == GameState.game)
                {
                    
                }
                else if (screen == GameState.end)
                {
                    
                }

                Raylib.EndDrawing();
            }
        }
    }
}
