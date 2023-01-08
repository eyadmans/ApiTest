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
    public class TheCountry
    {
        [Key]
        public int Id { set; get; }

        public Country  Branch { set; get; }

     
    }
}
