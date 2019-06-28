using System;
using System.Collections.Generic;
using System.Text;
using GameOfLife.Engines.Abstract;
using GameOfLife.Enums;

namespace GameOfLife.Classes
{
    public abstract class MortalCell : Cell
    {
        public int MaxAge { get; private set; }
        public int Age { get; private set; }


        public MortalCell(CellState state, int x, int y, RuleEngine rules, int maxAge) : base(state, x, y, rules)
        {
            MaxAge = MaxAge;
        }

        public override void UpdateState()
        {
            base.UpdateState();
            Age++;
            FearTheReaper();
        }

        public abstract void FearTheReaper();
    }

    public class AbsoluteMortalCell : MortalCell
    {
        public AbsoluteMortalCell(CellState state, int x, int y, RuleEngine rules, int maxAge) : base(state, x, y, rules, maxAge)
        {
        }

        public override void FearTheReaper()
        {
            if (Age > MaxAge)
                this.State = CellState.Dead;
        }
    }
    public class ProbabilisticMoralCell : MortalCell
    {
        public ProbabilisticMoralCell(CellState state, int x, int y, RuleEngine rules, int maxAge) : base(state, x, y, rules, maxAge)
        {
        }

        public override void FearTheReaper()
        {
            //"Roll Under" logic, skews toward it being very unlikely to die before half max life
            //TODO: Figure out how to actually do lifetime probability
            var roll = Rng.Random.Next(100) * 2;
            if(roll < Age)
                this.State = CellState.Dead;
        }
    }

}
