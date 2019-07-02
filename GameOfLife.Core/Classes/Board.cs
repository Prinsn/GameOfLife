using GameOfLife.Core.Classes;
using GameOfLife.Core.Engines.Abstract;
using GameOfLife.Core.Enums;
using GameOfLife.Core.Extensions;
using GameOfLife.Core.Neighborhoods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife
{
    public class Board
    {
        private IEnumerable<int> _xIterator { get; set; }
        private IEnumerable<int> _yIterator { get; set; }

        public int Width { get; private set; }

        public int Height { get; private set; }        
        public Cell[,] State { get; private set; }

        public List<Actor> Actors { get; private set; } = new List<Actor>();

        public Board(int w, int h)
        {
            Width = w;
            Height = h;
            _xIterator = Enumerable.Range(0, w).ToList();
            _yIterator = Enumerable.Range(0, h).ToList();
        }

        public Cell[,] Init(Func<CellState> initFunc, RuleEngine rules)
        {
            NeighborhoodCache.Reset();
            State = new Cell[Width, Height];

            BoardIterator((x, y) =>
            {
                State[x, y] = new Cell(initFunc(), x, y, rules);
            });

            return State;
        }

        public void UpdateBoard()
        {
            var board = this;
            List<Action> GetNewStates = new List<Action>();
            List<Action> UpdateStates = new List<Action>();

            BoardIterator((x, y) =>
            {
                GetNewStates.Add(() => State[x, y].BufferStateChange(board));
                UpdateStates.Add(() => State[x, y].UpdateState());
            });           

            //Needs threadsafe dictionary
            //Parallel.ForEach(GetNewStates, foo => foo());
            //Parallel.ForEach(UpdateStates, foo => foo());

            GetNewStates.ForEach(z => z());
            board.Actors.ForEach(a =>
            {
                a.ActOn(board);
            });
            UpdateStates.ForEach(z => z());
        }


        public static Func<CellState> _RandomState => () => RandomState();
        /// <summary>
        /// Probability of being alive is 1 / max
        /// </summary>
        /// <param name="max"></param>
        /// <returns></returns>
        public static CellState RandomState(int max = 2)
        {
            return Rng.Random.Next(max) % max == 0 ? CellState.Alive : CellState.Dead; 
        }

        /// <summary>
        /// Iterator delegator for two dimensional iteration over the board
        /// Default iteration is left (x 0 -> max) down y (0 -> max)
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="right"></param>
        /// <param name=""></param>
        public void BoardIterator(Action<int, int> predicate, bool right = true, bool down = true, int fromX = 0, int fromY = 0)
        {
            var cols = right ? _xIterator : _xIterator.Reverse();
            var rows = down ? _yIterator : _yIterator.Reverse();
            foreach(var y in rows)
            {
                foreach(var x in cols)
                {
                    predicate(x, y);
                }
            }
        }

        public void LoadFromFile(string filename)
        {
            State = this.LoadBoardFromFile(filename);
        }

        public override string ToString()
        {
            return Print((x, y) => ((int)State[x, y].State).ToString());
        }


        public string VisualString()
        {
            return Print((x, y) => Visualize(State[x, y].State));
        }

        public void InitFromString(string boardState, RuleEngine engine)
        {
            NeighborhoodCache.Reset();
            var singleString = string.Join("", boardState.Trim().Split(Environment.NewLine));
            var i = 0;
            var board = this;
            BoardIterator((x, y) => {
                int state = 0;
                int.TryParse(boardState[i++].ToString(), out state);
                var cell = new Cell((CellState)state, x, y, engine);
                board.State[x, y] = cell;
            });
        }

        public string Print(Func<int, int, string> printFunc, bool newLine = true)
        {
            var sb = new StringBuilder();
            var rowTracker = 0;
            BoardIterator((x, y) =>
            {
                if (rowTracker != y)
                {
                    if (newLine)
                    {
                        sb.Append(Environment.NewLine);
                    }
                    rowTracker = y;
                }

                sb.Append(printFunc(x, y));
            });

            return sb.ToString();
        }

        public string Visualize(CellState state)
        {
            return state == CellState.Alive ? "■" : " ";
        }
    }
}
