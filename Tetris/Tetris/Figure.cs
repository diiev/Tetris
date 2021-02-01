using System;
using System.Collections.Generic;
using System.Text;

namespace Tetris
{
    abstract class Figure
    {
        private const int SIZE = 4;
        public Point[] Points = new Point[SIZE];
        public void Draw()
        {
            foreach (Point p in Points)
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
                Points = clone;
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
                newPoints[i] = new Point(Points[i]);
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
                Points = clone;
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
            foreach (Point p in Points)
            {
                p.Hide();
            }
        } 
      
        public abstract void Rotate(Point [] pList);
    }
}
