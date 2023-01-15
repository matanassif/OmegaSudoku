using System;

namespace Sudoku.Exceptions
{
    public class IllegalLengthException : Exception
    {
        //Thrown if the length of the sudoku string is illegal
        public IllegalLengthException(string message) : base(message)
        {

        }
    }
}