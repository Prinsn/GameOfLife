using GameOfLife;
using GameOfLife.Classes;
using GameOfLife.Engines;
using GameOfLife.Enums;
using GameOfLife.Templates;
using Newtonsoft.Json;
using NUnit.Framework;

namespace Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
           
        }

        [Test]
        public void BoardInitialize()
        {
            var board = new Board(5, 5);
            board.Init(() => CellState.Dead, new DefaultEngine());
            board.BoardIterator((x, y) => Assert.NotNull(board.State[x, y]));
        }

        [Test]
        public void ToadBehavior()
        {
            var board = new Board(5, 5);
            board.Init(() => CellState.Dead, new DefaultEngine());
            board.ToadAt(1, 1);

            var period0 = JsonConvert.SerializeObject(board.State);            
            board.UpdateBoard();
            var period1 = JsonConvert.SerializeObject(board.State);
            board.UpdateBoard();
            var period2 = JsonConvert.SerializeObject(board.State);

            //Two period oscilator
            Assert.AreEqual(period0, period1);
            Assert.AreEqual(period0, period2);

            //This test passes but the program didn't work
            Assert.IsTrue(false);
        }
    }
}