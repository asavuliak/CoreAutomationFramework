using System;
using System.Collections.Generic;
using System.Linq;
using GeoTimeZone;
using NUnit.Framework;
using TimeZoneConverter;

namespace CoreAutomationFramework.Methods
{
    public class VerificationMethods
    {
        MainMethods mainMethods => new MainMethods();

        public void CompareWithExpectedResult(double lat, double longitude, string outputResult)
        {
            List<MainMethods.Coordinates> coordinates = mainMethods.GetResultFromOutput(outputResult);
            Assert.IsTrue(coordinates.Any(x => x.Lat == lat), "Any mattes for lat");
            Assert.IsTrue(coordinates.Any(x => x.Longitude == longitude), "Any mattes for longitude");
        }
        
        public void CoordinateVerification(string outputResult)
        {
            List<MainMethods.Coordinates> coordinates = mainMethods.GetResultFromOutput(outputResult);
            foreach (var value in coordinates)
            {
                Assert.IsTrue(GetCoordinateResults(value.Lat, value.Longitude), "Incorrect format for coordinates is returned");
            }
        }

        public bool FileIsEmptyVerification(string outputResult)
        {
            if (mainMethods.GetResultFromOutput(outputResult).Count == 0)
                return true;
            return false;
        }
        private bool GetCoordinateResults(double lat, double lng)
        {
            string tzIana = TimeZoneLookup.GetTimeZone(lat, lng).Result;
            bool result = false;
            try
            {
                TimeZoneInfo tzInfo = TZConvert.GetTimeZoneInfo(tzIana);
                result = true;
            }
            catch (Exception e)
            {
                result = false;
            }

            return result;
        }
    }
}