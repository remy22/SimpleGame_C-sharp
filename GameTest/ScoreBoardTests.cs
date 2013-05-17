namespace GameTest
{
    using System;
    using System.Text;
    using Game15;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class ScoreBoardTests
    {
        [TestMethod]
        public void GetTopPlayersEmptyTest()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("--------------------");
            sb.AppendLine("Scoreboard is empty.");
            sb.Append("--------------------");

            string empty = ScoreBoard.GetTopPlayers();

            Assert.AreEqual(sb.ToString(), empty);
        }

        [TestMethod]
        public void AddPlayerScoreTest()
        {
            ScoreBoard.Add(10, "Pesho");
            ScoreBoard.Add(20, "Mimi");

            var players = ScoreBoard.Players;

            Assert.AreEqual(players.Count, 2);
        }

        [TestMethod]
        public void GetTopPlayersTest()
        {
            ScoreBoard.Add(10, "Pesho");
            ScoreBoard.Add(10, "Mimi");

            StringBuilder sb = new StringBuilder();
            int counter = 1;
            sb.AppendLine("--------------------");
            foreach (var player in ScoreBoard.Players)
            {
                sb.AppendFormat("{0}. {1} --> {2} moves", counter, player.Name, player.Score);
                sb.AppendLine();
                counter++;
            }

            sb.Append("--------------------");
            
            string consoleOutput = ScoreBoard.GetTopPlayers();

            Assert.AreEqual<string>(sb.ToString(), consoleOutput);
        }
    }
}
