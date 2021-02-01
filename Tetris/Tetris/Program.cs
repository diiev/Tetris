using System;
using System.Threading;

namespace Tetris
{
    class Program
    {
        static FigureGenerator generator;
        static void Main(string[] args)
        {
            Field.Draw();
            generator = new FigureGenerator(20, 0, '*');
            Figure currentFigure = generator.GetNewFigure();
            while (true)
            {

                if (Console.KeyAvailable)
                {
                    var key =  Console.ReadKey();
                    var result = HandleKey(currentFigure, key.Key);
                    ProcessResult(result, ref currentFigure);
                }
               
            }
         
           //  Console.ReadLine();
        }

        private static bool ProcessResult(Result result, ref Figure currentFigure)
        {
            if (result == Result.HEAP_STRIKE || result == Result.DOWN_BORDER_STRIKE)
            {
                Field.AddFigure(currentFigure);
                currentFigure = generator.GetNewFigure();
                return true;
            }
            else
                return false;
        }

        private static Result HandleKey(Figure figure, ConsoleKey key)
        {
            switch (key)
            {
                case ConsoleKey.LeftArrow:
                    return figure.TryMove(Direction.LEFT);
                case ConsoleKey.RightArrow:
                    return figure.TryMove(Direction.RIGHT);
                case ConsoleKey.DownArrow:
                    return figure.TryMove(Direction.DOWN);
                case ConsoleKey.Spacebar:
                    return figure.TryRotate();
            }
            return Result.SUCCESS;

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
