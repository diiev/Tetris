using System;
using System.Collections.Generic;
using System.Text;

namespace Tetris
{
    class Walls
    {
        private int width;
        private int height;

        public Walls(int width, int height) { 
          this.width = width;
         this.height = height;
            Console.SetWindowSize(width, height);
            Console.SetBufferSize(width, height);
        }

        
    }
}
