using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace GameOfLife.Extensions
{
    public static class BoardFileExtensions
    {
        private static readonly string FilePath = ".\\BoardStates\\";
        public static void SaveBoardState(this Board board, string fileName=null)
        {
            fileName = fileName ?? new DateTime().ToString();
            using (var sw = new StreamWriter(FilePath + fileName))
            {
                var serializedState = JsonConvert.SerializeObject(board.State);
                sw.Write(serializedState);
            }
        }

        public static Cell[,] LoadBoardState(this Board board, string fileName)
        {
            using (var sr = new StreamReader(FilePath + fileName))
            {
                var serializedState = sr.ReadToEnd();
                return JsonConvert.DeserializeObject<Cell[,]>(serializedState);
            }
        }
    }
}
