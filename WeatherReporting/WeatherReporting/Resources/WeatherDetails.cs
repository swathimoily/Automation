using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherReporting
{
    public class WeatherDetails
    {
        public double humidity;
        public double TempInDegrees;
        
        /// <summary>
        /// Compare two weather objects and return true if its withing the range else returns false
        /// </summary>
        /// <param name="uiWeather"></param>
        /// <param name="apiWeather"></param>
        /// <returns></returns>
        public bool CompareWeatherReport(WeatherDetails uiWeather, WeatherDetails apiWeather)
        {
            double tempDifference = uiWeather.TempInDegrees - apiWeather.TempInDegrees;
            double humidDiffence = uiWeather.humidity - apiWeather.humidity;
           
            if (tempDifference >= Convert.ToDouble(ConfigurationManager.AppSettings["StartRange"]) &&
                tempDifference <= Convert.ToDouble(ConfigurationManager.AppSettings["EndRange"]) &&
                humidDiffence >= Convert.ToDouble(ConfigurationManager.AppSettings["StartRange"]) &&
                humidDiffence <= Convert.ToDouble(ConfigurationManager.AppSettings["EndRange"]))
                return true;
            else
                return false;
        }
    }
}
