using Product.Database.Dtos.Companies;
using Product.Database.entities;
using Product.Database.Enums;
using Prouduct.Database.context;
using Prouduct.Database.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace product.buisness
{
    public class CompanyService
    {
        private Applicationcontext _context;

        public CompanyService(Applicationcontext context)
        {
            _context = context;
        }

        public bool AddNewCompany(string companyName , string description , string ownerName , bool status , Sectors sector , DateTime startDate , List<TheCountry> branch)
        {

            DateTime a =new DateTime (2020, 1, 1);
            DateTime b = DateTime.Now;
            if (startDate >= a & startDate <= b)
            {
                _context.Companies.Add(new Company()
                {
                    CompanyName = companyName,
                    Description = description,
                    OwnerName = ownerName,
                    Status = status,
                    Sector = sector,
                    StartDate = startDate,
                    Branch = branch
                });
                _context.SaveChanges();
                return true;
            }
            else
                return false;
        }
        
        public List<CompanyDto> GetAll()
        {
            List<CompanyDto> companiesDtos = new List<CompanyDto>();

            var companies = _context.Companies.ToList();
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
                     Sector=company.Sector
                });
            }
            return companiesDtos;
        }

        public void Delete(int id)
        {
            var company = _context.Companies.First(x=>x.Id == id);
            _context.Companies.Remove(company);
            _context.SaveChanges();
        }
        
        public bool EditCom(int id , string companyName, string description, string ownerName, bool status, Sectors sector, DateTime startDate, List<Country> branch)
        {
            
            var company = _context.Companies.FirstOrDefault(x=> x.Id==id);//1 3 5
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
    }
}
