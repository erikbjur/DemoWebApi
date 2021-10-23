using System;
using System.Collections.Generic;

namespace ObjectLibrary
{
    public interface ICompany
    {
        public String Name { get; set; }

        public List<IEmployee> EmployeeList { get; }
    }
}
