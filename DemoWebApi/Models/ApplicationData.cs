using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoWebApi.Models
{
    public static class ApplicationData
    {
        public static ApiCompany Company;
        public static void InitializeCompanyData()
        {
            Company = new ApiCompany();
        }
    }
}
