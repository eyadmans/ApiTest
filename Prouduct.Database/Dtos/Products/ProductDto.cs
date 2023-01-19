using production.Database.Enums;
using System;
using System.Collections.Generic;
using System.Text;
namespace production.Database.Dtos.Companies
{
    public class ProductDto
    {
        private double _price;
        public int Id { get; set; }
        public string Name { set; get; }
        public string Description { set; get; }
        public double Price
        {
            set
            { _price = value; }
            get 
            {
                return _price + (_price * Tax / 100) ;
            }
        }
        public double Tax { set; get; }
        public Colors Color { set; get; }
       
    }
}
