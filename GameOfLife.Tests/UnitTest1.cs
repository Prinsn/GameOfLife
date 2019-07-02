using GameOfLife;
using GameOfLife.Core.Classes;
using GameOfLife.Core.Engines;
using GameOfLife.Core.Enums;
using GameOfLife.Core.Neighborhoods;
using GameOfLife.Templates;
using Newtonsoft.Json;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

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
            board.Init(() => CellState.Dead, new DefaultestEngine());
            board.BoardIterator((x, y) => Assert.NotNull(board.State[x, y]));
        }

        [Test]
        public void ToadBehavior()
        {
            var board = new Board(5, 5);
            board.Init(() => CellState.Dead, new DefaultestEngine());
            board.ToadAt(1, 1);

            var period0 = JsonConvert.SerializeObject(board.State);            
            board.UpdateBoard();
            var period1 = JsonConvert.SerializeObject(board.State);
            board.UpdateBoard();
            var period2 = JsonConvert.SerializeObject(board.State);

            //Two period oscilator
            Assert.AreNotEqual(period0, period1);
            Assert.AreEqual(period0, period2);
        }

        [Test]
        public void VonNeumanShapeTest()
        {
            var testList = new N_VonNeuman[] {
                new N_VonNeuman<N_1>(),
                new N_VonNeuman<N_2>(),
                new N_VonNeuman<N_3>()
            };

            var count = new int[3];
            count[0] = 4;
            count[1] = count[0] + 8;
            count[2] = count[1] + 16;

            for(var i = 0; i < testList.Length; i++)
            {
                var coords = testList[i].GetNeighborCoords(new Coordinant(0, 0));
#if DEBUG
                var humanReadable = coords.Select(z => $"{z.X} , {z.Y}").ToList();
#endif
                Assert.IsTrue(coords.Count == count[i]);
            }
        }

        [Test]
        public void VonNeumanWrapTest()
        {
            var width_0 = 4;
            var height_0 = 4;
            var wvn = new Wrapping_N_VonNeuman<N_2>();
            var testList = new List<Coordinant>()
            {
                new Coordinant(0, 0),
                new Coordinant(0, height_0),
                new Coordinant(width_0, 0),
                new Coordinant(width_0, height_0)
            };


            foreach (var coord in testList)
            {
                var wrapped = 0;
                var coords = wvn.GetNeighborCoords(coord);
                var expectedWrap = coords.Count - 6;
#if DEBUG
                var humanReadable1 = coords.Select(z => $"{z.X} , {z.Y}").ToList();
#endif
                coords.ForEach(c =>
                {
                    if (c.Wrap(width_0+1, height_0+1))
                        ++wrapped;
                });

#if DEBUG
                var humanReadable2 = coords.Select(z => $"{z.X} , {z.Y}").ToList();
#endif

                //All but 5 should be wrapped, 6 -1 as the origin point isn't counted
                Assert.IsTrue(wrapped == coords.Count() - 5);
            }
        }
    }
}