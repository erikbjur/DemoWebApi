using System;
using System.Collections.Generic;

namespace ObjectLibrary
{
    public class CompanyDTO : ICompany
    {
        public String Name { get; set; }

        public List<IEmployee> EmployeeList { get; }

        public CompanyDTO()
        {
            this.EmployeeList = new List<IEmployee>();
        }
    }
}