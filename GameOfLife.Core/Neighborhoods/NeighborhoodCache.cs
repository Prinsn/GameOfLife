using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameOfLife.Core.Neighborhoods
{
    public static class NeighborhoodCache
    {
        private static Dictionary<Board, Dictionary<Cell, List<Cell>>> _cache = new Dictionary<Board, Dictionary<Cell, List<Cell>>>();

        public static void Reset()
        {
            _cache = new Dictionary<Board, Dictionary<Cell, List<Cell>>>();
        }

        public static List<Cell> GetCachedNeighbors(Board board, Cell cell)
        {
            Init(board, cell);
            
            return _cache[board][cell];
        }

        //public static List<Cell> Set(Board board, Cell cell, List<Cell> cells)
        //{
        //    Init(board, cell);

        //    Cache[board][cell] = cells;

        //    return cells;
        //}

        private static void Init(Board board, Cell cell)
        {
            if (!_cache.ContainsKey(board))
            {
                _cache.Add(board, new Dictionary<Cell, List<Cell>>());
            }

            if (!_cache[board].ContainsKey(cell))
            {
                _cache[board].Add(cell, new List<Cell>());
            }
        }
    }
}
