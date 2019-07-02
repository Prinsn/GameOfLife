using GameOfLife.Core._Game;
using GameOfLife.Core.Engines;
using GameOfLife.Core.Enums;
using GameOfLife.Core.Interfaces;
using GameOfLife.Core.Neighborhoods;
using GameOfLife.Templates;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameOfLife.SimulationTemplate
{
    public class GosperGliderGunTemplate : ISimulationTemplate
    {
        public void Run()
        {
            var width = 80;
            var height = 80;

            var soup = new Board(width, height);
            var engine = new DefaultEngine<MooreNeighborhood>();
            soup.Init(() => CellState.Dead, engine);
            GosperGliderGun.GggAt(soup, 10, 10);
            var driver = new ConsoleGame();
            driver.InitConsole(width, height);
            driver.LightningBolt(soup);
        }    
    }
}
