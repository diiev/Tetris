using OpenXmlPowerTools;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tetris
{
    class Point
    {
       public int X { get; set; }
       public int Y { get; set; }
        public char S { get; set; }
       public Point () {}
       
        public Point(Point point)
        {
            X = point.X;
            Y = point.Y;
            S = point.S;
        }

        public Point (int x, int y)
        {
            X = x;
            Y = y;
            
        }
       public void Draw()
        {
            DrawerProvider.Drawer.DrawPoint(X,Y);
        }

        public void Move(Direction direction)
        {

            switch (direction)
            {
                case Direction.DOWN: Y++; break;
                case Direction.LEFT: X--; break;
                case Direction.RIGHT: X++; break;
            }

        }

        internal void Hide()
        {
            DrawerProvider.Drawer.HidePoint(X, Y);
        }
    }
}
