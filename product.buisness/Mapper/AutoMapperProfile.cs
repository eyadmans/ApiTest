using production.Database.Dtos.Companies;
using Prouduction.Database.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using production.Database.Enums;
using production.Database.entities;
using Production.Database.Dtos.Companies;
using Production.Database.entities;
using Production.Database.Dtos.Products;

namespace production.buisness.Mapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<AddCompanyRequestDto , Company>();

            CreateMap<Country, CompanyCountry>()
                .ForMember(des=> des.Country , opt=> opt.MapFrom(res=> res)) ;

            CreateMap<Company,CompanyDto>()
                .ForMember(des => des.Status , opt => opt.MapFrom(res => res.Status == true ? "on" : "off"))
                .ForMember(des=> des.CompanyName , opt=>opt.MapFrom(res=>res.CompanyName.ToUpper()));
           
            CreateMap<EditCompanyRequestDto, Company>();

            CreateMap<AddProductRequestDto, Product>();

            CreateMap<Company, ProductCompany>()
                .ForMember(des => des.CompanyId, opt => opt.MapFrom(res => res.Id));

            CreateMap<Product, ProductCompany>()
                .ForMember(des => des.ProductId, opt => opt.MapFrom(res => res.Id));

            CreateMap<Product, ProductDto>();

            CreateMap<ProductEditRequest, Product>();
        }
    }
}
