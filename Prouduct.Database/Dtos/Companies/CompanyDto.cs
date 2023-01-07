using Product.Database.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Product.Database.Dtos.Companies
{
    public class CompanyDto
    {
        public int Id { get; set; }
        public string CompanyName 
        {
            get
            {
                return CompanyName;
            }
            set 
            {
                value = value.ToUpper();
            } 
        }
        public string Description { set; get; }
        public string OwnerName { set; get; }
        public string Status { set; get; }
        public Sectors Sector { set; get; }
        public DateTime StartDate { set; get; }
    }
}
