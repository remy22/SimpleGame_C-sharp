namespace GameTest
{
    using System;
    using System.Text;
    using Game15;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class PlayerTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestPlayerNullForName()
        {
            IPlayer player = new Player(null, 10);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestPlayerEmptyStringName()
        {
            IPlayer player = new Player("", 10);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestPlayerNegativeScore()
        {
            IPlayer player = new Player("Pesho", -100);   
        }

        [TestMethod]
        public void TestPlayerToString()
        {
            IPlayer player = new Player("Pesho", 100);

            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("{0} --> {1} moves", "Pesho", 100);
            sb.AppendLine();

            Assert.AreEqual(player.ToString(), sb.ToString());
        }
    }
}
