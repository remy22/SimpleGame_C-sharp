namespace Game15
{
    using System;
    using System.Linq;

    /// <summary>
    /// Class used to display any communication on the Console for the user
    /// </summary>
    public class Communicator
    {
        /// <summary>
        /// Asks the user to enter a number and returns his/her input
        /// </summary>
        /// <returns>The input from the console</returns>
        public static string GetNumber()
        {
            Console.Write("Enter a number to move: ");
            string input = Console.ReadLine();
            return input;
        }

        public static void DisplayMessage(string message)
        {
            Console.WriteLine(message);
        }

        /// <summary>
        /// Asks the user to enter his/her name and returns the input
        /// </summary>
        /// <returns>The input from the console</returns>
        public static string GetName()
        {
            Console.WriteLine("Congratulations! You won the game");
            Console.Write("Please enter your name for the top scoreboard: ");
            string name = Console.ReadLine();
            return name;
        }

        /// <summary>
        /// Displays the starting message on the Console
        /// </summary>
        public static void DisplayIntroMessage()
        {
            Console.WriteLine("Welcome to the game “15”." +
                Environment.NewLine + "Please try to arrange the numbers sequentially." +
                Environment.NewLine + "Commands:" +
                Environment.NewLine + " - 'top' - view the top scoreboard" +
                Environment.NewLine + " - 'restart' - start a new game" +
                Environment.NewLine + " - 'exit' - quit the game");
        }
    }
}