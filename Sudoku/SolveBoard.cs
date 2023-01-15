using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace Sudoku
{
    public class SolveBoard
    {
        /// <summary>
        /// Lets the user decide if he wants to insert the sudoku string by console or by file.
        /// </summary>
        /// <returns>The sudoku string</returns>
        public static string[] UserInput()
        {
            string[] choiceAndSudokuString = new string[3];

            while (true)
            {
                Console.WriteLine("\n\nIf you wish to insert sudoku by console, enter 'C'\nIf you wish to insert sudoku by file, enter 'F'");
                char choice = Console.ReadLine()[0];

                choiceAndSudokuString[2] = choice.ToString();

                InputOutput handler;

                switch (choice)
                {
                    case 'C':
                        handler = new ConsoleHandler();
                        string[] pahtAndSudokuString = handler.Read();

                        //The path
                        choiceAndSudokuString[0] = pahtAndSudokuString[0];

                        //The sudoku string
                        choiceAndSudokuString[1] = pahtAndSudokuString[1];

                        return choiceAndSudokuString;

                    case 'F':
                        handler = new FileHandler();
                        pahtAndSudokuString = handler.Read();

                        //The path
                        choiceAndSudokuString[0] = pahtAndSudokuString[0];

                        //The sudoku string
                        choiceAndSudokuString[1] = pahtAndSudokuString[1];

                        return choiceAndSudokuString;

                    default:
                        Console.WriteLine("'{0}' is an illegal response, please try again\n\n", choice);
                        break;
                }
            }
        }

        /// <summary>
        /// Presents the output of the program
        /// </summary>
        /// <param name="choice">The channel, which presents the output</param>
        /// <param name="board">The solved sudoku board</param>
        public static void Output(string channel, BoardClasses.Board board, string path)
        {
            InputOutput handler;

            switch (channel)
            {
                case "C":
                    handler = new ConsoleHandler();
                    handler.Write(board, path);
                    break;

                case "F":
                    handler = new FileHandler();
                    handler.Write(board, path);
                    handler = new ConsoleHandler();
                    handler.Write(board, path);
                    break;
            }

            Console.WriteLine(board.SudokuString);
        }

        /// <summary>
        /// The function Operates validation function on the given string and solves the sudoku using Dancing Links algorithm
        /// </summary>
        /// <param name="board">The sudoku board</param>
        /// <param name="sudokuString">The given string from the user</param>
        /// <returns>The solved sudoku in string form</returns>
        public static string Solving(BoardClasses.Board board, string sudokuString)
        {
            board.ConvertToMatrix();


            //Operating validation functions
            Validation.Validate(board);

            //Converting the sudoku board to a cover matrix
            byte[,] coverMatrix = board.ConvertToCoverMatrix();

            //Converting the cover matrix to a sparse matrix
            BoardClasses.SparseMatrix sparseMatrix = new BoardClasses.SparseMatrix(coverMatrix);

            //Finding the nodes which represent the result
            List<BoardClasses.SparseMatrixNode> algorithemXResult = sparseMatrix.solve();

            //Converting these nodes to a sudoku board
            board.ConvertToResult(algorithemXResult);

            //Converting the solved board to a string
            board.ConvertToString();

            return board.SudokuString;
        }

        public static bool SolveSudoku()
        {
            try
            {
                //Getting user input
                string[] choiceAndSudokuString = UserInput();

                //Channel of data (console or file)
                string path = choiceAndSudokuString[0];

                //The given sudoku string
                string sudokuString = choiceAndSudokuString[1];

                //The given path 
                string channel = choiceAndSudokuString[2];

                //A watch to measure the duration of the algorithem
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();

                int sudokuWidth = (int)Math.Sqrt(sudokuString.Length);
                BoardClasses.Board board = new BoardClasses.Board(sudokuString, sudokuWidth);

                string sudouString = Solving(board, sudokuString);

                //Stoping the watch and reporting the elapsed milliseconds
                stopwatch.Stop();
                Console.WriteLine("Time elapsed in milliseconds is: " + stopwatch.ElapsedMilliseconds);

                //Presenting the output
                Output(channel, board, path);
            }
            catch (Exceptions.FileNotTextFormatException fntfe)
            {
                Console.WriteLine(fntfe.Message.ToString());
            }
            catch (FileNotFoundException fnfe)
            {
                Console.WriteLine("The inserted file does not exist");
            }
            catch (UnauthorizedAccessException uae)
            {
                Console.WriteLine("There is unauthorized access to the given file");
            }
            catch (Exceptions.IllegalLengthException ile)
            {
                Console.WriteLine(ile.Message.ToString());
            }
            catch (Exceptions.IllegalElementValueException ieve)
            {
                Console.WriteLine(ieve.Message.ToString());
            }
            catch (Exceptions.IllegalElementPositionException iepe)
            {
                Console.WriteLine(iepe.Message.ToString());
            }
            catch (Exceptions.UnsolvableBoardException ube)
            {
                Console.WriteLine(ube.Message.ToString());
            }
            catch (SystemException)
            {
                Console.WriteLine("The given input is not valid");
            }
            return true;
        }
    }
}