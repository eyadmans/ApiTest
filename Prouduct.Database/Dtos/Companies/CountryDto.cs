using Product.Database.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Database.Dtos.Companies
{
    public class CountryDto
    {//there is no Key attribute in Dto just in database classes
        public int Id;
        public List<Country> barnch;
    }
}
