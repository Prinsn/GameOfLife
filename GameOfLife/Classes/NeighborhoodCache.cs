using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameOfLife.Classes
{
    public static class NeighborhoodCache
    {
        private static Dictionary<Board, Dictionary<Cell, List<Cell>>> Cache = new Dictionary<Board, Dictionary<Cell, List<Cell>>>();
        public static List<Cell> GetCachedNeighbors(Board board, Cell cell)
        {
            Init(board, cell);
            
            return Cache[board][cell];
        }

        //public static List<Cell> Set(Board board, Cell cell, List<Cell> cells)
        //{
        //    Init(board, cell);

        //    Cache[board][cell] = cells;

        //    return cells;
        //}

        private static void Init(Board board, Cell cell)
        {
            if (!Cache.ContainsKey(board))
            {
                Cache.Add(board, new Dictionary<Cell, List<Cell>>());
            }

            if (!Cache[board].ContainsKey(cell))
            {
                Cache[board].Add(cell, new List<Cell>());
            }
        }
    }
}
