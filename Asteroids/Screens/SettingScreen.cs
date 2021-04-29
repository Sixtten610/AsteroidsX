using System;
using Raylib_cs;

namespace Asteroids
{
    public class SettingScreen : ObjectScreen
    {
        Button back = new ButtonSingle(45, 120, 35, Color.WHITE, Color.WHITE, Color.LIGHTGRAY, 50, 850, "BACK", 13, 7, 3);





        public bool isBackPressed
        {
            get
            {
                return back.IsPressed();
            }
        }   
    }
}
