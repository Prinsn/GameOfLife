using GameOfLife.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameOfLife.Rules
{
    public class RuleList : List<Func<CellState, List<Cell>, CellState?>>
    { 
    }
}
