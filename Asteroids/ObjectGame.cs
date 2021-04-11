using System;
using Raylib_cs;

namespace Asteroids
{
    public class ObjectGame
    {
        public ObjectGame()
        {
            CreatePlayers();
        }

        protected virtual void CreatePlayers()
        {
            RegularSpaceship regularSpaceship = new RegularSpaceship(KeyboardKey.KEY_W, KeyboardKey.KEY_S, KeyboardKey.KEY_A, KeyboardKey.KEY_D, KeyboardKey.KEY_LEFT, KeyboardKey.KEY_RIGHT, KeyboardKey.KEY_SPACE);
        }

        public virtual void Draw()
        {
            Spaceship.DrawAll();
        }
        public virtual void Update()
        {
            Spaceship.UpdateAll();
        }
    }
}
