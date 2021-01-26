using System;

namespace Tetris
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.SetWindowSize(40, 30);
            Console.SetBufferSize(40, 30);
            Draw(2, 5, '*');
            Console.ReadLine();
        }
        static void Draw (int x, int y, char s)
        {
            Console.SetCursorPosition(x, y);
            Console.Write(s);
        }
    }
}
