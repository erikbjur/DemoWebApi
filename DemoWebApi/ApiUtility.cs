using System;
using System.Xml;
using System.Xml.Linq;
using DemoWebApi.Models;

namespace ApiUtility
{
    public static class ApiUtility
    {
        public static XmlDocument CreateXmlResults()
        {
            //Create new XDocument to load project data into
            XmlDocument dataFile = new();
            //Create the root node in the file
            XElement objRoot = new XElement ("Results");
            //Holds the group object that is being worked on
            //XElement objGroup;

            return dataFile;
        }

        public static ApiCompany ReadXmlData(XDocument objDoc)
        {
            //Create new company object
            ApiCompany objCompany = new();

            //Get the company name
            objCompany.Name = objDoc.Element("CompanyData").Element("Company").Element("Name").Value;

            //Go through the list of employees
            foreach (XElement objEmployeeElement in objDoc.Element("CompanyData").Element("Company").Element("EmployeeList").Elements("Employee"))
            {
                //Create a new employee
                ApiEmployee objEmployee = new();

                //Set the properties of the employee from the Xml
                objEmployee.Name = objEmployeeElement.Element("Name").Value;
                objEmployee.Age = int.Parse(objEmployeeElement.Element("Age").Value);
                
                //Add to the project
                objCompany.EmployeeList.Add(objEmployee);
            }

            //return Company object
            return objCompany;
        }
    }
}

   