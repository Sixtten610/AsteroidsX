using System;
using Raylib_cs;

namespace Asteroids
{
    class Program
    {
        enum GameState
        {                
            title,
            difficulty,
            settings,
            game1,
            game2,
            end
        }
        
        static void Main(string[] args)
        {
            Raylib.InitWindow(1000, 1000, "Asteroids");
            Raylib.SetTargetFPS(60);

            TitleScreen titleScreen = new TitleScreen();

            DifficultyScreen difficultyScreen = new DifficultyScreen();

            EndScreen endScreen = new EndScreen();

            GameState screen = GameState.title;

            

            while (!Raylib.WindowShouldClose())
            {
                Raylib.BeginDrawing();
                Raylib.ClearBackground(Color.BLACK);

                if (screen == GameState.title)
                {
                    titleScreen.Update();
                    titleScreen.Draw();

                    if(titleScreen.isSinglePlayerPressed)
                    {
                        screen = GameState.game1;
                    }
                    else if (titleScreen.isMultiPlayerPressed)
                    {

                    }
                    else if (titleScreen.isDifficultyPressed)
                    {
                        screen = GameState.difficulty;
                    }

                    
                }
                else if (screen == GameState.difficulty)
                {
                    difficultyScreen.Update();
                    difficultyScreen.Draw();

                    if (difficultyScreen.isBackPressed)
                    {
                        screen = GameState.title;
                    }
                    
                }
                else if (screen == GameState.end)
                {
                    
                }

                Raylib.EndDrawing();
            }

        }
    }
}
