using GameOfLife.Core._Game;
using GameOfLife.Core.Actors;
using GameOfLife.Core.Classes;
using GameOfLife.Core.Engines;
using GameOfLife.Core.Enums;
using GameOfLife.Core.Interfaces;
using GameOfLife.Core.Neighborhoods;

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
