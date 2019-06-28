using GameOfLife.Classes;
using GameOfLife.Classes.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameOfLife.Neighborhoods
{
    public abstract class N_VonNeuman : ICellNeighborhood
    {
        protected const int MIN_DISTANCE = 1;
        public int Distance { get; protected set; }

        protected virtual bool _wrapping { get; } = false;
        protected virtual bool _diagonals { get; } = true;

        public List<Cell> GetNeighbors(Board board, Cell cell)
        {
            var neighbors = NeighborhoodCache.GetCachedNeighbors(board, cell);
            if (neighbors.Any())
                return neighbors;

            var coordinantes = GetNeighborCoords(new Coordinant(cell.PosX, cell.PosY));
            coordinantes.ForEach(z =>
            {
                if (TryProcessBounds(board.Height - 1, board.Width - 1, ref z))
                {
                    neighbors.Add(board.State[z.X, z.Y]);
                }
            });

            return neighbors;
        }

        public List<Coordinant> GetNeighborCoords(Coordinant origin)
        {
            var points = new List<Coordinant>();
            for (var step = 1; step <= Distance; step++)
            {
                points.AddRange(new List<Coordinant>()
                {
                    new Coordinant(origin.X - step, origin.Y),
                    new Coordinant(origin.X + step, origin.Y),
                    new Coordinant(origin.X, origin.Y - step),
                    new Coordinant(origin.X, origin.Y + step)
                });

                if (_diagonals)
                {
                    points.AddRange(GetDiagonals(step));
                }
            }

            return points;
        }

        public List<Coordinant> GetDiagonals(int step)
        {
            var diagonalInterval = step - 1;
            var coords = new List<Coordinant>();
            for (var dStep = 1; dStep <= diagonalInterval; dStep++)
            {
                for (var slider = 0; slider < dStep; slider++)
                {
                    var y = dStep - slider;
                    var x = slider + 1;
                    coords.AddRange(new List<Coordinant>()
                    {
                        new Coordinant(x, y),
                        new Coordinant(-x, y),
                        new Coordinant(x, -y),
                        new Coordinant(-x, -y)
                    });
                }
            }

            return coords;
        }

        public bool TryProcessBounds(int width, int height, ref Coordinant coord)
        {
            if (coord.WrapX(width) && _wrapping)
                return false;

            if (coord.WrapY(height) && _wrapping)
                return false;


            return true;
        }
    }

    public class N_VonNeuman<TDistance> : N_VonNeuman where TDistance : IManhattanDistance, new()
    {


        public N_VonNeuman()
        {
            var distance = MIN_DISTANCE;

            try
            {
                int.TryParse(this.GetType().GenericTypeArguments[0].Name.Split('_')[1], out distance);
            }
            catch
            {
#if DEBUG
                throw new Exception("99% case that you're just not using the stupid convention I made.  An IManhattanDistance needs to be of name *_#.  It'll just use the default distance if it ever fails, so this isn't breaking, just stupid and I'm sorry.");
#endif
            }

            Distance = distance;
        }
    }    

    public class NoDiag_N_VonNeuman<TDistance> : N_VonNeuman<TDistance> where TDistance : IManhattanDistance, new()
    {
        protected override bool _diagonals => false;
    }

    public class Wrapping_N_VonNeuman<TDistance> : N_VonNeuman<TDistance> where TDistance : IManhattanDistance, new()
    {
        protected override bool _wrapping { get; } = true;
    }

    public class NoDiagWrapping_N_VonNeuman<TDistance> : N_VonNeuman<TDistance> where TDistance : IManhattanDistance, new()
    {
        protected override bool _wrapping { get; } = true;
        protected override bool _diagonals => false;
    }

    #region Junk for simulating templates
    public interface IManhattanDistance { }

    public class N_1 : IManhattanDistance { }
    public class N_2 : IManhattanDistance { }
    public class N_3 : IManhattanDistance { }

    //Anything below this line does not produce anything useful with default rules, will extinct in a few generations
    public class N_4 : IManhattanDistance { }
    public class N_5 : IManhattanDistance { }
    public class N_6 : IManhattanDistance { }
    public class N_7 : IManhattanDistance { }
    public class N_8 : IManhattanDistance { }
    public class N_9 : IManhattanDistance { }
    public class N_10 : IManhattanDistance { }
    public class N_11 : IManhattanDistance { }
    #endregion
}
