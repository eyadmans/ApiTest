using production.Database.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace production.Database.Dtos.Companies
{
    public class AddCompanyRequestDto
    {
        public string CompanyName { get; set; }
        public string Description { get; set; }
        public string OwnerName { get; set; }
        public bool Status { get; set; }
        public Sectors Sector { get; set; }
        public DateTime StartDate { get; set; }
        public List<Country> Branchs { get; set; }
    }
}
