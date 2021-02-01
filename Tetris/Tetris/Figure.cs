using System;
using System.Collections.Generic;
using System.Text;

namespace Tetris
{
    abstract class Figure
    {
        private const int SIZE = 4;
        protected Point[] points = new Point[SIZE];
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
                if (p.X < 0 || p.Y < 0 || p.X >= Field.Width || p.Y >= Field.Height)
                    return false;
            }
            return true;
        }


        private Point [] Clone ()
        {
            var newPoints = new Point[SIZE];
            for (int i = 0; i < SIZE; i++)
            {
                newPoints[i] = new Point(points[i]);
            }
            return newPoints;
        }

        internal void TryRotate()
        {
            Hide();
            var clone = Clone();
            Rotate(clone);
            if (VerifyPosition(clone))
            {
                points = clone;
            }
            Draw();
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
      
        public abstract void Rotate(Point [] pList);
    }
}
