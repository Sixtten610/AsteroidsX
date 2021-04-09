using System;
using System.Numerics;
using Raylib_cs;

namespace Asteroids
{
    public class ObjectScreen
    {
        Vector2 mousePosition;

        public virtual void GetMousePosition()
        {
            mousePosition = Raylib.GetMousePosition();
        }
        public virtual void Update()
        {

        }
        public virtual void Draw()
        {

        }
    }
}
