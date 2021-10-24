using System;
using System.Xml.Linq;
using DemoClientApp.Models;

namespace DemoClientApp
{
    public static class AppUtility
    {
        public static XDocument CreateXmlFromCompany( AppCompany objCompany )
        {
            //Create new XDocument to load project data into
            XDocument dataFile = new XDocument(
                new XDeclaration("1.0", "utf-8", "yes"));
            //Create the root node in the file
            XElement objRoot = new XElement( "CompanyData" );

            //Add the company
            XElement objGroup = new XElement( "Company",
                new XElement( "Name", objCompany.Name ));
            XElement objEmployeeGroup = new XElement( "EmployeeList" );
            foreach( AppEmployee objEmployee in objCompany.EmployeeList )
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
    }
}