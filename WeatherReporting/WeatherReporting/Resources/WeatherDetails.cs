using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherReporting.Resources;

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

            if (MathHelper.CheckVariance(tempDifference,Convert.ToInt32(ConfigurationManager.AppSettings["TempVariance"]))&&
                MathHelper.CheckVariance(humidDiffence, Convert.ToInt32(ConfigurationManager.AppSettings["HumidityVariance"])))
                return true;
            else
                return false;
        }
    }
}
