using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;
using GeoTimeZone;
using NUnit.Framework;
using TimeZoneConverter;

namespace CoreAutomationFramework.Methods
{
    public class MainMethods
    {
        public OutputResult ReadFromNmeaSentenceParser(string pathToDll)
        {
            OutputResult outputResult = new OutputResult();
            Process process = new Process();
            
            //I am working on macos that the reason why I run dll + dotnet command =)
            string fullPass = $"{pathToDll}NmeaSentenceParser.dll";
            process.StartInfo.FileName = "dotnet";

            process.StartInfo.Arguments = fullPass;
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.RedirectStandardError = true;
            process.Start();
            
            process.WaitForExit();
            outputResult.ExitCode = process.ExitCode;
            outputResult.Output = process.StandardOutput.ReadToEnd();
            outputResult.OutputError = process.StandardError.ReadToEnd();

            return outputResult;
        }
        
        public void CopyTextFromFileToAnotherFile(string fromFileName, string toFileName)
        {
            string fullPathFromFile = Path.Combine(Environment.CurrentDirectory,  @"TestData/", fromFileName);
            string fullPathToFile = Path.Combine(Environment.CurrentDirectory, toFileName);
            
            using (var inputStream = new StreamReader(fullPathFromFile))
            {
                using (var outputStream = new StreamWriter(fullPathToFile))
                {
                    outputStream.Write(inputStream.ReadToEnd());
                    outputStream.Close();
                    outputStream.Dispose();
                }
                inputStream.Close();
                inputStream.Dispose();
            }
            Thread.Sleep(2000);
        }
        public List<Coordinates> GetResultFromOutput(string outputResult)
        {
            List<string> newOutput = outputResult.Split("\n").ToList();

            List<Coordinates>  splitValue= new List<Coordinates>();
            foreach (var item in newOutput)
            {
                Coordinates coordinates = new Coordinates();

                if (item.Contains("Position"))
                {
                    int startPositionLat = item.IndexOf("lat") + 5;
                    string lat = item.ToString().Substring(startPositionLat, 17);
                    coordinates.Lat = Convert.ToDouble(lat);
                    
                    int startPositionLong = item.IndexOf("long") + 6;
                    string longitude = item.ToString().Substring(startPositionLong, 17);
                    coordinates.Longitude = Convert.ToDouble(longitude);
                    
                    splitValue.Add(coordinates);
                }
            }

            return splitValue;
        }

        public class OutputResult
        {
            public int ExitCode{ get; set; }
            public string Output{ get; set; }
            public string OutputError{ get; set; }
        }
        public class Coordinates
        {
            public double Lat { get; set; }
            public double Longitude { get; set; }
        }
    }
}