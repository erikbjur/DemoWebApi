using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DemoWebApi.Models;
using System.Text;

namespace DemoWebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CompanyController : ControllerBase
    {
        private Company CompanyData = new Company();

        //Create data for this company
        private void CreateCompanyDate()
        {
            //Create a new employee
            Employee objEmployee = new();
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
            foreach( Employee objEmployee in this.CompanyData.EmployeeList )
            {
                results.AppendLine("Name: " + objEmployee.Name + " Age: " + objEmployee.Age.ToString() );
            }
            return Ok(results.ToString());
        }
    }
}
