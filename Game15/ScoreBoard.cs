namespace Game15
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public static class ScoreBoard
    {
        private static IList<IPlayer> players = new List<IPlayer>();

        public static IList<IPlayer> Players
        {
            get
            {
                return players;
            }

            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("The value for 'Scores' can not be 'null'.");
                }

                players = value;
            }
        }

        public static void Add(int score, string name)
        {
            IPlayer newPlayer = new Player(name, score);

            Players.Add(newPlayer);

            Players = Players.OrderBy(x => x.Score).ToList();

            if (Players.Count > 5)
            {
                Players.RemoveAt(Players.Count - 1);
            }
        }

        public static string GetTopPlayers()
        {
            var sb = new StringBuilder();

            if (Players.Count != 0)
            {
                int counter = 1;
                sb.AppendLine("--------------------");
                foreach (var player in Players)
                {
                    sb.AppendFormat("{0}. {1}", counter, player.ToString());
                    counter++;
                }

                sb.Append("--------------------");
            }
            else
            {
                sb.AppendLine("--------------------");
                sb.AppendLine("Scoreboard is empty.");
                sb.Append("--------------------");
            }

            return sb.ToString();
        }
    }
}
