using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Text;
using System.Threading;
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
            IWait<IWebDriver> wait = new WebDriverWait(NDTVBase.driver, TimeSpan.FromSeconds(2000.00));
            wait.Until(driver1 => element.Displayed);
        }

        /// <summary>
        /// Wait for the element to load if elements returns null
        /// Mostly for page load element check
        /// </summary>
        /// <param name="by"></param>
        public void WaitForElementToLoad(By by)
        {
            IWebElement element = null;
            int waitTime = 60;
            while (waitTime != 500 && element == null)
            {
                try
                {
                    element = NDTVBase.driver.FindElement(by);
                }
                catch
                {
                    Thread.Sleep(50);
                }
                waitTime = waitTime + 100;
            }
        }
        
    }
}
