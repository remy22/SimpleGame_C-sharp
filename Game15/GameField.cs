namespace Game15
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class GameField
    {
        /// <summary>
        /// Game field width
        /// </summary>
        private const int FIELD_WIDTH = 4;

        /// <summary>
        /// Game field height
        /// </summary>
        private const int FIELD_HEIGHT = 4;

        /// <summary>
        /// Stores the current GameField
        /// </summary>
        private static readonly int[,] field = new int[FIELD_WIDTH, FIELD_HEIGHT];

        /// <summary>
        /// A dictionary that stores all the numbers and their coordinates
        /// </summary>
        private static readonly Dictionary<int, Coordinates> NumbersAndPositions = new Dictionary<int, Coordinates>();

        private static Random rand = new Random();

        /// <summary>
        /// Gets the current filed
        /// </summary>
        public static int[,] Field
        {
            get
            {
                return field;
            }
        }

        /// <summary>
        /// Generate a random Field
        /// </summary>
        public static void RandomField()
        {
            List<int> numbers = new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 };
            NumbersAndPositions.Clear();
            for (int row = 0; row < Field.GetLength(0); row++)
            {
                for (int col = 0; col < Field.GetLength(1); col++)
                {
                    int currentNumber = rand.Next(0, numbers.Count); // take a random number from the List of numbers
                    Field[row, col] = numbers[currentNumber]; // place the selected number in the current row and col
                    NumbersAndPositions.Add(numbers[currentNumber], new Coordinates(row, col)); // update the dictionary
                    numbers.RemoveAt(currentNumber); // remove it from the number from the List so it is not used again
                }
            }
        }

        /// <summary>
        /// Check if the specified number can move to the empty space in the GameField
        /// </summary>
        /// <param name="numberToMove">The number to move</param>
        /// <returns>True or False</returns>
        public static bool CanMoveNumber(int numberToMove)
        {
            return NumbersAndPositions[0].CheckNeighbour(NumbersAndPositions[numberToMove]);
        }

        /// <summary>
        /// Moves the specified number to the empty space on the GameField
        /// </summary>
        /// <param name="numberToMove">The number to move</param>
        public static void MoveNumber(int numberToMove)
        {
            Coordinates temp = NumbersAndPositions[0];
            NumbersAndPositions[0] = NumbersAndPositions[numberToMove];
            NumbersAndPositions[numberToMove] = temp;

            Field[NumbersAndPositions[numberToMove].Row, NumbersAndPositions[numberToMove].Col] = numberToMove;
            Field[NumbersAndPositions[0].Row, NumbersAndPositions[0].Col] = 0;
        }

        /// <summary>
        /// Check if the current field is solved
        /// </summary>
        /// <returns>true or false</returns>
        public static bool IsSolved()
        {
            bool isSolved = true;
            int[,] solvedField =
            {
                { 1, 2, 3, 4 },
                { 5, 6, 7, 8 },
                { 9, 10, 11, 12 },
                { 13, 14, 15, 0 }
            };
            for (int row = 0; row < Field.GetLength(0); row++)
            {
                for (int col = 0; col < Field.GetLength(1); col++)
                {
                    if (Field[row, col] != solvedField[row, col])
                    {
                        isSolved = false;
                    }
                }
            }

            return isSolved;
        }

        /// <summary>
        /// Returns the current GameField as a string
        /// </summary>
        /// <returns>String representation of the game field</returns>
        public static string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine(" -------------------");
            for (int row = 0; row < Field.GetLength(0); row++)
            {
                result.Append("|");
                for (int col = 0; col < Field.GetLength(1); col++)
                {
                    if (Field[row, col] == 0)
                    {
                        result.Append("    |");
                        continue;
                    }

                    result.Append(string.Format(" {0,2} |", Field[row, col]));
                }

                result.AppendLine();
            }

            result.Append(" -------------------");
            return result.ToString();
        }
    }
}
