using System;
using System.Collections.Generic;
using System.Text;

namespace GameOfLife.Classes.Interfaces
{
    public interface ICellNeighborhood
    {        
        List<Cell> GetNeighbors(Board board, Cell cell);
    }
}
