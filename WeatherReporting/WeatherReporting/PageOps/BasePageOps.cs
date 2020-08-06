using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Text;
using WeatherReporting.Pages;

namespace WeatherReporting.PageOps
{
    public class BasePageOps
    {
        /// <summary>
        /// Wait for the pageload to completed
        /// </summary>
        public void WaitForPageLoad()
        {
            IWait<IWebDriver> wait = new WebDriverWait(NDTVBase.driver, TimeSpan.FromSeconds(100.00));
            wait.Until(driver1 => ((IJavaScriptExecutor)NDTVBase.driver).ExecuteScript("return document.readyState").Equals("complete"));
    
        }        
    }
}
