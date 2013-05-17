namespace GameTest
{
    using System;
    using System.IO;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Game15;
    using System.Reflection;

    [TestClass]
    public class EngineTests
    {
        [TestMethod]
        public void TestReadCommandExit()
        {
            var method = typeof(Engine).GetMethod("ReadCommand", BindingFlags.Static | BindingFlags.NonPublic);
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                method.Invoke(obj: null, parameters: new object[] { "exit" });

                string result = sw.ToString();
                string expected = "Good Bye!\r\n";
                Assert.AreEqual<string>(expected, result);
            }
        }

        [TestMethod]
        public void TestReadCommandTop()
        {
            ScoreBoard.Players.Clear();
            var method = typeof(Engine).GetMethod("ReadCommand", BindingFlags.Static | BindingFlags.NonPublic);
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                method.Invoke(obj: null, parameters: new object[] { "top" });

                string actual = sw.ToString();
                string expected = "Welcome to the game “15”.\r\n" + 
                    "Please try to arrange the numbers sequentially.\r\n" +
                    "Commands:\r\n" + 
                    " - 'top' - view the top scoreboard\r\n" +
                    " - 'restart' - start a new game\r\n" +
                    " - 'exit' - quit the game\r\n" +
                    "--------------------\r\n" +
                    "Scoreboard is empty.\r\n" +
                    "--------------------\r\n";
                Assert.AreEqual<string>(expected, actual);
            }
        }

        [TestMethod]
        public void TestReadIllegalCommand()
        {
            var method = typeof(Engine).GetMethod("ReadCommand", BindingFlags.Static | BindingFlags.NonPublic);
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                method.Invoke(obj: null, parameters: new object[] { "18" });

                string actual = sw.ToString();
                string expected = "Welcome to the game “15”.\r\n" +
                    "Please try to arrange the numbers sequentially.\r\n" +
                    "Commands:\r\n" +
                    " - 'top' - view the top scoreboard\r\n" +
                    " - 'restart' - start a new game\r\n" +
                    " - 'exit' - quit the game\r\n" +
                    "Illegal command!\r\n";
                Assert.AreEqual<string>(expected, actual);
            }
        }
    }
}
