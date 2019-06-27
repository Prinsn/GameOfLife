using GameOfLife.Classes.Interfaces;
using GameOfLife.Engines;
using GameOfLife.Engines.Abstract;
using GameOfLife.Enums;
using Newtonsoft.Json;

namespace GameOfLife
{
    public class Cell
    {
        public int PosX { get; private set; }
        public int PosY { get; private set; }
        public CellState State { get; set; }

        [JsonIgnore]
        public CellState NextState { get; private set; }
        [JsonIgnore]
        public RuleEngine Rules { get; private set; }

        public Cell(CellState state, int x, int y, RuleEngine rules)
        {
            State = state;
            PosX = x;
            PosY = y;
            Rules = rules;
        }  

        public void BufferStateChange(Board board)
        {
            NextState = Rules.GetNewState(board, this);
        }            

        public void UpdateState()
        {
            State = NextState;
        }
    }

    public class Cell<TNeighborhood> : Cell where TNeighborhood : ICellNeighborhood, new()
    {
        public Cell(CellState state, int x, int y, RuleEngine<TNeighborhood> rules) : base(state, x, y, rules)
        {
        }
    }
}
