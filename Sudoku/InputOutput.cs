namespace Sudoku
{
    /// <summary>
    /// Enables functions which gets the input from the user and presents the output
    /// </summary>
    interface InputOutput
    {
        /// <summary>
        /// Gets the input from the user
        /// </summary>
        /// <returns>The path and the sudoku string which the user inserts and the channel which he did it by</returns>
        string[] Read();

        /// <summary>
        /// Writes the output to a platform (such as console or file)
        /// </summary>
        /// <param name="board">The sudoku board</param>
        /// <param name="path">The path of the file</param>
        void Write(BoardClasses.Board board, string path);
    }
}