using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace GameOfLife.Core.Extensions
{
    public static class BoardFileExtensions
    {
        private static readonly string FilePath = ".\\BoardStates\\";
        public static void SaveBoardToFile(this Board board, string fileName=null)
        {
            fileName = fileName ?? new DateTime().ToString();
            using (var sw = new StreamWriter(FilePath + fileName))
            {
                var serializedState = JsonConvert.SerializeObject(board.State);
                sw.Write(serializedState);
            }
        }

        public static Cell[,] LoadBoardFromFile(this Board board, string fileName)
        {
            using (var sr = new StreamReader(FilePath + fileName))
            {
                var serializedState = sr.ReadToEnd();
                return JsonConvert.DeserializeObject<Cell[,]>(serializedState);
            }
        }
    }
}
