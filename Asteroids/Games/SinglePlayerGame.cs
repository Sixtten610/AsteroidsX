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
        SniperSpaceship sniperSpaceship;

        UserInterface userInterface = new UserInterface();

        private int spaceShipScore;
        private int[] time = new int[6];
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
            else if (ButtonSeries.GetSelectedButtonID(1) == 3)
            {
                createdSpaceShip = 3;
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
                else if (ButtonSeries.GetSelectedButtonID(1) == 3)
                {
                    sniperSpaceship = new SniperSpaceship(1, KeyboardKey.KEY_W, KeyboardKey.KEY_S, KeyboardKey.KEY_A, KeyboardKey.KEY_D, KeyboardKey.KEY_LEFT, KeyboardKey.KEY_RIGHT, KeyboardKey.KEY_SPACE, 30);
                }
                createSinglePlayerShip = false;
            }
        }

        public override void Update()
        {
            userInterface.UpdateUI();

            spaceShipScore = Spaceship.GetSpaceshipScore(1);


            
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
            else if (createdSpaceShip == 3)
            {
                if (!sniperSpaceship.isSpaceshipAlive)
                {
                    this.isGameOn = false;
                }
                else if (sniperSpaceship.Shoot())
                {
                    Lazer lazer = new Lazer
                    (
                        sniperSpaceship.TriangleX, sniperSpaceship.TriangleY, 
                        sniperSpaceship.TriangleV, sniperSpaceship.TriangleR, sniperSpaceship.Damage, sniperSpaceship.GetID
                    );
                }
            }

            if (time[0] >= 10 * (4 - ButtonSeries.GetSelectedMultiplier(2)))
            {
                Asteroid asteroid = new Asteroid();
                time[0] = 0;
            }
            else
            {
                time[0]++;
            }

            if (spaceShipScore >= 2000)
            {
                wave = 2;

                if (time[1] == 600)
                {
                    MissileAsteroid missileAsteroid = new MissileAsteroid();
                    time[1] = 0;
                }
                else
                {
                    time[1]++;
                }
            }

            if (spaceShipScore >= 4000)
            {
                wave = 3;

                if (time[2] == 1000)
                {
                    ScatterAsteroid scatterAsteroid = new ScatterAsteroid();
                    time[2] = 0;
                }
                else
                {
                    time[2]++;
                }
            }

            if (spaceShipScore >= 6000)
            {
                wave = 4;

                if (time[3] == 2000)
                {
                    MissileScatterAsteroid missileScatterAsteroid = new MissileScatterAsteroid();
                    time[3] = 0;
                }
                else
                {
                    time[3]++;
                }
            }

            if (spaceShipScore >= 8000 && ButtonSeries.GetSelectedButtonID(4) == 0)
            {
                wave = 5;

                if (time[4] == 2000)
                {
                    LimitScreen limitScreen = new LimitScreen();
                    time[4] = 0;
                }
                else
                {
                    time[4]++;
                }
            }

            if (spaceShipScore >= 10000)
            {
                if (ButtonSeries.GetSelectedButtonID(4) == 0)
                {
                    wave = 6;    
                }
                else
                {
                    wave = 5;
                }

                if (time[5] == 4000)
                {
                    MissileScatterAsteroidMissile missileScatterAsteroidMissile = new MissileScatterAsteroidMissile();
                    time[5] = 0;
                }
                else
                {
                    time[5]++;
                }
            }

            base.Update();
        }
        public override void Draw()
        {
            base.Draw();

            Raylib.DrawText("WAVE:", 450, 30, 35, Color.WHITE);
            Raylib.DrawText(wave.ToString(), 580, 30, 35, Color.WHITE);
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
