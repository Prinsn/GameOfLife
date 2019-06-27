using GameOfLife.Classes.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace GameOfLife.Classes
{
    public class WrappingMooreNeighborhood : ICellNeighborhood
    {
        public List<Cell> GetNeighbors(Board board, Cell cell)
        {
            var neighbors = NeighborhoodCache.GetCachedNeighbors(board, cell);
            if (neighbors.Any())
                return neighbors;

            var leftEdge = cell.PosX - 1 < 0 ? board.Width - 1 : cell.PosX - 1;
            var rightEdge = cell.PosX + 1 == board.Width ? 0 : cell.PosX + 1;
            var topEdge = cell.PosY - 1 < 0 ? board.Height - 1 : cell.PosY - 1;
            var botEdge = cell.PosY + 1 == board.Height ? 0 : cell.PosY + 1;

            var cols = new[] { leftEdge, cell.PosX, rightEdge }.ToList();
            var rows = new[] { topEdge, cell.PosY, botEdge }.ToList();

            cols.ForEach(x =>
                rows.ForEach(y =>
                {
                    var nCell = board.State[x, y];
                    if (cell != nCell)
                        neighbors.Add(nCell);
                }
            ));

            return neighbors;
        }
    }
}
