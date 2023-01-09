using Product.Database.Enums;
using Prouduct.Database.entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Database.entities
{
    public class CompanyCountry
    {
        [Key]
        public int Id { set; get; }

        [ForeignKey("Company")]
        public int CompanyId { set; get; }
        public Company Company { set; get; }
        //oreign key can only be added for database classes
        public Country Country { set; get; }
        //we changed database so we need migration
    }
}
