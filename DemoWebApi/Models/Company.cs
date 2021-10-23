using System;
using System.Collections.Generic;

namespace DemoWebApi
{
    public class Company
    {
        public String Name { get; set; }

        public List<Employee> EmployeeList = new List<Employee>();

        public Company()
        {

        }
    }
}