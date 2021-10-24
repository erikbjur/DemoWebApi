using System;
using System.Collections.Generic;
using ObjectLibrary;

namespace DemoWebApi.Models
{
    public class ApiCompany : ICompany
    {
        public String Name { get; set; }

        public List<IEmployee> EmployeeList { get; }

        public ApiCompany()
        {
            this.EmployeeList = new List<IEmployee>();
        }
    }
}