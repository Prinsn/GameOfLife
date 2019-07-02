using GameOfLife.Core._Game;
using GameOfLife.Core.Actors;
using GameOfLife.Core.Classes;
using GameOfLife.Core.Enums;
using GameOfLife.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameOfLife.SimulationTemplate
{
    public class LangtonAntTemplate : ISimulationTemplate
    {
        public void Run()
        {
            var width = 80;
            var height = 80;

            var soup = new Board(width, height);
            soup.Init(() => CellState.Dead, null);
            soup.Actors.Add(new LangtonAnt(new Coordinant(width / 2, height / 2), false));

            var driver = new ConsoleGame();
            driver.InitConsole(width, height);
            driver.LightningBolt(soup);
        }    
    }
}
