using System;
using System.Threading;

namespace Tetris
{
    class Program
    {  
        static void Main(string[] args)
        {
            Field.Draw();
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
                s.TryMove(Direction.DOWN);
            if (key.Key == ConsoleKey.LeftArrow)
                s.TryMove(Direction.LEFT);
            if (key.Key == ConsoleKey.RightArrow)
                s.TryMove(Direction.RIGHT);
            if (key.Key == ConsoleKey.Spacebar)
                s.TryRotate();
               
        }

        static void FigureFall( out Figure  s, FigureGenerator generator)
        {
            s = generator.GetNewFigure();
            s.Draw();
            for (int i = 0; i < 15; i++)
            {
                s.Hide();
                s.TryMove(Direction.DOWN);
                s.Draw();
                Thread.Sleep(200);
            }
        }
      
    }
}
