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
        }
       
    }
}