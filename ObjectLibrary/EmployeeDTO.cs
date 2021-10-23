using System;

namespace ObjectLibrary
{
    public class EmployeeDTO : IEmployee
    {
        public String Name { get; set; }

        public int Age { get; set; }

        public EmployeeDTO()
        {

        }
    }
}
