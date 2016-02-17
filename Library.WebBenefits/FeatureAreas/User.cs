using Library.Core;
using Library.WebBenefits.Facades.PageObjects.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.WebBenefits.FeatureAreas
{
    public static class User
    {
        public static void Login(LoginPageParams p)
        {
            (new LoginPage()).Open();
            (new LoginPage()).SetFields(p);
            (new LoginPage()).ClickLoginButton();
        }

        public static void Logout()
        {
            // TODO: Implement
        }
    }
}
