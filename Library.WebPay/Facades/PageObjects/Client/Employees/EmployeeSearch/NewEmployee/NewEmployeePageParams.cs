using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.WebPay.Facades.PageObjects.Client.Employees.EmployeeSearch.NewEmployee
{
    public class NewEmployeePageParams
    {
        // Employee
        public string EmployeeId;
        public string LastName;
        public string FirstName;

        // Taxes
        public string SSN;
        public string FederalFilingStatus;
        public string StateFilingStatus;

        // Department / Position
        public string Department;
    }
}
