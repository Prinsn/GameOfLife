using GameOfLife.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameOfLife.Core.Rules
{
    public static class DefaultCellRuleDefinitions
    {
        public static CellState? UnderPopulation(CellState currentState, List<Cell> neighbors)
        {
            return _UnderPopulation(currentState, neighbors);
        }

        public static CellState? GoodPopulation(CellState currentState, List<Cell> neighbors)
        {
            return _GoodPopulation(currentState, neighbors);
        }

        public static CellState? OverPopulation(CellState currentState, List<Cell> neighbors)
        {
            return _OverPopulation(currentState, neighbors);
        }

        public static CellState? Reproduction(CellState currentState, List<Cell> neighbors)
        {
            return _Reproduction(currentState, neighbors);
        }

        /// <summary>
        /// Any live cell with 0 or 1 live neighbors becomes dead, because of underpopulation
        /// </summary>
        /// <param name="currentState">returns null if not alive</param>
        /// <param name="neighbors"></param>
        /// <param name="min">default 0</param>
        /// <param name="max">default 1</param>
        /// <returns>new cell state or null</returns>
        public static CellState? _UnderPopulation(CellState currentState, List<Cell> neighbors, int min = 0, int max = 1)
        {
            if (currentState != CellState.Alive)
                return null;

            if (BasicCoreRule(CellState.Alive, neighbors, min, max))
                return CellState.Dead;

            return null;
        }

        /// <summary>
        /// Any live cell with 2 or 3 live neighbors stays alive, because its neighborhood is just right
        /// </summary>
        /// <param name="currentState">returns null if not alive</param>
        /// <param name="neighbors"></param>
        /// <param name="min">default 2</param>
        /// <param name="max">default 3</param>
        /// <returns>new cell state or null</returns>
        public static CellState? _GoodPopulation(CellState currentState, List<Cell> neighbors, int min = 2, int max = 3)
        {
            if (currentState != CellState.Alive)
                return null;

            if (BasicCoreRule(CellState.Alive, neighbors, min, max))
                return CellState.Alive;

            return null;
        }

        /// <summary>
        /// Any live cell with more than 3 live neighbors becomes dead, because of overpopulation
        /// </summary>
        /// <param name="currentState">returns null if not alive</param>
        /// <param name="neighbors"></param>
        /// <param name="min">default 3</param>
        /// <param name="max">default max</param>
        /// <returns>new cell state or null</returns>
        public static CellState? _OverPopulation(CellState currentState, List<Cell> neighbors, int min = 3, int max = int.MaxValue)
        {
            if (currentState != CellState.Alive)
                return null;

            if (BasicCoreRule(CellState.Alive, neighbors, min, max))
                return CellState.Dead;

            return null;
        }

        /// <summary>
        ///Any dead cell with exactly 3 live neighbors becomes alive, by reproduction
        /// </summary>
        /// <param name="currentState">returns null if alive</param>
        /// <param name="neighbors"></param>
        /// <param name="min">default 3</param>
        /// <param name="max">default 3</param>
        /// <returns>new cell state or null</returns>
        public static CellState? _Reproduction(CellState currentState, List<Cell> neighbors, int min = 3, int max = 3)
        {
            if (currentState != CellState.Dead)
                return null;

            if (BasicCoreRule(CellState.Alive, neighbors, min, max))
                return CellState.Alive;

            return null;
        }

        public static bool BasicCoreRule(CellState compareState, List<Cell> neighbors, int min = 3, int max = 3)
        {
            var livingNeighbors = neighbors.Where(z => z.State == compareState);
            return livingNeighbors.Count() >= min && livingNeighbors.Count() <= max;
        }
    }
}
