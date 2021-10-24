using System;
using ObjectLibrary;

namespace DemoClientApp.Models
{
    public class AppEmployee : IEmployee
    {
        public String Name { get; set; }

        public int Age { get; set; }

        public AppEmployee()
        {

        }
    }
}
