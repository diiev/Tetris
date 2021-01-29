using System;

namespace Tetris
{
    class Program
    {  
      
        static void Main(string[] args)
        {

            Console.SetWindowSize(40, 30);
            Console.SetBufferSize(40, 30);
            Square square = new Square(4,4,'*');
            square.Draw();
            while (true)
            {
                square.Hide();
                square.Move(Direction.DOWN);
                square.Draw();
            }




            Console.ReadLine();
        }
      
    }
}
