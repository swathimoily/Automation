using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherReporting.PageOps;

namespace WeatherReporting
{
    public class NDTVBase
    {
        public static IWebDriver driver;
        
        //This will run before starting every test methods
        [TestInitialize()]
        public void TestInialize()
        {
            LaunchUrl();
        }

        //This will run before ending every test methods
        [TestCleanup]
        public void TestCleanUp()
        {
            CloseUrl();
        }

        //Launches the url 
        public void LaunchUrl()
        {
            if(ConfigurationManager.AppSettings["Browser"]=="Chrome")
            {
                ChromeOptions opt = new ChromeOptions();
                opt.BinaryLocation = ConfigurationManager.AppSettings["Chrome"];
                driver = new ChromeDriver(ConfigurationManager.AppSettings["ChromeDriver"], opt);
                driver.Navigate().GoToUrl(ConfigurationManager.AppSettings["NDTVurl"]);
                BasePageOps.WaitForPageLoad();    
            }
            //Else update code for repective browser
               
        }

        //Exit the browser, end the session, tabs, pop-ups etc 
        public void CloseUrl()
        {
            driver.Quit();
        }
    
    }
}
