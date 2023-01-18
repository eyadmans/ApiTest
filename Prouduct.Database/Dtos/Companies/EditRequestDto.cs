using production.Database.Dtos.Companies;
using Prouduction.Database.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Production.Database.Dtos.Companies
{
    public class EditRequestDto:AddCompanyRequestDto 
    {
        public int Id { get; set; }
    }
}
