using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Library.Core
{
    public class Browser
    {
        private static IWebDriver _driver = null;

        public Browser() { }

        public static void Launch(BrowsertType browserType)
        {
            if (_driver == null)
            {
                _driver = new WebDriver(browserType);

                AppDomain.CurrentDomain.FirstChanceException += FirstChanceHandler;
            }
        }

        private static void FirstChanceHandler(object source, FirstChanceExceptionEventArgs e)
        {
            string executingAssemblyPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            try
            {
                TakeScreenshot(Path.Combine(executingAssemblyPath, "Screenshots", DateTime.Now.ToString("yyyyMMdd_HHmmssff") + ".png"));
            }
            catch
            {
                // Do nothing. Suppress any exceptions.
            }
            finally
            {
                AppDomain.CurrentDomain.FirstChanceException -= FirstChanceHandler;
            }
        }

        public static void Close()
        {
            if (_driver != null)
            {
                _driver.Close();
            }
        }

        public static void Navigate(string url)
        {
            Browser.WebDriver.Manage().Window.Maximize();
            Browser.WebDriver.Navigate().GoToUrl(url);
        }

        public static IWebDriver WebDriver
        {
            get
            {
                Assert.IsNotNull(_driver);

                return _driver;
            }
        }

        public static void TakeScreenshot(string path)
        {
            Screenshot screenshot = (Browser.WebDriver as ITakesScreenshot).GetScreenshot();
            screenshot.SaveAsFile(path, ImageFormat.Png);
        }
    }
}
