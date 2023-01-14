using System;

namespace Sudoku.Exceptions
{
    class IllegalElementValueException : Exception
    {
        //Thrown if there is at least one element value in the sudoku string which is illegal
        public IllegalElementValueException(string message) : base(message)
        {

        }
    }
}