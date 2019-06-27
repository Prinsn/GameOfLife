using GameOfLife.Classes;
using GameOfLife.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using GameOfLife.Rules;

namespace GameOfLife.Engines
{
    public class DefaultEngine : RuleEngine<WrappingMooreNeighborhood>
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
