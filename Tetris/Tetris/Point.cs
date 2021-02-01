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

        public Point (int x, int y, char s)
        {
            X = x;
            Y = y;
            S = s;
        }
       public void Draw()
        {
            Console.SetCursorPosition(X, Y);
            Console.Write(S);
            Console.CursorVisible = false;
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
            Console.SetCursorPosition(X, Y);
            Console.Write(" ");
        }
    }
}
