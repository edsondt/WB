using Library.Core;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.WebPay.Facades.PageObjects
{
    public class WebPayBase
    {
        #region Applications
        public void ClickWebBenefitsButton()
        {
            Browser.WebDriver.FindElement(By.LinkText("Applications")).Click();
            Browser.WebDriver.FindElement(By.LinkText("Web Benefits")).Click();
        }
        #endregion Applications
    }
}
