using System;
using System.Xml.Linq;
using DemoWebApi.Models;

namespace DemoWebApi.Utilities
{
    public static class ApiUtility
    {
        public static XDocument CreateXmlResults( ApiCompany objCompany )
        {
            //Create new XDocument to load project data into
            XDocument dataFile = new XDocument(
                new XDeclaration("1.0", "utf-8", "yes"));
            //Create the root node in the file
            XElement objRoot = new XElement( "Results" );

            //Add the company
            XElement objGroup = new XElement( "Company",
                new XElement( "Name", objCompany.Name ));
            XElement objEmployeeGroup = new XElement( "EmployeeList" );
            foreach( ApiEmployee objEmployee in objCompany.EmployeeList )
            {
                XElement objEmployeeElement = new XElement( "Employee",
                    new XElement( "Name", objEmployee.Name ),
                    new XElement( "Age", objEmployee.Age ));
                objEmployeeGroup.Add( objEmployeeElement );
            }

            objGroup.Add( objEmployeeGroup );

            //Add the Group the the root
            objRoot.Add( objGroup );

            //Add the Root to the document
            dataFile.Add( objRoot );

            //Return the XDocument file
            return dataFile;
        }

        public static ApiCompany CreateCompanyFromXmlString(String xmlStringFile)
        {
            //Create XDocument from String
            XDocument objDoc = XDocument.Parse( xmlStringFile );

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

   