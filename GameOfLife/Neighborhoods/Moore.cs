using GameOfLife.Classes.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameOfLife.Neighborhoods
{
    public class MooreNeighborhood : ICellNeighborhood
    {
        public List<Cell> GetNeighbors(Board board, Cell cell)
        {
            var neighbors = NeighborhoodCache.GetCachedNeighbors(board, cell);
            if (neighbors.Any())
                return neighbors;

            var horiNeighbors = new[] { cell.PosX - 1, cell.PosX, cell.PosX + 1 }
                .Where(z => z > 0 && z < board.Width);

            var vertiNeighbors = new[] { cell.PosY - 1, cell.PosY, cell.PosY + 1 }
                .Where(z => z > 0 && z < board.Height);
           
            horiNeighbors.ToList().ForEach(x =>
                vertiNeighbors.ToList().ForEach(y =>
                {
                    var nCell = board.State[x, y];
                    if (cell != nCell)
                        neighbors.Add(nCell);
                })
            );

            return neighbors;
        }
    }
}
