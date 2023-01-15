using System;
using System.Collections.Generic;
using System.Text;

namespace Sudoku.Exceptions
{
    class FileNotTextFormatException : Exception
    {
        //Thrown if the given path does not contain a text file
        public FileNotTextFormatException(string message) : base(message)
        {

        }
    }
}
