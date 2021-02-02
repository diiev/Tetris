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

        public Result TryMove (Direction direction)
        {
            Hide();
            var clone = Clone();
            Move(clone, direction);
            var result = VerifyPosition(clone);
            if (result == Result.SUCCESS)
            {
                Points = clone;
            }
            Draw();
            return result;
        }
        private Result VerifyPosition(Point[] clone)
        {
            foreach (var p in clone )
            {
                if (p.Y >= Field.Height)
                    return Result.DOWN_BORDER_STRIKE;
                if (p.X >= Field.Width || p.X < 0 || p.Y < 0)
                    return Result.BORDER_STRIKE;
                if (Field.CheckStrike(p))
                    return Result.HEAP_STRIKE;
            }
            return Result.SUCCESS;
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

        internal Result TryRotate()
        {
            Hide();
            var clone = Clone();
            Rotate(clone);
            var result = VerifyPosition(clone);
            if (result == Result.SUCCESS)
            {
                Points = clone;
            }
            Draw();
            return result;
        }

        public void Move (Point [] points, Direction direction)
        {  
           
                foreach (Point p in points)
                {
                    p.Move(direction);
                }
            
           
        }

        internal bool IsOnTop()
        {
            return Points[0].Y == 0;
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
