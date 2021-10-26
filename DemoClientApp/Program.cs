using System;
using System.Diagnostics;
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
            Stopwatch timer = new Stopwatch();

            //Now work on the Post Request
            Console.WriteLine("Press any key to start Post Request");
            Console.ReadKey();

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

            //Create xml file of Company.  This takes the place of creating loads of DTO's
            XDocument objDocument = new();
            objDocument = AppUtility.CreateXmlFromCompany( CompanyData );

            //Create string from XDocument
            String xmlData = objDocument.Document.ToString( SaveOptions.DisableFormatting );

            //Start the post request
            Console.WriteLine( "Calling the post request..." );
            timer.Start();
            String result = PostXMLData( xmlData ).Result;
            timer.Stop();
            Console.WriteLine( "Here's what came back from the API.  It took " + timer.ElapsedMilliseconds + "ms" );
            Console.WriteLine( result );

            //Try Get Request for data created in the API
            Console.WriteLine("Press any key to start Get Request");
            Console.ReadKey();
            
            Console.WriteLine( "Calling Get request" );
            timer.Reset();
            timer.Start();
            String results = GetEmployees();
            timer.Stop();
            Console.WriteLine( "Here's what came back from the get request that took " + timer.ElapsedMilliseconds + "ms" );
            Console.WriteLine( results );

            Console.ReadKey();
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
