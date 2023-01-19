using production.Database.Enums;
using Production.Database.entities;
using Prouduction.Database.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace production.Database.Dtos.Companies
{
    public class AddProductRequestDto
    {
        public string ProductName { set; get; }
        public string ProductDescription { set; get; }
        public double Price { set; get; }
        public double Tax { set; get; }
        public Colors Color { set; get; }
        public List<int> Companies { set; get; }
    }
}
