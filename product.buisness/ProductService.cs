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
using Microsoft.EntityFrameworkCore;
namespace production.buisness
{
    public class ProductService
    {
        private ApplicationContext _context;
        private AutoMapper.IMapper _mapper;
        private readonly ProductEditValidator _editValidator;
        private readonly ProductAddValidator _addValidator;

        public ProductService(ApplicationContext context, AutoMapper.IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
            _editValidator = new ProductEditValidator();
            _addValidator = new ProductAddValidator();
        }

        public async Task<bool> AddNewProduct(AddProductRequestDto productDto)
        {
            var companies = _context.Companies.Where(x => x.IsDeleted == false).ToList();
            foreach (var productCompanyId in productDto.Companies)
            {
                if (companies.All(x => x.Id != productCompanyId))
                    return false;
            }
            var result = await _addValidator.ValidateAsync(productDto);
            if (result.IsValid == false)
                return false;
            var product = _mapper.Map<Product>(productDto);
            product.CreateDate = DateTime.Now;
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            return true;
        }
        public List<ProductDto> GetAllProducts()
        {
            List<ProductDto> productDtos = new List<ProductDto>();
            var products = _context.Products.Where(x => x.IsDeleted == false).ToList();
            productDtos = _mapper.Map<List<ProductDto>>(products);
            return productDtos;
        }

        public void DeleteProduct(int id)
        {
            var product = _context.Products.First(x=>x.Id == id);
            product.IsDeleted = true;
            _context.SaveChanges();
        }
        
        public async Task<bool> EditProduct(ProductEditRequest edit)
        {
            var result = await _editValidator.ValidateAsync(edit);
            if (result.IsValid == false)
                return false;

            var product = _context.Products.FirstOrDefault(x => x.Id == edit.Id & x.IsDeleted == false);
            product.LastEditDate = DateTime.Now;
            _mapper.Map(edit, product);
            await _context.SaveChangesAsync();
            return true;
        }
        public double  GetHighestPrice()
        {
            var mostExpensiveProduct = _context.Products.Max(x => x.Price);
            return mostExpensiveProduct;
        }
        public ProductDto GetProductById(int id)
        {
            var product = _context.Products.FirstOrDefault(x => x.Id == id);
            var result = _mapper.Map<ProductDto>(product);
            return result;
        }
        public List<Company> GetProductCompanies(int id)
        {
            List<Company> result = new List<Company>();
            var companies = _context.ProductCompanies.Include(x=>x.Company).Where(x => x.ProductId == id).ToList();
            result = companies.Select(x => x.Company).ToList();
            return result;
        }
    }
}
