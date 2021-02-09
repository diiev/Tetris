using Microsoft.SmallBasic.Library;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tetris
{

    class GuiDrawer : IDrawer
    {
        private const int SIZE = 20;
        public void DrawPoint(int x, int y)
        {
            GraphicsWindow.PenColor = "DarkBlue";
            GraphicsWindow.PenWidth = 2;
            GraphicsWindow.DrawRectangle(x * SIZE, y * SIZE, SIZE, SIZE);

        }

        public void HidePoint(int x, int y)
        {
            GraphicsWindow.PenColor = GraphicsWindow.BackgroundColor;
            GraphicsWindow.PenWidth = 4;
            GraphicsWindow.DrawRectangle(x * SIZE, y * SIZE, SIZE, SIZE);
        }

        public void InitField()
        {

            GraphicsWindow.BackgroundColor = "LightBlue";
            GraphicsWindow.Width = Field.Width * SIZE;
            GraphicsWindow.Height = Field.Height * SIZE;
        }

        public void WriteGameOver()
        {
            GraphicsWindow.BrushColor = "Red";
            GraphicsWindow.FontSize = 20;
            GraphicsWindow.DrawText((Field.Width / 2 - 4) * SIZE, Field.Height / 2 * SIZE, "G A M E  O V E R ");

        }
    }
}
