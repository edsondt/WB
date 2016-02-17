using Library.Core.Utils;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Core
{
    public static class WebDriverExtension
    {
        public static void WaitForAjax(this IWebDriver driver)
        {
            Wait.Until(
                () =>
                    (bool)(driver as IJavaScriptExecutor).ExecuteScript("return 'undefined' == typeof window.jQuery && 'undefined' == typeof Sys || 'undefined' != typeof window.jQuery && jQuery.isReady && jQuery.active == 0 || 'undefined' != typeof window.Sys && !Sys.WebForms.PageRequestManager.getInstance().get_isInAsyncPostBack()")
                );
        }
    }
}
