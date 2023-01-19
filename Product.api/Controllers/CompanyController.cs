using Microsoft.AspNetCore.Mvc;
using production.buisness;
using production.Database.Dtos.Companies;
using production.Database.entities;
using production.Database.Enums;
using Production.Database.Dtos.Companies;
using Production.Database.entities;
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
        private ProductService _productservice;
        public CompanyController (CompanyService companyService)
        {
            _companyservice = companyService;
        }

        [HttpPost("Product/AddCompany")]
        public async Task<bool> AddCompany(AddCompanyRequestDto companyDto)
        {
           
            var theResult = _companyservice.AddNewCompany(companyDto);
            return await theResult;
        }

        [HttpGet("Product/ViewCompanies")]
        public List<CompanyDto> ViewCompanies()
        {
            
            return _companyservice.GetAll();
          
        }
        
        [HttpDelete("Product/DeleteCom")]
        public void DeleteCom(int id)
        {
             _companyservice.Delete (id);
        }

        [HttpPost("Product/Edit")]
        public async Task<bool> EditCom(EditCompanyRequestDto edit)
        {
            var s= _companyservice.EditCompany(edit);
            return await s;
        }

        [HttpGet("Prodcut/GetCompanyProducts")]
        public List<Product> GetCompanyProducts(int id)
        {
            return _companyservice.GetCompanyProducts(id);
        }

        [HttpGet("Product/OnlyNames")]
        public List<string> ViewCompaniesNames()
        {
            return _companyservice.GetOnlyNames();
        }

        [HttpGet("Product/GetCompanyById")]
        public CompanyDto GetCompanyById(int id)
        {
            return _companyservice.GetCompanyById(id);
        }
        
    }
}
