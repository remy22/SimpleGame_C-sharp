namespace GameTest
{
    using System;
    using System.IO;
    using System.Text;
    using Game15;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class ComunicatorTests
    {
        [TestMethod]
        public void TestGetNumber()
        {
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);

                using (StringReader sr = new StringReader(string.Format("5{0}", Environment.NewLine)))
                {
                    Console.SetIn(sr);

                    string result = Communicator.GetNumber();

                    string expected = "5";

                    Assert.AreEqual<string>(expected, result);
                }
            }
        }

        [TestMethod]
        public void TestDisplayMessage()
        {
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);

                string message = "Test message";
                Communicator.DisplayMessage(message);

                string expected = string.Format("Test message{0}", Environment.NewLine);

                Assert.AreEqual<string>(expected, sw.ToString());
            }
        }

        [TestMethod]
        public void TestGetName()
        {
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);

                using (StringReader sr = new StringReader(string.Format("Pesho{0}", Environment.NewLine)))
                {
                    Console.SetIn(sr);

                    string result = Communicator.GetName();
                    string expected = "Pesho";

                    Assert.AreEqual<string>(expected, result);
                }
            }
        }

        [TestMethod]
        public void TestDisplayIntroMessage()
        {
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);

                Communicator.DisplayIntroMessage();

                StringBuilder sb = new StringBuilder();
                sb.AppendLine("Welcome to the game “15”.");
                sb.AppendLine("Please try to arrange the numbers sequentially.");
                sb.AppendLine("Commands:");                
                sb.AppendLine(" - 'top' - view the top scoreboard");              
                sb.AppendLine(" - 'restart' - start a new game");          
                sb.AppendLine(" - 'exit' - quit the game");

                string expected = sb.ToString();

                Assert.AreEqual<string>(expected, sw.ToString());
            }
        }
    }
}
