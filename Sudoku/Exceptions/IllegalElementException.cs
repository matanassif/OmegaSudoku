using System;
using System.Collections.Generic;
using System.Text;

namespace Sudoku.Exceptions
{
    class IllegalElementException : Exception
    {
        //Thrown if there is at least one element in the sudoku string which is illegal
        public IllegalElementException(string message) : base(message)
        {

        }
    }
}
