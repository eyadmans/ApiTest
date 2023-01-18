using FluentValidation;
using production.buisness.Validation;
using production.Database.Dtos.Companies;
using production.Database.entities;
using production.Database.Enums;
using Production.Database.Dtos.Products;
using Production.Database.entities;
using Prouduction.Database.context;
using Prouduction.Database.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace production.buisness
{
    public class ProductService
    {

        private Applicationcontext _context;
        private AutoMapper.IMapper _mapper;
        private readonly PValidator _pvalidator;

        public ProductService(Applicationcontext context, AutoMapper.IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
            _pvalidator = new PValidator();
        }

        public bool AddNewProduct(AddProuductRequestDto ProductDto)
        {
            
            var companies = _context.Companies.Where(x => x.IsDeleted == false).ToList();

            foreach (var productCompanyId in ProductDto.Companies)
            {
                if (companies.All(x => x.Id != productCompanyId))
                    return false;
            }
            var product = _mapper.Map<Product>(ProductDto);
            product.CreateDate = DateTime.Now;
            _context.Products.Add(product);

                _context.SaveChanges();
                return true;
        }
        public List<ProductDto> GetAllProducts()
        {
            List<ProductDto> ProductDtos = new List<ProductDto>();

            var products = _context.Products.Where(x => x.IsDeleted == false).ToList();
            var product = _mapper.Map<List<ProductDto>>(products);

            return product;
        }

        public void DeleteProduct(int id)
        {
            var product = _context.Products.First(x=>x.Id == id);
            product.IsDeleted = true;
            _context.SaveChanges();
        }
        
        public async Task<bool> EditProduct(PEditRequest edit)
        {
            var result = await _pvalidator.ValidateAsync(edit);
            if (result.IsValid == false)
                return false;

            var product = _context.Products.FirstOrDefault(x => x.Id == edit.Id & x.IsDeleted == false);
            _mapper.Map(edit, product);
            _context.SaveChanges();
            return true;
        }

        public double  GetHighestPrice()
        {
            var a = _context.Products.Max(x => x.Price);
            return a;
        }
    }
}
