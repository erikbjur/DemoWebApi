using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using DemoWebApi.Models;
using System.Text;
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

        //Create sample data for this company
        private void CreateCompanyData()
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

        [HttpGet("GetEmployees/Xml")]
        public ActionResult GetEmployees()
        {
            //Create the company data
            CreateCompanyData();
            
            StringBuilder results = new();
            foreach( ApiEmployee objEmployee in this.CompanyData.EmployeeList )
            {
                results.AppendLine("Name: " + objEmployee.Name + " Age: " + objEmployee.Age.ToString() );
            }

            return Ok( results.ToString() );
        }

        [HttpPost("XmlPost")]
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
            
            //Create string from XDocument
            String xmlResultsToSendBack = objModifiedDocument.Document.ToString( SaveOptions.DisableFormatting );

            return Ok( xmlResultsToSendBack );
        }
    }
}
