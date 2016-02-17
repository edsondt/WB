using Library.WebPay.Facades.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.WebPay.FeatureAreas
{
    public class Navigation
    {
        public static void SSOToWebBenefits()
        {
            (new WebPayBase()).ClickWebBenefitsButton();
        }
    }
}
