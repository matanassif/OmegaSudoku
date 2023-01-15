using Microsoft.VisualStudio.TestTools.UnitTesting;
using Xunit.Sdk;
using System;
using Sudoku;
using Sudoku.BoardClasses;
using NUnit.Framework;
using Sudoku.Exceptions;

namespace Tests
{
    [TestClass]
    public class UnitTest1
    {

        [TestMethod]
        public void TestMethod1()
        {
            string sudokuString = "770010006000805210001306900304000600062053071900408025009700502700000004120000739";
            int sudokuWidth = (int)Math.Sqrt(sudokuString.Length);
            Board board = new Board(sudokuString, sudokuWidth);

            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.ThrowsException<IllegalElementPositionException>(() => { SolveBoard.Solving(board, sudokuString); });
        }

        [TestMethod]
        public void TestMethod2()
        {
            string sudokuString = "070010006000805210001306900304000600062053071900408025009700502700000004120000739";
            int sudokuWidth = (int)Math.Sqrt(sudokuString.Length);
            Board board = new Board(sudokuString, sudokuWidth);
            string result = SolveBoard.Solving(board, sudokuString);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsTrue(result.Equals("573219846496875213281346957354127698862953471917468325649731582738592164125684739"));
        }

        [TestMethod]
        public void TestMethod3()
        {
            string sudokuString = "070010006000805210001306900304000600062053071900408025009700502700000004120000739";
            int sudokuWidth = (int)Math.Sqrt(sudokuString.Length);
            Board board = new Board(sudokuString, sudokuWidth);
            string result = SolveBoard.Solving(board, sudokuString);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsTrue(result.Equals("573219846496875213281346957354127698862953471917468325649731582738592164125684739"));
        }

        [TestMethod]
        public void TestMethod4()
        {
            string sudokuString = "070010006000805210001306900304000600062053071900408025009700502700000004120000739";
            int sudokuWidth = (int)Math.Sqrt(sudokuString.Length);
            Board board = new Board(sudokuString, sudokuWidth);
            string result = SolveBoard.Solving(board, sudokuString);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsTrue(result.Equals("573219846496875213281346957354127698862953471917468325649731582738592164125684739"));
        }
    }
}