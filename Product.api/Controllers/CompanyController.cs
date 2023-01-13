using Microsoft.AspNetCore.Mvc;
using production.buisness;
using production.Database.Dtos.Companies;
using production.Database.entities;
using production.Database.Enums;
using Prouduction.Database.entities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace production.api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CompanyController
    {
        private CompanyService _companyservice;
        public CompanyController(CompanyService companyService)
        {
            _companyservice = companyService;
        }

        [HttpPost("Product/AddCompany")]
        public bool AddCompany(AddCompanyRequestDto companyDto)
        {

            var theResult = _companyservice.AddNewCompany(companyDto);
            return theResult;
        }

        [HttpGet("Product/ViewCompanies")]
        public List<CompanyDto> ViewCompanies()
        {

            return _companyservice.GetAll();


        }

        [HttpDelete("Product/DeleteCom")]
        public void DeleteCom(int id)
        {
            _companyservice.Delete(id);
        }
        [HttpPost("Product/Edit")]
        public bool EditCom(int id, string companyName, string description, string ownerName, bool status, Sectors sector, DateTime startDate, List<Country> branch)
        {
            var s = _companyservice.EditCom(id, companyName, description, ownerName, status, sector, startDate, branch);
            return s;

        }

        [HttpGet("Product/Search")]
        public List<CompanyDto> SearchCompay(string name)
        {

            
                var a= _companyservice.Search(name);
            return a;

        }
    }
}