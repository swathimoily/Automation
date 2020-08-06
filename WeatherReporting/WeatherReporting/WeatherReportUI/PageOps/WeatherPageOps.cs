using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherReporting.Pages;

namespace WeatherReporting.PageOps
{
    class WeatherPageOps
    {
        WeatherPage weatherPage = new WeatherPage();
        UIHelper uIHelper = new UIHelper();

        /// <summary>
        /// Wait for loading weather page
        /// </summary>
        public void WaitForPageLoad()
        {
            uIHelper.WaitForPageLoad(weatherPage.Loading());
        }

        /// <summary>
        /// Select the city in the pin to city list
        /// </summary>
        /// <param name="city"></param>
        public void SelectCity(string city)
        {
            weatherPage.SearchBox().SendKeys(city);
            string isChecked=weatherPage.SelectCity(city).GetProperty("checked");
            if (isChecked != "True")
                weatherPage.SelectCity(city).Click();
        }

        /// <summary>
        /// Get the weather information
        /// </summary>
        /// <param name="city"></param>
        /// <returns></returns>
        public WeatherDetails GetWeatherInfo(string city)
        {
            WeatherDetails weatherDetails = new WeatherDetails();       
            weatherPage.PinCity(city).Click();
            weatherDetails.humidity = Convert.ToDouble((String.Join("", weatherPage.WeatherDetails("Humidity").GetAttribute("innerText").Where(char.IsDigit))));
            weatherDetails.TempInDegrees = Convert.ToDouble((String.Join("", weatherPage.WeatherDetails("Temp in Degrees").GetAttribute("innerText").Where(char.IsDigit))));
            return weatherDetails;
        }
        
    }
}
