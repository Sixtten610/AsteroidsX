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

            SinglePlayerGame singlePlayerGame = new SinglePlayerGame();

            EndScreen endScreen = new EndScreen();

            GameState screen = GameState.title;

            bool restartGames = true;

            while (!Raylib.WindowShouldClose())
            {
                if (restartGames)
                {
                    singlePlayerGame = new SinglePlayerGame();
                    restartGames = false;
                }

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
                    singlePlayerGame.CreateSinglePlayerShip();
                    singlePlayerGame.Update();
                    singlePlayerGame.Draw();
                    
                    if (!singlePlayerGame.ContinueGame)
                    {
                        screen = GameState.end;
                    }
                }
                else if (screen == GameState.end)
                {
                    endScreen.Update();
                    endScreen.Draw();

                    if(endScreen.isMainMenuPressed)
                    {
                        screen = GameState.title;
                        restartGames = true;
                    }
                }

                Raylib.EndDrawing();
            }

        }
    }
}
