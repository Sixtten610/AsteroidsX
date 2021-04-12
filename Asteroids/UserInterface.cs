using System.Collections.Generic;
using System.Numerics;
using System;
using Raylib_cs;

namespace Asteroids
{
    public class UserInterface
    {
        UserInterfaceKey a = new UserInterfaceKey(30, 910, KeyboardKey.KEY_A, "A", 3);
        UserInterfaceKey s = new UserInterfaceKey(90, 910, KeyboardKey.KEY_S, "S", 3);
        UserInterfaceKey d = new UserInterfaceKey(150, 910, KeyboardKey.KEY_D, "D", 3);
        UserInterfaceKey w = new UserInterfaceKey(90, 850, KeyboardKey.KEY_W, "W", 3);
        UserInterfaceKey rotL = new UserInterfaceKey(230, 910, KeyboardKey.KEY_LEFT, "<", 3);
        UserInterfaceKey rotR = new UserInterfaceKey(290, 910, KeyboardKey.KEY_RIGHT, ">", 3);
        UserInterfaceKey space = new UserInterfaceKey(370, 910, KeyboardKey.KEY_SPACE, "_", 3);



        public void UpdateUI()
        {
            UserInterfaceKey.UpdateAll();
        }
        public void DrawUI()
        {
            Raylib.DrawText("SCORE:", 30, 28, 35, ButtonSeries.GetSelectedColor(3));
            Raylib.DrawText(Spaceship.GetSpaceshipScore(1).ToString(), 180, 28, 35, ButtonSeries.GetSelectedColor(3));

            UserInterfaceKey.DrawAll();
        }
    }
}
