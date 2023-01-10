using Microsoft.AspNetCore.Mvc;
using production.buisness;
using production.Database.Dtos.Companies;
using production.Database.Enums;
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
            public bool AddProduct(AddProuductRequestDto product)
            {

                var theResult = _productservice.AddNewProduct(product);
                return theResult;
            }

            [HttpGet("Viewproducts")]
            public List<ProductDto> ViewProduct()
            {

                return _productservice.GetAllProducts();


            }

            [HttpDelete("DeletePro")]
            public void DeletePro(int id)
            {
                _productservice.DeleteProduct(id);
            }
            [HttpPost("EditPro")]
            public bool EditPro(int id, string ProductName, string ProductDescription, double Price, double Tax, Coulors Coulor, List<ProductCompany> Factory)
            {
                var s = _productservice.EditProduct(id, ProductName, ProductDescription, Price, Tax, Coulor, Factory);
                return s;

            }
        }
    }

