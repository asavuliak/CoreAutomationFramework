using System.Threading;
using CoreAutomationFramework.Methods;
using NUnit.Framework;

namespace CoreAutomationFramework.Tests
{
    [TestFixture]
    public class TestCase1 : BaseTest
    {
        private double expectedLat = 55.39699333333333;
        private double expectedLong = 10.97996833333333;
        MainMethods mainMethods => new MainMethods();

        [SetUp]
        public void Setup()
        {
            mainMethods.CopyTextFromFileToAnotherFile("sentencesTestCase1.txt", "sentences.txt");
            Thread.Sleep(5000);        
        }

        [Test]
        public void SuccessfuLTestCase1()
        {
            VerificationMethods verificationMethods = new VerificationMethods();
            var getOutput = mainMethods.ReadFromNmeaSentenceParser(pathToDll);
            
            Assert.AreEqual(getOutput.ExitCode, 0, "Program execute unsuccessful");
            verificationMethods.CoordinateVerification(getOutput.Output);
            verificationMethods.CompareWithExpectedResult(expectedLat, expectedLong, getOutput.Output);
        }
    }
}