using System.Threading;
using CoreAutomationFramework.Methods;
using NUnit.Framework;

namespace CoreAutomationFramework.Tests
{
    [TestFixture]
    public class NegativeFirstCharacterIsMissed : BaseTest
    {
        MainMethods mainMethods => new MainMethods();

        [TestCase("$ISMissed.txt")]
        [TestCase("$ISMissedFirstLine.txt")]
        public void NegativeFirstCharacterIsMissedTest(string fileName)
        {
            mainMethods.CopyTextFromFileToAnotherFile(fileName, "sentences.txt");
            var getOutput = mainMethods.ReadFromNmeaSentenceParser(pathToDll);
            
            Assert.AreEqual(134, getOutput.ExitCode, $"Incorrect ExitCode is returned. {getOutput.ExitCode} is returned instead of 134");
            Assert.IsTrue(getOutput.OutputError.Contains("Sentence has to start with the $ character"), $"Incorrect exception is returned. Was {getOutput.Output}");

        }
    }
}