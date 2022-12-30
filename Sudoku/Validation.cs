using System;
using System.Collections.Generic;
using System.Text;

namespace Sudoku
{
    class Validation
    {
        public static int IsLengthValid(string sudokuString)
        {
            /*Checks if the length of the given string is valid.
             If a square root exists for the string length, 
            then the function returns the width (which is also the height) of the sudoku board.
            Otherwise, the function throws the exception: IllegalLengthException*/

            int sudokuLength = 0;
            for (int stringIndex = 0; stringIndex < sudokuString.Length; stringIndex++)
            {
                sudokuLength += 1;
            }

            int squareRoot = (int)Math.Sqrt(sudokuLength);

            if (sudokuLength > 0 && squareRoot <= 25 && Math.Pow(squareRoot, 2) == sudokuLength)
                return squareRoot;

            throw new Exceptions.IllegalLengthException(String.Format("{0} is an illegal length for a sudoku board\n", sudokuLength));
        }

        public static void AreElementsValid(string sudokuString, int sudokuWidth)
        {
            /*Checks if every element in the given string is valid.
             If the ASCII value of any of the elements in the string is not between 48 (which is zero)
            to 48 + the width of the sudoku the function throws the exception: IllegalElementException*/

            for (int stringIndex = 0; stringIndex < sudokuString.Length; stringIndex++)
            {
                if ((int)sudokuString[stringIndex] < 48 || (int)sudokuString[stringIndex] > 48 + sudokuWidth)
                    throw new Exceptions.IllegalElementException(String.Format("'{0}' is an illegal element in the sudoku\n", sudokuString[stringIndex]));       
            }
        }
    }
}
