using System;

namespace Tetris
{
    internal class Stick : Figure
    {
       
        public Stick(int x, int y, char sym)
        {
            points[0] = new Point(x, y, '*');
            points[1] = new Point(x, y+1, '*');
            points[2] = new Point(x, y+2, '*');
            points[3] = new Point(x, y+3, '*');
            Draw();
        }

        public override void Rotate(Point [] plist)
        {
           if (points[0].X == points[1].X)
            {
                RotateHorisontal(plist);
            }
           else
            {
                RotateVertical(plist);
            }
        }

        private void RotateVertical(Point [] pList)
        {
            for (int i = 0; i < points.Length; i++)
            {
                pList[i].X = pList[0].X;
                pList[i].Y = pList[0].Y + i;
            }
        }

        private void RotateHorisontal(Point [] pList)
        {
            for (int i = 0; i < pList.Length; i++)
            {
                pList[i].Y = pList[0].Y;
                pList[i].X = pList[0].X+i; 
            }
        }
    }
}