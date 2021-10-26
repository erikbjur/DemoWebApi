using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using DemoClientApp.Models;

namespace DemoClientApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //Try Get Request for data created in the API
            Console.WriteLine( "Calling Get request" );
            String results = GetEmployees();
            Console.WriteLine( "Here's what came back from the get request..." );
            Console.WriteLine( results );

            //Now work on the Post Request
            Console.WriteLine( "Now lets do the post request..." );
            //First Create a new company object
            AppCompany CompanyData = new AppCompany();
            CompanyData.Name = "My Company";

            //Create a first employee
            AppEmployee objEmployee = new();
            objEmployee.Name = "Erik";
            objEmployee.Age = 44;
            //Add it to the company
            CompanyData.EmployeeList.Add( objEmployee );

            //Create a second employee
            objEmployee = new();
            objEmployee.Name = "Michelle";
            objEmployee.Age = 42;
            CompanyData.EmployeeList.Add( objEmployee );

            //Create xml file of Company
            XDocument objDocument = new();
            objDocument = AppUtility.CreateXmlFromCompany( CompanyData );

            //Create string from XDocument
            String xmlData = objDocument.Document.ToString( SaveOptions.DisableFormatting );
            Console.WriteLine("Done making XML String");

            //Start the post request
            Console.WriteLine( "Calling the post request..." );
            String result = PostXMLData( xmlData ).Result;
            Console.WriteLine( "Here's what came back from the API:" );
            Console.WriteLine( result );
            
        }

        public static String GetEmployees()
        {
            String result;

            using (HttpClient client = new HttpClient())
            {
                //Setting the base addresss
                client.BaseAddress = new Uri("https://localhost:5001/");
                
                result = client.GetStringAsync("Company/GetEmployees/Xml").Result;
            }

            return result;
        }

        public static async Task<String> PostXMLData( String xmlDataString )
        {
            //Create the Http Client
            HttpClient client = new();

            //Setting the base addresss
            client.BaseAddress = new Uri("https://localhost:5001/");

            StringContent objStringContent = new StringContent( xmlDataString, Encoding.UTF8, "text/plain" );
            HttpResponseMessage responseMessage = await client.PostAsync( "Company/XmlPost", objStringContent );
            String result = await responseMessage.Content.ReadAsStringAsync();

            client.Dispose();

            return result;
        }
    }
}
