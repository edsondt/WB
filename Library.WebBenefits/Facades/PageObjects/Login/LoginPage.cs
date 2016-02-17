using Library.Core;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.WebBenefits.Facades.PageObjects.Login
{
    public class LoginPage
    {
        // TODO: Move the absolute path to a config file so that it refers to the correct URL depending on the env.
        private const string ENV_PATH           = @"https://copperbenefitssb.qa.paylocity.com";
        private const string LOGIN_PAGE_PATH    = @"WebBenefits/Membership/Login";

        public void ClickLoginButton()
        {
            Browser.WebDriver.FindElement(By.Id("loginButton")).Click();
        }

        public void Open()
        {
            Browser.Navigate((new Uri(new Uri(ENV_PATH), LOGIN_PAGE_PATH)).ToString());
        }

        public void SetFields(LoginPageParams p)
        {
            Browser.WebDriver.FindElement(By.Id("coCode")).SendKeys(p.CompanyId);
            Browser.WebDriver.FindElement(By.Id("loginName")).SendKeys(p.Username);
            Browser.WebDriver.FindElement(By.Id("password")).SendKeys(p.Password);
        }
    }
}
