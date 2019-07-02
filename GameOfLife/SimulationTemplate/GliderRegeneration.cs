using GameOfLife.Core._Game;
using GameOfLife.Core.Actors;
using GameOfLife.Core.Classes;
using GameOfLife.Core.Engines;
using GameOfLife.Core.Enums;
using GameOfLife.Core.Interfaces;
using GameOfLife.Core.Neighborhoods;
using GameOfLife.Templates;

namespace GameOfLife.SimulationTemplate
{
    /// <summary>
    /// Ends at ~1000 generations but has a few instances of gliders coming out of the chaos
    /// </summary>
    public class GliderRegeneration : ISimulationTemplate
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

            soup.GliderAt(70, 5, true, false);
            soup.GliderAt(70, 25, true, false);
            soup.GliderAt(70, 55, true, false);
            soup.GliderAt(70, 65, true, false);

            soup.GliderAt(30, 30, false, false);
            soup.GliderAt(40, 40, false, false);
            soup.GliderAt(50, 50, false, false);
            soup.GliderAt(60, 60, false, false);

            soup.GliderAt(30, 60, false, true);
            soup.GliderAt(40, 50, false, true);
            soup.GliderAt(50, 40, false, true);
            soup.GliderAt(60, 30, false, true);

            var driver = new ConsoleGame();
            driver.InitConsole(width, height);
            driver.LightningBolt(soup);
        }
    }
}