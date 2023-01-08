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

        [ForeignKey("Com")]
        public int CompanyId { set; get; }
        public Company Com { set; get; }

        [ForeignKey("Cou")]
        public int CountryId { set; get; }
        public TheCountry Cou { set; get; }
    }
}
