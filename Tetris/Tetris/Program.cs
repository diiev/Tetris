using System;
using System.Threading;
using System.Timers;
using Microsoft.SmallBasic.Library;

namespace Tetris
{
    class Program
    {
        const int TIMER_INTERVAL = 500;
        static private object _lockObject = new object();
        static System.Timers.Timer aTimer;
        static Figure currentFigure;
        static FigureGenerator generator = new FigureGenerator(Field.Width / 2, 0);
        private static bool gameOver = false;

        static void Main(string[] args)
        {

            DrawerProvider.Drawer.InitField();

            SetTimer();
            currentFigure = generator.GetNewFigure();
            currentFigure.Draw();
            ConsoleGameStart();
            // GraphicsWindow.KeyDown += GraphicsWindow_KeyDown;


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
            gameOver = ProcessResult(result, ref currentFigure);
            if (gameOver)
                aTimer.Stop();
            Monitor.Exit(_lockObject);
        }
        private static bool ProcessResult(Result result, ref Figure currentFigure)
        {
            if (result == Result.HEAP_STRIKE || result == Result.DOWN_BORDER_STRIKE)
            {

                Field.AddFigure(currentFigure);
                Field.TryDeleteLines();
                if (currentFigure.IsOnTop())
                {
                    DrawerProvider.Drawer.WriteGameOver();
                    return true;
                }
                else
                {
                    currentFigure = generator.GetNewFigure();
                    return false;
                }

            }
            else
            {
                return false;
            }
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
        private static Result HandleKey(Figure figure, String key)
        {
            switch (key)
            {

                case "Left":
                    return figure.TryMove(Direction.LEFT);
                case "Right":
                    return figure.TryMove(Direction.RIGHT);
                case "Down":
                    return figure.TryMove(Direction.DOWN);
                case "Space":
                    return figure.TryRotate();
            }
            return Result.SUCCESS;

        }
        private static void GraphicsWindow_KeyDown()
        {
            Monitor.Enter(_lockObject);
            var result = HandleKey(currentFigure, GraphicsWindow.LastKey);
            if (GraphicsWindow.LastKey == "Down")
            {
                gameOver = ProcessResult(result, ref currentFigure);
            }
            Monitor.Exit(_lockObject);



        }
        public static void ConsoleGameStart()
        {
            while (true)
            {

                if (Console.KeyAvailable)
                {
                    var key = Console.ReadKey();
                    Monitor.Enter(_lockObject);
                    var result = HandleKey(currentFigure, key.Key);
                    ProcessResult(result, ref currentFigure);
                    Monitor.Exit(_lockObject);
                }

            }

        }
    }


}

