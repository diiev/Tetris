using System;

namespace Tetris
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.SetWindowSize(40, 30);
            Console.SetBufferSize(40, 30);
            Point p1 = new Point();
            p1.x = 25;
            p1.y = 23;
            p1.s = '*';
            p1.Draw();
            Console.ReadLine();
        }
      
    }
}
