using System;

namespace Sudoku
{
    class Program
    {
        static void Main(string[] args)
        {
            string sudokuString = UserInput();
            int sudokuWidth = Validation.IsLengthValid(sudokuString);
            Console.WriteLine();
            Console.WriteLine(String.Format("Sudoku width: {0}", sudokuWidth));
            Console.WriteLine();
            Validation.AreElementsValid(sudokuString, sudokuWidth);
            BoardClasses.Board board = new BoardClasses.Board(sudokuString, sudokuWidth);
            board.convertToMatrix();
            Console.WriteLine("Given Sudoku:");
            board.printBoard();
            Console.WriteLine();
            Optimization.InsertOnlyOptions(board);
            board.convertToString();
            Console.WriteLine("Solved Sudoku:");
            Console.WriteLine(board.SudokuString);
            Console.WriteLine();
            board.printBoard();
        }

        public static string UserInput()
        {
            /*Lets the user decide if he wants to insert the sudoku string by console or by file.
            Returns the sudoku string*/

            while (true)
            {
                Console.WriteLine("If you wish to insert sudoku by console, enter 'C'\nIf you wish to insert sudoku by file, enter 'F'");
                char choice = Console.ReadLine()[0];

                if(choice == 'C')
                {
                    Console.WriteLine("Please enter the sudoku string here:\n");
                    string sudokuString = Console.ReadLine();
                    return sudokuString;
                }

                else if (choice == 'F')
                {
                    Console.WriteLine("Please enter the file's path here:\n");
                    string path = Console.ReadLine();
                    string sudokuString = System.IO.File.ReadAllText(path);
                    return sudokuString;
                }

                Console.WriteLine("'{0}' is an illegal response, please try again\n\n", choice);
            }
        }
    }
}
