using GameOfLife._Game;
using GameOfLife.Classes;
using GameOfLife.Engines;
using GameOfLife.Interfaces;
using GameOfLife.Neighborhoods;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameOfLife.SimulationTemplate
{
    public class MortalWrappingVonNeuman : ISimulationTemplate
    {
        public void Run()
        {
            var width = 80;
            var height = 80;

            var soup = new Board(width, height);
            var engine = new DefaultEngine<NoDiag_N_VonNeuman<N_3>>();
            soup.Init(Board._RandomState, engine);

            //MortalCells
            var maxLife = 4;
            soup.BoardIterator((x, y) => soup.State[x, y] = new AbsoluteMortalCell(soup.State[x, y], maxLife));

            var driver = new ConsoleGame();
            driver.InitConsole(width, height);
            driver.LightningBolt(soup);
        }
    }
}
