using System;

namespace Tetris
{
    internal class FigureGenerator
    {

        private int _x;
        private int _y;
        private char _s;
        private Random random = new Random();
        public FigureGenerator(int x, int y, char s)
        {
            _x = x;
            _y = y;
            _s = s;
        }

        public Figure GetNewFigure()
        {
            if (random.Next(0, 2) == 0)
                return new Square(_x, _y, _s);
            else
                return new Stick(_x, _y, _s);
        }
    }
}