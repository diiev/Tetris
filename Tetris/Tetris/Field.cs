using System;
using System.Collections.Generic;
using System.Text;

namespace Tetris
{
     static class Field
    {
        public static int Width { get; set; } = 40;
        public static int Height { get; set; } = 30;

        public static void Draw ()
        {
            Console.SetBufferSize(Width, Height);
            Console.SetWindowSize(Width, Height);
        }
 
        
         
        
    }
}
