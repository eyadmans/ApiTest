using production.Database.entities;
using production.Database.Enums;
using Production.Database.entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Prouduction.Database.entities
{
    public class Company
    {
        [Key]
        public int Id { get; set; }
        public string CompanyName { set; get; }
        public string Description { set; get; }
        public string OwnerName { set; get; } 
        public bool Status { set; get; }
        public bool IsDeleted { get; set; }//we added this property to database. so we need migration
        public Sectors Sector { set; get; }
        public DateTime StartDate { set; get; }
        public List<CompanyCountry> Branchs { get; set; } = new List<CompanyCountry>();
        public DateTime CreateDate { get; set; }
        public List<ProductCompany> Products { get; set; } = new List<ProductCompany>();
    }
}
