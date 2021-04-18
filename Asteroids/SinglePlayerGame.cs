using System;
using Raylib_cs;
using System.Collections.Generic;

namespace Asteroids
{
    public class SinglePlayerGame : ObjectGame
    {
        RegularSpaceship regularSpaceship;
        HeavySpaceship heavySpaceship;
        ScoutSpaceship scoutSpaceship;
        UserInterface userInterface = new UserInterface();
        private int time = 0;
        private int time1 = 0;
        int createdSpaceShip;
        int wave = 1;


        private bool createSinglePlayerShip = true;
        public void CreateSinglePlayerShip()
        {
            if (ButtonSeries.GetSelectedButtonID(1) == 0)
            {
                createdSpaceShip = 0;       
            }
            else if (ButtonSeries.GetSelectedButtonID(1) == 2)
            {
                createdSpaceShip = 2;
            }
            else if (ButtonSeries.GetSelectedButtonID(1) == 1)
            {
                createdSpaceShip = 1;
            }

            if (createSinglePlayerShip)
            {
                if (ButtonSeries.GetSelectedButtonID(1) == 0)
                {
                    regularSpaceship = new RegularSpaceship(1, KeyboardKey.KEY_W, KeyboardKey.KEY_S, KeyboardKey.KEY_A, KeyboardKey.KEY_D, KeyboardKey.KEY_LEFT, KeyboardKey.KEY_RIGHT, KeyboardKey.KEY_SPACE);       
                }
                else if (ButtonSeries.GetSelectedButtonID(1) == 2)
                {
                    heavySpaceship = new HeavySpaceship(1, KeyboardKey.KEY_W, KeyboardKey.KEY_S, KeyboardKey.KEY_A, KeyboardKey.KEY_D, KeyboardKey.KEY_LEFT, KeyboardKey.KEY_RIGHT, KeyboardKey.KEY_SPACE);
                }
                else if (ButtonSeries.GetSelectedButtonID(1) == 1)
                {
                    scoutSpaceship = new ScoutSpaceship(1, KeyboardKey.KEY_W, KeyboardKey.KEY_S, KeyboardKey.KEY_A, KeyboardKey.KEY_D, KeyboardKey.KEY_LEFT, KeyboardKey.KEY_RIGHT, KeyboardKey.KEY_SPACE);
                }
                createSinglePlayerShip = false;
            }
        }

        public override void Update()
        {
            userInterface.UpdateUI();
            
            if (createdSpaceShip == 0)
                {
                    if (!regularSpaceship.isSpaceshipAlive)
                    {
                        this.isGameOn = false;
                    }
                    else if (regularSpaceship.Shoot())
                    {
                        Lazer lazer = new Lazer
                        (
                            regularSpaceship.TriangleX, regularSpaceship.TriangleY, 
                            regularSpaceship.TriangleV, regularSpaceship.TriangleR, regularSpaceship.Damage, regularSpaceship.GetID
                        );
                    }
                }
                else if (createdSpaceShip == 2)
                {
                    if (!heavySpaceship.isSpaceshipAlive)
                    {
                        this.isGameOn = false;
                    }
                    else if (heavySpaceship.Shoot())
                    {
                        Lazer lazer = new Lazer
                        (
                            heavySpaceship.TriangleX, heavySpaceship.TriangleY, 
                            heavySpaceship.TriangleV, heavySpaceship.TriangleR, heavySpaceship.Damage, heavySpaceship.GetID
                        );
                    }
                }
                else if (createdSpaceShip == 1)
                {
                    if (!scoutSpaceship.isSpaceshipAlive)
                    {
                        this.isGameOn = false;
                    }
                    else if (scoutSpaceship.Shoot())
                    {
                        Lazer lazer = new Lazer
                        (
                            scoutSpaceship.TriangleX, scoutSpaceship.TriangleY, 
                            scoutSpaceship.TriangleV, scoutSpaceship.TriangleR, scoutSpaceship.Damage, scoutSpaceship.GetID
                        );
                    }
                }
            System.Console.WriteLine(10 * (4 - ButtonSeries.GetSelectedMultiplier(2)));
            if (time >= 10 * (4 - ButtonSeries.GetSelectedMultiplier(2)))
            {
                Asteroid asteroid = new Asteroid();
                time = 0;
            }
            else
            {
                time++;
            }

            if (Spaceship.GetSpaceshipScore(1) > 3000)
            {
                wave = 2;

                if (time1 == 600)
                {
                    MissileAsteroid missileAsteroid = new MissileAsteroid();
                    time1 = 0;
                }
                else
                {
                    time1++;
                }
            }
            
            base.Update();
        }
        public override void Draw()
        {
            Raylib.DrawText("WAVE:", 450, 30, 35, Color.WHITE);
            Raylib.DrawText(wave.ToString(), 580, 30, 35, Color.WHITE);
            base.Draw();
            userInterface.DrawUI();
        }

        public bool ContinueGame
        {
            get
            {
                return isGameOn;
            }
        }
    }
}
