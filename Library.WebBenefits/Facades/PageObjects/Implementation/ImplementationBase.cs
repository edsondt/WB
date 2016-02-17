using Library.Core;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.WebBenefits.Facades.PageObjects.Implementation
{
    public class ImplementationBase
    {
        #region Applications
        public void ClickWebPayButton()
        {
            Browser.WebDriver.FindElement(By.LinkText("Applications")).Click();
            Browser.WebDriver.FindElement(By.LinkText("Web Pay")).Click();
        }
        #endregion Applications

        #region SB Tools
        public void ClickCompanySearchButton()
        {
            Browser.WebDriver.FindElement(By.LinkText("SB Tools")).Click();
            Browser.WebDriver.FindElement(By.LinkText("Company Search")).Click();
        }

        public void ClickInternalButton()
        {
            Browser.WebDriver.FindElement(By.LinkText("SB Tools")).Click();
            Browser.WebDriver.FindElement(By.LinkText("Internal")).Click();
        }
        #endregion SB Tools
    }
}
