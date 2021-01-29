using System;

namespace Tetris
{
    class Program
    {  
      
        static void Main(string[] args)
        {

            Console.SetWindowSize(40, 30);
            Console.SetBufferSize(40, 30);
          Figure  s = new Stick(20,5,'*');
            s.Draw();
            s.Hide();
            s.Rotate();
       




            Console.ReadLine();
        }
      
    }
}
