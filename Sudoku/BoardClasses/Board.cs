using System;
using System.Collections.Generic;
using System.Text;

namespace Sudoku.BoardClasses
{
    class Board
    {
        private string sudokuString;
        private int width;
        private int height;
        private Cell[,] elements;
        
        public Board(string sudokuString, int width)
        {
            this.sudokuString = sudokuString;
            this.width = width;
            this.height = width; //In sudoku the width and the height are equal
            this.elements = new Cell[width, width];
        }

        public int Height { get => height; set => height = value; }
        public int Width { get => width; set => width = value; }
        public string SudokuString { get => sudokuString; set => sudokuString = value; }

        public Cell[,] getElements()
        {
            //Returns the array of cells

            return this.elements;
        }
        public void convertToMatrix()
        {
            //Converts the sudoku string to a matrix

            for (int row = 0; row < this.height; row++)
            {
                for (int col = 0; col < this.width; col++)
                {
                    this.elements[row, col] = new Cell(row, col, this.width);
                    this.elements[row, col].FinalValue = this.sudokuString[this.width * row + col];
                }
            }
        }

        public void convertToString()
        {
            //Converts the sudoku matrix to a string

            this.sudokuString = "";
            for (int row = 0; row < this.height; row++)
            {
                for (int col = 0; col < this.width; col++)
                {
                    this.sudokuString += this.elements[row, col].FinalValue;
                }
            }
        }

        public void printBoard()
        {
            //Prints the sudoku board

            for (int row = 0; row < this.height; row++)
            {
                for (int col = 0; col < this.width; col++)
                {
                    Console.Write(this.elements[row,col].FinalValue + "\t");
                }
                Console.WriteLine(' ');
            }
        }
    }
}
