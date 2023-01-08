using Product.Database.entities;
using Product.Database.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Prouduct.Database.entities
{
    public class Company
    {
        [Key]
        public int Id { get; set; }
        public string CompanyName { set; get; }
        public string Description { set; get; }
        public string OwnerName { set; get; } 
        public bool Status { set; get; }
        public Sectors Sector { set; get; }
        public DateTime StartDate { set; get; }


        public List<TheCountry> Branch { set; get; }
    }
}
