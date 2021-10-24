using System;
using System.Xml;
using System.Xml.Linq;
using DemoClientApp.Models;

namespace AppUtility
{
    public static class AppUtility
    {
        public static XmlDocument CreateXmlFromCompany(Company objCompany)
        {
            //Create new XDocument to load project data into
            XmlDocument dataFile = new();
            //Create the root node in the file
            XElement objRoot = new XElement ("Company File");
            //Holds the group object that is being worked on
            XElement objGroup;

            //Add the company
            objGroup = new XElement( "Company",
                new XElement( "Name", objCompany.Name ));
            foreach( Employee objEmployee in objCompany.EmployeeList )
            {
                XElement objEmployeeElement = new XElement( "Employee",
                    new XElement( "Name", objEmployee.Name ),
                    new XElement( "Age", objEmployee.Age ));
                objGroup.Add( objEmployeeElement );
            }

            return dataFile;
        }
    }
}