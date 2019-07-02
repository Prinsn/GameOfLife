using GameOfLife.Core._Game;
using GameOfLife.Core.Engines;
using GameOfLife.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameOfLife.SimulationTemplate
{
    public class WrappingMooreDefault : ISimulationTemplate
    {
        public void Run()
        {
            var width = 80;
            var height = 80;

            var soup = new Board(width, height);
            soup.Init(Board._RandomState, new DefaultestEngine());

            var driver = new ConsoleGame();
            driver.InitConsole(width, height);
            driver.LightningBolt(soup);
        }
    }
}
