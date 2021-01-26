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
        }
    }
}
