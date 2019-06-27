using GameOfLife.Enums;

namespace GameOfLife.Engines.Abstract
{
    public abstract class RuleEngine
    {
        public abstract CellState GetNewState(Board board, Cell cell);
    }
}
