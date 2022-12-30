using System;
using System.Collections.Generic;
using System.Text;

namespace Sudoku.BoardClasses
{
    class Cell
    {
        private int rowIndex;
        private int colIndex;
        private char finalValue;
        private char[] possibleValues;
        private int possibilityAmount;

        public Cell(int rowIndex, int colIndex, int possibilitiesAmount)
        {
            this.rowIndex = rowIndex;
            this.colIndex = colIndex;
            this.finalValue = '0';
            this.possibleValues = new char[possibilitiesAmount];
            this.possibilityAmount = 0;

            for (int elementAscii = 49; elementAscii < 49 + possibilitiesAmount; elementAscii++)
            {
                addPossibility((char)elementAscii);
            }
        }

        public char FinalValue { get => finalValue; set => finalValue = value; }
        public int RowIndex { get => rowIndex; set => rowIndex = value; }
        public int ColIndex { get => colIndex; set => colIndex = value; }
        public char[] PossibleValues { get => possibleValues; set => possibleValues = value; }
        public int PossibilityAmount { get => possibilityAmount; set => possibilityAmount = value; }

        public bool IsEmpty()
        {
            //Returns true if the value of the cell is zero

            return FinalValue == '0';
        }

        public void addPossibility(char element)
        {
            //Adds the element to the possibilities array

            this.possibleValues[this.possibilityAmount] = element;
            this.possibilityAmount += 1;
        }

        public void removePossibility(char element)
        {
            //Removes the element from the possibilities array

            int index = this.possibilityAmount;

            //Finds the index of the element which will be removed
            for (int elementIndex = 0; elementIndex < this.possibilityAmount; elementIndex++)
            {
                if (this.possibleValues[elementIndex] == element)
                {
                    index = elementIndex;
                    break;
                }
            }
            
            //Removes it
            for (int elementIndex = index; elementIndex < this.possibilityAmount - 1; elementIndex++)
            {
                this.possibleValues[elementIndex] = this.possibleValues[elementIndex + 1];
            }

            this.possibilityAmount -= 1;
        }

        public bool isInPossibilityValues(char element)
        {
            //Returns true if the element is in the possibilities array

            for (int elementIndex = 0; elementIndex < this.possibilityAmount; elementIndex++)
            {
                if (this.possibleValues[elementIndex] == element)
                    return true;
            }
            return false;
        }
    }
}
