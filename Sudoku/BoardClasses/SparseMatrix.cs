using System.Collections.Generic;

namespace Sudoku.BoardClasses
{
    class SparseMatrix
    {
        //A list of all the main column nodes
        private List<MainColNode> mainColumns;

        //A list of all the nodes which represent the result
        private List<SparseMatrixNode> result;

        //The main column node which does not contain nodes in its column but is attached to the other main column nodes
        private MainColNode firstCoverMatrixNode;

        public SparseMatrix(byte[,] coverMatrix)
        {
            this.mainColumns = new List<MainColNode>();
            this.result = new List<SparseMatrixNode>();

            //Converts the cover matrix to a sparse matrix
            this.firstCoverMatrixNode = ConvertToSparseMatrix(coverMatrix);
        }

        /// <summary>
        /// Converts the cover matrix to a sparse matrix
        /// </summary>
        /// <param name="coverMatrix">The cover matrix</param>
        /// <returns>The main column node which does not contain nodes in its column but is attached to the other main column nodes</returns>
        public MainColNode ConvertToSparseMatrix(byte[,] coverMatrix)
        {
            MainColNode firstCoverMatrixNode = new MainColNode(-1);
            MainColNode currentMainCol = firstCoverMatrixNode;

            //Attaches all the main column nodes to each other
            for (int mainColIndex = 0; mainColIndex < coverMatrix.GetLength(1); mainColIndex++)
            {
                MainColNode nextMainCol = new MainColNode(mainColIndex);
                this.mainColumns.Add(nextMainCol);
                currentMainCol.AttachToRow(nextMainCol);
                currentMainCol = nextMainCol;
            }

            //Attaches to the matrix every node which is not empty
            for (int rowIndex = 0; rowIndex < coverMatrix.GetLength(0); rowIndex++)
            {
                SparseMatrixNode rowAttacher = null;

                for (int colIndex = 0; colIndex < coverMatrix.GetLength(1); colIndex++)
                {
                    if (coverMatrix[rowIndex, colIndex] == 1)
                    {
                        //Attaches the node to the column
                        currentMainCol = this.mainColumns[colIndex];
                        SparseMatrixNode node = new SparseMatrixNode(currentMainCol);
                        currentMainCol.AttachToColumn(node);

                        //Attaches the node to the row
                        if (rowAttacher != null)
                            rowAttacher.AttachToRow(node);
                        rowAttacher = node;
                    }
                }
            }

            return firstCoverMatrixNode;
        }

        /// <summary>
        /// Finds the list of nodes which represents the result from the sparse matrix
        /// </summary>
        /// <returns>The list of nodes which represents the result from the sparse matrix</returns>
        public List<SparseMatrixNode> solve()
        {
            this.Search();

            //if (this.result.Count == 0)
            //    throw new Exceptions.UnsolvableBoardException("The given sudoku board is Unsolvable");

            return this.result;
        }

        /// <summary>
        /// Implements algorithem X which gathers all the nodes that represent the result into the list 'result'
        /// </summary>
        /// <returns>If algorithem X found a list of nodes which represents the result from the sparse matrix</returns>
        public bool Search()
        {
            //Returns true if all the columns are covered
            if (firstCoverMatrixNode.Next == firstCoverMatrixNode)
                return true;

            //Chooses the column with the least amount of nodes and covers it
            MainColNode currentMainCol = this.ChooseShortesColumn();
            currentMainCol.Cover();

            SparseMatrixNode nextNodeInColumn = currentMainCol.Buttom;

            //Goes over the nodes in the column
            while (nextNodeInColumn != currentMainCol)
            {
                //Inserts the node in the column to the result 
                this.result.Add(nextNodeInColumn);
                SparseMatrixNode nextNodeInRow = nextNodeInColumn.Next;

                //Goes over the nodes in the row of the current node and covers their columns
                while (nextNodeInRow != nextNodeInColumn)
                {
                    nextNodeInRow.MainCol.Cover();
                    nextNodeInRow = nextNodeInRow.Next;
                }

                //Calls the function again
                if (Search())
                    return true;

                //Removes the last node from the result
                nextNodeInColumn = this.result[this.result.Count - 1];
                this.result.RemoveAt(this.result.Count - 1);

                //Gets its main column node
                currentMainCol = nextNodeInColumn.MainCol;

                //Goes over the nodes in the row of the current node and uncovers their columns
                nextNodeInRow = nextNodeInColumn.Previous;
                while (nextNodeInRow != nextNodeInColumn)
                {
                    nextNodeInRow.MainCol.Uncover();
                    nextNodeInRow = nextNodeInRow.Previous;
                }

                nextNodeInColumn = nextNodeInColumn.Buttom;
            }
            
            //Uncovers the chosen column
            currentMainCol.Uncover();
            return false;
        }

        /// <summary>
        /// Finds the column with the least amount of nodes
        /// </summary>
        /// <returns>The main column node of the column with the least amount of nodes</returns>
        public MainColNode ChooseShortesColumn()
        {
            MainColNode shortest = (MainColNode)this.firstCoverMatrixNode.Next;
            MainColNode columnPointer = (MainColNode)this.firstCoverMatrixNode.Next;

            //Goes over the nodes in the row and sets 'shortest' as the main column node of the column with the least amount of nodes
            while (columnPointer != this.firstCoverMatrixNode)
            {
                if (columnPointer.AmountOfNodes < shortest.AmountOfNodes)
                    shortest = columnPointer;

                columnPointer = (MainColNode)columnPointer.Next;
            }

            return shortest;
        }
    }
}