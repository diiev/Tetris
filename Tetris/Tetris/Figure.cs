using System;
using System.Collections.Generic;
using System.Text;

namespace Tetris
{
    abstract class Figure

    {
        private const int size = 4;
       protected Point[] points = new Point[size];
        public void Draw()
        {
            foreach (Point p in points)
            {
                p.Draw();
            }
        } 

        public void TryMove (Direction direction)
        {
            Hide();
            var clone = Clone();
            Move(clone, direction);
            if (VerifyPosition(clone))
            {
                points = clone;
            }
            Draw();
        }

        private bool VerifyPosition(Point[] clone)
        {
            foreach (var p in clone )
            {
                if (p.x < 0 || p.y < 0 || p.x >= 40 || p.y >= 30)
                    return false;

            }
            return true;
        }


        private Point [] Clone ()
        {
            var newPoints = new Point[size];
            for (int i = 0; i < size; i++)
            {
                newPoints[i] = new Point(points[i]);
            }
            return newPoints;
        } 
        public void Move (Point [] points, Direction direction)
        {
            foreach (Point p in points)
            {
                p.Move(direction);
            }
        }
        //public void Move(Direction direction)
        //{

        //    Hide();
        //    foreach (Point p in points)
        //    {
        //        p.Move(direction);
        //    }
        //    Draw();
        //} 
        public void Hide ()
        {
            foreach (Point p in points)
            {
                p.Hide();
            }
        } 
      
        public abstract void Rotate();
    }
}
