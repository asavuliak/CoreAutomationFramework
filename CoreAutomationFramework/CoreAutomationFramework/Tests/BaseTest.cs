using System;
using System.Reflection;
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
            Console.WriteLine("AfterTest");
            mainMethods.CopyTextFromFileToAnotherFile("sentencesMain.txt", "sentences.txt");
        }
    }
}