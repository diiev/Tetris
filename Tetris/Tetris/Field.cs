﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Tetris
{
     static class Field
    {
        public static int Width { get; set; } = 20;
        public static int Height { get; set; } = 20;
        private static bool[][] _heap; 

        static Field ()
        {
            _heap = new bool[Height][];
            for (int i = 0; i < Height; i++)
            {
                _heap[i] = new bool[Width];
            }
        }
         
        public static void TryDeleteLines()
        {
            for (int j = 0; j < Height; j++)
            {
                int counter = 0;

                for (int i = 0; i < Width; i++)
                {
                    if (_heap[j][i])
                        counter++;
                } 
                if (counter == Width)
                {
                    DeleteLine(j);
                    Redraw();
                }
            }
        }

        private static void Redraw()
        {
            for (int j = 0; j < Height; j++)
            {
                for (int i =0; i < Width; i++)
                {
                    if (_heap[j][i])
                        Drawer.DrawPoint(i, j);
                    else
                        Drawer.HidePoint(i, j);
                }
            }
        }

        private static void DeleteLine(int line)
        {
            for (int j = line; j >=0; j--)
            {
                for (int i = 0;  i < Width; i++)
                {
                    if (j == 0)
                        _heap[j][i] = false;
                    else
                        _heap[j][i] = _heap[j - 1][i];
                }
            }
        }

        public static bool CheckStrike(Point p)
        {
            return _heap[p.Y][p.X];
        }
        public static void AddFigure(Figure fig)
        {
            foreach (var p in fig.Points)
            {
                _heap[p.Y][p.X] = true;
            }
           
        }
        public static void Draw ()
        {
            Console.SetWindowSize(Width, Height);
            Console.SetBufferSize(Width, Height);
        }
    }
}
