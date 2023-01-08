using Microsoft.AspNetCore.Mvc;
using product.buisness;
using Product.Database.Dtos.Companies;
using Product.Database.entities;
using Product.Database.Enums;
using Prouduct.Database.entities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Product.api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CompanyController
    {
        private CompanyService _companyservice;
        public CompanyController (CompanyService companyService)
        {
            _companyservice = companyService;
        }

        [HttpPost("product/AddCompany")]
        public bool AddCompany(string companyName, string description, string ownerName, bool status, Sectors sector, DateTime startDate, List<TheCountry> branch)
        {
            var theResult = _companyservice.AddNewCompany(companyName, description, ownerName, status, sector, startDate, branch);
            return theResult;
        }

        [HttpGet("product/ViewCompanies")]
        public List<CompanyDto> ViewCompanies()
        {
            Debug.WriteLine("start fun ");
            var results = _companyservice.GetAll();
            Debug.WriteLine("end func");
            return results;
        }
        
        [HttpDelete("product/DeleteCom")]
        public void DeleteCom(int id)
        {
             _companyservice.Delete (id);
        }
        [HttpPost("product/Edit")]
        public bool EditCom(int id, string companyName, string description, string ownerName, bool status, Sectors sector, DateTime startDate, List<Country> branch)
        {
            var s= _companyservice.EditCom(id, companyName, description, ownerName, status, sector, startDate, branch);
            return s;      
        }
    }
}
