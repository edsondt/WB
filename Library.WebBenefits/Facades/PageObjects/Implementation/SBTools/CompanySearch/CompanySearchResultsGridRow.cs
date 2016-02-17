using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.WebBenefits.Facades.PageObjects.Implementation.SBTools.CompanySearch
{
    public class CompanySearchResultsGridRow
    {
        public string   GroupNumber         { get; set; }
        public string   Name                { get; set; }
        public int      NumberOfCompanies   { get; set; }
        public string   CompanySet          { get; set; }
        public string   Team                { get; set; }
    }
}
