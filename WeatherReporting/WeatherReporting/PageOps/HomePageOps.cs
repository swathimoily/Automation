using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherReporting.Pages;

namespace WeatherReporting.PageOps
{
    public class HomePageOps:BasePageOps
    {
        HomePage homePage = new HomePage();

        /// <summary>
        /// If Notifcation allow message box displayed then dismiss it
        /// </summary>
        public HomePageOps()
        {
            if (homePage.NoThanks().Displayed)
                homePage.NoThanks().Click();
        }

       /// <summary>
        /// If Notifcation allow message box displayed then dismiss it
       /// </summary>
        public void NaviagateToWeather()
        {
            homePage.SubMenu().Click();
            homePage.Weather().Click();
            BasePageOps.WaitForPageLoad();
        }
    }
}
