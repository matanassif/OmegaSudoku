# OmegaSudoku
<<<<<<< HEAD
The project is a Sudoku Solver which uses the Dancing Links algorithm.

There are a couple of conditions for every sudoku board in order to be valid or solvable:

1. Every possible symbol appears only once in every row.

2. Every possible symbol appears only once in every column.

3. Every possible symbol appears only once in every box.

4. The amounts of symbols in a board must have an integer type of square root, and so does its square root.

Therefore, the sudoku supports the following sizes of sudoku boards:

1X1, 4X4, 9X9, 16X16, 25X25

## Installation

The installation process is as the following:

Clone the following repository:

Open the solution file and run the file Program.cs.

## Usage
There are two ways to insert a sudoku to the program:

```C#
If you wish to insert sudoku by console, enter 'C'
If you wish to insert sudoku by file, enter 'F'
```

1. From the console.

2. From a file. The user needs to insert the path of the file which contains the sudoku string.

Both ways are required to be written as a string in one line.

For example, the following sudoku string, which represents an empty sudoku board:
```C#
000000000000000000000000000000000000000000000000000000000000000000000000000000000
```
Returns the following board:
```C#
1       2       3       4       5       6       7       8       9
6       8       7       1       3       9       2       5       4
4       9       5       2       7       8       1       3       6
7       1       2       8       9       3       4       6       5
9       5       6       7       1       4       8       2       3
3       4       8       6       2       5       9       1       7
2       6       1       3       4       7       5       9       8
8       7       9       5       6       1       3       4       2
5       3       4       9       8       2       6       7       1
```

Which in a one line string is represented as:
```C#
123456789687139254495278136712893465956714823348625917261347598879561342534982671
```

Another example for a solution for a 16X16 board is:
```C#
1       2       3       4       5       6       7       8       9       :       ;       <       =       >       ?
        @
?       =       @       7       1       4       ;       <       3       6       8       >       2       9       :
        5
<       ;       :       >       2       =       9       ?       1       4       5       @       3       6       8
        7
6       8       5       9       3       :       >       @       2       7       ?       =       1       4       ;
        <
9       1       2       3       ?       @       4       7       5       <       >       8       :       ;       6
        =
:       6       ?       ;       8       1       5       =       @       3       4       9       7       2       <
        >
>       @       <       =       9       2       6       ;       ?       1       7       :       5       3       4
        8
4       5       7       8       >       3       <       :       =       2       6       ;       @       1       9
        ?
3       ?       1       2       7       <       8       4       :       >       @       6       ;       =       5
        9
8       <       =       6       @       ?       1       5       ;       9       3       4       >       7       2
        :
7       9       >       @       :       ;       2       6       8       =       1       5       ?       <       3
        4
5       4       ;       :       =       >       3       9       <       ?       2       7       8       @       1
        6
2       3       6       1       4       5       =       >       7       8       <       ?       9       :       @
        ;
=       :       8       ?       6       7       @       1       4       ;       9       3       <       5       >
        2
@       >       9       <       ;       8       :       2       6       5       =       1       4       ?       7
        3
;       7       4       5       <       9       ?       3       >       @       :       2       6       8       =
```
## Custom Exceptions
The project contains 5 custom exceptions:

1. FileNotTextFormatException: thrown if the given file is not a text file.

2. IllegalElementPositionException: thrown if the same symbol appears more than once in a row, column or box.

3. IllegalElementValueException: thrown if there is a symbol which is illegal.

4. IllegalLengthException: thrown if the length of the given string is illegal.

5. UnsolvableBoardException: thrown if the given sudoku board is unsolvable.

## Algorithm Explanation

The algorithm operates according to the following stages:

1. Converting the given sudoku to a matrix.

2. Converting the sudoku matrix to a "Cover Matrix".

   Its size is (matrixSize * matrixSize * matrixSize, 4 * matrixSize * matrixSize)

   Every row represents a possibility in a specific cell and the columns represent the 4 constraints of value, row, 
   column and box.

3. Converting the "Cover Matrix" to a sparse matrix in order to scan the matrix faster, hence saving run time.

4. Operating Algorithm X on the sparse matrix, which scans the rows (which as mentioned above, are the possibilities of every cell) and selects all the rows which can exist in the same time according to the 4 constraints.

5. Converting the nodes of the sparse matrix to values of the cells.

6. Returning the solution.
