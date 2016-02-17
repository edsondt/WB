using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Library.WebBenefits.Facades.PageObjects.Login;
using Library.WebBenefits.Facades.PageObjects.Implementation.SBTools.CompanySearch;
using WB = Library.WebBenefits.FeatureAreas;
using WP = Library.WebPay.FeatureAreas;
using Library.Core;

namespace AutomatedTests.WebBenefits.POC
{
    [TestClass]
    public class LoginAndSSOTests
    {
        [TestInitialize]
        public void Initialize()
        {
            Browser.Launch(BrowsertType.Chrome);
        }

        [TestCleanup]
        public void Cleanup()
        {
            Browser.Close();
        }

        [TestMethod]
        public void WB_SB_Admin_SSO_To_WP()
        {
            var loginParams = new LoginPageParams()
            {
                CompanyId   = "1",
                Username    = "ckent",
                Password    = "krypt0n1t3!"
            };

            WB.User.Login(loginParams);
            WB.Implementation.Navigation.SSOToWebPay();
            WP.Navigation.SSOToWebBenefits();
            WB.User.Logout();
        }
    }
}
