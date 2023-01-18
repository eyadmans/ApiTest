using production.Database.Enums;
using Production.Database.entities;
using Prouduction.Database.entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace production.Database.entities
{
    public class Product : BaseEntities
    {
        [Required]
        [StringLength(100)]
        public string ProductName { set; get; }
        public string ProductDescription { set; get; }
        public double Price { set; get; }
        public double  Tax { set; get; }
        public Coulors Coulor { set; get; }
        public List<ProductCompany> Companies { set; get; } = new List<ProductCompany>();

    }
}
