using System;

namespace Sudoku.Exceptions
{
    public class IllegalElementPositionException : Exception
    {
        //Thrown if the position of the element is illegal
        public IllegalElementPositionException(string message) : base(message)
        {

        }
    }
}