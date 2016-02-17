using Library.Core;
using Library.WebBenefits.Facades.PageObjects.Implementation;
using Library.WebBenefits.Facades.PageObjects.Implementation.SBTools.CompanySearch;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.WebBenefits.FeatureAreas.Implementation
{
    public class ServiceBureau
    {
        public static List<CompanySearchResultsGridRow> SearchCompany(CompanySearchParams p)
        {
            (new ImplementationBase()).ClickCompanySearchButton();
            (new CompanySearchPage()).SetFields(p);
            (new CompanySearchPage()).ClickSearchButton();

            return (new CompanySearchPage()).SearchResults;
        }

        /// <summary>
        /// Opens a Company in the Implemnetation Page.
        /// </summary>
        /// <param name="p">Company Search params</param>
        /// <param name="position">The position in the results grid. A position of 1 is  the first company in the list.</param>
        public static void OpenCompany(CompanySearchParams p, int position = 1)
        {
            SearchCompany(p);

            // Click the row given the position. By default, this clicks the Company Name link of the first item in the results grid.
            (new CompanySearchPage()).ClickSearchResultField(position, 2);
        }
    }
}
