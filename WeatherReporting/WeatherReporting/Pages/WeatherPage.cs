using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherReporting.Pages
{
    public class WeatherPage
    {
        private By searchBox = By.ClassName("searchBox");
        
        public IWebElement SearchBox()
        {
            return (NDTVBase.driver.FindElement(searchBox));
        }

        public IWebElement SelectCity(string city)
        {
            return (NDTVBase.driver.FindElement(By.Id(city)));
        }

        public IWebElement PinCity(string city)
        {
            return (NDTVBase.driver.FindElement(By.XPath("//div[@title='"+city+"']/parent::div")));
        }

        public IWebElement WeatherDetails(string partialText)
        {
            return (NDTVBase.driver.FindElement(By.XPath("//span/b[contains(text(),'"+partialText+"')]")));
        }
    }
}
