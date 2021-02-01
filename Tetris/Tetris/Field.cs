using System;
using System.Collections.Generic;
using System.Text;

namespace Tetris
{
     static class Field
    {
        public static int Width { get; set; } = 40;
        public static int Height { get; set; } = 30;
        private static bool[][] _heap; 

        static Field ()
        {
            _heap = new bool[Height][];
            for (int i = 0; i < Height; i++)
            {
                _heap[i] = new bool[Width];
            }
        }

        public static bool CheckStrike(Point p)
        {
            return _heap[p.Y][p.X];
        }
        public static void AddFigure (Figure fig)
        {
            foreach (var p in fig.Points)
            {
                _heap[p.Y][p.X] = true;
            }
           
        }
        public static void Draw ()
        {
            Console.SetBufferSize(Width, Height);
            Console.SetWindowSize(Width, Height);
        }
 
        
         
        
    }
}
