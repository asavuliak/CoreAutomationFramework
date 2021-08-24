using System.Threading;
using CoreAutomationFramework.Methods;
using NUnit.Framework;

namespace CoreAutomationFramework.Tests
{
    [TestFixture]
    public class ChecksumIsMissedInTheLastColumn : BaseTest
    {
        MainMethods mainMethods => new MainMethods();

        
        [SetUp]
        public void Setup()
        {
            mainMethods.CopyTextFromFileToAnotherFile("ChecksumIsMissedInTheLastColumn.txt", "sentences.txt");
            Thread.Sleep(2000);
        }

        [Test]
        public void ChecksumIsMissedInTheLastColumnTest()
        {
            var getOutput = mainMethods.ReadFromNmeaSentenceParser(pathToDll);
            
            Assert.AreEqual(134, getOutput.ExitCode, $"Incorrect ExitCode is returned. {getOutput.ExitCode} is returned instead of 134");
            Assert.IsTrue(getOutput.OutputError.Contains("Unable to find checksum character in last column"), $"Incorrect exception is returned. Was {getOutput.Output}");
        }
    }
}