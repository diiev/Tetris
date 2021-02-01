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
           if (points[0].x == points[1].x) 
                 RotateHorisontal(plist);
           else
                RotateVertical(plist);
        }

        private void RotateVertical(Point [] pList)
        {
            for (int i = 0; i < points.Length; i++)
            {
                pList[i].x = pList[0].x;
                pList[i].y = pList[0].y + i;
            }
        }

        private void RotateHorisontal(Point [] pList)
        {
            for (int i = 0; i < pList.Length; i++)
            {
                pList[i].y = pList[0].y;
                pList[i].x = pList[0].x+i; 
            }
        }
    }
}