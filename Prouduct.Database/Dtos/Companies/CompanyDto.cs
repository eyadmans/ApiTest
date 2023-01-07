using Product.Database.Enums;
using System;
using System.Collections.Generic;
using System.Text;
//test comment
namespace Product.Database.Dtos.Companies
{
    public class CompanyDto
    {
        private string companyName;
        public int Id { get; set; }
        public string CompanyName
        {
            get
            {
                return companyName;
            }
            set 
            {
                companyName = value.ToUpper();
            } 
        }
        public string Description { set; get; }
        public string OwnerName { set; get; }
        public string Status { set; get; }
        public Sectors Sector { set; get; }
        public DateTime StartDate { set; get; }
    }
}
