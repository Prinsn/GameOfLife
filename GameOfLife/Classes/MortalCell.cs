using System;
using System.Collections.Generic;
using System.Text;
using GameOfLife.Engines.Abstract;
using GameOfLife.Enums;

namespace GameOfLife.Classes
{
    public abstract class MortalCell : Cell
    {
        public int MaxAge { get; protected set; }
        public int Age { get; protected set; }


        public MortalCell(Cell cell, int maxAge) : base(cell.State, cell.PosX, cell.PosY, cell.Rules)
        {
            MaxAge = maxAge;
        }

        public MortalCell(CellState state, int x, int y, RuleEngine rules, int maxAge) : base(state, x, y, rules)
        {
            MaxAge = maxAge;
        }

        public override void UpdateState()
        {
            base.UpdateState();
            FearTheReaper();
        }

        public abstract void FearTheReaper();
    }

    public class AbsoluteMortalCell : MortalCell
    {
        public AbsoluteMortalCell(Cell cell, int maxAge) : base(cell, maxAge)
        {
        }

        public AbsoluteMortalCell(CellState state, int x, int y, RuleEngine rules, int maxAge) : base(state, x, y, rules, maxAge)
        {
        }

        public override void FearTheReaper()
        {
            if (this.State == CellState.Dead)
                return;

            if (++Age > MaxAge)
            {
                this.State = CellState.Dead;
                Age = 0;
            }
        }
    }
    public class ProbabilisticMoralCell : MortalCell
    {
        public ProbabilisticMoralCell(Cell cell, int maxAge) : base(cell, maxAge)
        {
        }

        public ProbabilisticMoralCell(CellState state, int x, int y, RuleEngine rules, int maxAge) : base(state, x, y, rules, maxAge)
        {
        }

        public override void FearTheReaper()
        {
            //"Roll Under" logic, skews toward it being very unlikely to die before half max life
            //TODO: Figure out how to actually do lifetime probability
            if (this.State == CellState.Dead)
                return;

            var roll = Rng.Random.Next(100) * 2;
            if (roll < ++Age)
            {
                this.State = CellState.Dead;
                Age = 0;
            }
        }
    }

}
