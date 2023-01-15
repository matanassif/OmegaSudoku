using Sudoku.BoardClasses;
using System;
using System.IO;

namespace Sudoku
{
    /// <summary>
    /// Handles reading from a file and writing to a file
    /// </summary>
    public class FileHandler : InputOutput
    {
        /// <summary>
        /// Reads the input from a file
        /// </summary>
        /// <returns>The path and the given sudoku string</returns>
        public string[] Read()
        {
            Console.WriteLine("Please enter the file's path here:\n");
            string[] pathAndSudokuString = new string[2];

            //Path
            pathAndSudokuString[0] = Console.ReadLine();

            //Throws an exception if the path does not contain a text file
            if (!pathAndSudokuString[0].EndsWith(".txt"))
                throw new Exceptions.FileNotTextFormatException("The given path does not contain a text file");

            //Sudoku string
            pathAndSudokuString[1] = File.ReadAllText(pathAndSudokuString[0]);

            return pathAndSudokuString;
        }

        /// <summary>
        /// Writes the output to a file
        /// </summary>
        /// <param name="board">The sudoku board</param>
        /// <param name="path">The path of the file</param>
        public void Write(Board board, string path)
        {
            board.ConvertToString();
            File.WriteAllText(path, board.SudokuString);
        }
    }
}