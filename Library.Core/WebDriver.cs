using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Reflection;
using System.IO;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Interactions.Internal;
using System.Drawing;
using System.Windows.Forms;
using Library.Core.Utils;

namespace Library.Core
{
    public enum BrowsertType { Chrome, IE_x86, IE_x64 }

    public class WebDriver : IWebDriver, IJavaScriptExecutor, IHasInputDevices, ILocatable, ITakesScreenshot
    {
        private IWebDriver _webDriver = null;

        private const string CHROME_DRIVER_PATH = @"Drivers\IE_Driver_x86";
        private const string IE_DRIVER_x86_PATH = @"Drivers\IE_Driver_x86";
        private const string IE_DRIVER_x64_PATH = @"Drivers\IE_Driver_x64";

        public WebDriver(BrowsertType wb)
        {
            Cursor.Position = new Point(0, 0);

            string executingAssemblyPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            if (wb == BrowsertType.Chrome)
            {
                Environment.SetEnvironmentVariable("webdriver.chrome.driver", Path.Combine(executingAssemblyPath, CHROME_DRIVER_PATH));
                _webDriver = new ChromeDriver();
            }
            else if (wb == BrowsertType.IE_x86)
            {
                Environment.SetEnvironmentVariable("webdriver.ie.driver", Path.Combine(executingAssemblyPath, IE_DRIVER_x86_PATH));
                _webDriver = new InternetExplorerDriver();
            }
            else if (wb == BrowsertType.IE_x64)
            {
                Environment.SetEnvironmentVariable("webdriver.ie.driver", Path.Combine(executingAssemblyPath, IE_DRIVER_x64_PATH));
                _webDriver = new InternetExplorerDriver();
            }
        }

        #region IWebDriver Methods

        public string CurrentWindowHandle
        {
            get
            {
                return _webDriver.CurrentWindowHandle;
            }
        }

        public string PageSource
        {
            get
            {
                return _webDriver.PageSource;
            }
        }

        public string Title
        {
            get
            {
                return _webDriver.Title;
            }
        }

        public string Url
        {
            get
            {
                return _webDriver.Url;
            }

            set
            {
                _webDriver.Url = value;
            }
        }

        public ReadOnlyCollection<string> WindowHandles
        {
            get
            {
                return _webDriver.WindowHandles;
            }
        }

        public void Close()
        {
            _webDriver.Close();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_webDriver != null)
                {
                    _webDriver.Dispose();
                    _webDriver = null;
                }
            }
        }

        public IWebElement FindElement(By by)
        {
            return new WebElement(_webDriver.FindElement(by));
        }

        public ReadOnlyCollection<IWebElement> FindElements(By by)
        {
            var list = new List<IWebElement>();

            _webDriver.FindElements(by).ToList().ForEach(e => list.Add(new WebElement(e)));

            return new ReadOnlyCollection<IWebElement>(list);
        }

        public IOptions Manage()
        {
            return _webDriver.Manage();
        }

        public INavigation Navigate()
        {
            var navigation = _webDriver.Navigate();
            _webDriver.WaitForAjax();

            return navigation;
        }

        public void Quit()
        {
            _webDriver.Quit();
        }
        #endregion IWebDriver Methods

        #region IJavaScriptExecutor Methods
        public ITargetLocator SwitchTo()
        {
            return _webDriver.SwitchTo();
        }

        public object ExecuteScript(string script, params object[] args)
        {
            return (_webDriver as IJavaScriptExecutor).ExecuteScript(script, args);
        }

        public object ExecuteAsyncScript(string script, params object[] args)
        {
            return (_webDriver as IJavaScriptExecutor).ExecuteAsyncScript(script, args);
        }

        #endregion IJavaScriptExecutor Methods

        #region IHasInputDevices
        public IKeyboard Keyboard
        {
            get
            {
                return (_webDriver as IHasInputDevices).Keyboard;
            }
        }

        public IMouse Mouse
        {
            get
            {
                return (_webDriver as IHasInputDevices).Mouse;
            }
        }
        #endregion IHasInputDevices

        #region ILocatable
        public Point LocationOnScreenOnceScrolledIntoView
        {
            get
            {
                return (_webDriver as ILocatable).LocationOnScreenOnceScrolledIntoView;
            }
        }

        public ICoordinates Coordinates
        {
            get
            {
                return (_webDriver as ILocatable).Coordinates;
            }
        }
        #endregion ILocatable

        #region ITakesScreenshot
        public Screenshot GetScreenshot()
        {
            return (_webDriver as ITakesScreenshot).GetScreenshot();
        }
        #endregion ITakesScreenshot
    }
}
