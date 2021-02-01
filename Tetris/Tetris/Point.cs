using System;
using System.Collections.Generic;
using System.Text;

namespace Tetris
{
    class Point
    {
       public int x;
       public int y;
       public char s;
      

        public Point () {}

        public Point(Point point)
        {
            x = point.x;
            y = point.y;
            s = point.s;
        }

        public Point (int x, int y, char s)
        {
            this.x = x;
            this.y = y;
            this.s = s;
        }
       public void Draw()
        {
            Console.SetCursorPosition(x, y);
            Console.Write(s);
            Console.CursorVisible = false;

        }

        public void Move(Direction direction)
        {

                switch (direction)
                {

                    case Direction.DOWN: y++; break;
                    case Direction.LEFT: x--; break;
                    case Direction.RIGHT: x++; break;
                }
            
        }

        internal void Hide()
        {
            Console.SetCursorPosition(x, y);
            Console.Write(" ");
        }
    }
}
