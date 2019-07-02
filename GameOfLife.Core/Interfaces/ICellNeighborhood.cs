using System;
using System.Collections.Generic;
using System.Text;

namespace GameOfLife.Core.Classes.Interfaces
{
    public interface ICellNeighborhood
    {        
        List<Cell> GetNeighbors(Board board, Cell cell);
    }
}
