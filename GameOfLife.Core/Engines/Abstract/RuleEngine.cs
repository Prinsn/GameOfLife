using GameOfLife.Core.Enums;

namespace GameOfLife.Core.Engines.Abstract
{
    public abstract class RuleEngine
    {
        public abstract CellState GetNewState(Board board, Cell cell);
    }
}
