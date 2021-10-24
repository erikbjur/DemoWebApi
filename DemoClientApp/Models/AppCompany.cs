using System;
using System.Collections.Generic;
using ObjectLibrary;

namespace DemoClientApp.Models
{
    public class AppCompany : ICompany
    {
        public String Name { get; set; }

        public List<IEmployee> EmployeeList { get; }

        public AppCompany()
        {
            this.EmployeeList = new List<IEmployee>();
        }
    }
}