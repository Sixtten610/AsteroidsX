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

            PauseScreen pauseScreen = new PauseScreen();

            DifficultyScreen difficultyScreen = new DifficultyScreen();

            SinglePlayer singlePlayer = new SinglePlayer();

            SinglePlayerGame singlePlayerGame = new SinglePlayerGame();

            MultiPlayer multiPlayer = new MultiPlayer();

            EndScreen endScreen = new EndScreen();

            GameState screen = GameState.title;

            bool restartGames = false;

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
                    singlePlayerGame.CreateSinglePlayerShip();
                    singlePlayerGame.Update();
                    singlePlayerGame.Draw();
                    
                    if (!singlePlayerGame.ContinueGame)
                    {
                        screen = GameState.end;
                    }
                }
                else if (screen == GameState.multiPlayer)
                {
                    multiPlayer.Update();
                    multiPlayer.Draw();

                    if (multiPlayer.isBackPressed)
                    {
                        screen = GameState.title;
                    }
                    else if (multiPlayer.isPlayPressed)
                    {
                        screen = GameState.multiPlayerGame;
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

                if (restartGames)
                {
                    ObjectGame.Clear();
                    singlePlayerGame = new SinglePlayerGame();
                    restartGames = false;
                }

                Raylib.EndDrawing();
            }

        }
    }
}
