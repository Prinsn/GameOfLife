using GameOfLife.Classes;
using GameOfLife.Engines;
using GameOfLife.Engines.Abstract;
using GameOfLife.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameOfLife.Actors
{
    public class LangtonAnt : Actor
    {
        public Direction Facing { get; set; }
        public bool Wrap { get; set; }

        public LangtonAnt(Coordinant at, bool wrap) : base(at)
        {
            Wrap = wrap;
        }

        public override void ActOn(Board board)
        {
            if (Wrap)
            {
                this.Location.Wrap(board.Width - 1, board.Height - 1);
            }
            else
            {
                this.Location.Clamp(board.Width - 1, board.Height - 1);
            }

            var cell = board.State[this.Location.X, this.Location.Y];

            //"Black"
            if(cell.State == CellState.Alive)
            {
                cell.NextState = CellState.Dead;
                TurnLeft();
            }
            //White 
            else if (cell.State == CellState.Dead)
            {
                cell.NextState = CellState.Alive;
                TurnRight();
            }

            Step(board);
        }

        private void TurnLeft()
        {
            var val = (int)Facing;
            if(--val < (int)Direction.N)
            {
                this.Facing = Direction.W;
            }
            else
            {
                this.Facing = (Direction)val;
            }
        }

        private void TurnRight()
        {
            var val = (int)Facing;
            if (++val > (int)Direction.W)
            {
                this.Facing = Direction.N;
            }
            else
            {
                this.Facing = (Direction)val;
            }
        }

        private void Step(Board board)
        {
            this.NextLocation = new Coordinant(this.Location);
            this.NextLocation.Move(this.Facing);
            if (Wrap)
            {
                this.NextLocation.Wrap(board.Width - 1, board.Height - 1);
            }
            else
            {
                this.NextLocation.Clamp(board.Width - 1, board.Height - 1);
            }

            this.Location = this.NextLocation;
        }
    }
}
