using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherReporting
{
    public class WeatherReportingAPIHelper
    {
        /// <summary>
        /// Gives the Weather information using city and apiKey
        /// </summary>
        /// <param name="city"></param>
        /// <param name="apiKey"></param>
        /// <returns></returns>
        public WeatherDetails GetWeatherReportByCity(string city,string apiKey)
        {
            ServiceTestBaseHelper serviceTestBase = new ServiceTestBaseHelper(ConfigurationManager.AppSettings["EndPoint"]+"weather", HttpVerb.GET);
            string response = serviceTestBase.MakeRequest("?q="+city+"&appid="+apiKey);
            return (GetWeatherDeatils(response));
        }

        /// <summary>
        /// Concerted response object into WeatherDetails object 
        /// </summary>
        /// <param name="response"></param>
        /// <returns></returns>
        public WeatherDetails GetWeatherDeatils(string response)
        {
            WeatherDetails weatherDetails = new WeatherDetails();
            JObject jObject = JObject.Parse(response);
            weatherDetails.TempInDegrees = Math.Round(Convert.ToDouble(Convert.ToDouble(jObject.GetValue("main").First.First) - 273.15),2);
            weatherDetails.humidity = Convert.ToDouble(jObject.GetValue("main").Last.First); 
            return weatherDetails;
        }        
    }
}
