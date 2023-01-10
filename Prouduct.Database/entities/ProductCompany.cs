using production.Database.entities;
using Prouduction.Database.entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Production.Database.entities
{
    public class ProductCompany
    {
        [Key]
        public int Id { set; get; }

        [ForeignKey("Company")]
        public int CompanyId { set; get; }
        public Company Company { set; get; }


        [ForeignKey("Product")]
        public int ProductId { set; get; }
        public Product Product  { set; get; }
    }
}
