using System;
using System.Net.Http;
using System.Xml.Linq;
using DemoClientApp.Models;

namespace DemoClientApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Creating the HTTP Client");

            //Create the Http Client
            HttpClient client = new();

            //Create a new company object
            Company CompanyData = new Company();
            CompanyData.Name = "My Company";

            //Create a new employee
            Employee objEmployee = new();
            objEmployee.Name = "Erik";
            objEmployee.Age = 44;
            //Add it to the company
            CompanyData.EmployeeList.Add(objEmployee);

            //Create a new employee
            objEmployee = new();
            objEmployee.Name = "Michelle";
            objEmployee.Age = 42;
            CompanyData.EmployeeList.Add(objEmployee);

            //Create xml file of Company
            XDocument objDocument = new();
            objDocument = AppUtility.CreateXmlFromCompany( CompanyData );
            Console.WriteLine("Done");

        }
    }
}
