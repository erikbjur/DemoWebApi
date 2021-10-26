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
        //private ApiCompany CompanyData = new ApiCompany();

        //Create sample data for this company
        private void CreateCompanyData()
        {
            //Create a new employee
            ApiEmployee objEmployee = new();
            objEmployee.Name = "Erik";
            objEmployee.Age = 44;
            //Add it to the company
            DemoWebApi.Models.ApplicationData.Company.EmployeeList.Add(objEmployee);
            //this.CompanyData.EmployeeList.Add(objEmployee);

            //Create a new employee
            objEmployee = new();
            objEmployee.Name = "Michelle";
            objEmployee.Age = 42;
            DemoWebApi.Models.ApplicationData.Company.EmployeeList.Add(objEmployee);
            //this.CompanyData.EmployeeList.Add(objEmployee);
        }

        [HttpGet("GetEmployees/Xml")]
        public ActionResult GetEmployees()
        {
            //Create the company data
            //CreateCompanyData();
            
            StringBuilder results = new();
            foreach( ApiEmployee objEmployee in DemoWebApi.Models.ApplicationData.Company.EmployeeList)
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
            DemoWebApi.Models.ApplicationData.Company = ApiUtility.CreateCompanyFromXmlString( xmlStringData );

            //Here we double the age of every employee
            foreach( ApiEmployee objEmployee in DemoWebApi.Models.ApplicationData.Company.EmployeeList)
            {
                objEmployee.Age = objEmployee.Age * 2;
            }

            //Create xml file of the modified company
            XDocument objModifiedDocument = ApiUtility.CreateXmlResults(DemoWebApi.Models.ApplicationData.Company);
            
            //Create string from XDocument
            String xmlResultsToSendBack = objModifiedDocument.Document.ToString( SaveOptions.DisableFormatting );

            return Ok( xmlResultsToSendBack );
        }
    }
}
