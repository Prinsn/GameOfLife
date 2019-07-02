using GameOfLife.Core.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameOfLife.Core.Classes
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

        public Coordinant(Coordinant from)
        {
            _x = from.X;
            _y = from.Y;
        }

        public bool WrapX(int bound)
        {
            return UpdateWrap(bound, ref _x);
        }

        public bool WrapY(int bound)
        {
            return UpdateWrap(bound, ref _y);
        }

        public bool Wrap(int xBound, int yBound)
        {
            var x = WrapX(xBound);
            var y = WrapY(yBound);
            return x || y;
        }

        private bool UpdateWrap(int bound, ref int prop)
        {
            if (prop < 0)
            {
                prop += bound;
                return true;
            }

            if (prop >= bound)
            {
                prop -= bound;
                return true;
            }

            return false;
        }

        public bool Clamp(int xBound, int yBound)
        {
            var x = ClampX(xBound);
            var y = ClampY(yBound);
            return x || y;
        }

        public bool ClampX(int bound)
        {
            return UpdateClamp(bound, ref _x);
        }

        public bool ClampY(int bound)
        {
            return UpdateClamp(bound, ref _y);
        }

        public bool UpdateClamp(int bound, ref int prop)
        {
            if (prop < 0)
            {
                prop = 0;
                return true;
            }

            if (prop >= bound)
            {
                prop = bound -1;
                return true;
            }

            return false;
        }

        public void Move(Direction direction)
        {
            switch (direction)
            {
                case Direction.N:
                    _x--;
                    break;
                case Direction.S:
                    _x++;
                    break;
                case Direction.E:
                    _y--;
                    break;
                case Direction.W:
                    _y++;
                    break;
            }
        }
    }
}
