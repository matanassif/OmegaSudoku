using System;

namespace Sudoku.Exceptions
{
    public class UnsolvableBoardException : Exception
    {
        //Thrown if the the result of algorithem X is an empty list (meaning that the given board is unsolvable)
        public UnsolvableBoardException(string message) : base(message)
        {

        }
    }
}