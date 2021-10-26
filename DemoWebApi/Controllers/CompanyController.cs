using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DemoWebApi.Models;
using System.Text;
using System.Net.Http;
using System.Net;
using System.IO;
using System.Xml.Linq;
using DemoWebApi.Utilities;

namespace DemoWebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CompanyController : ControllerBase
    {
        private ApiCompany CompanyData = new ApiCompany();

        //Create data for this company
        private void CreateCompanyDate()
        {
            //Create a new employee
            ApiEmployee objEmployee = new();
            objEmployee.Name = "Erik";
            objEmployee.Age = 44;
            //Add it to the company
            this.CompanyData.EmployeeList.Add(objEmployee);

            //Create a new employee
            objEmployee = new();
            objEmployee.Name = "Michelle";
            objEmployee.Age = 42;
            this.CompanyData.EmployeeList.Add(objEmployee);
        }

        [HttpGet("GetEmployees")]
        public ActionResult GetEmployees()
        {
            //Create the company data
            CreateCompanyDate();
            
            StringBuilder results = new();
            foreach( ApiEmployee objEmployee in this.CompanyData.EmployeeList )
            {
                results.AppendLine("Name: " + objEmployee.Name + " Age: " + objEmployee.Age.ToString() );
            }

            //HttpResponseMessage returnResponse = new HttpResponseMessage( HttpStatusCode.OK );
            //returnResponse.Content = new StringContent( results.ToString(), Encoding.UTF8, "text/plain");

            return Ok( results.ToString() );

        }

        [HttpPost]
        //public async Task<ActionResult> Post([FromBody] String xmlStringData )
        public async Task<ActionResult> Post()
        {
            string xmlStringData;
            using (StreamReader reader = new StreamReader( Request.Body, Encoding.UTF8 ) )
            {
                xmlStringData = await reader.ReadToEndAsync();
            }

            //Create a Company object from the xml string
            ApiCompany objCompany = ApiUtility.CreateCompanyFromXmlString( xmlStringData );

            //Here we double the age of every employee
            foreach( ApiEmployee objEmployee in objCompany.EmployeeList )
            {
                objEmployee.Age = objEmployee.Age * 2;
            }

            //Create xml file of the modified company
            XDocument objModifiedDocument = ApiUtility.CreateXmlResults( objCompany );
            
            //Add the XML header / encoding stuff to the beginning of the file
            //String xmlResultsToSendBack = "<xml version=1.0 encoding=utf-8 standalone=yes>" + objModifiedDocument.Document.ToString( SaveOptions.DisableFormatting );
            String xmlResultsToSendBack = objModifiedDocument.Document.ToString( SaveOptions.DisableFormatting );

            return Ok( xmlResultsToSendBack );
        }
    }
}
