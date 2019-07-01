using GameOfLife.Engines;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameOfLife.Classes
{
    public abstract class Actor
    {
        public Coordinant Location { get; set; }
        public Coordinant NextLocation { get; set; }

        public ConsoleColor Color { get; set; } = ConsoleColor.DarkRed;

        public abstract void ActOn(Board board);

        public Actor(Coordinant at)
        {
            Location = at;
        }

        public virtual void DisplayConsole(Board board)
        {
            var pos = new[] { Console.CursorLeft, Console.CursorTop };
            Console.SetCursorPosition(Location.X, Location.Y);
            var priorBackGroundColor = Console.BackgroundColor;
            Console.BackgroundColor = Color;
            var cell = board.State[this.Location.X, this.Location.Y];
            Console.Write(board.Visualize(cell.State));
            Console.BackgroundColor = priorBackGroundColor;
            Console.SetCursorPosition(pos[0], pos[1]);
        }
    }
}
