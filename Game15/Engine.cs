namespace Game15
{
    using System;
    using System.Linq;

    /// <summary>
    /// Controller class, serves as a game engine
    /// </summary>
    public class Engine
    {
        private static bool isGameInProgress = true;

        /// <summary>
        /// Initializes a game at program start or when user inputs "restart"
        /// </summary>
        public static void Initialize()
        {
            GameField.RandomField();
            Communicator.DisplayIntroMessage();
        }

        /// <summary>
        /// Reads the user's commands from the Console and updates the GameField
        /// </summary>
        public static void Run()
        {
            int moves = 0;
            do
            {
                Console.WriteLine(GameField.ToString());
                string command = Communicator.GetNumber();
                ReadCommand(command);
                moves++;

                if (GameField.IsSolved())
                {
                    string name = Communicator.GetName();
                    ScoreBoard.Add(moves, name);
                    moves = 0;
                    Initialize();
                }
            }
            while (isGameInProgress);
        }

        /// <summary>
        /// Reads the user's input from the Console and in case it is "exit"
        /// changes the isGameInProgress to false
        /// </summary>
        /// <param name="isGameInProgress">when false will end the game</param>
        private static void ReadCommand(string command)
        {
            isGameInProgress = true;
            switch (command)
            {
                case "top":
                    Console.Clear();
                    Communicator.DisplayIntroMessage();
                    string topPlayers = ScoreBoard.GetTopPlayers();
                    Communicator.DisplayMessage(topPlayers);
                    break;
                case "restart":
                    Console.Clear();
                    Initialize();
                    break;
                case "exit":
                    Communicator.DisplayMessage("Good Bye!");
                    isGameInProgress = false;
                    break;
                default:
                    int numberToMove;
                    bool isValidNumber = false;
                    if (int.TryParse(command, out numberToMove))
                    {
                        isValidNumber = 0 < numberToMove && numberToMove < 16;
                    }

                    Console.Clear();
                    Communicator.DisplayIntroMessage();
                    if (isValidNumber && GameField.CanMoveNumber(numberToMove))
                    {
                        GameField.MoveNumber(numberToMove);
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Illegal command!");
                        Console.ForegroundColor = ConsoleColor.White;
                    }

                    break;
            }
        }
    }
}
