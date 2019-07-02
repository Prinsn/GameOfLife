using GameOfLife.Core.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameOfLife.Templates
{
    public static class Glider
    {
        public static Board GliderAt(this Board board, int _x, int _y, bool down = true, bool right = true)
        {
            int[,] glider;

            var flipBit0 = right ? 0 : 1;
            var flipBit1 = right ? 1 : 0;
            //var row1 = new[] { flipBit0, flipBit1, flipBit0 };
            //var row2 = new[] { flipBit0, flipBit0, flipBit1 };
            //var row3 = new[] { flipBit1, flipBit1, flipBit1 };

            if(down)
            {
                glider = new[,]
                {
                    { 0, 1, 0 },
                    { flipBit0, 0, flipBit1 },
                    { 1, 1, 1 }
                };
            }
            else
            {
                glider = new[,]
                {
                    { 1, 1, 1},
                    { flipBit0, 0, flipBit1 },
                    { 0, 1, 0 }
                };
            }

            try
            {
                for (var x = 0; x < glider.GetLength(0); x++)
                {
                    for (var y = 0; y < glider.GetLength(1); y++)
                    {
                        board.State[_x + x, _y + y].State = (CellState)glider[x, y];
                    }
                }

            }
            catch
            {
                //crappy handling for bad placement position
            }


            return board;            
        }
    }
}
