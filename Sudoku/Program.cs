using System;
using System.Diagnostics;

namespace Sudoku
{
    public class Program
    {
        static void Main(string[] args)
        {
            while(true)
                 SolveBoard.SolveSudoku();
        }
    }
}