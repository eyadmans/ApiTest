using production.Database.Dtos.Companies;
using production.Database.entities;
using production.Database.Enums;
using Production.Database.entities;
using Prouduction.Database.context;
using Prouduction.Database.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace production.buisness
{
    public class ProductService
    {

        private Applicationcontext _context;
        private CompanyService g;

        public ProductService(Applicationcontext context)
        {
            _context = context;
        }

        public bool AddNewProduct(AddProuductRequestDto ProductDto)
        {
            
            var companies = _context.Companies.Where(x => x.IsDeleted == false).ToList();
            //افحص كل اي دي جاي من المستخدم
            foreach (var productCompanyId in ProductDto.Companies)
            {
                //ازا ما في ولا شركة بالداتا بيز الاي دي تبعها نفس الاي دي يلي المستخدم كتبها رجعلو فولس
                if (companies.All(x => x.Id != productCompanyId))
                    return false;

            }
            
            
            if (ProductDto.Price  > 0 && ProductDto.Tax >= 0 && ProductDto.Tax <= 100)
            {
                var product = new Product()
                {
                    ProductName = ProductDto.ProductName,
                    ProductDescription = ProductDto.ProductDescription,
                    Price = ProductDto.Price,
                    Tax = ProductDto.Tax,
                    Coulor = ProductDto.Coulor,
                    IsDeleted = false
                };
                foreach (var factor in ProductDto.Companies)
                    
                    product.Factory.Add(new ProductCompany() {CompanyId = factor}) ;
                //اي دي الكومباني ما موجود

                _context.Products.Add(product);
                _context.SaveChanges();
                return true;
            }
            else
                return false;
        }
        
        public List<ProductDto> GetAllProducts()
        {
            List<ProductDto> ProductDtos = new List<ProductDto>();

            var products = _context.Products.Where(x=> x.IsDeleted==false).ToList();
            foreach(var product in products)
            {
              
                    
                ProductDtos.Add(new ProductDto()
                {
                    Id = product.Id,
                    ProductName = product.ProductName,
                    ProductDescription = product.ProductDescription,
                    Price = product.Price,
                     Tax=product.Tax,
                     Coulor =product.Coulor,
                });
            }
            return ProductDtos;
        }

        public void DeleteProduct(int id)
        {
            var product = _context.Products.First(x=>x.Id == id);
            product.IsDeleted = true;
            _context.SaveChanges();
        }
        
        public bool EditProduct(int id , string  ProductName, string ProductDescription, double Price, double Tax, Coulors Coulor, List<ProductCompany> Factory)
        {
            
            var product = _context.Products.FirstOrDefault(x=> x.Id==id & x.IsDeleted==false);//1 3 5
            if (product == null)
                return false;
            product.ProductName = ProductName;
            product.ProductDescription = ProductDescription;
            product.Price = Price;
            product.Tax = Tax; 
            product.Coulor= Coulor;
            product.Factory = Factory;
            _context.SaveChanges();
            return true;
        }
    }
}
