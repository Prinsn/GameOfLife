using GameOfLife.Engines;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace GameOfLife
{
    class Program
    {
        public static int AvgSample = 10;
        public static Queue<double> FrameTimes = new Queue<double>(AvgSample);
        static void Main(string[] args)
        {
            var board = new Board(10, 10);
            board.Init(Board._RandomState, new DefaultEngine());

            Console.SetWindowSize(80, 80);
            Console.SetBufferSize(80, 80);

            Console.CursorVisible = false;

            //Life is automatic and eternal
            var lastUpdate = DateTime.Now;
            while (true)
            {
                Console.SetCursorPosition(0, 0);
                Console.Write(board.ToString());
                board.UpdateBoard();
                RefreshDelay(ref lastUpdate);                
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="last"></param>
        /// <param name="refreshRate">Refresh rate in miliseconds</param>
        static void RefreshDelay(ref DateTime last, int refreshRate = 100)
        {
            var now = DateTime.Now;
            var elapsed = last.Millisecond - now.Millisecond;
            last = now;
            if(FrameTimes.Count == AvgSample)
            {
                FrameTimes.Dequeue();
            }

            if (elapsed < refreshRate)
            {
                Thread.Sleep(refreshRate - elapsed);
                FrameTimes.Enqueue(0);
            }            
            else
            {
                FrameTimes.Enqueue(elapsed);
            }

            Console.WriteLine($"\nFrame rate: {refreshRate} ms");
            var avg = FrameTimes.Sum() / FrameTimes.Count;
            Console.WriteLine($"Average Delay: {avg} ms".PadRight(50));
        }
    }
}
