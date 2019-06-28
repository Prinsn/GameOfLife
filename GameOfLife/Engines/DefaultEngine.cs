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

    public class DefaultTestEngine : DefaultEngine<WrappingMooreNeighborhood> { }
    public class DefaultEngine<TNeighborhood> : RuleEngine<TNeighborhood> where TNeighborhood : ICellNeighborhood, new()
    {
        public DefaultEngine() : base(new RuleList())
        {
            init();
        }

        public DefaultEngine(RuleList rules) : base(new RuleList())
        {
            init();
        }

        private void init()
        {
            Rules.AddRange(new RuleList
            {
                RuleDefinitions.UnderPopulation,
                RuleDefinitions.GoodPopulation,
                RuleDefinitions.OverPopulation,
                RuleDefinitions.Reproduction
            });
        }
    }
}
