using GameOfLife.Core.Classes;
using GameOfLife.Core.Engines.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameOfLife.Core.Engines
{  
    public abstract class BehaviorEngine
    {
        public abstract bool Wrapping { get; set; }
        public abstract void Act(object actor, Board board);
    }
}
