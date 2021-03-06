﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherReporting.Pages;

namespace WeatherReporting.PageOps
{
    public class HomePageOps:UIHelper
    {
        HomePage homePage = new HomePage();
        UIHelper uiHelper = new UIHelper();

        /// <summary>
        ///This will dismiss notification alert
        /// </summary>
        public void DismissNotiicationAlert()
        {
            uiHelper.WaitForElementDisplay(homePage.NoThanks());
            if (homePage.NoThanks().Displayed)
                homePage.NoThanks().Click();
        }

       /// <summary>
        /// If Notifcation allow message box displayed then dismiss it
       /// </summary>
        public void NaviagateToWeather()
        {
            WeatherPageOps weatherPageOps = new WeatherPageOps();
            homePage.SubMenu().Click();
            homePage.Weather().Click();
            weatherPageOps.WaitForPageLoad();
        }
    }
}
