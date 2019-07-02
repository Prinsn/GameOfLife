using GameOfLife.Core.Enums;
using System.Collections.Generic;

namespace GameOfLife.Templates
{
    public static class GosperGliderGun
    {
        public static Board GggAt(this Board board, int _x, int _y)
        {
            var ggg = new HashSet<string>();

            //Left block
            ggg.Add("1,5"); ggg.Add("2,5");
            ggg.Add("1,6"); ggg.Add("2,6");

            //Right block
            ggg.Add("35,3"); ggg.Add("36,3");
            ggg.Add("35,4"); ggg.Add("36,4");

            //Left blob
            ggg.Add("13,3"); ggg.Add("14,3");
            ggg.Add("12,4"); ggg.Add("16,4");
            ggg.Add("11,5"); ggg.Add("17,5");
            ggg.Add("11,6"); ggg.Add("15,6"); ggg.Add("17,6"); ggg.Add("18,6");
            ggg.Add("11,7"); ggg.Add("17,7");
            ggg.Add("12,8"); ggg.Add("16,8");
            ggg.Add("13,9"); ggg.Add("14,9");

            //Right blob
            ggg.Add("25,1");
            ggg.Add("23,2"); ggg.Add("25,2");
            ggg.Add("21,3"); ggg.Add("22,3");
            ggg.Add("21,4"); ggg.Add("22,4");
            ggg.Add("21,5"); ggg.Add("22,5");
            ggg.Add("23,6"); ggg.Add("25,6");
            ggg.Add("25,7");


            try
            {
                board.BoardIterator((x, y) =>
                {
                    if (ggg.Contains($"{x},{y}"))
                    {
                        board.State[x + _x, y + _y].State = CellState.Alive;
                    }
                });
            }
            catch
            {
                //crappy handling for bad placement position
            }

            return board;            
        }
    }
}
