namespace Sudoku.BoardClasses
{
    class Cell
    {
        //Row index
        private int rowIndex;

        //Column index
        private int colIndex;

        //Final value of the cell
        private char finalValue;

        public Cell(int rowIndex, int colIndex)
        {
            this.rowIndex = rowIndex;
            this.colIndex = colIndex;
            this.finalValue = '0';          
        }

        public char FinalValue { get => finalValue; set => finalValue = value; }
        public int RowIndex { get => rowIndex; set => rowIndex = value; }
        public int ColIndex { get => colIndex; set => colIndex = value; }
    }
}