using System.Threading;
using CoreAutomationFramework.Methods;
using NUnit.Framework;

namespace CoreAutomationFramework.Tests
{
    [TestFixture]
    public class IncorrectGll : BaseTest
    {
        MainMethods mainMethods => new MainMethods();
        
        [TestCase("FieldDelimiterIsMissed.txt")]
        [TestCase("ReplaceLatitudeDirectory.txt")]
        public void IncorrectGllTest(string fileName)
        {
            mainMethods.CopyTextFromFileToAnotherFile(fileName, "sentences.txt");
            var getOutput = mainMethods.ReadFromNmeaSentenceParser(pathToDll);
            
            Assert.AreEqual(134, getOutput.ExitCode, $"Incorrect ExitCode is returned. {getOutput.ExitCode} is returned instead of 134");
            Assert.IsTrue(getOutput.OutputError.Contains("The checksum of the sentence is not correct"), $"Incorrect exception is returned. Was {getOutput.Output}");
        }
    }
}