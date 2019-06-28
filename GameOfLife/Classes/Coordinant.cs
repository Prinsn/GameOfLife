using System;
using System.Collections.Generic;
using System.Text;

namespace GameOfLife.Classes
{
    public class Coordinant
    {
        private int _x;
        public int X => _x;
        private int _y;
        public int Y => _y;

        public Coordinant(int x, int y)
        {
            _x = x;
            _y = y;
        }

        public bool WrapX(int bound)
        {
            return UpdateBounds(bound, ref _x);
        }

        public bool WrapY(int bound)
        {
            return UpdateBounds(bound, ref _y);
        }

        public bool Wrap(int xBound, int yBound)
        {
            var x = WrapX(xBound);
            var y = WrapY(yBound);
            return x || y;
        }

        private bool UpdateBounds(int bound, ref int prop)
        {
            if (prop < 0)
            {
                prop += bound;
                return true;
            }

            if (prop > bound)
            {
                prop -= bound;
                return true;
            }

            return false;
        }
    }
}
