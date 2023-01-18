using production.Database.entities;
using production.Database.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace production.Database.Dtos.Companies
{
    public class CompanyDto
    {
        private string _companyName;
        public int Id { get; set; }
        public string CompanyName
        {
            get
            {
                return _companyName;
            }
            set 
            {
                _companyName = value.ToUpper();
            } 
        }
        public string Description { set; get; }
        public string OwnerName { set; get; }
        public string Status { set; get; }
        public Sectors Sector { set; get; }
        public DateTime StartDate { set; get; }
        public List<CompanyCountry> Branchs { get; set; } = new List<CompanyCountry>();
    }
}
