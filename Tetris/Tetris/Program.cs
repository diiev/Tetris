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
            Figure figure = generator.GetNewFigure();
            while (true)
            {
               
                if (Console.KeyAvailable)
                {
                    var key =  Console.ReadKey();
                    HandleKey(figure, key); 
                }
               
            }
         
           //  Console.ReadLine();
        }

        private static void HandleKey(Figure figure, ConsoleKeyInfo key)
        {
            if (key.Key == ConsoleKey.DownArrow)
                figure.TryMove(Direction.DOWN);
            if (key.Key == ConsoleKey.LeftArrow)
                figure.TryMove(Direction.LEFT);
            if (key.Key == ConsoleKey.RightArrow)
                figure.TryMove(Direction.RIGHT);
            if (key.Key == ConsoleKey.Spacebar)
                figure.TryRotate();
               
        }

        static void FigureFall( out Figure figure, FigureGenerator generator)
        {
            figure = generator.GetNewFigure();
            figure.Draw();
            for (int i = 0; i < 15; i++)
            {
                figure.Hide();
                figure.TryMove(Direction.DOWN);
                figure.Draw();
                Thread.Sleep(200);
            }
        }
      
    }
}
