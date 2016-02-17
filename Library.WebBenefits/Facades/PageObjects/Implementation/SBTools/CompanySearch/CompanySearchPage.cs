using Library.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.WebBenefits.Facades.PageObjects.Implementation.SBTools.CompanySearch
{
    public class CompanySearchPage : ImplementationBase
    {
        public void SetFields(CompanySearchParams p)
        {
            Browser.WebDriver.FindElement(By.Id("GroupNumber"))     .SendKeys(p.GroupNumber);
            Browser.WebDriver.FindElement(By.Id("Name"))            .SendKeys(p.Name);
            Browser.WebDriver.FindElement(By.Id("CompanySetId"))    .SendKeys(p.WebPayCompanyCompanySetId);
            Browser.WebDriver.FindElement(By.Id("CompanySetName"))  .SendKeys(p.WebPayCompanyCompanySetName);
            SetTeamDropdown(p.Team);
        }

        public void SetTeamDropdown(string team, int position = 1)
        {
            if (String.IsNullOrWhiteSpace(team))
            {
                return;
            }

            Browser.WebDriver.FindElement(By.XPath(".//*[contains(@class,'k-input')]")).Click();
            Browser.WebDriver.FindElement(By.XPath(String.Format("//*[@id='Teams_listbox']/li[text()='{0}'][{1}]", team, position))).Click();
        }

        public void ClickSearchButton()
        {
            Browser.WebDriver.FindElement(By.XPath(".//button[text()='Search']")).Click();
        }

        public void ClickShowAllButton()
        {
            Browser.WebDriver.FindElement(By.XPath(".//button[text()='Show All']")).Click();
        }

        public void ClickAddButton()
        {
            Browser.WebDriver.FindElement(By.XPath(".//*[text()='Add']")).Click();
        }

        public List<CompanySearchResultsGridRow> SearchResults
        {
            get
            {
                var results = new List<CompanySearchResultsGridRow>();

                Browser.WebDriver.FindElements(By.XPath(".//table/tbody/tr"))
                    .ToList()
                    .ForEach(r =>
                    {
                        var row = new CompanySearchResultsGridRow();

                        row.GroupNumber         = r.FindElement(By.XPath("./td[1]")).Text;
                        row.Name                = r.FindElement(By.XPath("./td[2]")).Text;
                        row.NumberOfCompanies   = Int32.Parse(r.FindElement(By.XPath("./td[3]")).Text);
                        row.CompanySet          = r.FindElement(By.XPath("./td[4]")).Text;
                        row.Team                = r.FindElement(By.XPath("./td[5]")).Text;

                        results.Add(row);
                    });


                return results;
            }
        }

        public void ClickSearchResultField(int row, int column)
        {
            var searchResults = SearchResults;

            Browser.WebDriver.FindElement(By.XPath(String.Format(".//table/tbody/tr[{0}]/td[{1}]", row, column))).Click();
        }
    }
}