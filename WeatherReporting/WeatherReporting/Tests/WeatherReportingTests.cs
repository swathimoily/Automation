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
            WeatherDetails weatherDetailsFrmUI, weatherDetailsFrmAPI;
            WeatherReportingAPIHelper weatherReportingAPIHelper = new WeatherReportingAPIHelper();
          
            //Getting Weatherreport details through API
            //Navigating to Weather reportinf page
            homePageOps.NaviagateToWeather();
            //Selecting the city and getting Weather info
            weatherPageOps.SelectCity(TestContext.DataRow["CityName"].ToString());
            weatherDetailsFrmUI = weatherPageOps.GetWeatherInfo(TestContext.DataRow["CityName"].ToString());

            //Getting Weatherreport details through API
            weatherDetailsFrmAPI = weatherReportingAPIHelper.GetWeatherReportByCity(TestContext.DataRow["CityName"].ToString(), TestContext.DataRow["APIKey"].ToString());
            if (!weatherDetailsFrmUI.CompareWeatherReport(weatherDetailsFrmUI, weatherDetailsFrmAPI))
            { Assert.Fail("WeatherReport is not in specified range..!!"); }
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
