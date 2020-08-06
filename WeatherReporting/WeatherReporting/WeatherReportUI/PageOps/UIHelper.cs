using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Text;
using WeatherReporting.Pages;

namespace WeatherReporting.PageOps
{
    public class UIHelper
    {
        /// <summary>
        /// Wait for the pageload to completed
        /// </summary>
        public void WaitForPageLoad()
        {
            IWait<IWebDriver> wait = new WebDriverWait(NDTVBase.driver, TimeSpan.FromSeconds(100.00));
            wait.Until(driver1 => ((IJavaScriptExecutor)NDTVBase.driver).ExecuteScript("return document.readyState").Equals("complete"));
    
        }

        /// <summary>
        /// Wait for blocking elemnt become none
        /// </summary>
        /// <param name="blockingElement"></param>
        public void WaitForPageLoad(IWebElement blockingElement)
        {
            IWait<IWebDriver> wait = new WebDriverWait(NDTVBase.driver, TimeSpan.FromSeconds(100.00));
            wait.Until(loading => (blockingElement.GetCssValue("Display").Equals("none")));
        }

        /// <summary>
        /// Wait for control to be displayed
        /// </summary>
        /// <param name="element"></param>
        public void WaitForElementDisplay(IWebElement element)
        {
            IWait<IWebDriver> wait = new WebDriverWait(NDTVBase.driver, TimeSpan.FromSeconds(300.00));
            wait.Until(driver1 => element.Displayed);

        }  
        
    }
}
