using System;
using System.Threading;
using System.Timers;

namespace Tetris
{
    class Program
    {
        const int TIMER_INTERVAL = 500;
        static System.Timers.Timer aTimer;
        static FigureGenerator generator;
        static Figure currentFigure;
        static private object _lockObject = new object();
       
        
        static void Main(string[] args)
        {
           
            //Field.Draw();
            generator = new FigureGenerator(Field.Width/2, 0, Drawer.DEFAULT_SYMBOL);
            currentFigure = generator.GetNewFigure();
            SetTimer();
            while (true)
            {

                if (Console.KeyAvailable)
                {
                    var key =  Console.ReadKey();
                    Monitor.Enter(_lockObject);
                    var result = HandleKey(currentFigure, key.Key);
                    ProcessResult(result, ref currentFigure);
                    Monitor.Exit(_lockObject);
                }
               
            } 
         
           //  Console.ReadLine();
        }

        private static void SetTimer()
        {
            // Create a timer with a two second interval.
            aTimer = new System.Timers.Timer(TIMER_INTERVAL);
            // Hook up the Elapsed event for the timer. 
            aTimer.Elapsed += OnTimedEvent;
            aTimer.AutoReset = true;
            aTimer.Enabled = true;
        }
        private static void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            Monitor.Enter(_lockObject);
            var result = currentFigure.TryMove(Direction.DOWN);
            ProcessResult(result, ref currentFigure);
            Monitor.Exit(_lockObject);
        }
        private static bool ProcessResult(Result result, ref Figure currentFigure)
        {
            if (result == Result.HEAP_STRIKE || result == Result.DOWN_BORDER_STRIKE)
            {
               
                Field.TryDeleteLines();
                Field.AddFigure(currentFigure);
                if (currentFigure.IsOnTop())
                {
                    WriteGameOver();
                    aTimer.Elapsed -= OnTimedEvent;
                    return true;
                }
                else
                {
                    currentFigure = generator.GetNewFigure();
                    return false;
                }
               
            }
            else
                return false;
        }

        private static void WriteGameOver()
        {
            Console.Clear();
            Console.SetCursorPosition(Field.Width / 2 - 4, Field.Height / 2);
            Console.WriteLine("G A M E  O V E R !");
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
                Thread.Sleep(300);
            }
        }
      
    }
}
