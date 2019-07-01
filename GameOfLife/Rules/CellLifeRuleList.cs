using GameOfLife.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameOfLife.Rules
{
    public class CellLifeRuleList : List<Func<CellState, List<Cell>, CellState?>>
    { 
    }
}
