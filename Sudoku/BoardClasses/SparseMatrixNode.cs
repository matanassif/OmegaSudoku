namespace Sudoku.BoardClasses
{
    public class SparseMatrixNode
    {
        //The node which represents the column and all the other nodes which are in column are beneath it
        protected MainColNode mainCol;

        //The nodes which represents the node above, under, before and after this node
        protected SparseMatrixNode previous, next, top, buttom;

        public SparseMatrixNode(MainColNode mainCol)
        {
            this.mainCol = mainCol;
            this.top = this.buttom = this.previous = this.next = this;
        }

        public SparseMatrixNode Previous { get => previous; set => previous = value; }
        public SparseMatrixNode Next { get => next; set => next = value; }
        public SparseMatrixNode Top { get => top; set => top = value; }
        public SparseMatrixNode Buttom { get => buttom; set => buttom = value; }
        public MainColNode MainCol { get => mainCol; set => mainCol = value; }

        //Attaches a node to be after this node in the row
        public void AttachToRow(SparseMatrixNode nextNode)
        {
            nextNode.next = this.next;
            this.next.previous = nextNode;
            this.next = nextNode;
            nextNode.previous = this;
        }

        //Attaches a node to be above this node in the row
        public void AttachToColumn(SparseMatrixNode topNode)
        {
            topNode.top = this.top;
            this.top.buttom = topNode;
            this.top = topNode;
            topNode.buttom = this;
            this.mainCol.AmountOfNodes += 1;
        }
    }
}