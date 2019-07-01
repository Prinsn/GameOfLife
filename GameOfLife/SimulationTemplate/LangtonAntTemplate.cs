using GameOfLife._Game;
using GameOfLife.Actors;
using GameOfLife.Classes;
using GameOfLife.Enums;
using GameOfLife.Interfaces;
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
