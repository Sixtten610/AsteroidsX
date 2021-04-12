using System;
using Raylib_cs;
using System.Collections.Generic;

namespace Asteroids
{
    public class SinglePlayerGame : ObjectGame
    {
        RegularSpaceship regularSpaceship;
        UserInterface userInterface = new UserInterface();
        private int time = 0;


        public SinglePlayerGame()
        {
            regularSpaceship = new RegularSpaceship(1, KeyboardKey.KEY_W, KeyboardKey.KEY_S, KeyboardKey.KEY_A, KeyboardKey.KEY_D, KeyboardKey.KEY_LEFT, KeyboardKey.KEY_RIGHT, KeyboardKey.KEY_SPACE);
        }

        public override void Update()
        {
            userInterface.UpdateUI();

            if (regularSpaceship.Shoot())
            {
                Lazer lazer = new Lazer
                (
                    regularSpaceship.TriangleX, regularSpaceship.TriangleY, 
                    regularSpaceship.TriangleV, regularSpaceship.TriangleR, regularSpaceship.Damage, regularSpaceship.GetID
                );
            }

            if (time == 10)
            {
                Asteroid asteroid = new Asteroid();
                time = 0;
            }
            else
            {
                time++;
            }
            System.Console.WriteLine(regularSpaceship.GetScore);
            
            base.Update();
        }
        public override void Draw()
        {
            base.Draw();
            userInterface.DrawUI();
        }
    }
}
