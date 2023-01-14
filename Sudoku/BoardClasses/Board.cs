using System;
using System.Collections.Generic;

namespace Sudoku.BoardClasses
{
    class Board
    {
        //The given sudoku string which will be changed to the string of the result
        private string sudokuString;

        //The width and height of the board(regular board width is 9)
        private int width;

        //A matrix of the cells of the sudoku
        private Cell[,] elements;

        //The 4 constarints of the sudoku (cell, columns, rows and boxes)
        private const int CONSTRAINTS_AMOUNT = 4;
        
        public Board(string sudokuString, int width)
        {
            this.sudokuString = sudokuString;
            this.width = width;
            this.elements = new Cell[width, width];
        }

        public int Width { get => width; set => width = value; }
        public string SudokuString { get => sudokuString; set => sudokuString = value; }

        /// <summary>
        /// Returns the array of cells
        /// </summary>
        /// <returns>The array of cells</returns>
        public Cell[,] GetElements()
        {
            return this.elements;
        }

        /// <summary>
        /// Converts the given string to a sudoku board
        /// </summary>
        public void ConvertToMatrix()
        {
            //Converts the sudoku string to a matrix

            for (int row = 0; row < this.width; row++)
            {
                for (int col = 0; col < this.width; col++)
                {
                    this.elements[row, col] = new Cell(row, col);
                    this.elements[row, col].FinalValue = this.sudokuString[this.width * row + col];
                }
            }
        }
        
        /// <summary>
        /// Converts the sudoku board to string which will be inserted into the file if necessary
        /// </summary>
        public void ConvertToString()
        {
            //Converts the sudoku matrix to a string

            this.sudokuString = "";
            for (int row = 0; row < this.width; row++)
            {
                for (int col = 0; col < this.width; col++)
                {
                    this.sudokuString += this.elements[row, col].FinalValue;
                }
            }
        }

        /// <summary>
        /// Prints the sudoku board
        /// </summary>
        public void PrintBoard()
        {
            //Prints the sudoku board

            for (int row = 0; row < this.width; row++)
            {
                for (int col = 0; col < this.width; col++)
                {
                    Console.Write(this.elements[row,col].FinalValue + "\t");
                }
                Console.WriteLine(' ');
            }
        }

        /// <summary>
        /// Converts the given sudoku board to a Cover Matrix according to Dancing Links
        /// </summary>
        /// <returns>The Cover Matrix which is a byte matrix</returns>
        public byte[,] ConvertToCoverMatrix()
        {
            //Setting the starting positions of the 4 constraits columns
            int cellColumnPosition = 0;
            int rowColumnPosition =  2 * this.width * this.width;
            int boxColumnPosition = rowColumnPosition + this.width * this.width;

            //Creating the cover matrix
            byte[,] matrix = new byte[this.width * this.width * this.width, this.width * this.width * CONSTRAINTS_AMOUNT];
            //Console.WriteLine($"Row length: {this.width * this.width * this.width}, Col length: {this.width * this.width * CONSTRAINTS_AMOUNT}");
            //Setting the starting position of the row
            int rowPosition = 0;

            //Setting the possible values in the cover matrix for every element 
            for (int rowIndex = 0; rowIndex < this.width; rowIndex++)
            {
                int colColumnPosition = this.width * this.width;

                for (int colIndex = 0; colIndex < this.width; colIndex++)
                {
                    int element = this.elements[rowIndex, colIndex].FinalValue - '0';
                    int square = (rowIndex / (int)Math.Sqrt(this.width)) * (int)Math.Sqrt(this.width) + colIndex / (int)Math.Sqrt(this.width);

                    //If the element is zero, then all the numbers between 1 to (this.width + 1) are possible 
                    if (element == 0)
                    {
                        for (int possibility = 0; possibility < this.width; possibility++)
                        {
                            //Inserting 1 in the proper locations
                            matrix[rowPosition, cellColumnPosition] = 1;
                            matrix[rowPosition, colColumnPosition] = 1;
                            matrix[rowPosition, rowColumnPosition + possibility] = 1;
                            matrix[rowPosition, boxColumnPosition + square * this.width + possibility] = 1;

                            //Advancing the rowPosition and colColumnPosition by 1
                            rowPosition += 1;
                            colColumnPosition += 1;
                        }
                    }

                    //Else, FinalValue is the only possibility, since it was given by the user
                    else
                    {
                        //Skipping the rest of the numbers between 1 to FinalValue
                        rowPosition += element - 1;
                        colColumnPosition += element - 1;

                        //Inserting 1 in the proper locations
                        matrix[rowPosition, cellColumnPosition] = 1;
                        matrix[rowPosition, colColumnPosition] = 1;
                        matrix[rowPosition, rowColumnPosition + element - 1] = 1;
                        matrix[rowPosition, boxColumnPosition + square * this.width + element - 1] = 1;

                        //Skipping the rest of the numbers between FinalValue to (this.width + 1)
                        //Console.WriteLine(String.Format($"Row index: {rowPosition}, Col index: {colColumnPosition}, Actual Row index: {rowIndex}, Actual Col index: {colIndex}, Element: {element}, this.width: {this.width}"));
                        rowPosition += this.width - element + 1;
                        colColumnPosition += this.width - element + 1;
                    }

                    //every time we have finished handling the cell we go to the next one, so we add 1 to the cellColumnPosition
                    cellColumnPosition += 1;
                }

                //every time we have finished handling the row we go to the next one, so we add 1 to the rowColumnPosition
                rowColumnPosition += this.width;
            }

            return matrix;
        }

        /// <summary>
        /// Converts the representation of the nodes to a value which is inserted into its corresponding cell
        /// </summary>
        /// <param name="resultsList">List of the nodes which represents the value in each cell</param>
        public void ConvertToResult(List<SparseMatrixNode> resultsList)
        {
            //Goes over the nodes in the list
            while (resultsList.Count != 0)
            {
                //Taking out the last node in the list
                SparseMatrixNode resultNode = resultsList[resultsList.Count - 1];
                resultsList.RemoveAt(resultsList.Count - 1);

                //Finding the node in the leftmost column
                SparseMatrixNode beginningNode = resultNode;
                SparseMatrixNode nextResult = beginningNode.Previous;

                while(resultNode.MainCol.Index > nextResult.MainCol.Index)
                {
                    nextResult = nextResult.Previous;
                }
                beginningNode = nextResult.Next;

                //SparseMatrixNode nextResult = resultNode.Next;

                //while (nextResult != resultNode)
                //{
                //    if (nextResult.MainCol.Index < beginningNode.MainCol.Index)
                //    {
                //        beginningNode = nextResult;
                //    }
                //    nextResult = nextResult.Next;
                //}

                //The indexes of the main column nodes of the the leftmost coulm node and the one after it
                int leftmostColumnIndex = beginningNode.MainCol.Index;
                int nextLeftmost = beginningNode.Next.MainCol.Index;

                /*The formula is:
                for row: leftmostColumnIndex divided by the width of the board
                for column: leftmostColumnIndex modulo the width of the board
                for value: nextleftmostNodeColumnIndex modulo the width of the board plus 1*/

                int rowIndex = leftmostColumnIndex / this.width;
                int colIndex = leftmostColumnIndex % this.width;
                int value = nextLeftmost % this.width + 1;

                //Inserting the value into the proper cell
                this.elements[rowIndex, colIndex].FinalValue = (char)(value + 48);
            }
        }
    }
}