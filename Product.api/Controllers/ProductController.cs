using Microsoft.AspNetCore.Mvc;
using production.buisness;
using production.Database.Dtos.Companies;
using production.Database.Enums;
using Production.Database.Dtos.Products;
using Production.Database.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Production.api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController
    {
        private ProductService _productservice;
        public ProductController(ProductService productservice)
        {
            _productservice = productservice;
        }

        [HttpPost("AddProduct")]
        public async Task <bool> AddProduct(AddProductRequestDto product)
        {
        var theResult = _productservice.AddNewProduct(product);
        return await theResult;
        }

        [HttpGet("Viewproducts")]
        public List<ProductDto> ViewProducts()
        {
        return _productservice.GetAllProducts();
        }

        [HttpDelete("DeleteProduct")]
        public void DeleteProduct(int id)
        {
            _productservice.DeleteProduct(id);
        }

        [HttpPost("EditProduct")]
        public async Task<bool> EditProduct(ProductEditRequest edit)
        {
            var s = _productservice.EditProduct(edit);
            return await s;
        }

        [HttpGet("GetMaxPrice")]
        public double MaxPrice()
        {
          return   _productservice.GetHighestPrice();
        }

    }
}

