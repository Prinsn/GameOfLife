using GameOfLife.Core.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameOfLife.Templates
{
    public static class Toad
    {
        public static Board ToadAt(this Board board, int _x, int _y, bool flip = false, bool rotate = false)
        {            
            var fOn = flip ? 0 : 1;
            var fOff = flip ? 1 : 0;
            int[,] toad;


            if (rotate)
            {
                toad = new[,]
                {
                    {fOn, 1, 1, fOff },
                    {fOff, 1, 1, fOn }
                 };
            }
            else
            {
                toad = new[,]
                {
                    {fOn, fOff },
                    {1, 1 },
                    {1, 1 },
                    {fOff, fOn },
                 };
            }           

            try
            {
                for (var x = 0; x < toad.GetLength(0); x++)
                {
                    for(var y = 0; y < toad.GetLength(1); y++)
                    {
                        board.State[_x + x, _y + y].State = (CellState)toad[x, y];
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
