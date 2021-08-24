using System.Threading;
using CoreAutomationFramework.Methods;
using NUnit.Framework;

namespace CoreAutomationFramework.Tests
{
    [TestFixture]
    public class NoGLLInTheFile : BaseTest
    {
        MainMethods mainMethods => new MainMethods();

        
        [SetUp]
        public void Setup()
        {
            mainMethods.CopyTextFromFileToAnotherFile("NoGllInTheFile.txt", "sentences.txt");
            Thread.Sleep(2000);
        }

        [Test]
        public void NoGllInTheFileTest()
        {
            VerificationMethods verificationMethods = new VerificationMethods();
            var getOutput = mainMethods.ReadFromNmeaSentenceParser(pathToDll);
            
            Assert.AreEqual(getOutput.ExitCode, 0, "Program execute unsuccessful");
            verificationMethods.CoordinateVerification(getOutput.Output);
            Assert.IsTrue(verificationMethods.FileIsEmptyVerification(getOutput.Output), "Output is not empty");
        }
    }
}