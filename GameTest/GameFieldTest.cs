using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Game15;

namespace GameTest
{
    [TestClass]
    public class GameFieldTest
    {
        [TestMethod]
        public void TestIsSolvedTrue()
        {
            int[,] actual =
            {
                { 1, 2, 3, 4 },
                { 5, 6, 7, 8 },
                { 9, 10, 11, 12 },
                { 13, 14, 15, 0 }
            };
            bool expected = GameField.IsSolved();
            Assert.AreEqual(expected, actual);

        }

        [TestMethod]
        public void TestIsSolvedFalse()
        {
            int[,] field =
            {
                { 11, 2, 3, 14 },
                { 15, 6, 7, 8 },
                { 9, 10, 1, 12 },
                { 13, 4, 5, 0 }
            };


        }
    }
}
