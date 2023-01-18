using production.Database.entities;
using production.Database.Enums;
using Production.Database.entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Prouduction.Database.entities
{
    public class Company: BaseEntities
    {
        [Required]
        [StringLength(100)]
        public string CompanyName { set; get; }
        [StringLength(1000)]
        public string Description { set; get; }
        [StringLength(50)]
        public string OwnerName { set; get; } 
        public bool Status { set; get; }

        public Sectors Sector { set; get; }
        public DateTime StartDate { set; get; }
        public List<CompanyCountry> Branchs { get; set; } = new List<CompanyCountry>();
        public List<ProductCompany> Products { get; set; } = new List<ProductCompany>();
    }
}
