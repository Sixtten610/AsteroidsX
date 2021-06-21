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
        private int selectedButton = ButtonSeries.GetSelectedButtonID(1);
        private int spaceShipScore;
        private int[] time = new int[7];
        private int wave = 1;
        private int createdSpaceShip;
        private bool createSinglePlayerShip = true;


        public void CreateSinglePlayerShip()
        {
            for (int i = 0; i < 4; i++)
            {
                if (selectedButton == i)
                {
                    createdSpaceShip = i;     
                }
            }

            if (createSinglePlayerShip)
            {
                switch (selectedButton)
                {
                    case 0:
                    {
                        regularSpaceship = new RegularSpaceship(1, KeyboardKey.KEY_W, KeyboardKey.KEY_S, KeyboardKey.KEY_A, KeyboardKey.KEY_D, KeyboardKey.KEY_LEFT, KeyboardKey.KEY_RIGHT, KeyboardKey.KEY_SPACE); 
                    }
                    break;
                    case 1:
                    {
                        scoutSpaceship = new ScoutSpaceship(1, KeyboardKey.KEY_W, KeyboardKey.KEY_S, KeyboardKey.KEY_A, KeyboardKey.KEY_D, KeyboardKey.KEY_LEFT, KeyboardKey.KEY_RIGHT, KeyboardKey.KEY_SPACE);
                    }
                    break;
                    case 2:
                    {
                        heavySpaceship = new HeavySpaceship(1, KeyboardKey.KEY_W, KeyboardKey.KEY_S, KeyboardKey.KEY_A, KeyboardKey.KEY_D, KeyboardKey.KEY_LEFT, KeyboardKey.KEY_RIGHT, KeyboardKey.KEY_SPACE);
                    }
                    break;
                    case 3:
                    {
                        sniperSpaceship = new SniperSpaceship(1, KeyboardKey.KEY_W, KeyboardKey.KEY_S, KeyboardKey.KEY_A, KeyboardKey.KEY_D, KeyboardKey.KEY_LEFT, KeyboardKey.KEY_RIGHT, KeyboardKey.KEY_SPACE, 20);
                    }
                    break;
                }
                createSinglePlayerShip = false;

            }
        }

        public override void Update()
        {
            userInterface.UpdateUI();
            spaceShipScore = Spaceship.GetSpaceshipScore(1);

            switch (createdSpaceShip)
            {
                case 0:
                {
                    if (!regularSpaceship.IsSpaceshipAlive)
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
                break;
                case 1:
                {
                    if (!scoutSpaceship.IsSpaceshipAlive)
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
                break;
                case 2:
                {
                    if (!heavySpaceship.IsSpaceshipAlive)
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
                break;
                case 3:
                {
                    if (!sniperSpaceship.IsSpaceshipAlive)
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
                break;
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

            if (spaceShipScore >= 20000)
            {
                if (time[6] == 0)
                {
                    time[6] = 20000 - spaceShipScore / 10;
                }
                else
                {
                    time[6]--;
                }
                
                if (ButtonSeries.GetSelectedButtonID(2) == 4)
                {
                    wave = 7;    
                }
                else
                {
                    wave = 6;
                }
                
                int t = time[6];
                switch (t)
                {
                    case 1:
                    {
                        for (int i = 0; i < 200; i++)
                        {    
                            Asteroid asteroid = new Asteroid();
                        }
                    }
                    break;
                    case 2000:
                    {
                        for (int i = 0; i < 3; i++)
                        {
                            MissileAsteroid missileAsteroid = new MissileAsteroid();
                        }
                    }
                    break;
                    case 4000:
                    {
                        for (int i = 0; i < 5; i++)
                        {
                            ScatterAsteroid scatterAsteroid = new ScatterAsteroid();
                        }
                    }
                    break;
                    case 6000:
                    {
                        for (int i = 0; i < 3; i++)
                        {
                            MissileScatterAsteroid missileScatterAsteroid = new MissileScatterAsteroid();
                        }
                    }
                    break;
                    case 8000:
                    {
                        for (int i = 0; i < 4; i++)
                        {
                            MissileScatterAsteroidMissile missileScatterAsteroidMissile = new MissileScatterAsteroidMissile();
                        }
                    }
                    break;
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
