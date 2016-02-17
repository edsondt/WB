using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Library.Core;
using Library.WebBenefits.Facades.PageObjects.Login;
using Library.WebPay.Facades.PageObjects.Client.Employees.EmployeeSearch.NewEmployee;
using Library.WebBenefits.Facades.PageObjects.Implementation.SBTools.CompanySearch;
using WB = Library.WebBenefits.FeatureAreas;
using WP = Library.WebPay.FeatureAreas;

namespace AutomatedTests.WebBenefits.POC
{
    [TestClass]
    public class EnrollmentTriggeringTests
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
        public void Enrollment_Is_Triggered_For_A_New_Hire()
        {
            var loginParams = new LoginPageParams()
            {
                CompanyId           = "1",
                Username            = "ckent",
                Password            = "krypt0n1t3!"
            };

            var newEmployeePageParams = new NewEmployeePageParams()
            {
                LastName            = "Smith",
                FirstName           = "Sam",
                FederalFilingStatus = "Single",
                StateFilingStatus   = "Single",
                Department          = "Accounting"
            };

            var companySearchParams = new CompanySearchParams()
            {
                Name = "AR MPY Test Company"
            };

            WB.User.Login(loginParams);

            WB.Implementation.ServiceBureau.OpenCompany(companySearchParams);

            WP.Employee.AddNew(newEmployeePageParams);
            WP.Employee.AddBenefitsClass();
            WP.Employee.SetupUserAccount();
            WP.Navigation.SSOToWebBenefits();

            WB.Implementation.Employees.UpdateEligibility();
            WB.Implementation.Employees.ImpersonateEmployee();

            // Assert
            // Verify that Enrollment is triggered.
        }
    }
}
