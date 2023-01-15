using System;

namespace Sudoku
{
    /// <summary>
    /// Handles reading from the console and writing to the console
    /// </summary>
    public class ConsoleHandler : InputOutput
    {
        /// <summary>
        /// Reads the input from the console
        /// </summary>
        /// <returns>The path and the given sudoku string</returns>
        public string[] Read()
        {
            Console.WriteLine("Please enter the sudoku string here:\n");
            string[] pathAndSudokuString = new string[2];

            //Path
            pathAndSudokuString[0] = null;

            //Sudoku string
            pathAndSudokuString[1] = Console.ReadLine();
            return pathAndSudokuString;
        }

        /// <summary>
        /// Writes the output to the console
        /// </summary>
        /// <param name="board">The sudoku board</param>
        /// <param name="path">null</param>
        public void Write(BoardClasses.Board board, string path)
        {
            board.PrintBoard();
        }
    }
}