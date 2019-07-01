using GameOfLife.Classes;
using GameOfLife.Engines.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameOfLife.Engines
{  
    public abstract class BehaviorEngine
    {
        public abstract bool Wrapping { get; set; }
        public abstract void Act(object actor, Board board);
    }
}
