using System;

namespace Tetris
{
    internal class Stick : Figure
    {
       
        public Stick(int x, int y, char sym)
        {
            Points[0] = new Point(x, y, '*');
            Points[1] = new Point(x, y+1, '*');
            Points[2] = new Point(x, y+2, '*');
            Points[3] = new Point(x, y+3, '*');
            Draw();
        }

        public override void Rotate(Point [] plist)
        {
           if (Points[0].X == Points[1].X)
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
            for (int i = 0; i < Points.Length; i++)
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