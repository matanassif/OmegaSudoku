using System;

namespace Sudoku
{
    class Validation
    {
        /// <summary>
        /// Checks if the length of the given string is valid.
        ///  If a square root exists for the string length,
        /// then the function returns the width(which is also the height) of the sudoku board.
        ///Otherwise, the function throws the exception: IllegalLengthException
        /// </summary>
        /// <param name="sudokuString">The given string which represents the sudoku board</param>
        /// <returns>The width of the sudoku board if the Length is valid</returns>
        public static int IsLengthValid(string sudokuString)
        {
            int sudokuLength = 0;
            for (int stringIndex = 0; stringIndex < sudokuString.Length; stringIndex++)
            {
                sudokuLength += 1;
            }

            int squareRoot = (int)Math.Sqrt(sudokuLength);
            int squareRootOfsquareRoot = (int)Math.Sqrt(squareRoot);

            //Checking the length has a squareroot(meaning the width of the board) and the width has a squareroot(meaning the width of every box in board)
            if (sudokuLength > 0 && squareRoot <= 25 && Math.Pow(squareRoot, 2) == sudokuLength && Math.Pow(squareRootOfsquareRoot, 2) == squareRoot)
                return squareRoot;

            throw new Exceptions.IllegalLengthException(String.Format("{0} is an illegal length for a sudoku board\n", sudokuLength));
        }

        /// <summary>
        /// Checks if every element in the given string is valid.
        /// If the ASCII value of any of the elements in the string is not between 48 (which is zero)
        /// to 48 + the width of the sudoku the function throws the exception: IllegalElementException
        /// </summary>
        /// <param name="sudokuString">The given string which represents the sudoku board</param>
        /// <param name="sudokuWidth">The width and height of the sudoku board</param>
        public static void AreElementsValuesValid(string sudokuString, int sudokuWidth)
        {
            for (int stringIndex = 0; stringIndex < sudokuString.Length; stringIndex++)
            {
                if ((int)sudokuString[stringIndex] < 48 || (int)sudokuString[stringIndex] > 48 + sudokuWidth)
                    throw new Exceptions.IllegalElementValueException(String.Format("'{0}' is an illegal element in the sudoku\n", sudokuString[stringIndex]));       
            }
        }

        /// <summary>
        /// Checks if every element's position in the given string is valid.
        /// If the element has in its column/row/box another element with the same value,
        /// the function throws the exception: IllegalElementPositionException
        /// </summary>
        /// <param name="board">The sudoku board</param>
        public static void AreElementsPositionValid(BoardClasses.Board board)
        {
            foreach (BoardClasses.Cell cell in board.GetElements())
            {
                //Checks the cell's column
                for (int row = 0; row < board.Width; row++)
                {
                    if (row != cell.RowIndex)
                    {
                        BoardClasses.Cell currentCell = board.GetElements()[row, cell.ColIndex];
                        if (currentCell.FinalValue == cell.FinalValue && cell.FinalValue != '0')
                        {
                            throw new Exceptions.IllegalElementPositionException($"In row number {row + 1}, the number {cell.FinalValue} exists more than once");
                        }
                    }
                }

                //Checks the cell's row
                for (int col = 0; col < board.Width; col++)
                {
                    if (col != cell.ColIndex)
                    {
                        BoardClasses.Cell currentCell = board.GetElements()[cell.RowIndex, col];
                        if (currentCell.FinalValue == cell.FinalValue && cell.FinalValue != '0')
                        {
                            throw new Exceptions.IllegalElementPositionException($"In row number {col + 1}, the number {cell.FinalValue} exists more than once");
                        }
                    }
                }

                //Checks the cell's box
                int boxWidth = (int)Math.Sqrt(board.Width);

                for (int row = boxWidth * (cell.RowIndex / boxWidth); row < boxWidth * (cell.RowIndex / boxWidth) + boxWidth; row++)
                {
                    for (int col = boxWidth * (cell.ColIndex / boxWidth); col < boxWidth * (cell.ColIndex / boxWidth) + boxWidth; col++)
                    {
                        if (row != cell.RowIndex && col != cell.ColIndex)
                        {
                            BoardClasses.Cell currentCell = board.GetElements()[row, col];
                            if (currentCell.FinalValue == cell.FinalValue && cell.FinalValue != '0')
                            {
                                throw new Exceptions.IllegalElementPositionException($"In box which starts at ({row + 1}, {col + 1}), the number {cell.FinalValue} exists more than once");
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Activates all the validation functions
        /// </summary>
        /// <param name="board">The sudoku board</param>
        public static void Validate(BoardClasses.Board board)
        {
            IsLengthValid(board.SudokuString);
            AreElementsValuesValid(board.SudokuString, board.Width);
            AreElementsPositionValid(board);
        }
    }
}