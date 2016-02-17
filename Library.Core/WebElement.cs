using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Drawing;
using OpenQA.Selenium.Interactions.Internal;

namespace Library.Core
{
    public class WebElement : IWebElement, ILocatable
    {
        private IWebElement _webElement = null;

        #region IWebElement
        public WebElement(IWebElement webElement)
        {
            _webElement = webElement;
        }

        public bool Displayed
        {
            get
            {
                return _webElement.Displayed;
            }
        }

        public bool Enabled
        {
            get
            {
                return _webElement.Enabled;
            }
        }

        public Point Location
        {
            get
            {
                return _webElement.Location;
            }
        }

        public bool Selected
        {
            get
            {
                return _webElement.Selected;
            }
        }

        public Size Size
        {
            get
            {
                return _webElement.Size;
            }
        }

        public string TagName
        {
            get
            {
                return _webElement.TagName;
            }
        }

        public string Text
        {
            get
            {
                return _webElement.Text;
            }
        }

        public void Clear()
        {
            _webElement.Clear();
        }

        public void Click()
        {
            _webElement.Click();

            Browser.WebDriver.WaitForAjax();
        }

        public IWebElement FindElement(By by)
        {
            return new WebElement(_webElement.FindElement(by));
        }

        public ReadOnlyCollection<IWebElement> FindElements(By by)
        {
            var list = new List<IWebElement>();

            _webElement.FindElements(by).ToList().ForEach(e => list.Add(new WebElement(e)));

            return new ReadOnlyCollection<IWebElement>(list);
        }

        public string GetAttribute(string attributeName)
        {
            return _webElement.GetAttribute(attributeName);
        }

        public string GetCssValue(string propertyName)
        {
            return _webElement.GetCssValue(propertyName);
        }

        public void SendKeys(string text)
        {
            if (String.IsNullOrWhiteSpace(text))
            {
                return;
            }

            _webElement.SendKeys(text);

            Browser.WebDriver.WaitForAjax();
        }

        public void Submit()
        {
            _webElement.Submit();
        }
        #endregion IWebElement

        #region ILocatable
        public Point LocationOnScreenOnceScrolledIntoView
        {
            get
            {
                return (_webElement as ILocatable).LocationOnScreenOnceScrolledIntoView;
            }
        }

        public ICoordinates Coordinates
        {
            get
            {
                return (_webElement as ILocatable).Coordinates;
            }
        }
        #endregion ILocatable
    }
}
