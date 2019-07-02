using GameOfLife.Core.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameOfLife.Core.Rules
{
    public class CellLifeRuleList : List<Func<CellState, List<Cell>, CellState?>>
    { 
    }
}
