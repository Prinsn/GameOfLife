using GameOfLife.Core.Engines.Abstract;
using GameOfLife.Core.Classes.Interfaces;
using GameOfLife.Core.Enums;
using GameOfLife.Core.Rules;
using System.Linq;

namespace GameOfLife.Core.Engines
{    
    public class RuleEngine<TNeighborhood> : RuleEngine where TNeighborhood : ICellNeighborhood, new()
    {
        public CellLifeRuleList Rules { get; set; }
        public RuleEngine(CellLifeRuleList rules)
        {
            Rules = rules ?? new CellLifeRuleList();
        }

        public override CellState GetNewState(Board board, Cell cell)
        {
            var neighborhood = new TNeighborhood();
            foreach(var rule in Rules)
            {
                var newState = rule(cell.State, neighborhood.GetNeighbors(board, cell));

                if(newState.HasValue)
                {
                    return newState.Value;
                }
            }

            return cell.State;
        }
    }
}
