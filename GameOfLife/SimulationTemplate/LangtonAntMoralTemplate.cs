﻿using GameOfLife._Game;
using GameOfLife.Actors;
using GameOfLife.Classes;
using GameOfLife.Engines;
using GameOfLife.Enums;
using GameOfLife.Interfaces;
using GameOfLife.Neighborhoods;

namespace GameOfLife.SimulationTemplate
{
    class LangtonAntMoralTemplate : ISimulationTemplate
    {
        public void Run()
        {
            var width = 80;
            var height = 80;

            var soup = new Board(width, height);
            //var engine = new DefaultEngine<WrappingMooreNeighborhood>();
            soup.Init(() => CellState.Dead, null);
            soup.Actors.Add(new LangtonAnt(new Coordinant(width / 2, height / 2), true));
            //MortalCells
            var maxLife = 100;
            soup.BoardIterator((x, y) => soup.State[x, y] = new AbsoluteMortalCell(soup.State[x, y], maxLife));

            var driver = new ConsoleGame();
            driver.InitConsole(width, height);
            driver.LightningBolt(soup);
        }
    }
}