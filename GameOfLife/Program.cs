using GameOfLife._Game;
using GameOfLife.Engines;
using System.Threading.Tasks;

namespace GameOfLife
{
    class Program
    {

        static void Main(string[] args)
        {

            var width = 80;
            var height = 80;

            var soup = new Board(width, height);
            soup.Init(Board._RandomState, new DefaultEngine());

            var driver = new ConsoleGame();
            driver.InitConsole(width, height);
            driver.LightningBolt(soup);
        }        
    }
}
