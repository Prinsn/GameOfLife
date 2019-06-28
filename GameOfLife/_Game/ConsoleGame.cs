using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GameOfLife._Game
{
    public class ConsoleGame
    {
        private const int _frameSampleCount = 10;
        private int Generation = 0;
        public Queue<double> FrameTimes = new Queue<double>(_frameSampleCount);

        public void LightningBolt(Board board)
        {
            //Life is automatic and eternal
            var lastUpdate = DateTime.Now;
            while (true)
            {
                PrintBoard(board);
                board.UpdateBoard();
                RefreshDelay(ref lastUpdate);
            }
        }

        public void PrintBoard(Board board)
        {
            Console.SetCursorPosition(0, 0);
            Console.Write(board.ToString());
        }

        public void InitConsole(int w, int h)
        {
            try
            {
                Console.WindowWidth = Console.BufferWidth = w + 5;
                Console.WindowHeight = Console.BufferHeight = h + 5;
            }
            catch
            {
                //Just default to max size if any sizes are exceeded
                Console.WindowWidth = Console.BufferWidth = Console.LargestWindowWidth;
                Console.WindowHeight = Console.BufferHeight = Console.LargestWindowHeight;
            }

            Console.CursorVisible = false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="last"></param>
        /// <param name="refreshRate">Refresh rate in miliseconds</param>
        public void RefreshDelay(ref DateTime last, int refreshRate = 100)
        {
            var now = DateTime.Now;
            var elapsed = (int)(now.Ticks - last.Ticks) / 10000;
            var ms = (int)(now.Millisecond - last.Millisecond);
            if (elapsed < 0 || ms < 0)
            {
                elapsed += 0;
            }

            last = now;
            if (FrameTimes.Count == _frameSampleCount)
            {
                FrameTimes.Dequeue();
            }

            FrameTimes.Enqueue(elapsed);

            if (elapsed < refreshRate)
            {
                Thread.Sleep(refreshRate - elapsed);
            }

            Console.WriteLine("");

            var avg = Math.Round(FrameTimes.Sum() / FrameTimes.Count);
            var maxFps = Math.Round(1/(refreshRate /1000.0));            
            var fps = Math.Round(1.0/(avg/1000.0));
            Console.WriteLine($"FPS: {Math.Min(fps, maxFps)}/ {maxFps}".PadRight(5));            
            Console.WriteLine($"Generation: {Generation++}");            
            //Console.WriteLine($"Actual Framerate Delay: {avg} ms".PadRight(50));
        }
    }
}
