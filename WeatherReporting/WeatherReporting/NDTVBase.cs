using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherReporting.PageOps;

namespace WeatherReporting
{
    public class NDTVBase
    {
        public static IWebDriver driver;
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        private TestContext testContextInstance;

        //This will run before starting every test methods
        [TestInitialize()]
        public void TestInialize()
        {
            LaunchUrl();
        }

        //This will run before ending every test methods contains logs creating info
        [TestCleanup]
        public void TestCleanUp()
        {
            CloseUrl();
            switch(TestContext.CurrentTestOutcome)
            {
                case UnitTestOutcome.Passed: Logger.Log("\n"+DateTime.Now+" : "+ TestContext.TestName + " : Passed");
                    break;
                case UnitTestOutcome.Failed: Logger.Log("\n"+DateTime.Now + " : " + TestContext.TestName + " : Failed - " + Logger.exception);
                    break;
                case UnitTestOutcome.Aborted: Logger.Log("\n" + DateTime.Now + " : " + TestContext.TestName + " : Passed"); Logger.Log("\n" + DateTime.Now + " : " + TestContext.TestName + " : Passed");
                    break;
                case UnitTestOutcome.Timeout: Logger.Log("\n" + DateTime.Now + " : " + TestContext.TestName + " : Timeout");
                    break;
                default: Logger.Log("Unknown Error!!Please Debug..");
                    break;
            }
        }

        //Launches the url and dismiss the notification allow popup
        public void LaunchUrl()
        {
            UIHelper uiHelper = new UIHelper();
            HomePageOps homePageOps = new HomePageOps();
            if(ConfigurationManager.AppSettings["Browser"]=="Chrome")
            {
                ChromeOptions opt = new ChromeOptions();
                opt.BinaryLocation = ConfigurationManager.AppSettings["Chrome"];
                driver = new ChromeDriver(ConfigurationManager.AppSettings["ChromeDriver"], opt);
                driver.Navigate().GoToUrl(ConfigurationManager.AppSettings["NDTVurl"]);
                uiHelper.WaitForPageLoad();
                homePageOps.DismissNotiicationAlert();                
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
