using System;
using System.Collections.Generic;
using System.Text;

namespace Sudoku
{
    class Optimization
    {
        public static void InsertOnlyOptions(BoardClasses.Board board)
        {
            //For every empty cell (contains '0') inserts all the possibilities

            int changesAmount = 0;

            for (int row = 0; row < board.Height; row++)
            {
                for (int col = 0; col < board.Width; col++)
                {
                    BoardClasses.Cell currentCell = board.getElements()[row, col];
                    if (currentCell.IsEmpty())
                        changesAmount += InsertCellPossibilities(board, currentCell);
                }
            }

            if (changesAmount != 0)
                InsertOnlyOptions(board);
        }

        public static int InsertCellPossibilities(BoardClasses.Board board, BoardClasses.Cell cell)
        {
            /*Checks all the possibilities of the cell and returns 1 if there was an insertion*/

            //Checks the cell's column
            for (int row = 0; row < board.Height; row++)
            {
                if(row != cell.RowIndex)
                {
                    BoardClasses.Cell currentCell = board.getElements()[row, cell.ColIndex];
                    if (currentCell.FinalValue != '0')
                    {
                        if (cell.isInPossibilityValues(currentCell.FinalValue))
                            cell.removePossibility(currentCell.FinalValue);
                    }                       
                }                  
            }


            //Checks the cell's row
            for (int col = 0; col < board.Width; col++)
            {
                if (col != cell.ColIndex)
                {
                    BoardClasses.Cell currentCell = board.getElements()[cell.RowIndex, col];
                    if (currentCell.FinalValue != '0')
                    {
                        if (cell.isInPossibilityValues(currentCell.FinalValue))
                            cell.removePossibility(currentCell.FinalValue);
                    }
                }
            }


            //Checks the cell's box
            int boxWidth = (int)Math.Sqrt(board.Width);

            for (int row = boxWidth * (cell.RowIndex / boxWidth); row < boxWidth * (cell.RowIndex / boxWidth) + boxWidth; row++)
            {
                for (int col = boxWidth * (cell.ColIndex / boxWidth); col < boxWidth * (cell.ColIndex / boxWidth) + boxWidth; col++)
                {
                    if (row != cell.RowIndex && col != cell.ColIndex)
                    {
                        BoardClasses.Cell currentCell = board.getElements()[row, col];
                        if (currentCell.FinalValue != '0')
                        {
                            if (cell.isInPossibilityValues(currentCell.FinalValue))
                                cell.removePossibility(currentCell.FinalValue);
                        }
                    }
                }
            }

            //If there is only one possibility, it will be inserted
            //Returns 1 if there was an insertion
            if (cell.PossibilityAmount == 1)
            {
                cell.FinalValue = cell.PossibleValues[0];
                cell.removePossibility(cell.FinalValue);
                return 1;
            }

            return 0;
        }
    }
}
