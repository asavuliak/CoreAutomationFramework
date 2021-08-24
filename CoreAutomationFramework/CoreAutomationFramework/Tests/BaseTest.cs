using System.Threading;
using CoreAutomationFramework.Methods;
using NUnit.Framework;

namespace CoreAutomationFramework.Tests
{
    public class BaseTest
    {
        protected string pathToDll => @"/Users/asa/RiderProjects/NmeaSentenceParser/NmeaSentenceParser/bin/Debug/net5.0/";
        MainMethods mainMethods => new MainMethods();
        
        [TearDown]
        public void AfterTest()
        {
            mainMethods.CopyTextFromFileToAnotherFile("sentencesMain.txt", "sentences.txt");
        }
    }
}