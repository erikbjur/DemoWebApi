using System;
using System.Collections.Generic;
using ObjectLibrary;

namespace DemoWebApi.Models
{
    public class Company : ICompany
    {
        public String Name { get; set; }

        public List<IEmployee> EmployeeList { get; }

        public Company()
        {
            this.EmployeeList = new List<IEmployee>();
        }
    }
}