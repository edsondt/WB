using Library.WebBenefits.Facades.PageObjects.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.WebBenefits.FeatureAreas.Implementation
{
    public class Navigation
    {
        public static void SSOToWebPay()
        {
            (new ImplementationBase()).ClickWebPayButton();
        }

        public static void OpenInternalPage()
        {
            (new ImplementationBase()).ClickInternalButton();
        }

        public static void OpenCompanySearchPage()
        {
            (new ImplementationBase()).ClickCompanySearchButton();
        }
    }
}
