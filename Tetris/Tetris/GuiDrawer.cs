using Microsoft.SmallBasic.Library;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tetris
{
    class GuiDrawer : IDrawer
    {
        public void DrawPoint(int x, int y)
        {
            GraphicsWindow.PenColor = "Black";
            GraphicsWindow.DrawRectangle(20, 20, 10, 10);
        }

        public void HidePoint(int x, int y)
        {
            GraphicsWindow.PenColor = "";
            GraphicsWindow.DrawRectangle(0, 0, 0, 0);
        }

        public void InitField()
        {
            GraphicsWindow.Width = 200;
            GraphicsWindow.Height = 400;
            GraphicsWindow.BackgroundColor = "LightGreen";
        }

        public void WriteGameOver()
        {
            throw new NotImplementedException();
        }
    }
}
