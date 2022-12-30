using System;
using System.Collections.Generic;
using System.Text;

namespace Sudoku.Exceptions
{
    class IllegalLengthException : Exception
    {
        //Thrown if the length of the sudoku string is illegal
        public IllegalLengthException(string message) : base(message)
        {

        }
    }
}
