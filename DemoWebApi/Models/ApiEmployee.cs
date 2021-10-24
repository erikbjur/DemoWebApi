using System;
using ObjectLibrary;

namespace DemoWebApi.Models
{
    public class ApiEmployee : IEmployee
    {
        public String Name { get; set; }

        public int Age { get; set; }

        public ApiEmployee()
        {

        }
    }
}
