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
            XElement objRoot = new XElement ("LoadPathFile");
            //Holds the group object that is being worked on
            XElement objGroup;



            return dataFile;
        }

        public static void ReadXmlData()
        {
            Company objCompany = new();

            
        }
    }
}

   