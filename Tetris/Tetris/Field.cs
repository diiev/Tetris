using System;
using System.Collections.Generic;
using System.Text;

namespace Tetris
{
     static class Field
    {
        static public int WIDTH = 40;
        static public int HEIGHT = 30;

        public static void Draw ()
        {
            Console.SetBufferSize(40, 30);
            Console.SetWindowSize(40, 30);
        }
 
        

        
    }
}
