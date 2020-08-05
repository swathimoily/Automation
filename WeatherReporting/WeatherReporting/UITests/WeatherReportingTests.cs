using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WeatherReporting.PageOps;

namespace WeatherReporting
{
    [TestClass]
    public class WeatherReportingTests : NDTVBase
    {    

        [TestMethod]
        [DeploymentItem("TestData\\City.csv"), DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\City.csv", "City#csv", DataAccessMethod.Sequential)]
        public void VerifyWeatherReportedForCity()
        {
            HomePageOps homePageOps = new HomePageOps();
            WeatherPageOps weatherPageOps = new WeatherPageOps();    
            WeatherDetails weatherDetails;
                        
            //Navigating to Weather reportinf page
            homePageOps.NaviagateToWeather();

            //Selecting the city and getting Weather info
            weatherPageOps.SelectCity(TestContext.DataRow["CityName"].ToString());
            weatherDetails = weatherPageOps.GetWeatherInfo(TestContext.DataRow["CityName"].ToString());
        }
        public TestContext TestContext
            {
                get
                {
                    return testContextInstance;
                }
                set
                {
                    testContextInstance = value;
                }
            }

        private TestContext testContextInstance;
    }
}
