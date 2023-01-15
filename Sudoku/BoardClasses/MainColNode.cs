namespace Sudoku.BoardClasses
{
    /// <summary>
    /// The node which represents the column and all the other nodes which are in column are beneath it
    /// </summary>
    public class MainColNode : SparseMatrixNode
    {
        //Index of the Main Column
        private int index;

        //The amount of nodes the column contains
        private int amountOfNodes;

        public MainColNode(int index) : base(null)
        {
            this.amountOfNodes = 0;
            this.index = index;

            //Since every node contains a pointer to the top of the column, this node points itself
            this.mainCol = this;
        }

        public int Index { get => index; set => index = value; }
        public int AmountOfNodes { get => amountOfNodes; set => amountOfNodes = value; }

        /// <summary>
        /// Covers the column and for every row which has a node in this column, the function deataches every node in the row from its column
        /// </summary>
        public void Cover()
        {
            //Detaches the node from its row
            this.previous.Next = this.next;
            this.next.Previous = this.previous;

            SparseMatrixNode rowInMainCol = this.Buttom;

            //Goes through the rows which are contained in the current column 
            while (rowInMainCol != this)
            {
                SparseMatrixNode nextRowNode = rowInMainCol.Next;

                //Goes through the nodes which are contained in the current row and deattaches them from their columns
                while (nextRowNode != rowInMainCol)
                {
                    //Detaches the node from its column
                    nextRowNode.MainCol.AmountOfNodes -= 1;
                    nextRowNode.Top.Buttom = nextRowNode.Buttom;
                    nextRowNode.Buttom.Top = nextRowNode.Top;

                    nextRowNode = nextRowNode.Next;
                }

                rowInMainCol = rowInMainCol.Buttom;
            }
        }

        /// <summary>
        /// Uncovers the column and for every row which has a node in this column, the function reattaches every node in the row to its original column
        /// </summary>
        public void Uncover()
        {
            SparseMatrixNode rowInMainCol = this.Top;

            //Goes through the rows which are contained in the current column 
            while (rowInMainCol != this)
            {
                SparseMatrixNode previousRowNode = rowInMainCol.Previous;

                //Goes through the nodes which were contained in the current row and reattaches them to their columns
                while (previousRowNode != rowInMainCol)
                {
                    //Reattaches the node to its column
                    previousRowNode.MainCol.AmountOfNodes += 1;
                    previousRowNode.Top.Buttom = previousRowNode;
                    previousRowNode.Buttom.Top = previousRowNode;

                    previousRowNode = previousRowNode.Previous;
                }

                rowInMainCol = rowInMainCol.Top;
            }

            //Reattaches the node to its row
            this.previous.Next = this;
            this.next.Previous = this;
        }
    }
}