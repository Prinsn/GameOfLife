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
    public class GlidersInADangerousTime : ISimulationTemplate
    {
        public void Run()
        {
            var width = 80;
            var height = 80;

            var soup = new Board(width, height);
            var engine = new DefaultEngine<WrappingMooreNeighborhood>();
            soup.Init(() => CellState.Dead, engine);

            soup.GliderAt(2, 10);
            soup.GliderAt(2, 30);
            soup.GliderAt(2, 50);
            soup.GliderAt(2, 70);

            soup.GliderAt(2, 5, true, false);
            soup.GliderAt(10, 25, true, false);
            soup.GliderAt(10, 55, true, false);
            soup.GliderAt(10, 65, true, false);


            soup.GliderAt(30, 20, false, false);
            soup.GliderAt(65, 40, false, true);
            var driver = new ConsoleGame();
            driver.InitConsole(width, height);
            driver.LightningBolt(soup);
        }  
    }
}
