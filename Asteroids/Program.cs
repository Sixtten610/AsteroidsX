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
            singlePlayer,
            multiPlayer,
            singlePlayerGame,
            multiPlayerGame,
            end
        }
        
        static void Main(string[] args)
        {
            Raylib.InitWindow(1000, 1000, "Asteroids");
            Raylib.SetTargetFPS(60);

            TitleScreen titleScreen = new TitleScreen();

            DifficultyScreen difficultyScreen = new DifficultyScreen();

            SinglePlayer singlePlayer = new SinglePlayer();

            EndScreen endScreen = new EndScreen();

            GameState screen = GameState.title;

            SinglePlayerGame singlePlayerGame = new SinglePlayerGame();


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
                        screen = GameState.singlePlayer;
                    }
                    else if (titleScreen.isMultiPlayerPressed)
                    {
                        screen = GameState.multiPlayer;
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
                else if (screen == GameState.singlePlayer)
                {
                    singlePlayer.Update();
                    singlePlayer.Draw();
                    
                    if (singlePlayer.isBackPressed)
                    {
                        screen = GameState.title;
                    }
                    else if (singlePlayer.isPlayPressed)
                    {
                        screen = GameState.singlePlayerGame;
                    }
                }
                else if (screen == GameState.singlePlayerGame)
                {
                    singlePlayerGame.Update();
                    singlePlayerGame.Draw();
                }
                else if (screen == GameState.end)
                {
                    
                }

                Raylib.EndDrawing();
            }

        }
    }
}
