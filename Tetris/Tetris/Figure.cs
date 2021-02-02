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

            Move(direction);

            var result = VerifyPosition();
            if (result != Result.SUCCESS)
                Move(Reverse(direction));
            
            Draw();
            return result;
        }

        private Direction Reverse(Direction dir)
        {
            switch (dir)
            {
                case Direction.LEFT:
                    return Direction.RIGHT;
                case Direction.RIGHT:
                    return Direction.LEFT;
                case Direction.DOWN:
                    return Direction.UP;
                case Direction.UP:
                    return Direction.DOWN;
                
            }
            return dir;
            
        }

        private Result VerifyPosition()
        {
            foreach (var p in Points )
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

        internal Result TryRotate()
        {
            Hide();
            Rotate();
            var result = VerifyPosition();
            if (result != Result.SUCCESS)
                Rotate();
           
            Draw();
            return result;
        }


        public void Move (Direction direction)
        {

            foreach (Point p in Points)
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
      
        public abstract void Rotate();
    }
}
