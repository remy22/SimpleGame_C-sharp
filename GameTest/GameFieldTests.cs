namespace GameTest
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;
    using System.Text;
    using Game15;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class GameFieldTests
    {
        [TestMethod]
        public void TestCanMoveNumberTrue()
        {
            int fieldLength = 4;
            int fillCounter = 0;
            int[,] testMatrix = new int[fieldLength, fieldLength];
            for (int x = 0; x < fieldLength; x++)
            {
                for (int y = 0; y < fieldLength; y++)
                {
                    testMatrix[x, y] = fillCounter;

                    fillCounter++;
                }
            }

            FieldInfo changedField = typeof(GameField).GetField("field", BindingFlags.Static | BindingFlags.NonPublic);
            changedField.SetValue(null, testMatrix);
            FieldInfo changedDict = typeof(GameField).GetField("NumbersAndPositions", BindingFlags.Static | BindingFlags.NonPublic);
            Coordinates testCooridates = new Coordinates(0, 1);
            Dictionary<int, Coordinates> testDict = new Dictionary<int, Coordinates>();
            testDict.Add(1, testCooridates);
            testCooridates = new Coordinates(0, 0);
            testDict.Add(0, testCooridates);
            changedDict.SetValue(null, testDict);

            bool result = GameField.CanMoveNumber(1);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TestCanMoveNumberFalse()
        {
            FieldInfo changedDict = typeof(GameField).GetField("NumbersAndPositions", BindingFlags.Static | BindingFlags.NonPublic);
            Coordinates testCooridates = new Coordinates(0, 1);
            Dictionary<int, Coordinates> testDict = new Dictionary<int, Coordinates>();
            testDict.Add(1, testCooridates);
            testCooridates = new Coordinates(1, 0);
            testDict.Add(0, testCooridates);
            changedDict.SetValue(null, testDict);

            bool result = GameField.CanMoveNumber(1);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void TestMoveNumber()
        {
            int fieldLength = 4;
            int fillCounter = 0;
            int[,] testMatrix = new int[fieldLength, fieldLength];
            for (int x = 0; x < fieldLength; x++)
            {
                for (int y = 0; y < fieldLength; y++)
                {
                    testMatrix[x, y] = fillCounter;

                    fillCounter++;
                }
            }

            FieldInfo changedField = typeof(GameField).GetField("field", BindingFlags.Static | BindingFlags.NonPublic);
            changedField.SetValue(null, testMatrix);
            FieldInfo changedDict = typeof(GameField).GetField("NumbersAndPositions", BindingFlags.Static | BindingFlags.NonPublic);
            Coordinates testCooridates = new Coordinates(0, 1);
            Dictionary<int, Coordinates> testDict = new Dictionary<int, Coordinates>();
            testDict.Add(1, testCooridates);
            testCooridates = new Coordinates(0, 0);
            testDict.Add(0, testCooridates);
            changedDict.SetValue(null, testDict);
            GameField.MoveNumber(1);

            int[,] check = (int[,])changedField.GetValue(null);
            bool result = check[0, 0] == 1;

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TestIsSolved()
        {
            int fieldLength = 4;
            int fillCounter = 1;
            int[,] testMatrix = new int[fieldLength, fieldLength];
            for (int x = 0; x < fieldLength; x++)
            {
                for (int y = 0; y < fieldLength; y++)
                {
                    if (fillCounter != 16)
                    {
                        testMatrix[x, y] = fillCounter;
                    }
                    else
                    {
                        testMatrix[x, y] = 0;
                    }

                    fillCounter++;
                }
            }

            FieldInfo changedField = typeof(GameField).GetField("field", BindingFlags.Static | BindingFlags.NonPublic);
            changedField.SetValue(null, testMatrix);

            bool result = GameField.IsSolved();
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TestToString()
        {
            GameField.RandomField();
            int[,] copyGameField = (int[,])GameField.Field.Clone();

            StringBuilder sb = new StringBuilder();
            sb.AppendLine(" -------------------");
            for (int row = 0; row < copyGameField.GetLength(0); row++)
            {
                sb.Append("|");
                for (int col = 0; col < copyGameField.GetLength(1); col++)
                {
                    if (copyGameField[row, col] == 0)
                    {
                        sb.Append("    |");
                        continue;
                    }

                    sb.Append(string.Format(" {0,2} |", copyGameField[row, col]));
                }
                sb.AppendLine();
            }
            sb.Append(" -------------------");

            Assert.AreEqual(GameField.ToString(), sb.ToString());
        }

        [TestMethod]
        public void TestRandomField()
        {
            GameField.RandomField();
            int[,] firstGameField = (int[,])GameField.Field.Clone();
            GameField.RandomField();
            int[,] secondGameField = (int[,])GameField.Field.Clone();

            bool areTheSame = this.AreMatricesTheSame(firstGameField, secondGameField);
            Assert.IsFalse(areTheSame);
        }

        private bool AreMatricesTheSame(int[,] first, int[,] second)
        {
            for (int row = 0; row < first.GetLength(0); row++)
            {
                for (int col = 0; col < first.GetLength(1); col++)
                {
                    if (first[row, col] != second[row, col])
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}
