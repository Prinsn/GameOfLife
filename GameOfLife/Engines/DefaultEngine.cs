using GameOfLife.Classes;
using GameOfLife.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using GameOfLife.Rules;
using GameOfLife.Neighborhoods;
using GameOfLife.Classes.Interfaces;

namespace GameOfLife.Engines
{

    public class DefaultestEngine : DefaultEngine<WrappingMooreNeighborhood> { }
    public class DefaultEngine<TNeighborhood> : RuleEngine<TNeighborhood> where TNeighborhood : ICellNeighborhood, new()
    {
        public DefaultEngine() : base(new CellLifeRuleList())
        {
            init();
        }

        public DefaultEngine(CellLifeRuleList rules) : base(new CellLifeRuleList())
        {
            init();
        }

        private void init()
        {
            Rules.AddRange(new CellLifeRuleList
            {
                DefaultCellRuleDefinitions.UnderPopulation,
                DefaultCellRuleDefinitions.GoodPopulation,
                DefaultCellRuleDefinitions.OverPopulation,
                DefaultCellRuleDefinitions.Reproduction
            });
        }
    }
}
