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
            // skapar en 1000x1000 pixel ruta
            Raylib.InitWindow(1000, 1000, "Asteroids");
            Raylib.SetTargetFPS(60);
            
            // enum för gamestates
            GameState screen = GameState.title;

            // de olika skärmarna som man kan navigera
            TitleScreen titleScreen = new TitleScreen();

            PauseScreen pauseScreen = new PauseScreen();

            DifficultyScreen difficultyScreen = new DifficultyScreen();

            SettingScreen settingScreen = new SettingScreen();

            SinglePlayerScreen singlePlayerScreen = new SinglePlayerScreen();

            EndScreen endScreen = new EndScreen();

            MultiPlayer multiPlayer = new MultiPlayer();

            // single-player spel
            SinglePlayerGame singlePlayerGame = new SinglePlayerGame();

            bool restartGames = false;

            // spel loop
            while (!Raylib.WindowShouldClose())
            {
                Raylib.BeginDrawing();
                Raylib.ClearBackground(Color.BLACK);
                
                // if [..] if else för vilken spelskärm som ska visas
                // skärmarna har Uppdate och Draw metoder, samt knappar för att
                // reagera med annat UI i prog.cs
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
                    else if (titleScreen.isSettingsPressed)
                    {
                        screen = GameState.settings;
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
                    singlePlayerScreen.Update();
                    singlePlayerScreen.Draw();
                    
                    if (singlePlayerScreen.isBackPressed)
                    {
                        screen = GameState.title;
                    }
                    else if (singlePlayerScreen.isPlayPressed)
                    {
                        screen = GameState.singlePlayerGame;
                    }
                }
                else if (screen == GameState.singlePlayerGame)
                {
                    pauseScreen.isPaused();

                    if (pauseScreen.GetIfPaused)
                    {

                        pauseScreen.Update();
                        pauseScreen.Draw();

                        if (pauseScreen.isMainMenuPressed())
                        {
                            screen = GameState.title;
                            restartGames = true;
                        }
                    }
                    else
                    {
                        singlePlayerGame.CreateSinglePlayerShip();
                        singlePlayerGame.Update();
                        singlePlayerGame.Draw();

                        if (!singlePlayerGame.ContinueGame)
                        {
                            screen = GameState.end;
                        }
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
                else if (screen == GameState.settings)
                {
                    settingScreen.Update();
                    settingScreen.Draw();

                    if (singlePlayerScreen.isBackPressed)
                    {
                        screen = GameState.title;
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

                // skapar nytt spel om metoden kallas
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
