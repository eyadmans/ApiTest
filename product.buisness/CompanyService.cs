using production.Database.Dtos.Companies;
using production.Database.entities;
using production.Database.Enums;
using Production.Database.Dtos.Companies;
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
        private  AutoMapper.IMapper _mapper;
        public CompanyService(Applicationcontext context, AutoMapper.IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public bool AddNewCompany(AddCompanyRequestDto companyDto)
        {
            //first of all. as we used dto to send data to user. we need to use it to take data from user.
            
            DateTime a =new DateTime (2020, 1, 1);
            DateTime b = DateTime.Now;
            if (companyDto.StartDate >= a & companyDto.StartDate <= b)
            {
                var company = _mapper.Map<Company>(companyDto);
                company.CreateDate = DateTime.Now;
                _context.Companies.Add(company);
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
            var company = _mapper.Map<List<CompanyDto>>(companies);
        
            return company;
        }

        public void Delete(int id)
        {
            //if you try to delete the company it will give you an error. and the reason that company has Country related to it 
            var company = _context.Companies.First(x=>x.Id == id);
            company.IsDeleted = true;
            _context.SaveChanges();
        }
        
        public bool EditCom(EditRequestDto edit)
        {
            
            var company = _context.Companies.FirstOrDefault(x=> x.Id==edit.Id & x.IsDeleted==false);//1 3 5
            _mapper.Map(edit,company);
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
