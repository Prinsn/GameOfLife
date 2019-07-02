using GameOfLife.Core._Game;
using GameOfLife.Core.Actors;
using GameOfLife.Core.Classes;
using GameOfLife.Core.Engines;
using GameOfLife.Core.Enums;
using GameOfLife.Core.Interfaces;
using GameOfLife.Core.Neighborhoods;

namespace GameOfLife.SimulationTemplate
{
    public class MultiLangtonAntMortal : ISimulationTemplate
    {        
        private int _lifeTime;

        public MultiLangtonAntMortal(int cellLife = 100)
        {            
            _lifeTime = cellLife;
        }

        public void Run()
        {
            var width = 80;
            var height = 80;

            var soup = new Board(width, height);
            //var engine = new DefaultEngine<WrappingMooreNeighborhood>();
            soup.Init(() => CellState.Dead, null);
            soup.Actors.Add(new LangtonAnt(new Coordinant(width / 4, height / 4), true));
            soup.Actors.Add(new LangtonAnt(new Coordinant(width / 4 * 3, height / 4), true));
            soup.Actors.Add(new LangtonAnt(new Coordinant(width / 4, height / 4 * 3), true));
            soup.Actors.Add(new LangtonAnt(new Coordinant(width / 4 * 3, height / 4 * 3), true));
            
            //MortalCells
            soup.BoardIterator((x, y) => soup.State[x, y] = new AbsoluteMortalCell(soup.State[x, y], _lifeTime));

            var driver = new ConsoleGame();
            driver.InitConsole(width, height);
            driver.LightningBolt(soup);
        }
    }
}
