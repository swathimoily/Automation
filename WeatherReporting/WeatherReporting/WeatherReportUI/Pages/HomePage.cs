using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherReporting.Pages
{
    public class HomePage
    {
        private By noThanks = By.ClassName("notnow");
        private By subMenu = By.Id("h_sub_menu");
        private By weather = By.LinkText("WEATHER");
              

        public IWebElement NoThanks()
        {
            return (NDTVBase.driver.FindElement(noThanks));
        }

        public IWebElement SubMenu()
        {
            return (NDTVBase.driver.FindElement(subMenu));
        }

        public IWebElement Weather()
        {
            return (NDTVBase.driver.FindElement(weather));
        }
    
    }
}
