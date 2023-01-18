
using production.buisness.Validation;
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
using System.Threading.Tasks;

namespace production.buisness
{
    public class CompanyService
    {
        private ApplicationContext _context;
        private AutoMapper.IMapper _mapper;
        private readonly CompanyEditValidator _validatorCompany;
        private readonly CompanyAddValidator _addvalidatorCompany;

        public CompanyService(ApplicationContext context, AutoMapper.IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
            _validatorCompany = new CompanyEditValidator();
            _addvalidatorCompany = new CompanyAddValidator();
        }

        public async Task<bool> AddNewCompany(AddCompanyRequestDto companyDto)
        {
            var result = await _addvalidatorCompany.ValidateAsync(companyDto);
            if (result.IsValid == false)
                return false;

            var company = _mapper.Map<Company>(companyDto);
            company.CreateDate = DateTime.Now;
            _context.Companies.Add(company);
            _context.SaveChanges();
            return true;
        }       
        public List<CompanyDto> GetAll()
        {
            List<CompanyDto> companiesDtos = new List<CompanyDto>();
            var companies = _context.Companies.Where(x=>x.IsDeleted == false).ToList();
            companiesDtos = _mapper.Map<List<CompanyDto>>(companies);
            return companiesDtos;
        }

        public void Delete(int id)
        {
            var company = _context.Companies.First(x=>x.Id == id);
            company.IsDeleted = true;
            _context.SaveChanges();
        }
        
        public async Task<bool> EditCom(EditCompanyRequestDto edit)
        {
            var result = await _validatorCompany.ValidateAsync(edit);
            if (result.IsValid == false)
                return false;

            var company = _context.Companies.FirstOrDefault(x=> x.Id==edit.Id & x.IsDeleted==false);
            company.LastEditDate = DateTime.Now;
            _mapper.Map(edit,company);
            _context.SaveChanges() ;
            return true;
        }
        public List<string> GetOnlyNames()
        {
            var names = _context.Companies.Select(x => x.CompanyName).ToList() ;
            return names;
        }    
    }

       
    
}
