using production.Database.Dtos.Companies;
using production.Database.entities;
using production.Database.Enums;
using Prouduction.Database.context;
using Prouduction.Database.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace production.buisness
{
    public class CompanyService
    {
        private Applicationcontext _context;

        public CompanyService(Applicationcontext context)
        {
            _context = context;
        }

        public bool AddNewCompany(AddCompanyRequestDto companyDto)
        {
            //first of all. as we used dto to send data to user. we need to use it to take data from user.
            
            DateTime a =new DateTime (2020, 1, 1);
            DateTime b = DateTime.Now;
            if (companyDto.StartDate >= a & companyDto.StartDate <= b)
            {
                var company = new Company()
                {
                    CompanyName = companyDto.CompanyName,
                    Description = companyDto.Description,
                    OwnerName = companyDto.OwnerName,
                    Status = companyDto.Status,
                    Sector = companyDto.Sector,
                    StartDate = companyDto.StartDate,
                    IsDeleted = false
                };
                _context.Companies.Add(company);
                _context.SaveChanges();
                foreach (var branch in companyDto.Branchs)
                {
                    _context.CompanyCountries.Add(new CompanyCountry() { Country = branch,CompanyId=company.Id });
                }

                _context.SaveChanges();
                return true;
            }
            else
                return false;
        }
        
        public List<CompanyDto> GetAll()
        {
            List<CompanyDto> companiesDtos = new List<CompanyDto>();

            var companies = _context.Companies.Where(x=>x.IsDeleted == false).ToList();
            foreach(var company in companies)
            {
                companiesDtos.Add(new CompanyDto()
                {
                    Status = company.Status == true ? "On" : "OFF",
                    CompanyName = company.CompanyName,
                    Description = company.Description,
                    Id = company.Id,
                    StartDate = company.StartDate,
                     OwnerName=company.OwnerName,
                     Sector=company.Sector,
                });
            }
            return companiesDtos;
        }

        public void Delete(int id)
        {
            //if you try to delete the company it will give you an error. and the reason that company has Country related to it 
            var company = _context.Companies.First(x=>x.Id == id);
            company.IsDeleted = true;
            _context.SaveChanges();
        }
        
        public bool EditCom(int id , string companyName, string description, string ownerName, bool status, Sectors sector, DateTime startDate, List<Country> branch)
        {
            
            var company = _context.Companies.FirstOrDefault(x=> x.Id==id & x.IsDeleted==false);//1 3 5
            if (company == null)
                return false;
            company.CompanyName = companyName;
            company.Description = description;
            company.OwnerName = ownerName;
            company.Status = status;
            company.Sector = sector;
            company.StartDate = startDate;
            _context.SaveChanges();
            return true;
        }


        public List<string> GetOnlyNames()
        {
            var names = _context.Companies.Select(x => x.CompanyName).ToList() ;
            return names;
        }

      
          
        
    }

       
    
}
