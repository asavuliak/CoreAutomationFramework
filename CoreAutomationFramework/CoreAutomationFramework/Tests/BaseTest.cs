using System;
using System.IO;
using CoreAutomationFramework.Config;
using CoreAutomationFramework.Methods;
using NUnit.Framework;
using System.Text.Json;

namespace CoreAutomationFramework.Tests
{
    public class BaseTest
    {
        private AppSettings appSettings = new AppSettings();
        protected string path => Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json");

        public AppSettings EnvironmentConfig()
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json");
            var jsonFile = File.ReadAllText(path);
            return  JsonSerializer.Deserialize<AppSettings>(jsonFile);
        }

        protected string pathToDll => EnvironmentConfig().pathToConsoleApp;
        MainMethods mainMethods => new MainMethods();

        [TearDown]
        public void AfterTest()
        {
            Console.WriteLine("AfterTest");
            mainMethods.CopyTextFromFileToAnotherFile("sentencesMain.txt", "sentences.txt");
        }
    }
}