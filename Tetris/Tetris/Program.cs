using System;
using System.Threading;

namespace Tetris
{
    class Program
    {  
        static void Main(string[] args)
        {

            Console.SetWindowSize(40, 30);
            Console.SetBufferSize(40, 30);
            FigureGenerator generator = new FigureGenerator(20, 0, '*');
            Figure s = generator.GetNewFigure();
            while (true)
            {
               
                if (Console.KeyAvailable)
                {
                    var key =  Console.ReadKey();
                    HandleKey(s, key);
                    
                }
               
            }
         
           //  Console.ReadLine();
        }

        private static void HandleKey(Figure s, ConsoleKeyInfo key)
        {
            if (key.Key == ConsoleKey.DownArrow)
                s.Move(Direction.DOWN);
            if (key.Key == ConsoleKey.LeftArrow)
                s.Move(Direction.LEFT);
            if (key.Key == ConsoleKey.RightArrow)
                s.Move(Direction.RIGHT);
        }

        static void FigureFall( out Figure  s, FigureGenerator generator)
        {
            s = generator.GetNewFigure();
            s.Draw();
            for (int i = 0; i < 15; i++)
            {
                s.Hide();
                s.Move(Direction.DOWN);
                s.Draw();
                Thread.Sleep(200);
            }
        }
      
    }
}
